namespace QLGuiXe.Forms
{
    partial class frmDangKyVeThang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();

            this.grpKhachHang = new System.Windows.Forms.GroupBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.btnThemKhachHang = new System.Windows.Forms.Button();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblPhuongTien = new System.Windows.Forms.Label();
            this.cboPhuongTien = new System.Windows.Forms.ComboBox();
            this.btnThemPhuongTien = new System.Windows.Forms.Button();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.txtLoaiXe = new System.Windows.Forms.TextBox();

            this.grpVeThang = new System.Windows.Forms.GroupBox();
            this.lblTheThang = new System.Windows.Forms.Label();
            this.cboTheThang = new System.Windows.Forms.ComboBox();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblSoThang = new System.Windows.Forms.Label();
            this.nudSoThang = new System.Windows.Forms.NumericUpDown();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lblNgayKetThucValue = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblDonGiaValue = new System.Windows.Forms.Label();

            this.grpThanhToan = new System.Windows.Forms.GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongTienValue = new System.Windows.Forms.Label();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.lblDanhSach = new System.Windows.Forms.Label();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();

            this.grpKhachHang.SuspendLayout();
            this.grpVeThang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoThang)).BeginInit();
            this.grpThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();

            this.SuspendLayout();

            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTieuDe.Location =
                new System.Drawing.Point(392, 15);

            this.lblTieuDe.Name =
                "lblTieuDe";

            this.lblTieuDe.Size =
                new System.Drawing.Size(390, 37);

            this.lblTieuDe.Text =
                "ĐĂNG KÝ VÀ GIA HẠN VÉ THÁNG";

            // 
            // grpKhachHang
            // 
            this.grpKhachHang.Controls.Add(
                this.lblKhachHang
            );

            this.grpKhachHang.Controls.Add(
                this.cboKhachHang
            );

            this.grpKhachHang.Controls.Add(
                this.btnThemKhachHang
            );

            this.grpKhachHang.Controls.Add(
                this.lblHoTen
            );

            this.grpKhachHang.Controls.Add(
                this.txtHoTen
            );

            this.grpKhachHang.Controls.Add(
                this.lblSoDienThoai
            );

            this.grpKhachHang.Controls.Add(
                this.txtSoDienThoai
            );

            this.grpKhachHang.Controls.Add(
                this.lblPhuongTien
            );

            this.grpKhachHang.Controls.Add(
                this.cboPhuongTien
            );

            this.grpKhachHang.Controls.Add(
                this.btnThemPhuongTien
            );

            this.grpKhachHang.Controls.Add(
                this.lblBienSo
            );

            this.grpKhachHang.Controls.Add(
                this.txtBienSo
            );

            this.grpKhachHang.Controls.Add(
                this.lblLoaiXe
            );

            this.grpKhachHang.Controls.Add(
                this.txtLoaiXe
            );

            this.grpKhachHang.Location =
                new System.Drawing.Point(20, 70);

            this.grpKhachHang.Name =
                "grpKhachHang";

            this.grpKhachHang.Size =
                new System.Drawing.Size(360, 350);

            this.grpKhachHang.TabStop =
                false;

            this.grpKhachHang.Text =
                "Thông tin khách hàng và phương tiện";

            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize =
                true;

            this.lblKhachHang.Location =
                new System.Drawing.Point(18, 30);

            this.lblKhachHang.Name =
                "lblKhachHang";

            this.lblKhachHang.Text =
                "Khách hàng";

            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboKhachHang.Location =
                new System.Drawing.Point(120, 26);

            this.cboKhachHang.Name =
                "cboKhachHang";

            this.cboKhachHang.Size =
                new System.Drawing.Size(220, 23);

            this.cboKhachHang.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cboKhachHang_SelectedIndexChanged
                );

            // 
            // btnThemKhachHang
            // 
            this.btnThemKhachHang.Location =
                new System.Drawing.Point(160, 58);

            this.btnThemKhachHang.Name =
                "btnThemKhachHang";

            this.btnThemKhachHang.Size =
                new System.Drawing.Size(130, 30);

            this.btnThemKhachHang.Text =
                "Thêm khách hàng";

            this.btnThemKhachHang.UseVisualStyleBackColor =
                true;

            this.btnThemKhachHang.Click +=
                new System.EventHandler(
                    this.btnThemKhachHang_Click
                );

            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize =
                true;

            this.lblHoTen.Location =
                new System.Drawing.Point(18, 105);

            this.lblHoTen.Name =
                "lblHoTen";

            this.lblHoTen.Text =
                "Họ tên";

            // 
            // txtHoTen
            // 
            this.txtHoTen.Location =
                new System.Drawing.Point(120, 101);

            this.txtHoTen.Name =
                "txtHoTen";

            this.txtHoTen.ReadOnly =
                true;

            this.txtHoTen.Size =
                new System.Drawing.Size(220, 23);

            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize =
                true;

            this.lblSoDienThoai.Location =
                new System.Drawing.Point(18, 145);

            this.lblSoDienThoai.Name =
                "lblSoDienThoai";

            this.lblSoDienThoai.Text =
                "Số điện thoại";

            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location =
                new System.Drawing.Point(120, 141);

            this.txtSoDienThoai.Name =
                "txtSoDienThoai";

            this.txtSoDienThoai.ReadOnly =
                true;

            this.txtSoDienThoai.Size =
                new System.Drawing.Size(220, 23);

            // 
            // lblPhuongTien
            // 
            this.lblPhuongTien.AutoSize =
                true;

            this.lblPhuongTien.Location =
                new System.Drawing.Point(18, 185);

            this.lblPhuongTien.Name =
                "lblPhuongTien";

            this.lblPhuongTien.Text =
                "Phương tiện";

            // 
            // cboPhuongTien
            // 
            this.cboPhuongTien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboPhuongTien.Location =
                new System.Drawing.Point(120, 181);

            this.cboPhuongTien.Name =
                "cboPhuongTien";

            this.cboPhuongTien.Size =
                new System.Drawing.Size(220, 23);

            this.cboPhuongTien.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cboPhuongTien_SelectedIndexChanged
                );

            // 
            // btnThemPhuongTien
            // 
            this.btnThemPhuongTien.Location =
                new System.Drawing.Point(160, 213);

            this.btnThemPhuongTien.Name =
                "btnThemPhuongTien";

            this.btnThemPhuongTien.Size =
                new System.Drawing.Size(130, 30);

            this.btnThemPhuongTien.Text =
                "Thêm phương tiện";

            this.btnThemPhuongTien.UseVisualStyleBackColor =
                true;

            this.btnThemPhuongTien.Click +=
                new System.EventHandler(
                    this.btnThemPhuongTien_Click
                );

            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize =
                true;

            this.lblBienSo.Location =
                new System.Drawing.Point(18, 260);

            this.lblBienSo.Name =
                "lblBienSo";

            this.lblBienSo.Text =
                "Biển số";

            // 
            // txtBienSo
            // 
            this.txtBienSo.Location =
                new System.Drawing.Point(120, 256);

            this.txtBienSo.Name =
                "txtBienSo";

            this.txtBienSo.ReadOnly =
                true;

            this.txtBienSo.Size =
                new System.Drawing.Size(220, 23);

            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize =
                true;

            this.lblLoaiXe.Location =
                new System.Drawing.Point(18, 300);

            this.lblLoaiXe.Name =
                "lblLoaiXe";

            this.lblLoaiXe.Text =
                "Loại xe";

            // 
            // txtLoaiXe
            // 
            this.txtLoaiXe.Location =
                new System.Drawing.Point(120, 296);

            this.txtLoaiXe.Name =
                "txtLoaiXe";

            this.txtLoaiXe.ReadOnly =
                true;

            this.txtLoaiXe.Size =
                new System.Drawing.Size(220, 23);

            // 
            // grpVeThang
            // 
            this.grpVeThang.Controls.Add(
                this.lblTheThang
            );

            this.grpVeThang.Controls.Add(
                this.cboTheThang
            );

            this.grpVeThang.Controls.Add(
                this.lblNgayBatDau
            );

            this.grpVeThang.Controls.Add(
                this.dtpBatDau
            );

            this.grpVeThang.Controls.Add(
                this.lblSoThang
            );

            this.grpVeThang.Controls.Add(
                this.nudSoThang
            );

            this.grpVeThang.Controls.Add(
                this.lblNgayKetThuc
            );

            this.grpVeThang.Controls.Add(
                this.lblNgayKetThucValue
            );

            this.grpVeThang.Controls.Add(
                this.lblDonGia
            );

            this.grpVeThang.Controls.Add(
                this.lblDonGiaValue
            );

            this.grpVeThang.Location =
                new System.Drawing.Point(400, 70);

            this.grpVeThang.Name =
                "grpVeThang";

            this.grpVeThang.Size =
                new System.Drawing.Size(350, 350);

            this.grpVeThang.TabStop =
                false;

            this.grpVeThang.Text =
                "Thông tin vé tháng";

            // 
            // lblTheThang
            // 
            this.lblTheThang.AutoSize =
                true;

            this.lblTheThang.Location =
                new System.Drawing.Point(18, 30);

            this.lblTheThang.Name =
                "lblTheThang";

            this.lblTheThang.Text =
                "Thẻ tháng";

            // 
            // cboTheThang
            // 
            this.cboTheThang.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboTheThang.Location =
                new System.Drawing.Point(130, 26);

            this.cboTheThang.Name =
                "cboTheThang";

            this.cboTheThang.Size =
                new System.Drawing.Size(195, 23);

            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize =
                true;

            this.lblNgayBatDau.Location =
                new System.Drawing.Point(18, 75);

            this.lblNgayBatDau.Name =
                "lblNgayBatDau";

            this.lblNgayBatDau.Text =
                "Ngày bắt đầu";

            // 
            // dtpBatDau
            // 
            this.dtpBatDau.CustomFormat =
                "dd/MM/yyyy";

            this.dtpBatDau.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;

            this.dtpBatDau.Location =
                new System.Drawing.Point(130, 70);

            this.dtpBatDau.Name =
                "dtpBatDau";

            this.dtpBatDau.Size =
                new System.Drawing.Size(195, 23);

            this.dtpBatDau.ValueChanged +=
                new System.EventHandler(
                    this.dtpBatDau_ValueChanged
                );

            // 
            // lblSoThang
            // 
            this.lblSoThang.AutoSize =
                true;

            this.lblSoThang.Location =
                new System.Drawing.Point(18, 120);

            this.lblSoThang.Name =
                "lblSoThang";

            this.lblSoThang.Text =
                "Số tháng";

            // 
            // nudSoThang
            // 
            this.nudSoThang.Location =
                new System.Drawing.Point(130, 116);

            this.nudSoThang.Maximum =
                new decimal(
                    new int[] { 24, 0, 0, 0 }
                );

            this.nudSoThang.Minimum =
                new decimal(
                    new int[] { 1, 0, 0, 0 }
                );

            this.nudSoThang.Name =
                "nudSoThang";

            this.nudSoThang.Size =
                new System.Drawing.Size(195, 23);

            this.nudSoThang.Value =
                new decimal(
                    new int[] { 1, 0, 0, 0 }
                );

            this.nudSoThang.ValueChanged +=
                new System.EventHandler(
                    this.nudSoThang_ValueChanged
                );

            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize =
                true;

            this.lblNgayKetThuc.Location =
                new System.Drawing.Point(18, 165);

            this.lblNgayKetThuc.Name =
                "lblNgayKetThuc";

            this.lblNgayKetThuc.Text =
                "Ngày kết thúc";

            // 
            // lblNgayKetThucValue
            // 
            this.lblNgayKetThucValue.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblNgayKetThucValue.Location =
                new System.Drawing.Point(130, 160);

            this.lblNgayKetThucValue.Name =
                "lblNgayKetThucValue";

            this.lblNgayKetThucValue.Size =
                new System.Drawing.Size(195, 25);

            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize =
                true;

            this.lblDonGia.Location =
                new System.Drawing.Point(18, 210);

            this.lblDonGia.Name =
                "lblDonGia";

            this.lblDonGia.Text =
                "Đơn giá / tháng";

            // 
            // lblDonGiaValue
            // 
            this.lblDonGiaValue.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblDonGiaValue.Location =
                new System.Drawing.Point(130, 205);

            this.lblDonGiaValue.Name =
                "lblDonGiaValue";

            this.lblDonGiaValue.Size =
                new System.Drawing.Size(195, 25);

            this.lblDonGiaValue.Text =
                "0 ₫";

            // 
            // grpThanhToan
            // 
            this.grpThanhToan.Controls.Add(
                this.lblTongTien
            );

            this.grpThanhToan.Controls.Add(
                this.lblTongTienValue
            );

            this.grpThanhToan.Controls.Add(
                this.lblPhuongThuc
            );

            this.grpThanhToan.Controls.Add(
                this.cboPhuongThuc
            );

            this.grpThanhToan.Controls.Add(
                this.btnDangKy
            );

            this.grpThanhToan.Controls.Add(
                this.btnThanhToan
            );

            this.grpThanhToan.Controls.Add(
                this.btnGiaHan
            );

            this.grpThanhToan.Controls.Add(
                this.btnLamMoi
            );

            this.grpThanhToan.Controls.Add(
                this.btnThoat
            );

            this.grpThanhToan.Location =
                new System.Drawing.Point(770, 70);

            this.grpThanhToan.Name =
                "grpThanhToan";

            this.grpThanhToan.Size =
                new System.Drawing.Size(370, 350);

            this.grpThanhToan.TabStop =
                false;

            this.grpThanhToan.Text =
                "Thanh toán và thao tác";

            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize =
                true;

            this.lblTongTien.Location =
                new System.Drawing.Point(18, 30);

            this.lblTongTien.Name =
                "lblTongTien";

            this.lblTongTien.Text =
                "Tổng tiền";

            // 
            // lblTongTienValue
            // 
            this.lblTongTienValue.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTongTienValue.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTongTienValue.Location =
                new System.Drawing.Point(120, 25);

            this.lblTongTienValue.Name =
                "lblTongTienValue";

            this.lblTongTienValue.Size =
                new System.Drawing.Size(225, 35);

            this.lblTongTienValue.Text =
                "0 ₫";

            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.AutoSize =
                true;

            this.lblPhuongThuc.Location =
                new System.Drawing.Point(18, 80);

            this.lblPhuongThuc.Name =
                "lblPhuongThuc";

            this.lblPhuongThuc.Text =
                "Phương thức";

            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboPhuongThuc.Location =
                new System.Drawing.Point(120, 76);

            this.cboPhuongThuc.Name =
                "cboPhuongThuc";

            this.cboPhuongThuc.Size =
                new System.Drawing.Size(225, 23);

            // 
            // btnDangKy
            // 
            this.btnDangKy.Location =
                new System.Drawing.Point(20, 125);

            this.btnDangKy.Name =
                "btnDangKy";

            this.btnDangKy.Size =
                new System.Drawing.Size(100, 35);

            this.btnDangKy.Text =
                "Đăng ký";

            this.btnDangKy.UseVisualStyleBackColor =
                true;

            this.btnDangKy.Click +=
                new System.EventHandler(
                    this.btnDangKy_Click
                );

            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location =
                new System.Drawing.Point(135, 125);

            this.btnThanhToan.Name =
                "btnThanhToan";

            this.btnThanhToan.Size =
                new System.Drawing.Size(100, 35);

            this.btnThanhToan.Text =
                "Thanh toán";

            this.btnThanhToan.UseVisualStyleBackColor =
                true;

            this.btnThanhToan.Click +=
                new System.EventHandler(
                    this.btnThanhToan_Click
                );

            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location =
                new System.Drawing.Point(250, 125);

            this.btnGiaHan.Name =
                "btnGiaHan";

            this.btnGiaHan.Size =
                new System.Drawing.Size(100, 35);

            this.btnGiaHan.Text =
                "Gia hạn";

            this.btnGiaHan.UseVisualStyleBackColor =
                true;

            this.btnGiaHan.Click +=
                new System.EventHandler(
                    this.btnGiaHan_Click
                );

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location =
                new System.Drawing.Point(75, 180);

            this.btnLamMoi.Name =
                "btnLamMoi";

            this.btnLamMoi.Size =
                new System.Drawing.Size(100, 35);

            this.btnLamMoi.Text =
                "Làm mới";

            this.btnLamMoi.UseVisualStyleBackColor =
                true;

            this.btnLamMoi.Click +=
                new System.EventHandler(
                    this.btnLamMoi_Click
                );

            // 
            // btnThoat
            // 
            this.btnThoat.Location =
                new System.Drawing.Point(195, 180);

            this.btnThoat.Name =
                "btnThoat";

            this.btnThoat.Size =
                new System.Drawing.Size(100, 35);

            this.btnThoat.Text =
                "Thoát";

            this.btnThoat.UseVisualStyleBackColor =
                true;

            this.btnThoat.Click +=
                new System.EventHandler(
                    this.btnThoat_Click
                );

            // 
            // lblDanhSach
            // 
            this.lblDanhSach.AutoSize =
                true;

            this.lblDanhSach.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblDanhSach.Location =
                new System.Drawing.Point(20, 440);

            this.lblDanhSach.Name =
                "lblDanhSach";

            this.lblDanhSach.Text =
                "DANH SÁCH ĐĂNG KÝ VÉ THÁNG";

            // 
            // dgvDangKy
            // 
            this.dgvDangKy.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dgvDangKy.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvDangKy.Location =
                new System.Drawing.Point(20, 470);

            this.dgvDangKy.Name =
                "dgvDangKy";

            this.dgvDangKy.Size =
                new System.Drawing.Size(1120, 250);

            this.dgvDangKy.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvDangKy_CellClick
                );

            // 
            // frmDangKyVeThang
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1160, 740);

            this.Controls.Add(
                this.dgvDangKy
            );

            this.Controls.Add(
                this.lblDanhSach
            );

            this.Controls.Add(
                this.grpThanhToan
            );

            this.Controls.Add(
                this.grpVeThang
            );

            this.Controls.Add(
                this.grpKhachHang
            );

            this.Controls.Add(
                this.lblTieuDe
            );

            this.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F
                );

            this.MinimumSize =
                new System.Drawing.Size(1176, 779);

            this.Name =
                "frmDangKyVeThang";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text =
                "Đăng ký vé tháng";

            this.Load +=
                new System.EventHandler(
                    this.frmDangKyVeThang_Load
                );

            this.grpKhachHang.ResumeLayout(false);
            this.grpKhachHang.PerformLayout();

            this.grpVeThang.ResumeLayout(false);
            this.grpVeThang.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.nudSoThang)).EndInit();

            this.grpThanhToan.ResumeLayout(false);
            this.grpThanhToan.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;

        private System.Windows.Forms.GroupBox grpKhachHang;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Button btnThemKhachHang;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblPhuongTien;
        private System.Windows.Forms.ComboBox cboPhuongTien;
        private System.Windows.Forms.Button btnThemPhuongTien;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.TextBox txtLoaiXe;

        private System.Windows.Forms.GroupBox grpVeThang;
        private System.Windows.Forms.Label lblTheThang;
        private System.Windows.Forms.ComboBox cboTheThang;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Label lblSoThang;
        private System.Windows.Forms.NumericUpDown nudSoThang;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lblNgayKetThucValue;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblDonGiaValue;

        private System.Windows.Forms.GroupBox grpThanhToan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTongTienValue;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.ComboBox cboPhuongThuc;

        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.Label lblDanhSach;
        private System.Windows.Forms.DataGridView dgvDangKy;
    }
}