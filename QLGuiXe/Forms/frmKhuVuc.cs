using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmKhuVuc : Form
{
    private QuanLyDanhSach page = null!;
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance;
    private DataTable _table;
    public frmKhuVuc()
    {
        InitializeComponent();
        page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa);
        _table = _data.GetTable("KHUVUC");
        page.Configure("Khu vực đỗ xe", "Theo dõi sức chứa, số xe đang gửi và tình trạng từng khu vực.", "+ Thêm khu vực", "Tìm tên hoặc mã khu vực...");
        page.ConfigureFilter("Loại xe:", new[] { "Ô tô", "Xe máy" }, "LoaiXe"); page.ConfigureSecondFilter("Trạng thái:", new[] { "HOAT_DONG", "BAO_TRI", "TAM_DONG" }, "TrangThai");
        page.Bind(_table, "MaKhuVuc", "TenKhuVuc");
        DuLieuForm.RenameColumns(page.Grid, ("MaKhuVuc", "Mã khu vực"), ("TenKhuVuc", "Tên khu vực"), ("LoaiXe", "Loại xe"), ("SucChua", "Sức chứa"), ("DangGui", "Đang gửi"), ("ConTrong", "Còn trống"), ("TrangThai", "Trạng thái"));
        page.AddButton.Click += Add_Click; page.EditButton.Click += Edit_Click; page.DeleteButton.Visible = false;
        page.RefreshButton.Click += (_, _) => ReloadData();
        page.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(page) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết khu vực"); };
    }
    private static RecordEditorDialog Editor(string title, DataRow? row) => new(title, new[]
    {
        new EditorField("MaKhuVuc", "Mã khu vực", row?["MaKhuVuc"]?.ToString()),
        new EditorField("TenKhuVuc", "Tên khu vực", row?["TenKhuVuc"]?.ToString()),
        new EditorField("LoaiXe", "Loại xe", row?["LoaiXe"]?.ToString() ?? "Xe máy", Options: new[] { "Xe máy", "Ô tô" }),
        new EditorField("SucChua", "Sức chứa", row?["SucChua"]?.ToString()),
        new EditorField("TrangThai", "Trạng thái", row?["TrangThai"]?.ToString() ?? "HOAT_DONG", Options: new[] { "HOAT_DONG", "BAO_TRI", "TAM_DONG" })
    });
    private void Add_Click(object? sender, EventArgs e) { using var d = Editor("Thêm khu vực", null); if (d.ShowDialog(this) != DialogResult.OK) return; if (!int.TryParse(d.Values["SucChua"], out var capacity) || capacity <= 0) { MessageBox.Show("Sức chứa phải là số nguyên dương."); return; } try { _data.Execute("INSERT dbo.KHUVUC(MaKhuVuc,TenKhuVuc,LoaiXe,SucChua,TrangThai) VALUES(UPPER(@Ma),@Ten,@Loai,@SucChua,@TrangThai)", KetNoiCSDL.Param("@Ma", d.Values["MaKhuVuc"]), KetNoiCSDL.Param("@Ten", d.Values["TenKhuVuc"]), KetNoiCSDL.Param("@Loai", d.Values["LoaiXe"]), KetNoiCSDL.Param("@SucChua", capacity), KetNoiCSDL.Param("@TrangThai", d.Values["TrangThai"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void Edit_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null) return; using var d = Editor("Sửa khu vực", row); if (d.ShowDialog(this) != DialogResult.OK) return; if (!int.TryParse(d.Values["SucChua"], out var capacity) || capacity < row.Field<int>("DangGui")) { MessageBox.Show("Sức chứa không được nhỏ hơn số xe đang gửi."); return; } try { _data.Execute("UPDATE dbo.KHUVUC SET TenKhuVuc=@Ten,LoaiXe=@Loai,SucChua=@SucChua,TrangThai=@TrangThai WHERE MaKhuVuc=@Ma", KetNoiCSDL.Param("@Ten", d.Values["TenKhuVuc"]), KetNoiCSDL.Param("@Loai", d.Values["LoaiXe"]), KetNoiCSDL.Param("@SucChua", capacity), KetNoiCSDL.Param("@TrangThai", d.Values["TrangThai"]), KetNoiCSDL.Param("@Ma", row["MaKhuVuc"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void ReloadData() { _table = _data.GetTable("KHUVUC"); page.Bind(_table, "MaKhuVuc", "TenKhuVuc"); }
    private void ShowDatabaseError(Exception ex) => MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}


