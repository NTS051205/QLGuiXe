using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmPhuongTien : Form
{
    private QuanLyDanhSach page = null!;
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance; private DataTable _table = null!;
    public frmPhuongTien()
    {
        InitializeComponent(); page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa); _table = _data.GetTable("PHUONGTIEN");
        page.Configure("Quản lý phương tiện", "Quản lý biển số, loại xe và chủ sở hữu; khách vãng lai có thể để trống khách hàng.", "+ Thêm phương tiện", "Tìm theo biển số...");
        page.ConfigureFilter("Loại xe:", new[] { "Ô tô", "Xe máy" }, "LoaiXe");
        page.Bind(_table, "MaPT", "BienSo", "KhachHang");
        DuLieuForm.RenameColumns(page.Grid, ("MaPT", "Mã phương tiện"), ("BienSo", "Biển số"), ("LoaiXe", "Loại xe"), ("KhachHang", "Khách hàng sở hữu"));
        page.AddButton.Click += Add_Click; page.EditButton.Click += Edit_Click; page.DeleteButton.Visible = false; page.ViewButton.Text = "Lịch sử"; page.ViewButton.Click += History_Click;
        page.RefreshButton.Click += (_, _) => ReloadData();
    }
    private IReadOnlyList<string> Customers => new[] { "— Khách vãng lai —" }.Concat(_data.GetTable("KHACHHANG").AsEnumerable().Select(r => r.Field<string>("HoTen")!)).ToArray();
    private RecordEditorDialog Editor(string title, DataRow? row) => new(title, new[]
    {
        new EditorField("BienSo", "Biển số", row?["BienSo"]?.ToString(), Placeholder: "Ví dụ: 51H-123.45"),
        new EditorField("LoaiXe", "Loại xe", row?["LoaiXe"]?.ToString() ?? "Xe máy", Options: new[] { "Xe máy", "Ô tô" }),
        new EditorField("KhachHang", "Khách hàng sở hữu", row is null || row["KhachHang"] == DBNull.Value ? "— Khách vãng lai —" : row["KhachHang"].ToString(), false, Customers)
    });
    private void Add_Click(object? sender, EventArgs e) { using var d = Editor("Thêm phương tiện", null); if (d.ShowDialog(this) != DialogResult.OK) return; var customer = d.Values["KhachHang"].StartsWith("—") ? null : d.Values["KhachHang"]; try { _data.Execute("INSERT dbo.PHUONGTIEN(MaPT,BienSo,LoaiXe,MaKH) VALUES(@MaPT,UPPER(@BienSo),@LoaiXe,(SELECT MaKH FROM dbo.KHACHHANG WHERE HoTen=@KhachHang))", KetNoiCSDL.Param("@MaPT", _data.NextCode("PHUONGTIEN", "MaPT", "PT")), KetNoiCSDL.Param("@BienSo", d.Values["BienSo"]), KetNoiCSDL.Param("@LoaiXe", d.Values["LoaiXe"]), KetNoiCSDL.Param("@KhachHang", customer)); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void Edit_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null) return; using var d = Editor("Sửa phương tiện", row); if (d.ShowDialog(this) != DialogResult.OK) return; var customer = d.Values["KhachHang"].StartsWith("—") ? null : d.Values["KhachHang"]; try { _data.Execute("UPDATE dbo.PHUONGTIEN SET BienSo=UPPER(@BienSo),LoaiXe=@LoaiXe,MaKH=(SELECT MaKH FROM dbo.KHACHHANG WHERE HoTen=@KhachHang) WHERE MaPT=@MaPT", KetNoiCSDL.Param("@BienSo", d.Values["BienSo"]), KetNoiCSDL.Param("@LoaiXe", d.Values["LoaiXe"]), KetNoiCSDL.Param("@KhachHang", customer), KetNoiCSDL.Param("@MaPT", row["MaPT"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void History_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null) return; var history = _data.GetTable("LUOTGUIXE").AsEnumerable().Where(r => r.Field<string>("BienSo") == row.Field<string>("BienSo")).OrderByDescending(r => r.Field<DateTime>("ThoiGianVao")).Select(r => $"{r.Field<DateTime>("ThoiGianVao"):dd/MM/yyyy HH:mm} • {r.Field<string>("TrangThai")} • {DinhDang.Money(r.Field<decimal>("TienGui"))}").ToArray(); MessageBox.Show(history.Length == 0 ? "Phương tiện chưa có lịch sử gửi xe." : string.Join(Environment.NewLine, history), $"Lịch sử {row["BienSo"]}", MessageBoxButtons.OK, MessageBoxIcon.Information); }
    private void ReloadData() { _table = _data.GetTable("PHUONGTIEN"); page.Bind(_table, "MaPT", "BienSo", "KhachHang"); }
    private void ShowDatabaseError(Exception ex) => MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}


