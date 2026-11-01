using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmTaiKhoan : Form
{
    private QuanLyDanhSach page = null!;
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance;
    private DataTable _table = null!;
    public frmTaiKhoan()
    {
        InitializeComponent();
        page = new QuanLyDanhSach(lblTieuDe, lblMoTa, btnThem, txtTimKiem, lblBoLoc, cboBoLoc, lblBoLocPhu, cboBoLocPhu, lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLamMoi, dgvDuLieu, lblTongSo, btnXem, btnSua, btnXoa);
        _table = _data.GetTable("TAIKHOAN");
        page.Configure("Quản lý tài khoản", "Tạo tài khoản, phân quyền và khóa quyền truy cập hệ thống.", "+ Tạo tài khoản", "Tìm tên đăng nhập hoặc nhân viên...");
        page.ConfigureFilter("Vai trò:", new[] { "ADMIN", "NHANVIEN" }, "VaiTro");
        page.ConfigureSecondFilter("Trạng thái:", new[] { "HOAT_DONG", "KHOA" }, "TrangThai");
        page.Bind(_table, "MaTK", "TenDangNhap", "NhanVien");
        DuLieuForm.RenameColumns(page.Grid, ("MaTK", "Mã tài khoản"), ("TenDangNhap", "Tên đăng nhập"), ("NhanVien", "Nhân viên sở hữu"), ("VaiTro", "Vai trò"), ("TrangThai", "Trạng thái"));
        page.AddButton.Click += Add_Click; page.EditButton.Click += Edit_Click; page.DeleteButton.Text = "Khóa"; page.DeleteButton.Click += Lock_Click;
        page.RefreshButton.Click += (_, _) => ReloadData();
        page.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(page) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết tài khoản (không hiển thị mật khẩu)"); };
    }

    private IReadOnlyList<string> Employees => _data.GetTable("NHANVIEN").AsEnumerable().Where(r => r.Field<string>("TrangThai") == "HOAT_DONG").Select(r => r.Field<string>("HoTen")!).ToArray();
    private RecordEditorDialog Editor(string title, DataRow? row, bool requirePassword) => new(title, new[]
    {
        new EditorField("NhanVien", "Nhân viên sở hữu", row?["NhanVien"]?.ToString(), Options: Employees),
        new EditorField("TenDangNhap", "Tên đăng nhập", row?["TenDangNhap"]?.ToString()),
        new EditorField("MatKhau", "Mật khẩu", null, requirePassword, Kind: EditorKind.Password),
        new EditorField("XacNhan", "Xác nhận mật khẩu", null, requirePassword, Kind: EditorKind.Password),
        new EditorField("VaiTro", "Vai trò", row?["VaiTro"]?.ToString() ?? "NHANVIEN", Options: new[] { "ADMIN", "NHANVIEN" }),
        new EditorField("TrangThai", "Trạng thái", row?["TrangThai"]?.ToString() ?? "HOAT_DONG", Options: new[] { "HOAT_DONG", "KHOA" })
    });

    private void Add_Click(object? sender, EventArgs e)
    {
        using var dialog = Editor("Tạo tài khoản", null, true); if (dialog.ShowDialog(this) != DialogResult.OK) return;
        if (dialog.Values["MatKhau"] != dialog.Values["XacNhan"]) { MessageBox.Show("Mật khẩu xác nhận không khớp."); return; }
        if (_table.AsEnumerable().Any(r => r.Field<string>("TenDangNhap")!.Equals(dialog.Values["TenDangNhap"], StringComparison.OrdinalIgnoreCase))) { MessageBox.Show("Tên đăng nhập đã tồn tại."); return; }
        try
        {
            _data.Execute("INSERT dbo.TAIKHOAN(MaTK,TenDangNhap,MatKhauHash,MaNV,VaiTro,TrangThai) VALUES(@Ma,@Ten,CONVERT(varchar(64),HASHBYTES('SHA2_256',@MatKhau),2),(SELECT MaNV FROM dbo.NHANVIEN WHERE HoTen=@NhanVien),@VaiTro,@TrangThai)",
                KetNoiCSDL.Param("@Ma", _data.NextCode("TAIKHOAN", "MaTK", "TK")), KetNoiCSDL.Param("@Ten", dialog.Values["TenDangNhap"]),
                KetNoiCSDL.Param("@MatKhau", dialog.Values["MatKhau"]), KetNoiCSDL.Param("@NhanVien", dialog.Values["NhanVien"]),
                KetNoiCSDL.Param("@VaiTro", dialog.Values["VaiTro"]), KetNoiCSDL.Param("@TrangThai", dialog.Values["TrangThai"]));
            ReloadData();
        }
        catch (Exception ex) { ShowDatabaseError(ex); }
    }
    private void Edit_Click(object? sender, EventArgs e)
    {
        var row = DuLieuForm.RequireSelection(page); if (row is null) return;
        using var dialog = Editor("Sửa tài khoản", row, false); if (dialog.ShowDialog(this) != DialogResult.OK) return;
        if (dialog.Values["MatKhau"] != dialog.Values["XacNhan"]) { MessageBox.Show("Mật khẩu xác nhận không khớp."); return; }
        try
        {
            var passwordSql = string.IsNullOrWhiteSpace(dialog.Values["MatKhau"]) ? string.Empty : ",MatKhauHash=CONVERT(varchar(64),HASHBYTES('SHA2_256',@MatKhau),2)";
            _data.Execute($"UPDATE dbo.TAIKHOAN SET TenDangNhap=@Ten,MaNV=(SELECT MaNV FROM dbo.NHANVIEN WHERE HoTen=@NhanVien),VaiTro=@VaiTro,TrangThai=@TrangThai{passwordSql} WHERE MaTK=@Ma",
                KetNoiCSDL.Param("@Ten", dialog.Values["TenDangNhap"]), KetNoiCSDL.Param("@NhanVien", dialog.Values["NhanVien"]),
                KetNoiCSDL.Param("@VaiTro", dialog.Values["VaiTro"]), KetNoiCSDL.Param("@TrangThai", dialog.Values["TrangThai"]),
                KetNoiCSDL.Param("@MatKhau", dialog.Values["MatKhau"]), KetNoiCSDL.Param("@Ma", row["MaTK"]));
            ReloadData();
        }
        catch (Exception ex) { ShowDatabaseError(ex); }
    }
    private void Lock_Click(object? sender, EventArgs e) { var row = DuLieuForm.RequireSelection(page); if (row is null || !DuLieuForm.Confirm("Khóa tài khoản đã chọn?")) return; try { _data.Execute("UPDATE dbo.TAIKHOAN SET TrangThai='KHOA' WHERE MaTK=@Ma", KetNoiCSDL.Param("@Ma", row["MaTK"])); ReloadData(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void ReloadData() { _table = _data.GetTable("TAIKHOAN"); page.Bind(_table, "MaTK", "TenDangNhap", "NhanVien"); }
    private void ShowDatabaseError(Exception ex) => MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}


