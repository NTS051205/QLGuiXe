using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmNhanVien : Form
{
    private QuanLyDanhSach page = null!;
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance;
    private DataTable _table = null!;

    public frmNhanVien()
    {
        InitializeComponent();
        page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa);
        _table = _data.GetTable("NHANVIEN");
        page.Configure("Quản lý nhân viên", "Quản lý hồ sơ và trạng thái làm việc của nhân viên bãi xe.", "+ Thêm nhân viên", "Tìm theo tên hoặc số điện thoại...");
        page.ConfigureFilter("Trạng thái:", new[] { "HOAT_DONG", "TAM_NGHI", "VO_HIEU" }, "TrangThai");
        page.Bind(_table, "HoTen", "SoDienThoai", "MaNV");
        DuLieuForm.RenameColumns(page.Grid, ("MaNV", "Mã nhân viên"), ("HoTen", "Họ tên"), ("SoDienThoai", "Số điện thoại"), ("TrangThai", "Trạng thái"));
        page.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(page) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết nhân viên"); };
        page.AddButton.Click += Add_Click;
        page.EditButton.Click += Edit_Click;
        page.DeleteButton.Click += Disable_Click;
        page.RefreshButton.Click += (_, _) => ReloadData();
    }

    private void Add_Click(object? sender, EventArgs e)
    {
        using var dialog = Editor("Thêm nhân viên", null);
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        if (!DuLieuForm.IsPhone(dialog.Values["SoDienThoai"])) { MessageBox.Show("Số điện thoại phải gồm 9–11 chữ số."); return; }
        try
        {
            _data.Execute("INSERT dbo.NHANVIEN(MaNV,HoTen,SoDienThoai,TrangThai) VALUES(@MaNV,@HoTen,@SoDienThoai,@TrangThai)",
                KetNoiCSDL.Param("@MaNV", _data.NextCode("NHANVIEN", "MaNV", "NV")),
                KetNoiCSDL.Param("@HoTen", dialog.Values["HoTen"]), KetNoiCSDL.Param("@SoDienThoai", dialog.Values["SoDienThoai"]),
                KetNoiCSDL.Param("@TrangThai", dialog.Values["TrangThai"]));
            ReloadData();
        }
        catch (Exception ex) { ShowDatabaseError(ex); }
    }

    private void Edit_Click(object? sender, EventArgs e)
    {
        var row = DuLieuForm.RequireSelection(page); if (row is null) return;
        using var dialog = Editor("Sửa thông tin nhân viên", row);
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        if (!DuLieuForm.IsPhone(dialog.Values["SoDienThoai"])) { MessageBox.Show("Số điện thoại phải gồm 9–11 chữ số."); return; }
        try
        {
            _data.Execute("UPDATE dbo.NHANVIEN SET HoTen=@HoTen,SoDienThoai=@SoDienThoai,TrangThai=@TrangThai WHERE MaNV=@MaNV",
                KetNoiCSDL.Param("@HoTen", dialog.Values["HoTen"]), KetNoiCSDL.Param("@SoDienThoai", dialog.Values["SoDienThoai"]),
                KetNoiCSDL.Param("@TrangThai", dialog.Values["TrangThai"]), KetNoiCSDL.Param("@MaNV", row["MaNV"]));
            ReloadData();
        }
        catch (Exception ex) { ShowDatabaseError(ex); }
    }

    private void Disable_Click(object? sender, EventArgs e)
    {
        var row = DuLieuForm.RequireSelection(page); if (row is null || !DuLieuForm.Confirm("Vô hiệu hóa nhân viên đã chọn?")) return;
        try
        {
            _data.Execute("UPDATE dbo.NHANVIEN SET TrangThai='VO_HIEU' WHERE MaNV=@MaNV", KetNoiCSDL.Param("@MaNV", row["MaNV"]));
            ReloadData();
        }
        catch (Exception ex) { ShowDatabaseError(ex); }
    }

    private void ReloadData() { _table = _data.GetTable("NHANVIEN"); page.Bind(_table, "HoTen", "SoDienThoai", "MaNV"); }
    private void ShowDatabaseError(Exception ex) => MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    private static RecordEditorDialog Editor(string title, DataRow? row) => new(title, new[]
    {
        new EditorField("HoTen", "Họ tên", row?["HoTen"]?.ToString()),
        new EditorField("SoDienThoai", "Số điện thoại", row?["SoDienThoai"]?.ToString(), Placeholder: "Ví dụ: 0901234567"),
        new EditorField("TrangThai", "Trạng thái", row?["TrangThai"]?.ToString() ?? "HOAT_DONG", Options: new[] { "HOAT_DONG", "TAM_NGHI", "VO_HIEU" })
    });
}


