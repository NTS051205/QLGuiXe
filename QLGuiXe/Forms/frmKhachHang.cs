using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmKhachHang : Form
{
    private QuanLyDanhSach page = null!;
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance; private DataTable _table = null!;
    public frmKhachHang()
    {
        InitializeComponent(); page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa); _table = _data.GetTable("KHACHHANG");
        page.Configure("Quản lý khách hàng", "Quản lý thông tin khách đăng ký; khách vãng lai không bắt buộc có hồ sơ.", "+ Thêm khách hàng", "Tìm theo tên hoặc số điện thoại...");
        page.Bind(_table, "MaKH", "HoTen", "SoDienThoai");
        DuLieuForm.RenameColumns(page.Grid, ("MaKH", "Mã khách hàng"), ("HoTen", "Họ tên"), ("SoDienThoai", "Số điện thoại"));
        page.AddButton.Click += Add_Click; page.EditButton.Click += Edit_Click; page.DeleteButton.Text = "Xóa"; page.DeleteButton.Click += Delete_Click;
        page.RefreshButton.Click += (_, _) => ReloadData();
        page.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(page) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết khách hàng"); };
    }
    private static RecordEditorDialog Editor(string title, DataRow? row) => new(title, new[] { new EditorField("HoTen", "Họ tên", row?["HoTen"]?.ToString()), new EditorField("SoDienThoai", "Số điện thoại", row?["SoDienThoai"]?.ToString()) });
    private void Add_Click(object? sender, EventArgs e) { using var d = Editor("Thêm khách hàng", null); if (d.ShowDialog(this) != DialogResult.OK) return; if (!DuLieuForm.IsPhone(d.Values["SoDienThoai"])) { MessageBox.Show("Số điện thoại phải gồm 9–11 chữ số."); return; } try { _data.Execute("INSERT dbo.KHACHHANG(MaKH,HoTen,SoDienThoai) VALUES(@MaKH,@HoTen,@SoDienThoai)", KetNoiCSDL.Param("@MaKH", _data.NextCode("KHACHHANG", "MaKH", "KH")), KetNoiCSDL.Param("@HoTen", d.Values["HoTen"]), KetNoiCSDL.Param("@SoDienThoai", d.Values["SoDienThoai"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void Edit_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null) return; using var d = Editor("Sửa khách hàng", row); if (d.ShowDialog(this) != DialogResult.OK) return; if (!DuLieuForm.IsPhone(d.Values["SoDienThoai"])) { MessageBox.Show("Số điện thoại phải gồm 9–11 chữ số."); return; } try { _data.Execute("UPDATE dbo.KHACHHANG SET HoTen=@HoTen,SoDienThoai=@SoDienThoai WHERE MaKH=@MaKH", KetNoiCSDL.Param("@HoTen", d.Values["HoTen"]), KetNoiCSDL.Param("@SoDienThoai", d.Values["SoDienThoai"]), KetNoiCSDL.Param("@MaKH", row["MaKH"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void Delete_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null || !DuLieuForm.Confirm("Xóa khách hàng đã chọn?")) return; try { _data.Execute("DELETE dbo.KHACHHANG WHERE MaKH=@MaKH", KetNoiCSDL.Param("@MaKH", row["MaKH"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void ReloadData() { _table = _data.GetTable("KHACHHANG"); page.Bind(_table, "MaKH", "HoTen", "SoDienThoai"); }
    private void ShowDatabaseError(Exception ex) => MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}


