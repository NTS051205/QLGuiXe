using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmCaLam : Form
{
    private QuanLyDanhSach page = null!;
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance; private DataTable _table = null!;
    public frmCaLam()
    {
        InitializeComponent(); page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa); _table = _data.GetTable("CALAM");
        page.Configure("Quản lý ca làm", "Thiết lập khung giờ làm việc; hỗ trợ ca kết thúc vào ngày hôm sau.", "+ Thêm ca", "Tìm theo tên ca...");
        page.Bind(_table, "MaCa", "TenCa");
        DuLieuForm.RenameColumns(page.Grid, ("MaCa", "Mã ca"), ("TenCa", "Tên ca"), ("GioBatDau", "Giờ bắt đầu"), ("GioKetThuc", "Giờ kết thúc"), ("QuaDem", "Qua đêm"));
        page.AddButton.Click += Add_Click; page.EditButton.Click += Edit_Click; page.DeleteButton.Text = "Xóa"; page.DeleteButton.Click += Delete_Click;
        page.RefreshButton.Click += (_, _) => ReloadData();
        page.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(page) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết ca làm"); };
    }
    private static RecordEditorDialog Editor(string title, DataRow? row) => new(title, new[]
    {
        new EditorField("TenCa", "Tên ca", row?["TenCa"]?.ToString()),
        new EditorField("GioBatDau", "Giờ bắt đầu", row?["GioBatDau"]?.ToString(), Kind: EditorKind.Time),
        new EditorField("GioKetThuc", "Giờ kết thúc", row?["GioKetThuc"]?.ToString(), Kind: EditorKind.Time)
    });
    private void Add_Click(object? sender, EventArgs e) { using var d = Editor("Thêm ca làm", null); if (d.ShowDialog(this) != DialogResult.OK) return; try { _data.Execute("INSERT dbo.CALAM(MaCa,TenCa,GioBatDau,GioKetThuc) VALUES(@Ma,@Ten,@BatDau,@KetThuc)", KetNoiCSDL.Param("@Ma", _data.NextCode("CALAM", "MaCa", "CA", 2)), KetNoiCSDL.Param("@Ten", d.Values["TenCa"]), KetNoiCSDL.Param("@BatDau", TimeSpan.Parse(d.Values["GioBatDau"])), KetNoiCSDL.Param("@KetThuc", TimeSpan.Parse(d.Values["GioKetThuc"]))); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void Edit_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null) return; using var d = Editor("Sửa ca làm", row); if (d.ShowDialog(this) != DialogResult.OK) return; try { _data.Execute("UPDATE dbo.CALAM SET TenCa=@Ten,GioBatDau=@BatDau,GioKetThuc=@KetThuc WHERE MaCa=@Ma", KetNoiCSDL.Param("@Ten", d.Values["TenCa"]), KetNoiCSDL.Param("@BatDau", TimeSpan.Parse(d.Values["GioBatDau"])), KetNoiCSDL.Param("@KetThuc", TimeSpan.Parse(d.Values["GioKetThuc"])), KetNoiCSDL.Param("@Ma", row["MaCa"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void Delete_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null || !DuLieuForm.Confirm("Xóa ca làm đã chọn?")) return; try { _data.Execute("DELETE dbo.CALAM WHERE MaCa=@Ma", KetNoiCSDL.Param("@Ma", row["MaCa"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void ReloadData() { _table = _data.GetTable("CALAM"); page.Bind(_table, "MaCa", "TenCa"); }
    private void ShowDatabaseError(Exception ex) => MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}


