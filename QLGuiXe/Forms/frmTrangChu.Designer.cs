#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

partial class frmTrangChu
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSidebar;
    private Label lblTenHeThong;
    private FlowLayoutPanel flpMenu;
    private Button btnDashboard;
    private Button btnXeVao;
    private Button btnXeRa;
    private Button btnLichSu;
    private Button btnDangKyVeThang;
    private Button btnKhachHang;
    private Button btnPhuongTien;
    private Button btnLoaiVe;
    private Button btnBangGia;
    private Button btnKhuVuc;
    private Button btnNhanVien;
    private Button btnTaiKhoan;
    private Button btnCaLam;
    private Button btnPhanCongCa;
    private Panel pnlHeader;
    private Label lblPageTitle;
    private Label lblCurrentUser;
    private Button btnDangXuat;
    private Panel pnlContent;
    private Panel pnlDashboard;
    private Label lblWelcome;
    private FlowLayoutPanel flpQuickActions;
    private Button btnQuickXeVao;
    private Button btnQuickXeRa;
    private Button btnQuickVeThang;
    private TableLayoutPanel tlpThongTin;
    private GroupBox grpTongXe;
    private Label lblTongXeValue;
    private GroupBox grpOTo;
    private Label lblOToValue;
    private GroupBox grpXeMay;
    private Label lblXeMayValue;
    private GroupBox grpConTrong;
    private Label lblConTrongValue;
    private GroupBox grpVeThang;
    private Label lblVeThangValue;
    private TableLayoutPanel tlpDanhSach;
    private GroupBox grpXeGanDay;
    private DataGridView dgvXeGanDay;
    private GroupBox grpKhuVuc;
    private DataGridView dgvKhuVuc;
    private GroupBox grpVeSapHetHan;
    private DataGridView dgvVeSapHetHan;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlSidebar = new Panel();
        flpMenu = new FlowLayoutPanel();
        btnDashboard = new Button();
        btnXeVao = new Button();
        btnXeRa = new Button();
        btnLichSu = new Button();
        btnDangKyVeThang = new Button();
        btnKhachHang = new Button();
        btnPhuongTien = new Button();
        btnLoaiVe = new Button();
        btnBangGia = new Button();
        btnKhuVuc = new Button();
        btnNhanVien = new Button();
        btnTaiKhoan = new Button();
        btnCaLam = new Button();
        btnPhanCongCa = new Button();
        lblTenHeThong = new Label();
        pnlHeader = new Panel();
        lblPageTitle = new Label();
        lblCurrentUser = new Label();
        btnDangXuat = new Button();
        pnlContent = new Panel();
        pnlDashboard = new Panel();
        tlpDanhSach = new TableLayoutPanel();
        grpXeGanDay = new GroupBox();
        dgvXeGanDay = new DataGridView();
        grpKhuVuc = new GroupBox();
        dgvKhuVuc = new DataGridView();
        grpVeSapHetHan = new GroupBox();
        dgvVeSapHetHan = new DataGridView();
        tlpThongTin = new TableLayoutPanel();
        grpTongXe = new GroupBox();
        lblTongXeValue = new Label();
        grpOTo = new GroupBox();
        lblOToValue = new Label();
        grpXeMay = new GroupBox();
        lblXeMayValue = new Label();
        grpConTrong = new GroupBox();
        lblConTrongValue = new Label();
        grpVeThang = new GroupBox();
        lblVeThangValue = new Label();
        flpQuickActions = new FlowLayoutPanel();
        btnQuickXeVao = new Button();
        btnQuickXeRa = new Button();
        btnQuickVeThang = new Button();
        lblWelcome = new Label();
        pnlSidebar.SuspendLayout();
        flpMenu.SuspendLayout();
        pnlHeader.SuspendLayout();
        pnlContent.SuspendLayout();
        pnlDashboard.SuspendLayout();
        tlpDanhSach.SuspendLayout();
        grpXeGanDay.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvXeGanDay).BeginInit();
        grpKhuVuc.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKhuVuc).BeginInit();
        grpVeSapHetHan.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvVeSapHetHan).BeginInit();
        tlpThongTin.SuspendLayout();
        grpTongXe.SuspendLayout();
        grpOTo.SuspendLayout();
        grpXeMay.SuspendLayout();
        grpConTrong.SuspendLayout();
        grpVeThang.SuspendLayout();
        flpQuickActions.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = SystemColors.ControlLight;
        pnlSidebar.BorderStyle = BorderStyle.FixedSingle;
        pnlSidebar.Controls.Add(flpMenu);
        pnlSidebar.Controls.Add(lblTenHeThong);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Margin = new Padding(4, 4, 4, 4);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(274, 960);
        pnlSidebar.TabIndex = 2;
        // 
        // flpMenu
        // 
        flpMenu.AutoScroll = true;
        flpMenu.Controls.Add(btnDashboard);
        flpMenu.Controls.Add(btnXeVao);
        flpMenu.Controls.Add(btnXeRa);
        flpMenu.Controls.Add(btnLichSu);
        flpMenu.Controls.Add(btnDangKyVeThang);
        flpMenu.Controls.Add(btnKhachHang);
        flpMenu.Controls.Add(btnPhuongTien);
        flpMenu.Controls.Add(btnLoaiVe);
        flpMenu.Controls.Add(btnBangGia);
        flpMenu.Controls.Add(btnKhuVuc);
        flpMenu.Controls.Add(btnNhanVien);
        flpMenu.Controls.Add(btnTaiKhoan);
        flpMenu.Controls.Add(btnCaLam);
        flpMenu.Controls.Add(btnPhanCongCa);
        flpMenu.Dock = DockStyle.Fill;
        flpMenu.FlowDirection = FlowDirection.TopDown;
        flpMenu.Location = new Point(0, 78);
        flpMenu.Margin = new Padding(4, 4, 4, 4);
        flpMenu.Name = "flpMenu";
        flpMenu.Padding = new Padding(10, 10, 10, 10);
        flpMenu.Size = new Size(272, 880);
        flpMenu.TabIndex = 0;
        flpMenu.WrapContents = false;
        // 
        // btnDashboard
        // 
        btnDashboard.Location = new Point(14, 14);
        btnDashboard.Margin = new Padding(4, 4, 4, 4);
        btnDashboard.Name = "btnDashboard";
        btnDashboard.Size = new Size(238, 48);
        btnDashboard.TabIndex = 0;
        btnDashboard.Tag = "Dashboard";
        btnDashboard.Text = "Trang chủ";
        btnDashboard.UseVisualStyleBackColor = true;
        btnDashboard.Click += btnDashboard_Click;
        // 
        // btnXeVao
        // 
        btnXeVao.Location = new Point(14, 70);
        btnXeVao.Margin = new Padding(4, 4, 4, 4);
        btnXeVao.Name = "btnXeVao";
        btnXeVao.Size = new Size(238, 48);
        btnXeVao.TabIndex = 1;
        btnXeVao.Tag = "XeVao";
        btnXeVao.Text = "Xe vào";
        btnXeVao.UseVisualStyleBackColor = true;
        // 
        // btnXeRa
        // 
        btnXeRa.Location = new Point(14, 126);
        btnXeRa.Margin = new Padding(4, 4, 4, 4);
        btnXeRa.Name = "btnXeRa";
        btnXeRa.Size = new Size(238, 48);
        btnXeRa.TabIndex = 2;
        btnXeRa.Tag = "XeRa";
        btnXeRa.Text = "Xe ra";
        btnXeRa.UseVisualStyleBackColor = true;
        // 
        // btnLichSu
        // 
        btnLichSu.Location = new Point(14, 182);
        btnLichSu.Margin = new Padding(4, 4, 4, 4);
        btnLichSu.Name = "btnLichSu";
        btnLichSu.Size = new Size(238, 48);
        btnLichSu.TabIndex = 3;
        btnLichSu.Tag = "LichSu";
        btnLichSu.Text = "Lịch sử gửi xe";
        btnLichSu.UseVisualStyleBackColor = true;
        // 
        // btnDangKyVeThang
        // 
        btnDangKyVeThang.Location = new Point(14, 238);
        btnDangKyVeThang.Margin = new Padding(4, 4, 4, 4);
        btnDangKyVeThang.Name = "btnDangKyVeThang";
        btnDangKyVeThang.Size = new Size(238, 48);
        btnDangKyVeThang.TabIndex = 4;
        btnDangKyVeThang.Tag = "DangKyVeThang";
        btnDangKyVeThang.Text = "Đăng ký vé tháng";
        btnDangKyVeThang.UseVisualStyleBackColor = true;
        // 
        // btnKhachHang
        // 
        btnKhachHang.Location = new Point(14, 294);
        btnKhachHang.Margin = new Padding(4, 4, 4, 4);
        btnKhachHang.Name = "btnKhachHang";
        btnKhachHang.Size = new Size(238, 48);
        btnKhachHang.TabIndex = 5;
        btnKhachHang.Tag = "KhachHang";
        btnKhachHang.Text = "Khách hàng";
        btnKhachHang.UseVisualStyleBackColor = true;
        // 
        // btnPhuongTien
        // 
        btnPhuongTien.Location = new Point(14, 350);
        btnPhuongTien.Margin = new Padding(4, 4, 4, 4);
        btnPhuongTien.Name = "btnPhuongTien";
        btnPhuongTien.Size = new Size(238, 48);
        btnPhuongTien.TabIndex = 6;
        btnPhuongTien.Tag = "PhuongTien";
        btnPhuongTien.Text = "Phương tiện";
        btnPhuongTien.UseVisualStyleBackColor = true;
        // 
        // btnLoaiVe
        // 
        btnLoaiVe.Location = new Point(14, 406);
        btnLoaiVe.Margin = new Padding(4, 4, 4, 4);
        btnLoaiVe.Name = "btnLoaiVe";
        btnLoaiVe.Size = new Size(238, 48);
        btnLoaiVe.TabIndex = 7;
        btnLoaiVe.Tag = "LoaiVe";
        btnLoaiVe.Text = "Loại vé và thẻ xe";
        btnLoaiVe.UseVisualStyleBackColor = true;
        // 
        // btnBangGia
        // 
        btnBangGia.Location = new Point(14, 462);
        btnBangGia.Margin = new Padding(4, 4, 4, 4);
        btnBangGia.Name = "btnBangGia";
        btnBangGia.Size = new Size(238, 48);
        btnBangGia.TabIndex = 8;
        btnBangGia.Tag = "BangGia";
        btnBangGia.Text = "Bảng giá";
        btnBangGia.UseVisualStyleBackColor = true;
        // 
        // btnKhuVuc
        // 
        btnKhuVuc.Location = new Point(14, 518);
        btnKhuVuc.Margin = new Padding(4, 4, 4, 4);
        btnKhuVuc.Name = "btnKhuVuc";
        btnKhuVuc.Size = new Size(238, 48);
        btnKhuVuc.TabIndex = 9;
        btnKhuVuc.Tag = "KhuVuc";
        btnKhuVuc.Text = "Khu vực đỗ xe";
        btnKhuVuc.UseVisualStyleBackColor = true;
        // 
        // btnNhanVien
        // 
        btnNhanVien.Location = new Point(14, 574);
        btnNhanVien.Margin = new Padding(4, 4, 4, 4);
        btnNhanVien.Name = "btnNhanVien";
        btnNhanVien.Size = new Size(238, 48);
        btnNhanVien.TabIndex = 10;
        btnNhanVien.Tag = "NhanVien";
        btnNhanVien.Text = "Nhân viên";
        btnNhanVien.UseVisualStyleBackColor = true;
        // 
        // btnTaiKhoan
        // 
        btnTaiKhoan.Location = new Point(14, 630);
        btnTaiKhoan.Margin = new Padding(4, 4, 4, 4);
        btnTaiKhoan.Name = "btnTaiKhoan";
        btnTaiKhoan.Size = new Size(238, 48);
        btnTaiKhoan.TabIndex = 11;
        btnTaiKhoan.Tag = "TaiKhoan";
        btnTaiKhoan.Text = "Tài khoản";
        btnTaiKhoan.UseVisualStyleBackColor = true;
        // 
        // btnCaLam
        // 
        btnCaLam.Location = new Point(14, 686);
        btnCaLam.Margin = new Padding(4, 4, 4, 4);
        btnCaLam.Name = "btnCaLam";
        btnCaLam.Size = new Size(238, 48);
        btnCaLam.TabIndex = 12;
        btnCaLam.Tag = "CaLam";
        btnCaLam.Text = "Ca làm";
        btnCaLam.UseVisualStyleBackColor = true;
        // 
        // btnPhanCongCa
        // 
        btnPhanCongCa.Location = new Point(14, 742);
        btnPhanCongCa.Margin = new Padding(4, 4, 4, 4);
        btnPhanCongCa.Name = "btnPhanCongCa";
        btnPhanCongCa.Size = new Size(238, 48);
        btnPhanCongCa.TabIndex = 13;
        btnPhanCongCa.Tag = "PhanCongCa";
        btnPhanCongCa.Text = "Phân công ca";
        btnPhanCongCa.UseVisualStyleBackColor = true;
        // 
        // lblTenHeThong
        // 
        lblTenHeThong.BackColor = SystemColors.Control;
        lblTenHeThong.Dock = DockStyle.Top;
        lblTenHeThong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTenHeThong.Location = new Point(0, 0);
        lblTenHeThong.Margin = new Padding(4, 0, 4, 0);
        lblTenHeThong.Name = "lblTenHeThong";
        lblTenHeThong.Size = new Size(272, 78);
        lblTenHeThong.TabIndex = 1;
        lblTenHeThong.Text = "QUẢN LÝ GỬI XE";
        lblTenHeThong.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = SystemColors.Control;
        pnlHeader.BorderStyle = BorderStyle.FixedSingle;
        pnlHeader.Controls.Add(lblPageTitle);
        pnlHeader.Controls.Add(lblCurrentUser);
        pnlHeader.Controls.Add(btnDangXuat);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(274, 0);
        pnlHeader.Margin = new Padding(4, 4, 4, 4);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(1326, 74);
        pnlHeader.TabIndex = 1;
        // 
        // lblPageTitle
        // 
        lblPageTitle.Dock = DockStyle.Left;
        lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblPageTitle.Location = new Point(0, 0);
        lblPageTitle.Margin = new Padding(4, 0, 4, 0);
        lblPageTitle.Name = "lblPageTitle";
        lblPageTitle.Padding = new Padding(18, 0, 0, 0);
        lblPageTitle.Size = new Size(400, 72);
        lblPageTitle.TabIndex = 0;
        lblPageTitle.Text = "Trang chủ";
        lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblCurrentUser
        // 
        lblCurrentUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblCurrentUser.Location = new Point(864, 14);
        lblCurrentUser.Margin = new Padding(4, 0, 4, 0);
        lblCurrentUser.Name = "lblCurrentUser";
        lblCurrentUser.Size = new Size(288, 45);
        lblCurrentUser.TabIndex = 1;
        lblCurrentUser.Text = "Người dùng";
        lblCurrentUser.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnDangXuat
        // 
        btnDangXuat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDangXuat.Location = new Point(1171, 15);
        btnDangXuat.Margin = new Padding(4, 4, 4, 4);
        btnDangXuat.Name = "btnDangXuat";
        btnDangXuat.Size = new Size(131, 42);
        btnDangXuat.TabIndex = 2;
        btnDangXuat.Text = "Đăng xuất";
        btnDangXuat.UseVisualStyleBackColor = true;
        btnDangXuat.Click += btnDangXuat_Click;
        // 
        // pnlContent
        // 
        pnlContent.BackColor = SystemColors.Control;
        pnlContent.Controls.Add(pnlDashboard);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(274, 74);
        pnlContent.Margin = new Padding(4, 4, 4, 4);
        pnlContent.Name = "pnlContent";
        pnlContent.Size = new Size(1326, 886);
        pnlContent.TabIndex = 0;
        // 
        // pnlDashboard
        // 
        pnlDashboard.AutoScroll = true;
        pnlDashboard.Controls.Add(tlpDanhSach);
        pnlDashboard.Controls.Add(tlpThongTin);
        pnlDashboard.Controls.Add(flpQuickActions);
        pnlDashboard.Controls.Add(lblWelcome);
        pnlDashboard.Dock = DockStyle.Fill;
        pnlDashboard.Location = new Point(0, 0);
        pnlDashboard.Margin = new Padding(4, 4, 4, 4);
        pnlDashboard.Name = "pnlDashboard";
        pnlDashboard.Padding = new Padding(19, 19, 19, 19);
        pnlDashboard.Size = new Size(1326, 886);
        pnlDashboard.TabIndex = 0;
        // 
        // tlpDanhSach
        // 
        tlpDanhSach.ColumnCount = 2;
        tlpDanhSach.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
        tlpDanhSach.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
        tlpDanhSach.Controls.Add(grpXeGanDay, 0, 0);
        tlpDanhSach.Controls.Add(grpKhuVuc, 1, 0);
        tlpDanhSach.Controls.Add(grpVeSapHetHan, 1, 1);
        tlpDanhSach.Dock = DockStyle.Fill;
        tlpDanhSach.Location = new Point(19, 271);
        tlpDanhSach.Margin = new Padding(4, 4, 4, 4);
        tlpDanhSach.Name = "tlpDanhSach";
        tlpDanhSach.Padding = new Padding(0, 12, 0, 0);
        tlpDanhSach.RowCount = 2;
        tlpDanhSach.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tlpDanhSach.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tlpDanhSach.Size = new Size(1288, 596);
        tlpDanhSach.TabIndex = 0;
        // 
        // grpXeGanDay
        // 
        grpXeGanDay.Controls.Add(dgvXeGanDay);
        grpXeGanDay.Dock = DockStyle.Fill;
        grpXeGanDay.Location = new Point(4, 16);
        grpXeGanDay.Margin = new Padding(4, 4, 4, 4);
        grpXeGanDay.Name = "grpXeGanDay";
        grpXeGanDay.Padding = new Padding(4, 4, 4, 4);
        tlpDanhSach.SetRowSpan(grpXeGanDay, 2);
        grpXeGanDay.Size = new Size(739, 576);
        grpXeGanDay.TabIndex = 0;
        grpXeGanDay.TabStop = false;
        grpXeGanDay.Text = "Xe vào gần nhất";
        // 
        // dgvXeGanDay
        // 
        dgvXeGanDay.ColumnHeadersHeight = 29;
        dgvXeGanDay.Dock = DockStyle.Fill;
        dgvXeGanDay.Location = new Point(4, 24);
        dgvXeGanDay.Margin = new Padding(4, 4, 4, 4);
        dgvXeGanDay.Name = "dgvXeGanDay";
        dgvXeGanDay.ReadOnly = true;
        dgvXeGanDay.RowHeadersWidth = 51;
        dgvXeGanDay.Size = new Size(731, 548);
        dgvXeGanDay.TabIndex = 0;
        // 
        // grpKhuVuc
        // 
        grpKhuVuc.Controls.Add(dgvKhuVuc);
        grpKhuVuc.Dock = DockStyle.Fill;
        grpKhuVuc.Location = new Point(751, 16);
        grpKhuVuc.Margin = new Padding(4, 4, 4, 4);
        grpKhuVuc.Name = "grpKhuVuc";
        grpKhuVuc.Padding = new Padding(4, 4, 4, 4);
        grpKhuVuc.Size = new Size(533, 284);
        grpKhuVuc.TabIndex = 1;
        grpKhuVuc.TabStop = false;
        grpKhuVuc.Text = "Tình trạng khu vực";
        // 
        // dgvKhuVuc
        // 
        dgvKhuVuc.ColumnHeadersHeight = 29;
        dgvKhuVuc.Dock = DockStyle.Fill;
        dgvKhuVuc.Location = new Point(4, 24);
        dgvKhuVuc.Margin = new Padding(4, 4, 4, 4);
        dgvKhuVuc.Name = "dgvKhuVuc";
        dgvKhuVuc.ReadOnly = true;
        dgvKhuVuc.RowHeadersWidth = 51;
        dgvKhuVuc.Size = new Size(525, 256);
        dgvKhuVuc.TabIndex = 0;
        // 
        // grpVeSapHetHan
        // 
        grpVeSapHetHan.Controls.Add(dgvVeSapHetHan);
        grpVeSapHetHan.Dock = DockStyle.Fill;
        grpVeSapHetHan.Location = new Point(751, 308);
        grpVeSapHetHan.Margin = new Padding(4, 4, 4, 4);
        grpVeSapHetHan.Name = "grpVeSapHetHan";
        grpVeSapHetHan.Padding = new Padding(4, 4, 4, 4);
        grpVeSapHetHan.Size = new Size(533, 284);
        grpVeSapHetHan.TabIndex = 2;
        grpVeSapHetHan.TabStop = false;
        grpVeSapHetHan.Text = "Vé tháng sắp hết hạn";
        // 
        // dgvVeSapHetHan
        // 
        dgvVeSapHetHan.ColumnHeadersHeight = 29;
        dgvVeSapHetHan.Dock = DockStyle.Fill;
        dgvVeSapHetHan.Location = new Point(4, 24);
        dgvVeSapHetHan.Margin = new Padding(4, 4, 4, 4);
        dgvVeSapHetHan.Name = "dgvVeSapHetHan";
        dgvVeSapHetHan.ReadOnly = true;
        dgvVeSapHetHan.RowHeadersWidth = 51;
        dgvVeSapHetHan.Size = new Size(525, 256);
        dgvVeSapHetHan.TabIndex = 0;
        // 
        // tlpThongTin
        // 
        tlpThongTin.ColumnCount = 5;
        tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpThongTin.Controls.Add(grpTongXe, 0, 0);
        tlpThongTin.Controls.Add(grpOTo, 1, 0);
        tlpThongTin.Controls.Add(grpXeMay, 2, 0);
        tlpThongTin.Controls.Add(grpConTrong, 3, 0);
        tlpThongTin.Controls.Add(grpVeThang, 4, 0);
        tlpThongTin.Dock = DockStyle.Top;
        tlpThongTin.Location = new Point(19, 140);
        tlpThongTin.Margin = new Padding(4, 4, 4, 4);
        tlpThongTin.Name = "tlpThongTin";
        tlpThongTin.RowCount = 1;
        tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpThongTin.Size = new Size(1288, 131);
        tlpThongTin.TabIndex = 1;
        // 
        // grpTongXe
        // 
        grpTongXe.Controls.Add(lblTongXeValue);
        grpTongXe.Dock = DockStyle.Fill;
        grpTongXe.Location = new Point(4, 4);
        grpTongXe.Margin = new Padding(4, 4, 4, 4);
        grpTongXe.Name = "grpTongXe";
        grpTongXe.Padding = new Padding(4, 4, 4, 4);
        grpTongXe.Size = new Size(249, 123);
        grpTongXe.TabIndex = 0;
        grpTongXe.TabStop = false;
        grpTongXe.Text = "Tổng xe đang gửi";
        // 
        // lblTongXeValue
        // 
        lblTongXeValue.Dock = DockStyle.Fill;
        lblTongXeValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTongXeValue.Location = new Point(4, 24);
        lblTongXeValue.Margin = new Padding(4, 0, 4, 0);
        lblTongXeValue.Name = "lblTongXeValue";
        lblTongXeValue.Size = new Size(241, 95);
        lblTongXeValue.TabIndex = 0;
        lblTongXeValue.Text = "0";
        lblTongXeValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // grpOTo
        // 
        grpOTo.Controls.Add(lblOToValue);
        grpOTo.Dock = DockStyle.Fill;
        grpOTo.Location = new Point(261, 4);
        grpOTo.Margin = new Padding(4, 4, 4, 4);
        grpOTo.Name = "grpOTo";
        grpOTo.Padding = new Padding(4, 4, 4, 4);
        grpOTo.Size = new Size(249, 123);
        grpOTo.TabIndex = 1;
        grpOTo.TabStop = false;
        grpOTo.Text = "Ô tô đang gửi";
        // 
        // lblOToValue
        // 
        lblOToValue.Dock = DockStyle.Fill;
        lblOToValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblOToValue.Location = new Point(4, 24);
        lblOToValue.Margin = new Padding(4, 0, 4, 0);
        lblOToValue.Name = "lblOToValue";
        lblOToValue.Size = new Size(241, 95);
        lblOToValue.TabIndex = 0;
        lblOToValue.Text = "0";
        lblOToValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // grpXeMay
        // 
        grpXeMay.Controls.Add(lblXeMayValue);
        grpXeMay.Dock = DockStyle.Fill;
        grpXeMay.Location = new Point(518, 4);
        grpXeMay.Margin = new Padding(4, 4, 4, 4);
        grpXeMay.Name = "grpXeMay";
        grpXeMay.Padding = new Padding(4, 4, 4, 4);
        grpXeMay.Size = new Size(249, 123);
        grpXeMay.TabIndex = 2;
        grpXeMay.TabStop = false;
        grpXeMay.Text = "Xe máy đang gửi";
        // 
        // lblXeMayValue
        // 
        lblXeMayValue.Dock = DockStyle.Fill;
        lblXeMayValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblXeMayValue.Location = new Point(4, 24);
        lblXeMayValue.Margin = new Padding(4, 0, 4, 0);
        lblXeMayValue.Name = "lblXeMayValue";
        lblXeMayValue.Size = new Size(241, 95);
        lblXeMayValue.TabIndex = 0;
        lblXeMayValue.Text = "0";
        lblXeMayValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // grpConTrong
        // 
        grpConTrong.Controls.Add(lblConTrongValue);
        grpConTrong.Dock = DockStyle.Fill;
        grpConTrong.Location = new Point(775, 4);
        grpConTrong.Margin = new Padding(4, 4, 4, 4);
        grpConTrong.Name = "grpConTrong";
        grpConTrong.Padding = new Padding(4, 4, 4, 4);
        grpConTrong.Size = new Size(249, 123);
        grpConTrong.TabIndex = 3;
        grpConTrong.TabStop = false;
        grpConTrong.Text = "Số chỗ còn trống";
        // 
        // lblConTrongValue
        // 
        lblConTrongValue.Dock = DockStyle.Fill;
        lblConTrongValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblConTrongValue.Location = new Point(4, 24);
        lblConTrongValue.Margin = new Padding(4, 0, 4, 0);
        lblConTrongValue.Name = "lblConTrongValue";
        lblConTrongValue.Size = new Size(241, 95);
        lblConTrongValue.TabIndex = 0;
        lblConTrongValue.Text = "0";
        lblConTrongValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // grpVeThang
        // 
        grpVeThang.Controls.Add(lblVeThangValue);
        grpVeThang.Dock = DockStyle.Fill;
        grpVeThang.Location = new Point(1032, 4);
        grpVeThang.Margin = new Padding(4, 4, 4, 4);
        grpVeThang.Name = "grpVeThang";
        grpVeThang.Padding = new Padding(4, 4, 4, 4);
        grpVeThang.Size = new Size(252, 123);
        grpVeThang.TabIndex = 4;
        grpVeThang.TabStop = false;
        grpVeThang.Text = "Vé tháng hiệu lực";
        // 
        // lblVeThangValue
        // 
        lblVeThangValue.Dock = DockStyle.Fill;
        lblVeThangValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblVeThangValue.Location = new Point(4, 24);
        lblVeThangValue.Margin = new Padding(4, 0, 4, 0);
        lblVeThangValue.Name = "lblVeThangValue";
        lblVeThangValue.Size = new Size(244, 95);
        lblVeThangValue.TabIndex = 0;
        lblVeThangValue.Text = "0";
        lblVeThangValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // flpQuickActions
        // 
        flpQuickActions.Controls.Add(btnQuickXeVao);
        flpQuickActions.Controls.Add(btnQuickXeRa);
        flpQuickActions.Controls.Add(btnQuickVeThang);
        flpQuickActions.Dock = DockStyle.Top;
        flpQuickActions.Location = new Point(19, 75);
        flpQuickActions.Margin = new Padding(4, 4, 4, 4);
        flpQuickActions.Name = "flpQuickActions";
        flpQuickActions.Size = new Size(1288, 65);
        flpQuickActions.TabIndex = 2;
        // 
        // btnQuickXeVao
        // 
        btnQuickXeVao.Location = new Point(4, 4);
        btnQuickXeVao.Margin = new Padding(4, 4, 4, 4);
        btnQuickXeVao.Name = "btnQuickXeVao";
        btnQuickXeVao.Size = new Size(150, 45);
        btnQuickXeVao.TabIndex = 0;
        btnQuickXeVao.Text = "Xe vào";
        btnQuickXeVao.UseVisualStyleBackColor = true;
        btnQuickXeVao.Click += btnQuickXeVao_Click;
        // 
        // btnQuickXeRa
        // 
        btnQuickXeRa.Location = new Point(162, 4);
        btnQuickXeRa.Margin = new Padding(4, 4, 4, 4);
        btnQuickXeRa.Name = "btnQuickXeRa";
        btnQuickXeRa.Size = new Size(150, 45);
        btnQuickXeRa.TabIndex = 1;
        btnQuickXeRa.Text = "Xe ra";
        btnQuickXeRa.UseVisualStyleBackColor = true;
        btnQuickXeRa.Click += btnQuickXeRa_Click;
        // 
        // btnQuickVeThang
        // 
        btnQuickVeThang.Location = new Point(320, 4);
        btnQuickVeThang.Margin = new Padding(4, 4, 4, 4);
        btnQuickVeThang.Name = "btnQuickVeThang";
        btnQuickVeThang.Size = new Size(200, 45);
        btnQuickVeThang.TabIndex = 2;
        btnQuickVeThang.Text = "Đăng ký vé tháng";
        btnQuickVeThang.UseVisualStyleBackColor = true;
        btnQuickVeThang.Click += btnQuickVeThang_Click;
        // 
        // lblWelcome
        // 
        lblWelcome.Dock = DockStyle.Top;
        lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblWelcome.Location = new Point(19, 19);
        lblWelcome.Margin = new Padding(4, 0, 4, 0);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(1288, 56);
        lblWelcome.TabIndex = 3;
        lblWelcome.Text = "TỔNG QUAN BÃI XE";
        lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // frmTrangChu
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1600, 960);
        Controls.Add(pnlContent);
        Controls.Add(pnlHeader);
        Controls.Add(pnlSidebar);
        Font = new Font("Segoe UI", 9F);
        Margin = new Padding(4, 4, 4, 4);
        MinimumSize = new Size(1370, 863);
        Name = "frmTrangChu";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý gửi xe";
        WindowState = FormWindowState.Maximized;
        pnlSidebar.ResumeLayout(false);
        flpMenu.ResumeLayout(false);
        pnlHeader.ResumeLayout(false);
        pnlContent.ResumeLayout(false);
        pnlDashboard.ResumeLayout(false);
        tlpDanhSach.ResumeLayout(false);
        grpXeGanDay.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvXeGanDay).EndInit();
        grpKhuVuc.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvKhuVuc).EndInit();
        grpVeSapHetHan.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvVeSapHetHan).EndInit();
        tlpThongTin.ResumeLayout(false);
        grpTongXe.ResumeLayout(false);
        grpOTo.ResumeLayout(false);
        grpXeMay.ResumeLayout(false);
        grpConTrong.ResumeLayout(false);
        grpVeThang.ResumeLayout(false);
        flpQuickActions.ResumeLayout(false);
        ResumeLayout(false);
    }
}
