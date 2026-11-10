using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmDangNhap : Form
{
    private readonly KETNOICSDL kn = new KETNOICSDL();

    public frmDangNhap()
    {
        InitializeComponent();
        try
        {
            DataTable dt = kn.GetData("dbo.sp_KiemTraKetNoi");
            lblTrangThaiKetNoi.Text = "● Đã kết nối " + Convert.ToString(dt.Rows[0]["TenCSDL"]);
            lblTrangThaiKetNoi.ForeColor = Color.Green;
            btnDangNhap.Enabled = true;
        }
        catch (Exception ex)
        {
            lblTrangThaiKetNoi.Text = "● Chưa kết nối: " + ex.Message;
            lblTrangThaiKetNoi.ForeColor = Color.Red;
            btnDangNhap.Enabled = false;
        }
    }

    private void chkHienMatKhau_CheckedChanged(object? sender, EventArgs e) =>
        txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;

    private void btnDangNhap_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
        {
            lblLoi.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
            return;
        }

        try
        {
            DataTable dt = kn.GetData(
                "dbo.sp_DangNhap",
                new SqlParameter("@TenDangNhap", txtTenDangNhap.Text.Trim()),
                new SqlParameter("@MatKhau", txtMatKhau.Text));

            if (dt.Rows.Count == 0)
            {
                lblLoi.Text = "Tên đăng nhập, mật khẩu hoặc trạng thái tài khoản không hợp lệ.";
                return;
            }

            DataRow taiKhoan = dt.Rows[0];
            PhienDangNhap.LuuThongTin(
                Convert.ToString(taiKhoan["MaNV"]),
                Convert.ToString(taiKhoan["HoTen"]),
                Convert.ToString(taiKhoan["VaiTro"]),
                Convert.ToString(taiKhoan["TenDangNhap"]));
            OpenMainForm();
        }
        catch (Exception ex)
        {
            lblLoi.Text = $"Lỗi kết nối SQL Server: {ex.Message}";
        }
    }

    private void btnDangNhapDemo_Click(object? sender, EventArgs e)
    {
        try
        {
            kn.GetData("dbo.sp_KiemTraKetNoi");
            PhienDangNhap.LuuThongTin("NV001", "Nguyễn Minh Anh", "ADMIN", "admin-demo");
            OpenMainForm();
        }
        catch (Exception ex)
        {
            lblLoi.Text = "Không thể mở dữ liệu: " + ex.Message;
        }
    }

    private void btnThoat_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void OpenMainForm()
    {
        Hide();
        using var main = new frmTrangChu();
        DialogResult ketQua = main.ShowDialog();

        if (ketQua == DialogResult.Retry)
        {
            PhienDangNhap.DangXuat();
            txtMatKhau.Clear();
            Show();
            txtMatKhau.Focus();
        }
        else
        {
            Close();
        }
    }

    private void txtThongTin_TextChanged(object? sender, EventArgs e) => lblLoi.Text = string.Empty;
}


