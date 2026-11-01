using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmBangGia : Form
{
    private QuanLyDanhSach page = null!;
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance;
    private DataTable _table = null!;
    public frmBangGia()
    {
        InitializeComponent();
        page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa);
        _table = _data.GetTable("BANGGIA");
        page.Configure("Bảng giá", "Quản lý giá vé lượt và vé tháng theo từng loại phương tiện.", "+ Thêm mức giá", "Tìm mã bảng giá...");
        page.ConfigureFilter("Loại xe:", new[] { "Ô tô", "Xe máy" }, "LoaiXe"); page.ConfigureSecondFilter("Loại vé:", new[] { "LUOT", "THANG" }, "LoaiVe");
        page.Bind(_table, "MaBangGia", "LoaiXe", "LoaiVe");
        DuLieuForm.RenameColumns(page.Grid, ("MaBangGia", "Mã bảng giá"), ("LoaiXe", "Loại xe"), ("LoaiVe", "Loại vé"), ("DonGia", "Đơn giá"), ("NgayApDung", "Ngày áp dụng"));
        page.Grid.Columns["DonGia"]!.DefaultCellStyle.Format = "#,##0 ₫"; page.Grid.Columns["NgayApDung"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
        page.AddButton.Click += Add_Click; page.EditButton.Click += Edit_Click; page.DeleteButton.Visible = false;
        page.RefreshButton.Click += (_, _) => ReloadData();
        page.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(page) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết bảng giá"); };
    }
    private static RecordEditorDialog Editor(string title, DataRow? row) => new(title, new[]
    {
        new EditorField("LoaiXe", "Loại xe", row?["LoaiXe"]?.ToString() ?? "Xe máy", Options: new[] { "Xe máy", "Ô tô" }),
        new EditorField("LoaiVe", "Loại vé", row?["LoaiVe"]?.ToString() ?? "LUOT", Options: new[] { "LUOT", "THANG" }),
        new EditorField("DonGia", "Đơn giá (VNĐ)", row?["DonGia"]?.ToString()),
        new EditorField("NgayApDung", "Ngày áp dụng", row?["NgayApDung"]?.ToString(), Kind: EditorKind.Date)
    });
    private void Add_Click(object? sender, EventArgs e) { using var d = Editor("Thêm mức giá", null); if (d.ShowDialog(this) != DialogResult.OK) return; if (!decimal.TryParse(d.Values["DonGia"], out var price) || price <= 0) { MessageBox.Show("Đơn giá phải là số dương."); return; } SavePrice(null, d, price); }
    private void Edit_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null) return; using var d = Editor("Sửa mức giá", row); if (d.ShowDialog(this) != DialogResult.OK) return; if (!decimal.TryParse(d.Values["DonGia"], out var price) || price <= 0) { MessageBox.Show("Đơn giá phải là số dương."); return; } SavePrice(row["MaBangGia"].ToString(), d, price); }
    private void SavePrice(string? id, RecordEditorDialog d, decimal price) { try { if (id is null) _data.Execute("INSERT dbo.BANGGIA(MaBangGia,LoaiXe,MaLoaiVe,DonGia,NgayApDung) VALUES(@Id,@LoaiXe,(SELECT MaLoaiVe FROM dbo.LOAIVE WHERE KyHieu=@LoaiVe),@DonGia,@Ngay)", KetNoiCSDL.Param("@Id", _data.NextCode("BANGGIA", "MaBangGia", "BG")), KetNoiCSDL.Param("@LoaiXe", d.Values["LoaiXe"]), KetNoiCSDL.Param("@LoaiVe", d.Values["LoaiVe"]), KetNoiCSDL.Param("@DonGia", price), KetNoiCSDL.Param("@Ngay", DateTime.Parse(d.Values["NgayApDung"]).Date)); else _data.Execute("UPDATE dbo.BANGGIA SET LoaiXe=@LoaiXe,MaLoaiVe=(SELECT MaLoaiVe FROM dbo.LOAIVE WHERE KyHieu=@LoaiVe),DonGia=@DonGia,NgayApDung=@Ngay WHERE MaBangGia=@Id", KetNoiCSDL.Param("@LoaiXe", d.Values["LoaiXe"]), KetNoiCSDL.Param("@LoaiVe", d.Values["LoaiVe"]), KetNoiCSDL.Param("@DonGia", price), KetNoiCSDL.Param("@Ngay", DateTime.Parse(d.Values["NgayApDung"]).Date), KetNoiCSDL.Param("@Id", id)); ReloadData(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning); } }
    private void ReloadData() { _table = _data.GetTable("BANGGIA"); page.Bind(_table, "MaBangGia", "LoaiXe", "LoaiVe"); }
}


