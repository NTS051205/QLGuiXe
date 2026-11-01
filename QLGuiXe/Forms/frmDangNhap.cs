using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmDangNhap : Form
{
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance;

    public frmDangNhap()
    {
        InitializeComponent();
        var connected = _data.CanConnect(out var connectionMessage);
        lblTrangThaiKetNoi.Text = connected ? $"● {connectionMessage}" : $"● Chưa kết nối: {connectionMessage}";
        lblTrangThaiKetNoi.ForeColor = connected ? DinhDang.Success : DinhDang.Danger;
        btnDangNhap.Enabled = connected;
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
            var account = _data.Authenticate(txtTenDangNhap.Text, txtMatKhau.Text);
            if (account is null)
            {
                lblLoi.Text = "Tên đăng nhập, mật khẩu hoặc trạng thái tài khoản không hợp lệ.";
                return;
            }

            PhienDangNhap.SignIn(account.Field<string>("MaNV")!, account.Field<string>("HoTen")!, account.Field<string>("VaiTro")!, account.Field<string>("TenDangNhap")!);
            OpenMainForm();
        }
        catch (Exception ex)
        {
            lblLoi.Text = $"Lỗi kết nối SQL Server: {ex.Message}";
        }
    }

    private void btnDangNhapDemo_Click(object? sender, EventArgs e)
    {
        if (!_data.CanConnect(out var message))
        {
            lblLoi.Text = $"Không thể mở dữ liệu: {message}";
            return;
        }
        PhienDangNhap.SignIn("NV001", "Nguyễn Minh Anh", "ADMIN", "admin-demo");
        OpenMainForm();
    }

    private void OpenMainForm()
    {
        Hide();
        using var main = new frmTrangChu();
        main.ShowDialog();
        Close();
    }

    private void txtThongTin_TextChanged(object? sender, EventArgs e) => lblLoi.Text = string.Empty;
}


