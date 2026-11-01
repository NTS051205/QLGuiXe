using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmXeVao : Form
{
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance;
    private readonly System.Windows.Forms.Timer _clock = new() { Interval = 1000 };

    public frmXeVao()
    {
        InitializeComponent();
        dgvXeDangGui.AllowUserToAddRows = false; dgvXeDangGui.AllowUserToDeleteRows = false; dgvXeDangGui.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvXeDangGui.ReadOnly = true; dgvXeDangGui.RowHeadersVisible = false; dgvXeDangGui.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        cboLoaiXe.Items.AddRange(new object[] { "Xe máy", "Ô tô" }); cboLoaiXe.SelectedIndex = 0;
        cboNhanVien.Items.AddRange(_data.GetTable("NHANVIEN").AsEnumerable().Where(r => r.Field<string>("TrangThai") == "HOAT_DONG").Select(r => r.Field<string>("HoTen")!).Cast<object>().ToArray()); cboNhanVien.SelectedIndex = 0;
        LoadCards(); LoadAreas(); BindOpenParking(); UpdateCheck();
        _clock.Tick += (_, _) => lblGiaTriThoiGianVao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        lblGiaTriThoiGianVao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        _clock.Start();
    }

    private void LoadCards()
    {
        var used = new HashSet<string?>(_data.GetTable("LUOTGUIXE").AsEnumerable().Where(r => r.Field<string>("TrangThai") == "DANG_GUI").Select(r => r.Field<string>("MaThe")));
        var current = cboTheXe.SelectedItem?.ToString(); cboTheXe.Items.Clear();
        foreach (var card in _data.GetTable("VE").AsEnumerable().Where(r => r.Field<string>("TrangThai") == "HOAT_DONG" && !used.Contains(r.Field<string>("MaThe")))) cboTheXe.Items.Add(card.Field<string>("MaThe")!);
        if (current is not null && cboTheXe.Items.Contains(current)) cboTheXe.SelectedItem = current; else if (cboTheXe.Items.Count > 0) cboTheXe.SelectedIndex = 0;
    }
    private void LoadAreas()
    {
        cboKhuVuc.Items.Clear(); foreach (var area in _data.GetTable("KHUVUC").AsEnumerable().Where(r => r.Field<string>("TrangThai") == "HOAT_DONG" && r.Field<string>("LoaiXe") == cboLoaiXe.Text)) cboKhuVuc.Items.Add(area.Field<string>("TenKhuVuc")!);
        if (cboKhuVuc.Items.Count > 0) cboKhuVuc.SelectedIndex = 0; UpdateAvailable();
    }
    private void BindOpenParking()
    {
        var view = new DataView(_data.GetTable("LUOTGUIXE")) { RowFilter = "TrangThai = 'DANG_GUI'", Sort = "ThoiGianVao DESC" }; dgvXeDangGui.DataSource = view;
        DuLieuForm.HideColumns(dgvXeDangGui, "ThoiGianRa", "TienGui", "NhanVienRa", "TrangThai");
        DuLieuForm.RenameColumns(dgvXeDangGui, ("MaLuotGui", "Mã lượt"), ("BienSo", "Biển số"), ("LoaiXe", "Loại xe"), ("MaThe", "Mã thẻ"), ("KhuVuc", "Khu vực"), ("ThoiGianVao", "Thời gian vào"), ("NhanVienVao", "Tiếp nhận"), ("LoaiVe", "Loại vé"));
        dgvXeDangGui.Columns["ThoiGianVao"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
    }
    private void txtBienSo_TextChanged(object? sender, EventArgs e)
    {
        txtBienSo.Text = txtBienSo.Text.ToUpperInvariant(); txtBienSo.SelectionStart = txtBienSo.Text.Length;
        var vehicle = _data.GetTable("PHUONGTIEN").AsEnumerable().FirstOrDefault(r => r.Field<string>("BienSo")!.Equals(txtBienSo.Text.Trim(), StringComparison.OrdinalIgnoreCase));
        if (vehicle is not null) cboLoaiXe.SelectedItem = vehicle.Field<string>("LoaiXe");
        UpdateCheck();
    }
    private void Input_Changed(object? sender, EventArgs e) { LoadAreas(); UpdateCheck(); }
    private void cboKhuVuc_SelectedIndexChanged(object? sender, EventArgs e) => UpdateAvailable();
    private void UpdateAvailable()
    {
        var area = _data.GetTable("KHUVUC").AsEnumerable().FirstOrDefault(r => r.Field<string>("TenKhuVuc") == cboKhuVuc.Text);
        lblGiaTriChoTrong.Text = area is null ? "—" : $"{area.Field<int>("ConTrong")} chỗ";
        lblGiaTriChoTrong.ForeColor = area is not null && area.Field<int>("ConTrong") > 0 ? DinhDang.Success : DinhDang.Danger;
    }
    private void UpdateCheck()
    {
        var plate = txtBienSo.Text.Trim(); var known = _data.GetTable("PHUONGTIEN").AsEnumerable().Any(r => r.Field<string>("BienSo")!.Equals(plate, StringComparison.OrdinalIgnoreCase)); var inside = plate.Length > 0 && _data.IsVehicleInside(plate); var monthly = plate.Length > 0 && _data.HasValidMonthlyPass(plate);
        lblTrangThaiPhuongTien.Text = known ? "✓ Đã có trong hệ thống" : "• Khách vãng lai / phương tiện mới"; lblTrangThaiPhuongTien.ForeColor = known ? DinhDang.Success : DinhDang.TextSecondary;
        lblTrangThaiTrongBai.Text = inside ? "✕ Phương tiện đang ở trong bãi" : "✓ Không có lượt gửi đang mở"; lblTrangThaiTrongBai.ForeColor = inside ? DinhDang.Danger : DinhDang.Success;
        lblTrangThaiVeThang.Text = monthly ? "✓ Vé tháng hợp lệ, đã thanh toán" : "• Không có vé tháng hợp lệ"; lblTrangThaiVeThang.ForeColor = monthly ? DinhDang.Success : DinhDang.Warning;
        lblGiaTriLoaiVe.Text = monthly ? "THANG — phí lượt 0 ₫" : "LUOT — tính theo bảng giá";
    }
    private void btnXacNhanXeVao_Click(object? sender, EventArgs e)
    {
        var plate = txtBienSo.Text.Trim(); if (plate.Length < 5) { MessageBox.Show("Vui lòng nhập biển số hợp lệ."); txtBienSo.Focus(); return; }
        if (cboTheXe.SelectedItem is null || cboKhuVuc.SelectedItem is null || cboNhanVien.SelectedItem is null) { MessageBox.Show("Vui lòng chọn đầy đủ thẻ xe, khu vực và nhân viên."); return; }
        var area = _data.GetTable("KHUVUC").AsEnumerable().First(r => r.Field<string>("TenKhuVuc") == cboKhuVuc.Text); if (area.Field<int>("ConTrong") <= 0) { MessageBox.Show("Khu vực đã hết chỗ trống."); return; }
        try
        {
            var parkingId = _data.AddParking(plate, cboLoaiXe.Text, cboTheXe.Text, cboKhuVuc.Text, cboNhanVien.Text);
            MessageBox.Show($"Đã ghi xe vào SQL Server. Mã lượt gửi: {parkingId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); BindOpenParking(); LoadCards(); ResetInput();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể nhận xe", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
    private void btnLamMoiXeVao_Click(object? sender, EventArgs e) => ResetInput();
    private void ResetInput() { txtBienSo.Clear(); cboLoaiXe.SelectedIndex = 0; LoadCards(); LoadAreas(); UpdateCheck(); txtBienSo.Focus(); }
    protected override void Dispose(bool disposing) { if (disposing) { _clock.Dispose(); components?.Dispose(); } base.Dispose(disposing); }
}


