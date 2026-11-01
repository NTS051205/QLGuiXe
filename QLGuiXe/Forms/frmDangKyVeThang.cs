using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmDangKyVeThang : Form
{
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance; private DataTable _table = null!;
    public frmDangKyVeThang()
    {
        InitializeComponent(); _table = _data.GetTable("DANGKYVETHANG");
        dgvDangKy.AllowUserToAddRows = false; dgvDangKy.AllowUserToDeleteRows = false; dgvDangKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvDangKy.ReadOnly = true; dgvDangKy.RowHeadersVisible = false; dgvDangKy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        cboKhachHang.Items.AddRange(_data.GetTable("KHACHHANG").AsEnumerable().Select(r => r.Field<string>("HoTen")!).Cast<object>().ToArray()); if (cboKhachHang.Items.Count > 0) cboKhachHang.SelectedIndex = 0;
        cboPhuongThuc.Items.AddRange(new object[] { "TIEN_MAT", "CHUYEN_KHOAN", "THE" }); cboPhuongThuc.SelectedIndex = 0; nudSoThang.Value = 1; dtpBatDau.Value = DateTime.Today;
        BindGrid(); RefreshCustomer(); LoadAvailableCards(); Calculate();
    }
    private void BindGrid()
    {
        dgvDangKy.DataSource = _table; DuLieuForm.RenameColumns(dgvDangKy, ("MaDangKy", "Mã đăng ký"), ("MaKH", "Mã KH"), ("KhachHang", "Khách hàng"), ("MaPT", "Mã PT"), ("BienSo", "Biển số"), ("MaVe", "Mã vé"), ("MaThe", "Mã thẻ tháng"), ("NgayBatDau", "Bắt đầu"), ("NgayKetThuc", "Kết thúc (không gồm)"), ("TongTien", "Tổng tiền"), ("ThanhToan", "Thanh toán"), ("TrangThai", "Trạng thái")); dgvDangKy.Columns["NgayBatDau"]!.DefaultCellStyle.Format = "dd/MM/yyyy"; dgvDangKy.Columns["NgayKetThuc"]!.DefaultCellStyle.Format = "dd/MM/yyyy"; dgvDangKy.Columns["TongTien"]!.DefaultCellStyle.Format = "#,##0 ₫";
    }
    private void cboKhachHang_SelectedIndexChanged(object? sender, EventArgs e) => RefreshCustomer();
    private void RefreshCustomer()
    {
        var customer = _data.GetTable("KHACHHANG").AsEnumerable().FirstOrDefault(r => r.Field<string>("HoTen") == cboKhachHang.Text); txtHoTen.Text = customer?.Field<string>("HoTen") ?? string.Empty; txtSoDienThoai.Text = customer?.Field<string>("SoDienThoai") ?? string.Empty;
        cboPhuongTien.Items.Clear(); foreach (var vehicle in _data.GetTable("PHUONGTIEN").AsEnumerable().Where(r => r["KhachHang"] != DBNull.Value && r.Field<string>("KhachHang") == cboKhachHang.Text)) cboPhuongTien.Items.Add(vehicle.Field<string>("BienSo")!); if (cboPhuongTien.Items.Count > 0) cboPhuongTien.SelectedIndex = 0; else { txtBienSo.Clear(); txtLoaiXe.Clear(); } Calculate();
    }
    private void cboPhuongTien_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var vehicle = _data.GetTable("PHUONGTIEN").AsEnumerable().FirstOrDefault(r => r.Field<string>("BienSo") == cboPhuongTien.Text); txtBienSo.Text = vehicle?.Field<string>("BienSo") ?? string.Empty; txtLoaiXe.Text = vehicle?.Field<string>("LoaiXe") ?? string.Empty; Calculate();
    }
    private void Value_Changed(object? sender, EventArgs e) => Calculate();
    private void Calculate()
    {
        if (txtLoaiXe is null) return; var price = _data.CurrentPrice(txtLoaiXe.Text, "THANG"); var end = dtpBatDau.Value.Date.AddMonths((int)nudSoThang.Value); lblKetThucValue.Text = end.ToString("dd/MM/yyyy"); lblDonGiaValue.Text = DinhDang.Money(price); lblTongTienValue.Text = DinhDang.Money(price * nudSoThang.Value);
    }
    private void LoadAvailableCards()
    {
        var activeCards = new HashSet<string?>(_table.AsEnumerable().Where(r => r.Field<string>("TrangThai") == "HIEU_LUC" && DateTime.Today < r.Field<DateTime>("NgayKetThuc")).Select(r => r.Field<string>("MaThe"))); cboTheThang.Items.Clear(); foreach (var card in _data.GetTable("VE").AsEnumerable().Where(r => r.Field<string>("LoaiVe") == "THANG" && r.Field<string>("TrangThai") == "HOAT_DONG" && !activeCards.Contains(r.Field<string>("MaThe")))) cboTheThang.Items.Add(card.Field<string>("MaThe")!); if (cboTheThang.Items.Count > 0) cboTheThang.SelectedIndex = 0;
    }
    private void btnDangKy_Click(object? sender, EventArgs e)
    {
        if (cboKhachHang.SelectedItem is null || cboPhuongTien.SelectedItem is null || cboTheThang.SelectedItem is null) { MessageBox.Show("Vui lòng chọn khách hàng, phương tiện và thẻ tháng còn trống."); return; }
        try
        {
            var result = _data.RegisterMonthlyPass(cboKhachHang.Text, cboPhuongTien.Text, cboTheThang.Text, dtpBatDau.Value.Date, (int)nudSoThang.Value);
            ReloadData(); LoadAvailableCards();
            MessageBox.Show($"Đã tạo đăng ký {result.RegistrationId}, hạn đến {result.EndDate:dd/MM/yyyy}, tổng tiền {DinhDang.Money(result.Total)}. Hãy chọn dòng và thanh toán để kích hoạt.", "Đã đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể đăng ký vé tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
    private void btnThanhToan_Click(object? sender, EventArgs e)
    {
        var row = Selected(); if (row is null) return; if (row.Field<string>("ThanhToan") == "DA_THANH_TOAN") { MessageBox.Show("Đăng ký này đã được thanh toán."); return; }
        try { var paymentId = _data.PayMonthlyPass(row.Field<string>("MaDangKy")!, PhienDangNhap.EmployeeId, cboPhuongThuc.Text); var amount = row.Field<decimal>("TongTien"); ReloadData(); MessageBox.Show($"Thanh toán {paymentId} thành công {DinhDang.Money(amount)}. Vé tháng đã được kích hoạt."); } catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
    private void btnGiaHan_Click(object? sender, EventArgs e)
    {
        var row = Selected(); if (row is null) return; var start = row.Field<DateTime>("NgayKetThuc") > DateTime.Today ? row.Field<DateTime>("NgayKetThuc") : DateTime.Today;
        try { var result = _data.RegisterMonthlyPass(row.Field<string>("KhachHang")!, row.Field<string>("BienSo")!, row.Field<string>("MaThe")!, start, (int)nudSoThang.Value); ReloadData(); MessageBox.Show($"Đã lập kỳ gia hạn {result.RegistrationId}. Vui lòng thanh toán để kích hoạt."); } catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể gia hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
    private DataRow? Selected() { var row = dgvDangKy.CurrentRow?.DataBoundItem is DataRowView view ? view.Row : null; if (row is null) MessageBox.Show("Vui lòng chọn một đăng ký trong danh sách."); return row; }
    private void btnLamMoi_Click(object? sender, EventArgs e) { ReloadData(); LoadAvailableCards(); Calculate(); }
    private void ReloadData() { _table = _data.GetTable("DANGKYVETHANG"); BindGrid(); }
}


