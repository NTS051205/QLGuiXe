namespace QLGuiXe.Forms
{
    partial class frmCaLam
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaCa;
        private System.Windows.Forms.TextBox txtMaCa;
        private System.Windows.Forms.Label lblTenCa;
        private System.Windows.Forms.TextBox txtTenCa;
        private System.Windows.Forms.Label lblGioBatDau;
        private System.Windows.Forms.DateTimePicker dtpGioBatDau;
        private System.Windows.Forms.Label lblGioKetThuc;
        private System.Windows.Forms.DateTimePicker dtpGioKetThuc;
        private System.Windows.Forms.CheckBox chkQuaDem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvCaLam;
        private System.Windows.Forms.Label lblTongSo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaCa = new System.Windows.Forms.Label();
            this.txtMaCa = new System.Windows.Forms.TextBox();
            this.lblTenCa = new System.Windows.Forms.Label();
            this.txtTenCa = new System.Windows.Forms.TextBox();
            this.lblGioBatDau = new System.Windows.Forms.Label();
            this.dtpGioBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblGioKetThuc = new System.Windows.Forms.Label();
            this.dtpGioKetThuc = new System.Windows.Forms.DateTimePicker();
            this.chkQuaDem = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvCaLam = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(242, 37);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ CA LÀM";
            // 
            // lblMaCa
            // 
            this.lblMaCa.AutoSize = true;
            this.lblMaCa.Location = new System.Drawing.Point(22, 70);
            this.lblMaCa.Name = "lblMaCa";
            this.lblMaCa.Size = new System.Drawing.Size(52, 20);
            this.lblMaCa.TabIndex = 1;
            this.lblMaCa.Text = "Mã ca:";
            // 
            // txtMaCa
            // 
            this.txtMaCa.Location = new System.Drawing.Point(80, 66);
            this.txtMaCa.Name = "txtMaCa";
            this.txtMaCa.ReadOnly = true;
            this.txtMaCa.Size = new System.Drawing.Size(120, 27);
            this.txtMaCa.TabIndex = 2;
            // 
            // lblTenCa
            // 
            this.lblTenCa.AutoSize = true;
            this.lblTenCa.Location = new System.Drawing.Point(225, 70);
            this.lblTenCa.Name = "lblTenCa";
            this.lblTenCa.Size = new System.Drawing.Size(54, 20);
            this.lblTenCa.TabIndex = 3;
            this.lblTenCa.Text = "Tên ca:";
            // 
            // txtTenCa
            // 
            this.txtTenCa.Location = new System.Drawing.Point(280, 66);
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.Size = new System.Drawing.Size(200, 27);
            this.txtTenCa.TabIndex = 4;
            // 
            // lblGioBatDau
            // 
            this.lblGioBatDau.AutoSize = true;
            this.lblGioBatDau.Location = new System.Drawing.Point(505, 70);
            this.lblGioBatDau.Name = "lblGioBatDau";
            this.lblGioBatDau.Size = new System.Drawing.Size(90, 20);
            this.lblGioBatDau.TabIndex = 5;
            this.lblGioBatDau.Text = "Giờ bắt đầu:";
            // 
            // dtpGioBatDau
            // 
            this.dtpGioBatDau.Location = new System.Drawing.Point(590, 66);
            this.dtpGioBatDau.Name = "dtpGioBatDau";
            this.dtpGioBatDau.Size = new System.Drawing.Size(100, 27);
            this.dtpGioBatDau.TabIndex = 6;
            this.dtpGioBatDau.ValueChanged += new System.EventHandler(this.CapNhatQuaDem);
            // 
            // lblGioKetThuc
            // 
            this.lblGioKetThuc.AutoSize = true;
            this.lblGioKetThuc.Location = new System.Drawing.Point(715, 70);
            this.lblGioKetThuc.Name = "lblGioKetThuc";
            this.lblGioKetThuc.Size = new System.Drawing.Size(91, 20);
            this.lblGioKetThuc.TabIndex = 7;
            this.lblGioKetThuc.Text = "Giờ kết thúc:";
            // 
            // dtpGioKetThuc
            // 
            this.dtpGioKetThuc.Location = new System.Drawing.Point(805, 66);
            this.dtpGioKetThuc.Name = "dtpGioKetThuc";
            this.dtpGioKetThuc.Size = new System.Drawing.Size(100, 27);
            this.dtpGioKetThuc.TabIndex = 8;
            this.dtpGioKetThuc.ValueChanged += new System.EventHandler(this.CapNhatQuaDem);
            // 
            // chkQuaDem
            // 
            this.chkQuaDem.AutoSize = true;
            this.chkQuaDem.Enabled = false;
            this.chkQuaDem.Location = new System.Drawing.Point(930, 69);
            this.chkQuaDem.Name = "chkQuaDem";
            this.chkQuaDem.Size = new System.Drawing.Size(92, 24);
            this.chkQuaDem.TabIndex = 9;
            this.chkQuaDem.Text = "Qua đêm";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(25, 110);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 34);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(130, 110);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(95, 34);
            this.btnXem.TabIndex = 11;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(235, 110);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 34);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(340, 110);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 34);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(445, 110);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 34);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(550, 110);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(95, 34);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(22, 169);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(73, 20);
            this.lblTimKiem.TabIndex = 16;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(101, 166);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 27);
            this.txtTimKiem.TabIndex = 17;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.LocDanhSach);
            // 
            // dgvCaLam
            // 
            this.dgvCaLam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaLam.Location = new System.Drawing.Point(25, 205);
            this.dgvCaLam.Name = "dgvCaLam";
            this.dgvCaLam.RowHeadersWidth = 51;
            this.dgvCaLam.Size = new System.Drawing.Size(1015, 390);
            this.dgvCaLam.TabIndex = 18;
            this.dgvCaLam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaLam_CellClick);
            // 
            // lblTongSo
            // 
            this.lblTongSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Location = new System.Drawing.Point(22, 612);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(131, 20);
            this.lblTongSo.TabIndex = 19;
            this.lblTongSo.Text = "Tổng số: 0 bản ghi";
            // 
            // frmCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 641);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaCa);
            this.Controls.Add(this.txtMaCa);
            this.Controls.Add(this.lblTenCa);
            this.Controls.Add(this.txtTenCa);
            this.Controls.Add(this.lblGioBatDau);
            this.Controls.Add(this.dtpGioBatDau);
            this.Controls.Add(this.lblGioKetThuc);
            this.Controls.Add(this.dtpGioKetThuc);
            this.Controls.Add(this.chkQuaDem);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dgvCaLam);
            this.Controls.Add(this.lblTongSo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1080, 680);
            this.Name = "frmCaLam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý ca làm";
            this.Load += new System.EventHandler(this.frmCaLam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
