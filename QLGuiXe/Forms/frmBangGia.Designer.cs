namespace QLGuiXe.Forms
{
    partial class frmBangGia
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
            this.lblMaBangGia = new System.Windows.Forms.Label();
            this.txtMaBangGia = new System.Windows.Forms.TextBox();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblLoaiVe = new System.Windows.Forms.Label();
            this.cboLoaiVe = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.nudDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblGiaSau19Gio = new System.Windows.Forms.Label();
            this.nudGiaSau19Gio = new System.Windows.Forms.NumericUpDown();
            this.lblGiaQuaDem = new System.Windows.Forms.Label();
            this.nudGiaQuaDem = new System.Windows.Forms.NumericUpDown();
            this.lblNgayApDung = new System.Windows.Forms.Label();
            this.dtpNgayApDung = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocLoaiXe = new System.Windows.Forms.Label();
            this.cboLocLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblLocLoaiVe = new System.Windows.Forms.Label();
            this.cboLocLoaiVe = new System.Windows.Forms.ComboBox();
            this.dgvBangGia = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.nudDonGia)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.nudGiaSau19Gio)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.nudGiaQuaDem)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvBangGia)).BeginInit();

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
            this.lblTieuDe.Text = "QUẢN LÝ BẢNG GIÁ";

            // 
            // lblMaBangGia
            // 
            this.lblMaBangGia.AutoSize = true;
            this.lblMaBangGia.Location =
                new System.Drawing.Point(22, 70);
            this.lblMaBangGia.Name = "lblMaBangGia";
            this.lblMaBangGia.Text = "Mã bảng giá:";

            // 
            // txtMaBangGia
            // 
            this.txtMaBangGia.Location =
                new System.Drawing.Point(110, 66);
            this.txtMaBangGia.Name = "txtMaBangGia";
            this.txtMaBangGia.ReadOnly = true;
            this.txtMaBangGia.Size =
                new System.Drawing.Size(120, 23);

            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location =
                new System.Drawing.Point(255, 70);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Text = "Loại xe:";

            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.Location =
                new System.Drawing.Point(315, 66);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size =
                new System.Drawing.Size(125, 23);

            // 
            // lblLoaiVe
            // 
            this.lblLoaiVe.AutoSize = true;
            this.lblLoaiVe.Location =
                new System.Drawing.Point(465, 70);
            this.lblLoaiVe.Name = "lblLoaiVe";
            this.lblLoaiVe.Text = "Loại vé:";

            // 
            // cboLoaiVe
            // 
            this.cboLoaiVe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiVe.Location =
                new System.Drawing.Point(525, 66);
            this.cboLoaiVe.Name = "cboLoaiVe";
            this.cboLoaiVe.Size =
                new System.Drawing.Size(125, 23);
            this.cboLoaiVe.SelectedIndexChanged +=
                new System.EventHandler(
                    this.CapNhatLoaiGia
                );

            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location =
                new System.Drawing.Point(675, 70);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Text = "Đơn giá:";

            // 
            // nudDonGia
            // 
            this.nudDonGia.Increment = 1000;
            this.nudDonGia.Location =
                new System.Drawing.Point(735, 66);
            this.nudDonGia.Maximum = 1000000000;
            this.nudDonGia.Name = "nudDonGia";
            this.nudDonGia.Size =
                new System.Drawing.Size(130, 23);
            this.nudDonGia.ThousandsSeparator = true;

            // 
            // lblNgayApDung
            // 
            this.lblNgayApDung.AutoSize = true;
            this.lblNgayApDung.Location =
                new System.Drawing.Point(885, 70);
            this.lblNgayApDung.Name = "lblNgayApDung";
            this.lblNgayApDung.Text = "Ngày áp dụng:";

            // 
            // dtpNgayApDung
            // 
            this.dtpNgayApDung.CustomFormat =
                "dd/MM/yyyy";
            this.dtpNgayApDung.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayApDung.Location =
                new System.Drawing.Point(970, 66);
            this.dtpNgayApDung.Name = "dtpNgayApDung";
            this.dtpNgayApDung.Size =
                new System.Drawing.Size(100, 23);

            // 
            // lblGiaSau19Gio
            // 
            this.lblGiaSau19Gio.AutoSize = true;
            this.lblGiaSau19Gio.Location =
                new System.Drawing.Point(570, 120);
            this.lblGiaSau19Gio.Name = "lblGiaSau19Gio";
            this.lblGiaSau19Gio.Text = "Giá sau 19 giờ:";

            // 
            // nudGiaSau19Gio
            // 
            this.nudGiaSau19Gio.Increment = 1000;
            this.nudGiaSau19Gio.Location =
                new System.Drawing.Point(670, 116);
            this.nudGiaSau19Gio.Maximum = 1000000000;
            this.nudGiaSau19Gio.Name = "nudGiaSau19Gio";
            this.nudGiaSau19Gio.Size =
                new System.Drawing.Size(130, 23);
            this.nudGiaSau19Gio.ThousandsSeparator = true;

            // 
            // lblGiaQuaDem
            // 
            this.lblGiaQuaDem.AutoSize = true;
            this.lblGiaQuaDem.Location =
                new System.Drawing.Point(820, 120);
            this.lblGiaQuaDem.Name = "lblGiaQuaDem";
            this.lblGiaQuaDem.Text = "Giá qua đêm:";

            // 
            // nudGiaQuaDem
            // 
            this.nudGiaQuaDem.Increment = 1000;
            this.nudGiaQuaDem.Location =
                new System.Drawing.Point(910, 116);
            this.nudGiaQuaDem.Maximum = 1000000000;
            this.nudGiaQuaDem.Name = "nudGiaQuaDem";
            this.nudGiaQuaDem.Size =
                new System.Drawing.Size(130, 23);
            this.nudGiaQuaDem.ThousandsSeparator = true;

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
            this.btnXem.UseVisualStyleBackColor = true;
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
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click +=
                new System.EventHandler(
                    this.btnSua_Click
                );

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location =
                new System.Drawing.Point(340, 110);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size =
                new System.Drawing.Size(95, 34);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click +=
                new System.EventHandler(
                    this.btnLamMoi_Click
                );

            // 
            // btnThoat
            // 
            this.btnThoat.Location =
                new System.Drawing.Point(445, 110);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size =
                new System.Drawing.Size(95, 34);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
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
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Text = "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location =
                new System.Drawing.Point(95, 165);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size =
                new System.Drawing.Size(240, 23);
            this.txtTimKiem.TextChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // lblLocLoaiXe
            // 
            this.lblLocLoaiXe.AutoSize = true;
            this.lblLocLoaiXe.Location =
                new System.Drawing.Point(360, 169);
            this.lblLocLoaiXe.Name = "lblLocLoaiXe";
            this.lblLocLoaiXe.Text = "Loại xe:";

            // 
            // cboLocLoaiXe
            // 
            this.cboLocLoaiXe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiXe.Location =
                new System.Drawing.Point(420, 165);
            this.cboLocLoaiXe.Name = "cboLocLoaiXe";
            this.cboLocLoaiXe.Size =
                new System.Drawing.Size(130, 23);
            this.cboLocLoaiXe.SelectedIndexChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // lblLocLoaiVe
            // 
            this.lblLocLoaiVe.AutoSize = true;
            this.lblLocLoaiVe.Location =
                new System.Drawing.Point(575, 169);
            this.lblLocLoaiVe.Name = "lblLocLoaiVe";
            this.lblLocLoaiVe.Text = "Loại vé:";

            // 
            // cboLocLoaiVe
            // 
            this.cboLocLoaiVe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiVe.Location =
                new System.Drawing.Point(635, 165);
            this.cboLocLoaiVe.Name = "cboLocLoaiVe";
            this.cboLocLoaiVe.Size =
                new System.Drawing.Size(130, 23);
            this.cboLocLoaiVe.SelectedIndexChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // dgvBangGia
            // 
            this.dgvBangGia.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));

            this.dgvBangGia.ColumnHeadersHeightSizeMode =
                System.Windows.Forms
                .DataGridViewColumnHeadersHeightSizeMode
                .AutoSize;

            this.dgvBangGia.Location =
                new System.Drawing.Point(25, 205);

            this.dgvBangGia.Name = "dgvBangGia";

            this.dgvBangGia.Size =
                new System.Drawing.Size(1045, 390);

            this.dgvBangGia.CellClick +=
                new System.Windows.Forms
                .DataGridViewCellEventHandler(
                    this.dgvBangGia_CellClick
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
            // frmBangGia
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1094, 641);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaBangGia);
            this.Controls.Add(this.txtMaBangGia);
            this.Controls.Add(this.lblLoaiXe);
            this.Controls.Add(this.cboLoaiXe);
            this.Controls.Add(this.lblLoaiVe);
            this.Controls.Add(this.cboLoaiVe);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.nudDonGia);
            this.Controls.Add(this.lblGiaSau19Gio);
            this.Controls.Add(this.nudGiaSau19Gio);
            this.Controls.Add(this.lblGiaQuaDem);
            this.Controls.Add(this.nudGiaQuaDem);
            this.Controls.Add(this.lblNgayApDung);
            this.Controls.Add(this.dtpNgayApDung);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblLocLoaiXe);
            this.Controls.Add(this.cboLocLoaiXe);
            this.Controls.Add(this.lblLocLoaiVe);
            this.Controls.Add(this.cboLocLoaiVe);
            this.Controls.Add(this.dgvBangGia);
            this.Controls.Add(this.lblTongSo);

            this.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.MinimumSize =
                new System.Drawing.Size(1110, 680);

            this.Name = "frmBangGia";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Quản lý bảng giá";

            this.Load +=
                new System.EventHandler(
                    this.frmBangGia_Load
                );

            ((System.ComponentModel.ISupportInitialize)
                (this.nudDonGia)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.nudGiaSau19Gio)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.nudGiaQuaDem)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvBangGia)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaBangGia;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.Label lblLoaiVe;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblGiaSau19Gio;
        private System.Windows.Forms.Label lblGiaQuaDem;
        private System.Windows.Forms.Label lblNgayApDung;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblLocLoaiXe;
        private System.Windows.Forms.Label lblLocLoaiVe;
        private System.Windows.Forms.Label lblTongSo;

        private System.Windows.Forms.TextBox txtMaBangGia;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.ComboBox cboLoaiVe;
        private System.Windows.Forms.ComboBox cboLocLoaiXe;
        private System.Windows.Forms.ComboBox cboLocLoaiVe;

        private System.Windows.Forms.NumericUpDown nudDonGia;
        private System.Windows.Forms.NumericUpDown nudGiaSau19Gio;
        private System.Windows.Forms.NumericUpDown nudGiaQuaDem;

        private System.Windows.Forms.DateTimePicker dtpNgayApDung;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.DataGridView dgvBangGia;
    }
}