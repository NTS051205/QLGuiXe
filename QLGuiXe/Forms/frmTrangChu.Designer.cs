namespace QLGuiXe.Forms
{
    partial class frmTrangChu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuGuiXe;
        private System.Windows.Forms.ToolStripMenuItem mnuXeVao;
        private System.Windows.Forms.ToolStripMenuItem mnuXeRa;
        private System.Windows.Forms.ToolStripMenuItem mnuLichSu;
        private System.Windows.Forms.ToolStripMenuItem mnuDangKyVeThang;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuPhuongTien;
        private System.Windows.Forms.ToolStripMenuItem mnuLoaiVe;
        private System.Windows.Forms.ToolStripMenuItem mnuBangGia;
        private System.Windows.Forms.ToolStripMenuItem mnuKhuVuc;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanSu;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuCaLam;
        private System.Windows.Forms.ToolStripMenuItem mnuPhanCongCa;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblNguoiDung;
        private System.Windows.Forms.GroupBox grpXeDangGui;
        private System.Windows.Forms.Label lblXeDangGuiValue;
        private System.Windows.Forms.GroupBox grpChoTrong;
        private System.Windows.Forms.Label lblChoTrongValue;
        private System.Windows.Forms.GroupBox grpVeThang;
        private System.Windows.Forms.Label lblVeThangValue;
        private System.Windows.Forms.GroupBox grpDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuValue;
        private System.Windows.Forms.Label lblTinhTrangKhuVuc;
        private System.Windows.Forms.Button btnLamMoiTongQuan;
        private System.Windows.Forms.DataGridView dgvTongQuan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuiXe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXeVao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXeRa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLichSu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangKyVeThang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhuongTien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoaiVe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangGia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhuVuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanSu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCaLam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhanCongCa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.grpXeDangGui = new System.Windows.Forms.GroupBox();
            this.lblXeDangGuiValue = new System.Windows.Forms.Label();
            this.grpChoTrong = new System.Windows.Forms.GroupBox();
            this.lblChoTrongValue = new System.Windows.Forms.Label();
            this.grpVeThang = new System.Windows.Forms.GroupBox();
            this.lblVeThangValue = new System.Windows.Forms.Label();
            this.grpDoanhThu = new System.Windows.Forms.GroupBox();
            this.lblDoanhThuValue = new System.Windows.Forms.Label();
            this.lblTinhTrangKhuVuc = new System.Windows.Forms.Label();
            this.btnLamMoiTongQuan = new System.Windows.Forms.Button();
            this.dgvTongQuan = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.grpXeDangGui.SuspendLayout();
            this.grpChoTrong.SuspendLayout();
            this.grpVeThang.SuspendLayout();
            this.grpDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongQuan)).BeginInit();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuGuiXe,
            this.mnuDanhMuc,
            this.mnuNhanSu,
            this.mnuBaoCaoMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 0;
            //
            // mnuHeThong
            //
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(69, 20);
            this.mnuHeThong.Text = "Hệ thống";
            //
            // mnuDangXuat
            //
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(180, 22);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            //
            // mnuThoat
            //
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(180, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            //
            // mnuGuiXe
            //
            this.mnuGuiXe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXeVao,
            this.mnuXeRa,
            this.mnuLichSu,
            this.mnuDangKyVeThang});
            this.mnuGuiXe.Name = "mnuGuiXe";
            this.mnuGuiXe.Size = new System.Drawing.Size(56, 20);
            this.mnuGuiXe.Text = "Gửi xe";
            //
            // mnuXeVao
            //
            this.mnuXeVao.Name = "mnuXeVao";
            this.mnuXeVao.Size = new System.Drawing.Size(180, 22);
            this.mnuXeVao.Text = "Xe vào";
            this.mnuXeVao.Click += new System.EventHandler(this.mnuXeVao_Click);
            //
            // mnuXeRa
            //
            this.mnuXeRa.Name = "mnuXeRa";
            this.mnuXeRa.Size = new System.Drawing.Size(180, 22);
            this.mnuXeRa.Text = "Xe ra";
            this.mnuXeRa.Click += new System.EventHandler(this.mnuXeRa_Click);
            //
            // mnuLichSu
            //
            this.mnuLichSu.Name = "mnuLichSu";
            this.mnuLichSu.Size = new System.Drawing.Size(180, 22);
            this.mnuLichSu.Text = "Lịch sử gửi xe";
            this.mnuLichSu.Click += new System.EventHandler(this.mnuLichSu_Click);
            //
            // mnuDangKyVeThang
            //
            this.mnuDangKyVeThang.Name = "mnuDangKyVeThang";
            this.mnuDangKyVeThang.Size = new System.Drawing.Size(180, 22);
            this.mnuDangKyVeThang.Text = "Đăng ký vé tháng";
            this.mnuDangKyVeThang.Click += new System.EventHandler(this.mnuDangKyVeThang_Click);
            //
            // mnuDanhMuc
            //
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhachHang,
            this.mnuPhuongTien,
            this.mnuLoaiVe,
            this.mnuBangGia,
            this.mnuKhuVuc});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(74, 20);
            this.mnuDanhMuc.Text = "Danh mục";
            //
            // mnuKhachHang
            //
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(180, 22);
            this.mnuKhachHang.Text = "Khách hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            //
            // mnuPhuongTien
            //
            this.mnuPhuongTien.Name = "mnuPhuongTien";
            this.mnuPhuongTien.Size = new System.Drawing.Size(180, 22);
            this.mnuPhuongTien.Text = "Phương tiện";
            this.mnuPhuongTien.Click += new System.EventHandler(this.mnuPhuongTien_Click);
            //
            // mnuLoaiVe
            //
            this.mnuLoaiVe.Name = "mnuLoaiVe";
            this.mnuLoaiVe.Size = new System.Drawing.Size(180, 22);
            this.mnuLoaiVe.Text = "Loại vé và thẻ xe";
            this.mnuLoaiVe.Click += new System.EventHandler(this.mnuLoaiVe_Click);
            //
            // mnuBangGia
            //
            this.mnuBangGia.Name = "mnuBangGia";
            this.mnuBangGia.Size = new System.Drawing.Size(180, 22);
            this.mnuBangGia.Text = "Bảng giá";
            this.mnuBangGia.Click += new System.EventHandler(this.mnuBangGia_Click);
            //
            // mnuKhuVuc
            //
            this.mnuKhuVuc.Name = "mnuKhuVuc";
            this.mnuKhuVuc.Size = new System.Drawing.Size(180, 22);
            this.mnuKhuVuc.Text = "Khu vực đỗ xe";
            this.mnuKhuVuc.Click += new System.EventHandler(this.mnuKhuVuc_Click);
            //
            // mnuNhanSu
            //
            this.mnuNhanSu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhanVien,
            this.mnuTaiKhoan,
            this.mnuCaLam,
            this.mnuPhanCongCa});
            this.mnuNhanSu.Name = "mnuNhanSu";
            this.mnuNhanSu.Size = new System.Drawing.Size(63, 20);
            this.mnuNhanSu.Text = "Nhân sự";
            //
            // mnuNhanVien
            //
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(180, 22);
            this.mnuNhanVien.Text = "Nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            //
            // mnuTaiKhoan
            //
            this.mnuTaiKhoan.Name = "mnuTaiKhoan";
            this.mnuTaiKhoan.Size = new System.Drawing.Size(180, 22);
            this.mnuTaiKhoan.Text = "Tài khoản";
            this.mnuTaiKhoan.Click += new System.EventHandler(this.mnuTaiKhoan_Click);
            //
            // mnuCaLam
            //
            this.mnuCaLam.Name = "mnuCaLam";
            this.mnuCaLam.Size = new System.Drawing.Size(180, 22);
            this.mnuCaLam.Text = "Ca làm";
            this.mnuCaLam.Click += new System.EventHandler(this.mnuCaLam_Click);
            //
            // mnuPhanCongCa
            //
            this.mnuPhanCongCa.Name = "mnuPhanCongCa";
            this.mnuPhanCongCa.Size = new System.Drawing.Size(180, 22);
            this.mnuPhanCongCa.Text = "Phân công ca";
            this.mnuPhanCongCa.Click += new System.EventHandler(this.mnuPhanCongCa_Click);
            //
            // mnuBaoCaoMenu
            //
            this.mnuBaoCaoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBaoCao});
            this.mnuBaoCaoMenu.Name = "mnuBaoCaoMenu";
            this.mnuBaoCaoMenu.Size = new System.Drawing.Size(61, 20);
            this.mnuBaoCaoMenu.Text = "Báo cáo";
            //
            // mnuBaoCao
            //
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(180, 22);
            this.mnuBaoCao.Text = "Báo cáo tổng hợp";
            this.mnuBaoCao.Click += new System.EventHandler(this.mnuBaoCao_Click);
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(20, 45);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(411, 37);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ GỬI XE";
            //
            // lblMoTa
            //
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.Location = new System.Drawing.Point(22, 88);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(366, 19);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Tổng quan hoạt động; chọn menu phía trên để mở chức năng.";
            //
            // lblNguoiDung
            //
            this.lblNguoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiDung.Location = new System.Drawing.Point(620, 35);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(360, 25);
            this.lblNguoiDung.TabIndex = 3;
            this.lblNguoiDung.Text = "Người dùng:";
            this.lblNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // grpXeDangGui
            //
            this.grpXeDangGui.Controls.Add(this.lblXeDangGuiValue);
            this.grpXeDangGui.Location = new System.Drawing.Point(20, 125);
            this.grpXeDangGui.Name = "grpXeDangGui";
            this.grpXeDangGui.Size = new System.Drawing.Size(220, 95);
            this.grpXeDangGui.TabIndex = 4;
            this.grpXeDangGui.TabStop = false;
            this.grpXeDangGui.Text = "Tổng xe đang gửi";
            //
            // lblXeDangGuiValue
            //
            this.lblXeDangGuiValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblXeDangGuiValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblXeDangGuiValue.Location = new System.Drawing.Point(3, 19);
            this.lblXeDangGuiValue.Name = "lblXeDangGuiValue";
            this.lblXeDangGuiValue.Size = new System.Drawing.Size(214, 73);
            this.lblXeDangGuiValue.TabIndex = 0;
            this.lblXeDangGuiValue.Text = "0";
            this.lblXeDangGuiValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // grpChoTrong
            //
            this.grpChoTrong.Controls.Add(this.lblChoTrongValue);
            this.grpChoTrong.Location = new System.Drawing.Point(265, 125);
            this.grpChoTrong.Name = "grpChoTrong";
            this.grpChoTrong.Size = new System.Drawing.Size(220, 95);
            this.grpChoTrong.TabIndex = 5;
            this.grpChoTrong.TabStop = false;
            this.grpChoTrong.Text = "Số chỗ còn trống";
            //
            // lblChoTrongValue
            //
            this.lblChoTrongValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChoTrongValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblChoTrongValue.Location = new System.Drawing.Point(3, 19);
            this.lblChoTrongValue.Name = "lblChoTrongValue";
            this.lblChoTrongValue.Size = new System.Drawing.Size(214, 73);
            this.lblChoTrongValue.TabIndex = 0;
            this.lblChoTrongValue.Text = "0";
            this.lblChoTrongValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // grpVeThang
            //
            this.grpVeThang.Controls.Add(this.lblVeThangValue);
            this.grpVeThang.Location = new System.Drawing.Point(510, 125);
            this.grpVeThang.Name = "grpVeThang";
            this.grpVeThang.Size = new System.Drawing.Size(220, 95);
            this.grpVeThang.TabIndex = 6;
            this.grpVeThang.TabStop = false;
            this.grpVeThang.Text = "Vé tháng hiệu lực";
            //
            // lblVeThangValue
            //
            this.lblVeThangValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVeThangValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblVeThangValue.Location = new System.Drawing.Point(3, 19);
            this.lblVeThangValue.Name = "lblVeThangValue";
            this.lblVeThangValue.Size = new System.Drawing.Size(214, 73);
            this.lblVeThangValue.TabIndex = 0;
            this.lblVeThangValue.Text = "0";
            this.lblVeThangValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // grpDoanhThu
            //
            this.grpDoanhThu.Controls.Add(this.lblDoanhThuValue);
            this.grpDoanhThu.Location = new System.Drawing.Point(755, 125);
            this.grpDoanhThu.Name = "grpDoanhThu";
            this.grpDoanhThu.Size = new System.Drawing.Size(220, 95);
            this.grpDoanhThu.TabIndex = 7;
            this.grpDoanhThu.TabStop = false;
            this.grpDoanhThu.Text = "Doanh thu hôm nay";
            //
            // lblDoanhThuValue
            //
            this.lblDoanhThuValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoanhThuValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuValue.Location = new System.Drawing.Point(3, 19);
            this.lblDoanhThuValue.Name = "lblDoanhThuValue";
            this.lblDoanhThuValue.Size = new System.Drawing.Size(214, 73);
            this.lblDoanhThuValue.TabIndex = 0;
            this.lblDoanhThuValue.Text = "0 ₫";
            this.lblDoanhThuValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTinhTrangKhuVuc
            //
            this.lblTinhTrangKhuVuc.AutoSize = true;
            this.lblTinhTrangKhuVuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTinhTrangKhuVuc.Location = new System.Drawing.Point(20, 245);
            this.lblTinhTrangKhuVuc.Name = "lblTinhTrangKhuVuc";
            this.lblTinhTrangKhuVuc.Size = new System.Drawing.Size(184, 21);
            this.lblTinhTrangKhuVuc.TabIndex = 8;
            this.lblTinhTrangKhuVuc.Text = "TÌNH TRẠNG KHU VỰC";
            //
            // btnLamMoiTongQuan
            //
            this.btnLamMoiTongQuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoiTongQuan.Location = new System.Drawing.Point(855, 238);
            this.btnLamMoiTongQuan.Name = "btnLamMoiTongQuan";
            this.btnLamMoiTongQuan.Size = new System.Drawing.Size(120, 32);
            this.btnLamMoiTongQuan.TabIndex = 9;
            this.btnLamMoiTongQuan.Text = "Làm mới tổng quan";
            this.btnLamMoiTongQuan.UseVisualStyleBackColor = true;
            this.btnLamMoiTongQuan.Click += new System.EventHandler(this.btnLamMoiTongQuan_Click);
            //
            // dgvTongQuan
            //
            this.dgvTongQuan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTongQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongQuan.Location = new System.Drawing.Point(20, 280);
            this.dgvTongQuan.Name = "dgvTongQuan";
            this.dgvTongQuan.Size = new System.Drawing.Size(955, 345);
            this.dgvTongQuan.TabIndex = 10;
            //
            // frmTrangChu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.dgvTongQuan);
            this.Controls.Add(this.btnLamMoiTongQuan);
            this.Controls.Add(this.lblTinhTrangKhuVuc);
            this.Controls.Add(this.grpDoanhThu);
            this.Controls.Add(this.grpVeThang);
            this.Controls.Add(this.grpChoTrong);
            this.Controls.Add(this.grpXeDangGui);
            this.Controls.Add(this.lblNguoiDung);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1016, 689);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý gửi xe";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpXeDangGui.ResumeLayout(false);
            this.grpChoTrong.ResumeLayout(false);
            this.grpVeThang.ResumeLayout(false);
            this.grpDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongQuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
