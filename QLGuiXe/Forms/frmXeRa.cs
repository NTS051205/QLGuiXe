using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmXeRa : Form
{
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance; private DataRow? _current;
    public frmXeRa()
    {
        InitializeComponent(); cboPhuongThucThanhToan.Items.AddRange(new object[] { "TIEN_MAT", "CHUYEN_KHOAN", "THE" }); cboPhuongThucThanhToan.SelectedIndex = 0; ResetView();
    }
    private void btnTimKiemXe_Click(object? sender, EventArgs e)
    {
        _current = _data.FindOpenParking(txtBienSoHoacMaThe.Text.Trim()); if (_current is null) { MessageBox.Show("Không tìm thấy lượt gửi đang mở theo biển số hoặc mã thẻ."); ResetView(false); return; }
        lblGiaTriBienSo.Text = _current.Field<string>("BienSo"); lblGiaTriLoaiXe.Text = _current.Field<string>("LoaiXe"); lblGiaTriMaThe.Text = _current.Field<string>("MaThe"); lblGiaTriKhuVuc.Text = _current.Field<string>("KhuVuc"); lblGiaTriThoiGianVao.Text = _current.Field<DateTime>("ThoiGianVao").ToString("dd/MM/yyyy HH:mm:ss"); lblGiaTriThoiGianRa.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); lblGiaTriThoiGianGui.Text = FormatDuration(DateTime.Now - _current.Field<DateTime>("ThoiGianVao")); lblGiaTriLoaiVe.Text = _current.Field<string>("LoaiVe"); var fee = _current.Field<string>("LoaiVe") == "THANG" ? 0M : _data.CurrentPrice(_current.Field<string>("LoaiXe")!, "LUOT"); lblGiaTriSoTien.Text = DinhDang.Money(fee); lblGiaTriSoTien.ForeColor = fee == 0 ? DinhDang.Success : DinhDang.Danger; lblTrangThaiXuLy.Text = fee == 0 ? "Vé tháng hợp lệ — không thu phí lượt" : "Chờ xác nhận và thanh toán"; btnXacNhanXeRa.Enabled = true; btnThanhToanXeRa.Enabled = false;
    }
    private static string FormatDuration(TimeSpan value) => $"{(int)value.TotalHours} giờ {value.Minutes} phút";
    private void btnXacNhanXeRa_Click(object? sender, EventArgs e)
    {
        if (_current is null) return; if (_current.Field<string>("LoaiVe") == "THANG") { Complete("KHONG_THU_PHI"); return; } btnThanhToanXeRa.Enabled = true; btnXacNhanXeRa.Enabled = false; lblTrangThaiXuLy.Text = "Đã xác nhận thông tin — vui lòng thu tiền và thanh toán";
    }
    private void btnThanhToanXeRa_Click(object? sender, EventArgs e) { if (_current is not null) Complete(cboPhuongThucThanhToan.Text); }
    private void Complete(string method)
    {
        if (_current is null) return;
        try
        {
            var fee = _data.CompleteParking(_current, PhienDangNhap.EmployeeName, method);
            MessageBox.Show(fee == 0 ? "Đã xác nhận xe ra. Vé tháng hợp lệ, phí lượt 0 ₫." : $"Thanh toán thành công {DinhDang.Money(fee)} và xác nhận xe ra.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetView(); txtBienSoHoacMaThe.Focus();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể xác nhận xe ra", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
    private void btnLamMoiXeRa_Click(object? sender, EventArgs e) => ResetView();
    private void ResetView(bool clearSearch = true) { _current = null; if (clearSearch) txtBienSoHoacMaThe.Clear(); foreach (var label in new[] { lblGiaTriBienSo, lblGiaTriLoaiXe, lblGiaTriMaThe, lblGiaTriKhuVuc, lblGiaTriThoiGianVao, lblGiaTriThoiGianRa, lblGiaTriThoiGianGui, lblGiaTriLoaiVe }) label.Text = "—"; lblGiaTriSoTien.Text = "0 ₫"; lblTrangThaiXuLy.Text = "Nhập biển số hoặc mã thẻ để tra cứu"; btnXacNhanXeRa.Enabled = false; btnThanhToanXeRa.Enabled = false; }
}


