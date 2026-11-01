using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmPhanCongCa : Form
{
    private QuanLyDanhSach page = null!;
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance; private DataTable _table = null!;
    public frmPhanCongCa()
    {
        InitializeComponent(); page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa); _table = _data.GetTable("PHANCONGCA");
        page.Configure("Phân công ca", "Sắp xếp nhân viên theo ca và ngày làm việc.", "+ Phân công", "Tìm nhân viên hoặc mã phân công...");
        page.ConfigureFilter("Nhân viên:", _data.GetTable("NHANVIEN").AsEnumerable().Select(r => r.Field<string>("HoTen")!).ToArray(), "NhanVien");
        page.ConfigureSecondFilter("Ca làm:", _data.GetTable("CALAM").AsEnumerable().Select(r => r.Field<string>("TenCa")!).ToArray(), "CaLam");
        page.ShowDateRange(); page.FromDatePicker.Value = DateTime.Today.AddDays(-7); page.ToDatePicker.Value = DateTime.Today.AddDays(7);
        page.Bind(_table, "MaPhanCong", "NhanVien", "CaLam"); page.FilterChanged += (_, _) => ApplyFilter();
        DuLieuForm.RenameColumns(page.Grid, ("MaPhanCong", "Mã phân công"), ("NhanVien", "Nhân viên"), ("CaLam", "Ca làm"), ("NgayLam", "Ngày làm"));
        page.Grid.Columns["NgayLam"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
        page.AddButton.Click += Add_Click; page.EditButton.Click += Edit_Click; page.DeleteButton.Text = "Xóa"; page.DeleteButton.Click += Delete_Click;
        page.RefreshButton.Click += (_, _) => ReloadData();
        page.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(page) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết phân công"); };
        ApplyFilter();
    }
    private void ApplyFilter() { var from = page.FromDatePicker.Value.Date.ToString("MM/dd/yyyy"); var to = page.ToDatePicker.Value.Date.AddDays(1).ToString("MM/dd/yyyy"); page.ApplyFilter($"[NgayLam] >= #{from}# AND [NgayLam] < #{to}#"); }
    private RecordEditorDialog Editor(string title, DataRow? row) => new(title, new[]
    {
        new EditorField("NhanVien", "Nhân viên", row?["NhanVien"]?.ToString(), Options: _data.GetTable("NHANVIEN").AsEnumerable().Where(r => r.Field<string>("TrangThai") == "HOAT_DONG").Select(r => r.Field<string>("HoTen")!).ToArray()),
        new EditorField("CaLam", "Ca làm", row?["CaLam"]?.ToString(), Options: _data.GetTable("CALAM").AsEnumerable().Select(r => r.Field<string>("TenCa")!).ToArray()),
        new EditorField("NgayLam", "Ngày làm", row?["NgayLam"]?.ToString(), Kind: EditorKind.Date)
    });
    private void Add_Click(object? sender, EventArgs e) { using var d = Editor("Thêm phân công", null); if (d.ShowDialog(this) != DialogResult.OK) return; try { _data.Execute("INSERT dbo.PHANCONGCA(MaPhanCong,MaNV,MaCa,NgayLam) VALUES(@Ma,(SELECT MaNV FROM dbo.NHANVIEN WHERE HoTen=@NhanVien),(SELECT MaCa FROM dbo.CALAM WHERE TenCa=@Ca),@Ngay)", KetNoiCSDL.Param("@Ma", _data.NextCode("PHANCONGCA", "MaPhanCong", "PC")), KetNoiCSDL.Param("@NhanVien", d.Values["NhanVien"]), KetNoiCSDL.Param("@Ca", d.Values["CaLam"]), KetNoiCSDL.Param("@Ngay", DateTime.Parse(d.Values["NgayLam"]).Date)); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void Edit_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null) return; using var d = Editor("Sửa phân công", row); if (d.ShowDialog(this) != DialogResult.OK) return; try { _data.Execute("UPDATE dbo.PHANCONGCA SET MaNV=(SELECT MaNV FROM dbo.NHANVIEN WHERE HoTen=@NhanVien),MaCa=(SELECT MaCa FROM dbo.CALAM WHERE TenCa=@Ca),NgayLam=@Ngay WHERE MaPhanCong=@Ma", KetNoiCSDL.Param("@NhanVien", d.Values["NhanVien"]), KetNoiCSDL.Param("@Ca", d.Values["CaLam"]), KetNoiCSDL.Param("@Ngay", DateTime.Parse(d.Values["NgayLam"]).Date), KetNoiCSDL.Param("@Ma", row["MaPhanCong"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void Delete_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null || !DuLieuForm.Confirm("Xóa phân công đã chọn?")) return; try { _data.Execute("DELETE dbo.PHANCONGCA WHERE MaPhanCong=@Ma", KetNoiCSDL.Param("@Ma", row["MaPhanCong"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void ReloadData() { _table = _data.GetTable("PHANCONGCA"); page.Bind(_table, "MaPhanCong", "NhanVien", "CaLam"); ApplyFilter(); }
    private void ShowDatabaseError(Exception ex) => MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}


