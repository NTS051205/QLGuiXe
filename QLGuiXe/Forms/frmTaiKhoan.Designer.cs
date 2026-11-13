namespace QLGuiXe.Forms
{
    partial class frmTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
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
            this.lblMaTK = new System.Windows.Forms.Label();
            this.txtMaTK = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblXacNhan = new System.Windows.Forms.Label();
            this.txtXacNhan = new System.Windows.Forms.TextBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocVaiTro = new System.Windows.Forms.Label();
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();

            this.SuspendLayout();

            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI",
                16F,
                System.Drawing.FontStyle.Bold
            );
            this.lblTieuDe.Location =
                new System.Drawing.Point(20, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "QUẢN LÝ TÀI KHOẢN";

            // 
            // lblMaTK
            // 
            this.lblMaTK.AutoSize = true;
            this.lblMaTK.Location =
                new System.Drawing.Point(22, 60);
            this.lblMaTK.Name = "lblMaTK";
            this.lblMaTK.Text = "Mã tài khoản:";

            // 
            // txtMaTK
            // 
            this.txtMaTK.Location =
                new System.Drawing.Point(115, 56);
            this.txtMaTK.Name = "txtMaTK";
            this.txtMaTK.ReadOnly = true;
            this.txtMaTK.Size =
                new System.Drawing.Size(125, 23);

            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location =
                new System.Drawing.Point(265, 60);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Text = "Nhân viên:";

            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Location =
                new System.Drawing.Point(335, 56);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size =
                new System.Drawing.Size(210, 23);

            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location =
                new System.Drawing.Point(570, 60);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Text = "Tên đăng nhập:";

            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location =
                new System.Drawing.Point(665, 56);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size =
                new System.Drawing.Size(165, 23);

            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location =
                new System.Drawing.Point(855, 60);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Text = "Vai trò:";

            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Location =
                new System.Drawing.Point(910, 56);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size =
                new System.Drawing.Size(130, 23);

            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location =
                new System.Drawing.Point(22, 97);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu:";

            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location =
                new System.Drawing.Point(115, 93);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size =
                new System.Drawing.Size(180, 23);

            // 
            // lblXacNhan
            // 
            this.lblXacNhan.AutoSize = true;
            this.lblXacNhan.Location =
                new System.Drawing.Point(325, 97);
            this.lblXacNhan.Name = "lblXacNhan";
            this.lblXacNhan.Text = "Xác nhận mật khẩu:";

            // 
            // txtXacNhan
            // 
            this.txtXacNhan.Location =
                new System.Drawing.Point(450, 93);
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.PasswordChar = '*';
            this.txtXacNhan.Size =
                new System.Drawing.Size(180, 23);

            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location =
                new System.Drawing.Point(660, 97);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái:";

            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location =
                new System.Drawing.Point(735, 93);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size =
                new System.Drawing.Size(145, 23);

            // 
            // btnThem
            // 
            this.btnThem.Location =
                new System.Drawing.Point(25, 135);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size =
                new System.Drawing.Size(95, 34);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);

            // 
            // btnXem
            // 
            this.btnXem.Location =
                new System.Drawing.Point(130, 135);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size =
                new System.Drawing.Size(95, 34);
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click +=
                new System.EventHandler(this.btnXem_Click);

            // 
            // btnSua
            // 
            this.btnSua.Location =
                new System.Drawing.Point(235, 135);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size =
                new System.Drawing.Size(95, 34);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            // 
            // btnKhoa
            // 
            this.btnKhoa.Location =
                new System.Drawing.Point(340, 135);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size =
                new System.Drawing.Size(95, 34);
            this.btnKhoa.Text = "Khóa";
            this.btnKhoa.UseVisualStyleBackColor = true;
            this.btnKhoa.Click +=
                new System.EventHandler(this.btnKhoa_Click);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location =
                new System.Drawing.Point(445, 135);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size =
                new System.Drawing.Size(95, 34);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click +=
                new System.EventHandler(this.btnLamMoi_Click);

            // 
            // btnThoat
            // 
            this.btnThoat.Location =
                new System.Drawing.Point(550, 135);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size =
                new System.Drawing.Size(95, 34);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click +=
                new System.EventHandler(this.btnThoat_Click);

            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location =
                new System.Drawing.Point(22, 194);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Text = "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location =
                new System.Drawing.Point(95, 190);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size =
                new System.Drawing.Size(260, 23);
            this.txtTimKiem.TextChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // lblLocVaiTro
            // 
            this.lblLocVaiTro.AutoSize = true;
            this.lblLocVaiTro.Location =
                new System.Drawing.Point(380, 194);
            this.lblLocVaiTro.Name = "lblLocVaiTro";
            this.lblLocVaiTro.Text = "Vai trò:";

            // 
            // cboLocVaiTro
            // 
            this.cboLocVaiTro.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocVaiTro.Location =
                new System.Drawing.Point(435, 190);
            this.cboLocVaiTro.Name = "cboLocVaiTro";
            this.cboLocVaiTro.Size =
                new System.Drawing.Size(135, 23);
            this.cboLocVaiTro.SelectedIndexChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Location =
                new System.Drawing.Point(595, 194);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Text = "Trạng thái:";

            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Location =
                new System.Drawing.Point(670, 190);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size =
                new System.Drawing.Size(145, 23);
            this.cboLocTrangThai.SelectedIndexChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvTaiKhoan.Location =
                new System.Drawing.Point(25, 230);

            this.dgvTaiKhoan.Name = "dgvTaiKhoan";

            this.dgvTaiKhoan.Size =
                new System.Drawing.Size(1015, 365);

            this.dgvTaiKhoan.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvTaiKhoan_CellClick
                );

            // 
            // lblTongSo
            // 
            this.lblTongSo.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom |
                 System.Windows.Forms.AnchorStyles.Left));

            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Location =
                new System.Drawing.Point(22, 612);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Text = "Tổng số: 0 bản ghi";

            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1064, 641);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaTK);
            this.Controls.Add(this.txtMaTK);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.lblTenDangNhap);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.cboVaiTro);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblXacNhan);
            this.Controls.Add(this.txtXacNhan);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnKhoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblLocVaiTro);
            this.Controls.Add(this.cboLocVaiTro);
            this.Controls.Add(this.lblLocTrangThai);
            this.Controls.Add(this.cboLocTrangThai);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.lblTongSo);

            this.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.MinimumSize =
                new System.Drawing.Size(1080, 680);

            this.Name = "frmTaiKhoan";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Quản lý tài khoản";

            this.Load +=
                new System.EventHandler(this.frmTaiKhoan_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaTK;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblXacNhan;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblLocVaiTro;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.Label lblTongSo;

        private System.Windows.Forms.TextBox txtMaTK;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtXacNhan;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.ComboBox cboLocVaiTro;
        private System.Windows.Forms.ComboBox cboLocTrangThai;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.DataGridView dgvTaiKhoan;
    }
}