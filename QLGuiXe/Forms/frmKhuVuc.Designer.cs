namespace QLGuiXe.Forms
{
    partial class frmKhuVuc
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
            this.lblMaKhuVuc = new System.Windows.Forms.Label();
            this.txtMaKhuVuc = new System.Windows.Forms.TextBox();
            this.lblTenKhuVuc = new System.Windows.Forms.Label();
            this.txtTenKhuVuc = new System.Windows.Forms.TextBox();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblSucChua = new System.Windows.Forms.Label();
            this.nudSucChua = new System.Windows.Forms.NumericUpDown();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblDangGui = new System.Windows.Forms.Label();
            this.lblDangGuiValue = new System.Windows.Forms.Label();
            this.lblConTrong = new System.Windows.Forms.Label();
            this.lblConTrongValue = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocLoaiXe = new System.Windows.Forms.Label();
            this.cboLocLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.dgvKhuVuc = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudSucChua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).BeginInit();

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
            this.lblTieuDe.Text = "QUẢN LÝ KHU VỰC";

            // 
            // lblMaKhuVuc
            // 
            this.lblMaKhuVuc.AutoSize = true;
            this.lblMaKhuVuc.Location =
                new System.Drawing.Point(22, 70);
            this.lblMaKhuVuc.Name = "lblMaKhuVuc";
            this.lblMaKhuVuc.Text = "Mã khu vực:";

            // 
            // txtMaKhuVuc
            // 
            this.txtMaKhuVuc.Location =
                new System.Drawing.Point(105, 66);
            this.txtMaKhuVuc.Name = "txtMaKhuVuc";
            this.txtMaKhuVuc.Size =
                new System.Drawing.Size(120, 23);

            // 
            // lblTenKhuVuc
            // 
            this.lblTenKhuVuc.AutoSize = true;
            this.lblTenKhuVuc.Location =
                new System.Drawing.Point(245, 70);
            this.lblTenKhuVuc.Name = "lblTenKhuVuc";
            this.lblTenKhuVuc.Text = "Tên khu vực:";

            // 
            // txtTenKhuVuc
            // 
            this.txtTenKhuVuc.Location =
                new System.Drawing.Point(335, 66);
            this.txtTenKhuVuc.Name = "txtTenKhuVuc";
            this.txtTenKhuVuc.Size =
                new System.Drawing.Size(180, 23);

            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location =
                new System.Drawing.Point(535, 70);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Text = "Loại xe:";

            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.Location =
                new System.Drawing.Point(595, 66);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size =
                new System.Drawing.Size(120, 23);

            // 
            // lblSucChua
            // 
            this.lblSucChua.AutoSize = true;
            this.lblSucChua.Location =
                new System.Drawing.Point(735, 70);
            this.lblSucChua.Name = "lblSucChua";
            this.lblSucChua.Text = "Sức chứa:";

            // 
            // nudSucChua
            // 
            this.nudSucChua.Location =
                new System.Drawing.Point(800, 66);
            this.nudSucChua.Maximum =
                new decimal(new int[] { 10000, 0, 0, 0 });
            this.nudSucChua.Minimum =
                new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSucChua.Name = "nudSucChua";
            this.nudSucChua.Size =
                new System.Drawing.Size(90, 23);
            this.nudSucChua.Value =
                new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location =
                new System.Drawing.Point(910, 70);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái:";

            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location =
                new System.Drawing.Point(980, 66);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size =
                new System.Drawing.Size(120, 23);

            // 
            // lblDangGui
            // 
            this.lblDangGui.AutoSize = true;
            this.lblDangGui.Location =
                new System.Drawing.Point(25, 103);
            this.lblDangGui.Name = "lblDangGui";
            this.lblDangGui.Text = "Đang gửi:";

            // 
            // lblDangGuiValue
            // 
            this.lblDangGuiValue.AutoSize = true;
            this.lblDangGuiValue.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblDangGuiValue.Location =
                new System.Drawing.Point(90, 103);
            this.lblDangGuiValue.Name = "lblDangGuiValue";
            this.lblDangGuiValue.Text = "0";

            // 
            // lblConTrong
            // 
            this.lblConTrong.AutoSize = true;
            this.lblConTrong.Location =
                new System.Drawing.Point(135, 103);
            this.lblConTrong.Name = "lblConTrong";
            this.lblConTrong.Text = "Còn trống:";

            // 
            // lblConTrongValue
            // 
            this.lblConTrongValue.AutoSize = true;
            this.lblConTrongValue.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblConTrongValue.Location =
                new System.Drawing.Point(205, 103);
            this.lblConTrongValue.Name = "lblConTrongValue";
            this.lblConTrongValue.Text = "0";

            // 
            // btnThem
            // 
            this.btnThem.Location =
                new System.Drawing.Point(25, 130);
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
                new System.Drawing.Point(130, 130);
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
                new System.Drawing.Point(235, 130);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size =
                new System.Drawing.Size(95, 34);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location =
                new System.Drawing.Point(340, 130);
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
                new System.Drawing.Point(445, 130);
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
                new System.Drawing.Point(22, 189);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Text = "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location =
                new System.Drawing.Point(95, 185);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size =
                new System.Drawing.Size(240, 23);
            this.txtTimKiem.TextChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // lblLocLoaiXe
            // 
            this.lblLocLoaiXe.AutoSize = true;
            this.lblLocLoaiXe.Location =
                new System.Drawing.Point(360, 189);
            this.lblLocLoaiXe.Name = "lblLocLoaiXe";
            this.lblLocLoaiXe.Text = "Loại xe:";

            // 
            // cboLocLoaiXe
            // 
            this.cboLocLoaiXe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiXe.Location =
                new System.Drawing.Point(420, 185);
            this.cboLocLoaiXe.Name = "cboLocLoaiXe";
            this.cboLocLoaiXe.Size =
                new System.Drawing.Size(130, 23);
            this.cboLocLoaiXe.SelectedIndexChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Location =
                new System.Drawing.Point(575, 189);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Text = "Trạng thái:";

            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Location =
                new System.Drawing.Point(650, 185);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size =
                new System.Drawing.Size(145, 23);
            this.cboLocTrangThai.SelectedIndexChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // dgvKhuVuc
            // 
            this.dgvKhuVuc.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dgvKhuVuc.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvKhuVuc.Location =
                new System.Drawing.Point(25, 225);

            this.dgvKhuVuc.Name = "dgvKhuVuc";

            this.dgvKhuVuc.Size =
                new System.Drawing.Size(1075, 370);

            this.dgvKhuVuc.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvKhuVuc_CellClick
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
            // frmKhuVuc
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1124, 641);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaKhuVuc);
            this.Controls.Add(this.txtMaKhuVuc);
            this.Controls.Add(this.lblTenKhuVuc);
            this.Controls.Add(this.txtTenKhuVuc);
            this.Controls.Add(this.lblLoaiXe);
            this.Controls.Add(this.cboLoaiXe);
            this.Controls.Add(this.lblSucChua);
            this.Controls.Add(this.nudSucChua);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblDangGui);
            this.Controls.Add(this.lblDangGuiValue);
            this.Controls.Add(this.lblConTrong);
            this.Controls.Add(this.lblConTrongValue);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblLocLoaiXe);
            this.Controls.Add(this.cboLocLoaiXe);
            this.Controls.Add(this.lblLocTrangThai);
            this.Controls.Add(this.cboLocTrangThai);
            this.Controls.Add(this.dgvKhuVuc);
            this.Controls.Add(this.lblTongSo);

            this.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.MinimumSize =
                new System.Drawing.Size(1140, 680);

            this.Name = "frmKhuVuc";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Quản lý khu vực";

            this.Load +=
                new System.EventHandler(this.frmKhuVuc_Load);

            ((System.ComponentModel.ISupportInitialize)(this.nudSucChua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaKhuVuc;
        private System.Windows.Forms.Label lblTenKhuVuc;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.Label lblSucChua;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblDangGui;
        private System.Windows.Forms.Label lblDangGuiValue;
        private System.Windows.Forms.Label lblConTrong;
        private System.Windows.Forms.Label lblConTrongValue;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblLocLoaiXe;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.Label lblTongSo;

        private System.Windows.Forms.TextBox txtMaKhuVuc;
        private System.Windows.Forms.TextBox txtTenKhuVuc;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.ComboBox cboLocLoaiXe;
        private System.Windows.Forms.ComboBox cboLocTrangThai;

        private System.Windows.Forms.NumericUpDown nudSucChua;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.DataGridView dgvKhuVuc;
    }
}