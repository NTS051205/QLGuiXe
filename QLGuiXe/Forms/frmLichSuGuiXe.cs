
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmLichSuGuiXe : Form
{
    private QuanLyDanhSach page = null!;
    public frmLichSuGuiXe()
    {
        InitializeComponent();
        page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa);
        page.Configure("Lịch sử gửi xe", "Tra cứu toàn bộ lượt xe vào, xe ra và chi phí phát sinh.", "+ Thêm mới", "Tìm theo biển số hoặc mã thẻ...");
        page.AddButton.Visible = false; page.EditButton.Visible = false; page.DeleteButton.Visible = false; page.ViewButton.Text = "Xem chi tiết";
        page.ConfigureFilter("Trạng thái:", new[] { "DANG_GUI", "DA_RA" }, "TrangThai"); page.ConfigureSecondFilter("Loại xe:", new[] { "Ô tô", "Xe máy" }, "LoaiXe");
        page.ShowDateRange(); page.FromDatePicker.Value = DateTime.Today.AddDays(-30); page.ToDatePicker.Value = DateTime.Today;
        page.Bind(KetNoiCSDL.Instance.GetTable("LUOTGUIXE"), "MaLuotGui", "BienSo", "MaThe", "KhuVuc"); page.FilterChanged += (_, _) => ApplyDateFilter();
        DuLieuForm.RenameColumns(page.Grid, ("MaLuotGui", "Mã lượt gửi"), ("MaPT", "Mã phương tiện"), ("BienSo", "Biển số"), ("LoaiXe", "Loại xe"), ("MaVe", "Mã vé"), ("MaThe", "Mã thẻ"), ("MaKhuVuc", "Mã khu vực"), ("KhuVuc", "Khu vực"), ("ThoiGianVao", "Thời gian vào"), ("ThoiGianRa", "Thời gian ra"), ("TienGui", "Tiền gửi"), ("NhanVienVao", "Nhân viên vào"), ("NhanVienRa", "Nhân viên ra"), ("TrangThai", "Trạng thái"), ("LoaiVe", "Loại vé"));
        page.Grid.Columns["ThoiGianVao"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; page.Grid.Columns["ThoiGianRa"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; page.Grid.Columns["TienGui"]!.DefaultCellStyle.Format = "#,##0 ₫";
        page.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(page) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết lượt gửi xe"); };
        page.RefreshButton.Click += (_, _) => { page.Bind(KetNoiCSDL.Instance.GetTable("LUOTGUIXE"), "MaLuotGui", "BienSo", "MaThe", "KhuVuc"); ApplyDateFilter(); };
        ApplyDateFilter();
    }
    private void ApplyDateFilter() { var from = page.FromDatePicker.Value.Date.ToString("MM/dd/yyyy"); var to = page.ToDatePicker.Value.Date.AddDays(1).ToString("MM/dd/yyyy"); page.ApplyFilter($"[ThoiGianVao] >= #{from}# AND [ThoiGianVao] < #{to}#"); }
}


