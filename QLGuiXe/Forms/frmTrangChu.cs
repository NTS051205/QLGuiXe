using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmTrangChu : Form
{
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance;
    private readonly Dictionary<string, Form> _pages = new(StringComparer.OrdinalIgnoreCase);
    private Button? _activeButton;

    public frmTrangChu()
    {
        InitializeComponent();
        ConfigureNavigation();
        ConfigureDashboard();
        ShowDashboard(btnDashboard);
    }

    private void ConfigureNavigation()
    {
        foreach (var button in flpMenu.Controls.OfType<Button>())
        {
            button.AccessibleName = button.Text;
            button.Click += NavButton_Click;
            button.MouseEnter += (_, _) => { if (button != _activeButton) button.BackColor = SystemColors.ControlDark; };
            button.MouseLeave += (_, _) => { if (button != _activeButton) button.BackColor = SystemColors.Control; };
        }
    }

    private void ConfigureDashboard()
    {
        foreach (var grid in new[] { dgvKhuVuc, dgvXeGanDay, dgvVeSapHetHan })
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        lblCurrentUser.Text = $"{PhienDangNhap.EmployeeName} - {PhienDangNhap.Role}";
        RefreshDashboard();
    }

    private void RefreshDashboard()
    {
        var parking = _data.GetTable("LUOTGUIXE").AsEnumerable().Where(r => r.Field<string>("TrangThai") == "DANG_GUI").ToArray();
        var areas = _data.GetTable("KHUVUC");
        var monthly = _data.GetTable("DANGKYVETHANG").AsEnumerable().Where(r => r.Field<string>("TrangThai") == "HIEU_LUC").ToArray();

        lblTongXeValue.Text = parking.Length.ToString();
        lblOToValue.Text = parking.Count(r => r.Field<string>("LoaiXe") == "Ô tô").ToString();
        lblXeMayValue.Text = parking.Count(r => r.Field<string>("LoaiXe") == "Xe máy").ToString();
        lblConTrongValue.Text = areas.AsEnumerable().Where(r => r.Field<string>("TrangThai") == "HOAT_DONG").Sum(r => r.Field<int>("ConTrong")).ToString();
        lblVeThangValue.Text = monthly.Length.ToString();

        dgvKhuVuc.DataSource = areas;
        dgvXeGanDay.DataSource = TopRows(_data.GetTable("LUOTGUIXE"), 10, "ThoiGianVao DESC");
        var expiring = _data.GetTable("DANGKYVETHANG").Clone();
        foreach (var row in _data.GetTable("DANGKYVETHANG").AsEnumerable().Where(r => r.Field<DateTime>("NgayKetThuc") <= DateTime.Today.AddDays(30)).OrderBy(r => r.Field<DateTime>("NgayKetThuc")).Take(10))
            expiring.ImportRow(row);
        dgvVeSapHetHan.DataSource = expiring;
        FormatDashboardGrids();
    }

    private static DataTable TopRows(DataTable source, int count, string sort)
    {
        var result = source.Clone();
        foreach (DataRowView row in new DataView(source) { Sort = sort }.Cast<DataRowView>().Take(count)) result.ImportRow(row.Row);
        return result;
    }

    private void FormatDashboardGrids()
    {
        HideColumns(dgvKhuVuc, "MaKhuVuc", "TrangThai");
        HideColumns(dgvXeGanDay, "MaLuotGui", "MaPT", "MaVe", "MaKhuVuc", "ThoiGianRa", "TienGui", "NhanVienRa", "TrangThai");
        HideColumns(dgvVeSapHetHan, "MaDangKy", "MaKH", "MaPT", "MaVe", "TongTien", "ThanhToan");
        RenameColumns(dgvKhuVuc, ("TenKhuVuc", "Khu vực"), ("LoaiXe", "Loại xe"), ("SucChua", "Sức chứa"), ("DangGui", "Đang gửi"), ("ConTrong", "Còn trống"));
        RenameColumns(dgvXeGanDay, ("BienSo", "Biển số"), ("LoaiXe", "Loại xe"), ("MaThe", "Mã thẻ"), ("KhuVuc", "Khu vực"), ("ThoiGianVao", "Thời gian vào"), ("NhanVienVao", "Tiếp nhận"), ("LoaiVe", "Loại vé"));
        RenameColumns(dgvVeSapHetHan, ("KhachHang", "Khách hàng"), ("BienSo", "Biển số"), ("MaThe", "Mã thẻ"), ("NgayBatDau", "Bắt đầu"), ("NgayKetThuc", "Hết hạn"), ("TrangThai", "Trạng thái"));
    }

    private static void HideColumns(DataGridView grid, params string[] names)
    {
        foreach (var name in names) if (grid.Columns.Contains(name)) grid.Columns[name]!.Visible = false;
    }

    private static void RenameColumns(DataGridView grid, params (string Name, string Header)[] columns)
    {
        foreach (var column in columns) if (grid.Columns.Contains(column.Name)) grid.Columns[column.Name]!.HeaderText = column.Header;
    }

    private void NavButton_Click(object? sender, EventArgs e)
    {
        if (sender is not Button button || button.Tag is not string key) return;
        Navigate(key, button);
    }

    private void Navigate(string key, Button? source = null)
    {
        if (key == "Dashboard")
        {
            ShowDashboard(source ?? btnDashboard);
            return;
        }

        ActivateButton(source ?? flpMenu.Controls.OfType<Button>().FirstOrDefault(x => Equals(x.Tag, key)));
        pnlDashboard.Visible = false;
        foreach (Control control in pnlContent.Controls) if (control != pnlDashboard) control.Visible = false;

        if (!_pages.TryGetValue(key, out var page))
        {
            page = CreatePage(key);
            DinhDang.ConfigurePage(page);
            _pages[key] = page;
            pnlContent.Controls.Add(page);
        }

        lblPageTitle.Text = source?.AccessibleName?.Trim() ?? key;
        page.Visible = true;
        page.BringToFront();
        page.Show();
    }

    private Form CreatePage(string key) => key switch
    {
        "XeVao" => new frmXeVao(),
        "XeRa" => new frmXeRa(),
        "LichSu" => new frmLichSuGuiXe(),
        "DangKyVeThang" => new frmDangKyVeThang(),
        "KhachHang" => new frmKhachHang(),
        "PhuongTien" => new frmPhuongTien(),
        "LoaiVe" => new frmLoaiVe(),
        "BangGia" => new frmBangGia(),
        "KhuVuc" => new frmKhuVuc(),
        "NhanVien" => new frmNhanVien(),
        "TaiKhoan" => new frmTaiKhoan(),
        "CaLam" => new frmCaLam(),
        "PhanCongCa" => new frmPhanCongCa(),
        _ => throw new ArgumentOutOfRangeException(nameof(key), key, "Trang chưa được khai báo.")
    };

    private void ShowDashboard(Button button)
    {
        ActivateButton(button);
        foreach (Control control in pnlContent.Controls) control.Visible = control == pnlDashboard;
        pnlDashboard.Visible = true;
        pnlDashboard.BringToFront();
        lblPageTitle.Text = "Trang chủ";
        RefreshDashboard();
    }

    private void ActivateButton(Button? button)
    {
        if (_activeButton is not null)
        {
            _activeButton.BackColor = SystemColors.Control;
            _activeButton.ForeColor = SystemColors.ControlText;
        }
        _activeButton = button;
        if (button is not null)
        {
            button.BackColor = SystemColors.ActiveCaption;
            button.ForeColor = SystemColors.ControlText;
        }
    }

    private void btnQuickXeVao_Click(object? sender, EventArgs e) => Navigate("XeVao", btnXeVao);
    private void btnQuickXeRa_Click(object? sender, EventArgs e) => Navigate("XeRa", btnXeRa);
    private void btnQuickVeThang_Click(object? sender, EventArgs e) => Navigate("DangKyVeThang", btnDangKyVeThang);
    private void btnDangXuat_Click(object? sender, EventArgs e) => Close();

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        foreach (var page in _pages.Values) page.Dispose();
        base.OnFormClosed(e);
    }

    private void btnDashboard_Click(object sender, EventArgs e)
    {

    }
}


