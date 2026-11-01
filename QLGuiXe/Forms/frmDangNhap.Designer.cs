#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

partial class frmDangNhap
{
    private System.ComponentModel.IContainer components = null;
    private GroupBox grpDangNhap;
    private Label lblTieuDe;
    private Label lblTenDangNhap;
    private TextBox txtTenDangNhap;
    private Label lblMatKhau;
    private TextBox txtMatKhau;
    private CheckBox chkHienMatKhau;
    private Label lblLoi;
    private Button btnDangNhap;
    private Button btnDangNhapDemo;
    private Label lblTrangThaiKetNoi;
    private Label lblPhienBan;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        grpDangNhap = new GroupBox();
        lblTieuDe = new Label();
        lblTenDangNhap = new Label();
        txtTenDangNhap = new TextBox();
        lblMatKhau = new Label();
        txtMatKhau = new TextBox();
        chkHienMatKhau = new CheckBox();
        lblLoi = new Label();
        btnDangNhap = new Button();
        btnDangNhapDemo = new Button();
        lblTrangThaiKetNoi = new Label();
        lblPhienBan = new Label();
        grpDangNhap.SuspendLayout();
        SuspendLayout();
        // 
        // grpDangNhap
        // 
        grpDangNhap.Controls.Add(lblTieuDe);
        grpDangNhap.Controls.Add(lblTenDangNhap);
        grpDangNhap.Controls.Add(txtTenDangNhap);
        grpDangNhap.Controls.Add(lblMatKhau);
        grpDangNhap.Controls.Add(txtMatKhau);
        grpDangNhap.Controls.Add(chkHienMatKhau);
        grpDangNhap.Controls.Add(lblLoi);
        grpDangNhap.Controls.Add(btnDangNhap);
        grpDangNhap.Controls.Add(btnDangNhapDemo);
        grpDangNhap.Controls.Add(lblTrangThaiKetNoi);
        grpDangNhap.Location = new Point(35, 25);
        grpDangNhap.Name = "grpDangNhap";
        grpDangNhap.Size = new Size(510, 345);
        grpDangNhap.TabIndex = 0;
        grpDangNhap.TabStop = false;
        grpDangNhap.Text = "Đăng nhập";
        // 
        // lblTieuDe
        // 
        lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTieuDe.Location = new Point(25, 28);
        lblTieuDe.Name = "lblTieuDe";
        lblTieuDe.Size = new Size(460, 40);
        lblTieuDe.TabIndex = 0;
        lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ GỬI XE";
        lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTenDangNhap
        // 
        lblTenDangNhap.AutoSize = true;
        lblTenDangNhap.Location = new Point(60, 88);
        lblTenDangNhap.Name = "lblTenDangNhap";
        lblTenDangNhap.Size = new Size(128, 23);
        lblTenDangNhap.TabIndex = 1;
        lblTenDangNhap.Text = "Tên đăng nhập:";
        // 
        // txtTenDangNhap
        // 
        txtTenDangNhap.Location = new Point(185, 84);
        txtTenDangNhap.Name = "txtTenDangNhap";
        txtTenDangNhap.Size = new Size(250, 30);
        txtTenDangNhap.TabIndex = 2;
        txtTenDangNhap.TextChanged += txtThongTin_TextChanged;
        // 
        // lblMatKhau
        // 
        lblMatKhau.AutoSize = true;
        lblMatKhau.Location = new Point(60, 130);
        lblMatKhau.Name = "lblMatKhau";
        lblMatKhau.Size = new Size(86, 23);
        lblMatKhau.TabIndex = 3;
        lblMatKhau.Text = "Mật khẩu:";
        // 
        // txtMatKhau
        // 
        txtMatKhau.Location = new Point(185, 126);
        txtMatKhau.Name = "txtMatKhau";
        txtMatKhau.Size = new Size(250, 30);
        txtMatKhau.TabIndex = 4;
        txtMatKhau.UseSystemPasswordChar = true;
        txtMatKhau.TextChanged += txtThongTin_TextChanged;
        // 
        // chkHienMatKhau
        // 
        chkHienMatKhau.AutoSize = true;
        chkHienMatKhau.Location = new Point(185, 162);
        chkHienMatKhau.Name = "chkHienMatKhau";
        chkHienMatKhau.Size = new Size(144, 27);
        chkHienMatKhau.TabIndex = 5;
        chkHienMatKhau.Text = "Hiện mật khẩu";
        chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
        // 
        // lblLoi
        // 
        lblLoi.ForeColor = Color.Red;
        lblLoi.Location = new Point(60, 192);
        lblLoi.Name = "lblLoi";
        lblLoi.Size = new Size(375, 35);
        lblLoi.TabIndex = 6;
        lblLoi.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnDangNhap
        // 
        btnDangNhap.Location = new Point(110, 235);
        btnDangNhap.Name = "btnDangNhap";
        btnDangNhap.Size = new Size(140, 38);
        btnDangNhap.TabIndex = 7;
        btnDangNhap.Text = "Đăng nhập";
        btnDangNhap.UseVisualStyleBackColor = true;
        btnDangNhap.Click += btnDangNhap_Click;
        // 
        // btnDangNhapDemo
        // 
        btnDangNhapDemo.Location = new Point(256, 235);
        btnDangNhapDemo.Name = "btnDangNhapDemo";
        btnDangNhapDemo.Size = new Size(140, 38);
        btnDangNhapDemo.TabIndex = 8;
        btnDangNhapDemo.Text = "Đăng nhập thử";
        btnDangNhapDemo.UseVisualStyleBackColor = true;
        btnDangNhapDemo.Click += btnDangNhapDemo_Click;
        // 
        // lblTrangThaiKetNoi
        // 
        lblTrangThaiKetNoi.Location = new Point(30, 288);
        lblTrangThaiKetNoi.Name = "lblTrangThaiKetNoi";
        lblTrangThaiKetNoi.Size = new Size(450, 36);
        lblTrangThaiKetNoi.TabIndex = 9;
        lblTrangThaiKetNoi.Text = "Đang kiểm tra kết nối SQL Server...";
        lblTrangThaiKetNoi.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblPhienBan
        // 
        lblPhienBan.Location = new Point(360, 383);
        lblPhienBan.Name = "lblPhienBan";
        lblPhienBan.Size = new Size(185, 25);
        lblPhienBan.TabIndex = 1;
        lblPhienBan.Text = "QLGuiXe - Phiên bản 1.0";
        lblPhienBan.TextAlign = ContentAlignment.MiddleRight;
        // 
        // frmDangNhap
        // 
        AcceptButton = btnDangNhap;
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(580, 420);
        Controls.Add(grpDangNhap);
        Controls.Add(lblPhienBan);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "frmDangNhap";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Đăng nhập - Quản lý gửi xe";
        grpDangNhap.ResumeLayout(false);
        grpDangNhap.PerformLayout();
        ResumeLayout(false);
    }
}
