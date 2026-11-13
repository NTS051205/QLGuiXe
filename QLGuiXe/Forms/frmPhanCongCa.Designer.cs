namespace QLGuiXe.Forms
{
    partial class frmPhanCongCa
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
            this.lblMaPhanCong = new System.Windows.Forms.Label();
            this.txtMaPhanCong = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblCaLam = new System.Windows.Forms.Label();
            this.cboCaLam = new System.Windows.Forms.ComboBox();
            this.lblNgayLam = new System.Windows.Forms.Label();
            this.dtpNgayLam = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocNhanVien = new System.Windows.Forms.Label();
            this.cboLocNhanVien = new System.Windows.Forms.ComboBox();
            this.lblLocCaLam = new System.Windows.Forms.Label();
            this.cboLocCaLam = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dgvPhanCong = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).BeginInit();

            this.SuspendLayout();

            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    16F,
                    System.Drawing.FontStyle.Bold
                );
            this.lblTieuDe.Location =
                new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "PHÂN CÔNG CA";

            // 
            // lblMaPhanCong
            // 
            this.lblMaPhanCong.AutoSize = true;
            this.lblMaPhanCong.Location =
                new System.Drawing.Point(22, 70);
            this.lblMaPhanCong.Name =
                "lblMaPhanCong";
            this.lblMaPhanCong.Text =
                "Mã phân công:";

            // 
            // txtMaPhanCong
            // 
            this.txtMaPhanCong.Location =
                new System.Drawing.Point(120, 66);
            this.txtMaPhanCong.Name =
                "txtMaPhanCong";
            this.txtMaPhanCong.ReadOnly = true;
            this.txtMaPhanCong.Size =
                new System.Drawing.Size(130, 23);

            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location =
                new System.Drawing.Point(275, 70);
            this.lblNhanVien.Name =
                "lblNhanVien";
            this.lblNhanVien.Text =
                "Nhân viên:";

            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Location =
                new System.Drawing.Point(345, 66);
            this.cboNhanVien.Name =
                "cboNhanVien";
            this.cboNhanVien.Size =
                new System.Drawing.Size(210, 23);

            // 
            // lblCaLam
            // 
            this.lblCaLam.AutoSize = true;
            this.lblCaLam.Location =
                new System.Drawing.Point(580, 70);
            this.lblCaLam.Name = "lblCaLam";
            this.lblCaLam.Text = "Ca làm:";

            // 
            // cboCaLam
            // 
            this.cboCaLam.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaLam.Location =
                new System.Drawing.Point(635, 66);
            this.cboCaLam.Name = "cboCaLam";
            this.cboCaLam.Size =
                new System.Drawing.Size(160, 23);

            // 
            // lblNgayLam
            // 
            this.lblNgayLam.AutoSize = true;
            this.lblNgayLam.Location =
                new System.Drawing.Point(820, 70);
            this.lblNgayLam.Name = "lblNgayLam";
            this.lblNgayLam.Text = "Ngày làm:";

            // 
            // dtpNgayLam
            // 
            this.dtpNgayLam.CustomFormat =
                "dd/MM/yyyy";
            this.dtpNgayLam.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLam.Location =
                new System.Drawing.Point(885, 66);
            this.dtpNgayLam.Name = "dtpNgayLam";
            this.dtpNgayLam.Size =
                new System.Drawing.Size(120, 23);

            // 
            // btnThem
            // 
            this.btnThem.Location =
                new System.Drawing.Point(25, 110);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size =
                new System.Drawing.Size(95, 34);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor =
                true;
            this.btnThem.Click +=
                new System.EventHandler(
                    this.btnThem_Click
                );

            // 
            // btnXem
            // 
            this.btnXem.Location =
                new System.Drawing.Point(130, 110);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size =
                new System.Drawing.Size(95, 34);
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor =
                true;
            this.btnXem.Click +=
                new System.EventHandler(
                    this.btnXem_Click
                );

            // 
            // btnSua
            // 
            this.btnSua.Location =
                new System.Drawing.Point(235, 110);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size =
                new System.Drawing.Size(95, 34);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor =
                true;
            this.btnSua.Click +=
                new System.EventHandler(
                    this.btnSua_Click
                );

            // 
            // btnXoa
            // 
            this.btnXoa.Location =
                new System.Drawing.Point(340, 110);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size =
                new System.Drawing.Size(95, 34);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor =
                true;
            this.btnXoa.Click +=
                new System.EventHandler(
                    this.btnXoa_Click
                );

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location =
                new System.Drawing.Point(445, 110);
            this.btnLamMoi.Name =
                "btnLamMoi";
            this.btnLamMoi.Size =
                new System.Drawing.Size(95, 34);
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
                new System.Drawing.Point(550, 110);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size =
                new System.Drawing.Size(95, 34);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor =
                true;
            this.btnThoat.Click +=
                new System.EventHandler(
                    this.btnThoat_Click
                );

            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location =
                new System.Drawing.Point(22, 169);
            this.lblTimKiem.Name =
                "lblTimKiem";
            this.lblTimKiem.Text =
                "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location =
                new System.Drawing.Point(95, 165);
            this.txtTimKiem.Name =
                "txtTimKiem";
            this.txtTimKiem.Size =
                new System.Drawing.Size(190, 23);
            this.txtTimKiem.TextChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // lblLocNhanVien
            // 
            this.lblLocNhanVien.AutoSize = true;
            this.lblLocNhanVien.Location =
                new System.Drawing.Point(305, 169);
            this.lblLocNhanVien.Name =
                "lblLocNhanVien";
            this.lblLocNhanVien.Text =
                "Nhân viên:";

            // 
            // cboLocNhanVien
            // 
            this.cboLocNhanVien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocNhanVien.Location =
                new System.Drawing.Point(375, 165);
            this.cboLocNhanVien.Name =
                "cboLocNhanVien";
            this.cboLocNhanVien.Size =
                new System.Drawing.Size(170, 23);
            this.cboLocNhanVien.SelectedIndexChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // lblLocCaLam
            // 
            this.lblLocCaLam.AutoSize = true;
            this.lblLocCaLam.Location =
                new System.Drawing.Point(565, 169);
            this.lblLocCaLam.Name =
                "lblLocCaLam";
            this.lblLocCaLam.Text =
                "Ca làm:";

            // 
            // cboLocCaLam
            // 
            this.cboLocCaLam.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocCaLam.Location =
                new System.Drawing.Point(620, 165);
            this.cboLocCaLam.Name =
                "cboLocCaLam";
            this.cboLocCaLam.Size =
                new System.Drawing.Size(130, 23);
            this.cboLocCaLam.SelectedIndexChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location =
                new System.Drawing.Point(770, 169);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Text = "Từ ngày:";

            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat =
                "dd/MM/yyyy";
            this.dtpTuNgay.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location =
                new System.Drawing.Point(830, 165);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size =
                new System.Drawing.Size(110, 23);
            this.dtpTuNgay.ValueChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location =
                new System.Drawing.Point(955, 169);
            this.lblDenNgay.Name =
                "lblDenNgay";
            this.lblDenNgay.Text = "Đến:";

            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat =
                "dd/MM/yyyy";
            this.dtpDenNgay.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location =
                new System.Drawing.Point(995, 165);
            this.dtpDenNgay.Name =
                "dtpDenNgay";
            this.dtpDenNgay.Size =
                new System.Drawing.Size(110, 23);
            this.dtpDenNgay.ValueChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // dgvPhanCong
            // 
            this.dgvPhanCong.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dgvPhanCong.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvPhanCong.Location =
                new System.Drawing.Point(25, 205);

            this.dgvPhanCong.Name =
                "dgvPhanCong";

            this.dgvPhanCong.Size =
                new System.Drawing.Size(1080, 390);

            this.dgvPhanCong.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvPhanCong_CellClick
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
            this.lblTongSo.Text =
                "Tổng số: 0 bản ghi";

            // 
            // frmPhanCongCa
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1129, 641);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaPhanCong);
            this.Controls.Add(this.txtMaPhanCong);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.lblCaLam);
            this.Controls.Add(this.cboCaLam);
            this.Controls.Add(this.lblNgayLam);
            this.Controls.Add(this.dtpNgayLam);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblLocNhanVien);
            this.Controls.Add(this.cboLocNhanVien);
            this.Controls.Add(this.lblLocCaLam);
            this.Controls.Add(this.cboLocCaLam);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dgvPhanCong);
            this.Controls.Add(this.lblTongSo);

            this.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F
                );

            this.MinimumSize =
                new System.Drawing.Size(1145, 680);

            this.Name = "frmPhanCongCa";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Phân công ca";

            this.Load +=
                new System.EventHandler(
                    this.frmPhanCongCa_Load
                );

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaPhanCong;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblCaLam;
        private System.Windows.Forms.Label lblNgayLam;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblLocNhanVien;
        private System.Windows.Forms.Label lblLocCaLam;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTongSo;

        private System.Windows.Forms.TextBox txtMaPhanCong;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.ComboBox cboCaLam;
        private System.Windows.Forms.ComboBox cboLocNhanVien;
        private System.Windows.Forms.ComboBox cboLocCaLam;

        private System.Windows.Forms.DateTimePicker dtpNgayLam;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.DataGridView dgvPhanCong;
    }
}