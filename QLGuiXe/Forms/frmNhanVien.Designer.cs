namespace QLGuiXe.Forms
{
    partial class frmNhanVien
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnVoHieu = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();

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
                new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "QUẢN LÝ NHÂN VIÊN";

            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location =
                new System.Drawing.Point(22, 70);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Text = "Mã nhân viên:";

            // 
            // txtMaNV
            // 
            this.txtMaNV.Location =
                new System.Drawing.Point(115, 66);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size =
                new System.Drawing.Size(130, 23);

            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location =
                new System.Drawing.Point(270, 70);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Text = "Họ tên:";

            // 
            // txtHoTen
            // 
            this.txtHoTen.Location =
                new System.Drawing.Point(325, 66);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size =
                new System.Drawing.Size(230, 23);

            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location =
                new System.Drawing.Point(580, 70);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Text = "Số điện thoại:";

            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location =
                new System.Drawing.Point(670, 66);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size =
                new System.Drawing.Size(150, 23);

            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location =
                new System.Drawing.Point(840, 70);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái:";

            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location =
                new System.Drawing.Point(910, 66);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size =
                new System.Drawing.Size(130, 23);

            // 
            // btnThem
            // 
            this.btnThem.Location =
                new System.Drawing.Point(25, 110);
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
                new System.Drawing.Point(130, 110);
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
                new System.Drawing.Point(235, 110);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size =
                new System.Drawing.Size(95, 34);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            // 
            // btnVoHieu
            // 
            this.btnVoHieu.Location =
                new System.Drawing.Point(340, 110);
            this.btnVoHieu.Name = "btnVoHieu";
            this.btnVoHieu.Size =
                new System.Drawing.Size(110, 34);
            this.btnVoHieu.Text = "Vô hiệu hóa";
            this.btnVoHieu.UseVisualStyleBackColor = true;
            this.btnVoHieu.Click +=
                new System.EventHandler(this.btnVoHieu_Click);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location =
                new System.Drawing.Point(460, 110);
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
                new System.Drawing.Point(565, 110);
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
                new System.Drawing.Point(22, 169);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Text = "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location =
                new System.Drawing.Point(95, 165);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size =
                new System.Drawing.Size(280, 23);
            this.txtTimKiem.TextChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Location =
                new System.Drawing.Point(400, 169);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Text = "Trạng thái:";

            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Location =
                new System.Drawing.Point(475, 165);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size =
                new System.Drawing.Size(150, 23);
            this.cboLocTrangThai.SelectedIndexChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dgvNhanVien.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvNhanVien.Location =
                new System.Drawing.Point(25, 205);

            this.dgvNhanVien.Name = "dgvNhanVien";

            this.dgvNhanVien.Size =
                new System.Drawing.Size(1015, 390);

            this.dgvNhanVien.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvNhanVien_CellClick
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
            // frmNhanVien
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1064, 641);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnVoHieu);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblLocTrangThai);
            this.Controls.Add(this.cboLocTrangThai);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.lblTongSo);

            this.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.MinimumSize =
                new System.Drawing.Size(1080, 680);

            this.Name = "frmNhanVien";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Quản lý nhân viên";

            this.Load +=
                new System.EventHandler(this.frmNhanVien_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.Label lblTongSo;

        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnVoHieu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.DataGridView dgvNhanVien;
    }
}