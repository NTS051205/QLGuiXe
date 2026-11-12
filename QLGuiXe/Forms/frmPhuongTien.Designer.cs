namespace QLGuiXe.Forms
{
    partial class frmPhuongTien
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
            this.lblMaPT = new System.Windows.Forms.Label();
            this.txtMaPT = new System.Windows.Forms.TextBox();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocLoaiXe = new System.Windows.Forms.Label();
            this.cboLocLoaiXe = new System.Windows.Forms.ComboBox();
            this.dgvPhuongTien = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuongTien)).BeginInit();
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

            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(257, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ PHƯƠNG TIỆN";

            // 
            // lblMaPT
            // 
            this.lblMaPT.AutoSize = true;
            this.lblMaPT.Location = new System.Drawing.Point(22, 70);
            this.lblMaPT.Name = "lblMaPT";
            this.lblMaPT.Size = new System.Drawing.Size(97, 15);
            this.lblMaPT.TabIndex = 1;
            this.lblMaPT.Text = "Mã phương tiện:";

            // 
            // txtMaPT
            // 
            this.txtMaPT.Location = new System.Drawing.Point(125, 66);
            this.txtMaPT.Name = "txtMaPT";
            this.txtMaPT.ReadOnly = true;
            this.txtMaPT.Size = new System.Drawing.Size(135, 23);
            this.txtMaPT.TabIndex = 2;

            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Location = new System.Drawing.Point(285, 70);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(46, 15);
            this.lblBienSo.TabIndex = 3;
            this.lblBienSo.Text = "Biển số:";

            // 
            // txtBienSo
            // 
            this.txtBienSo.CharacterCasing =
                System.Windows.Forms.CharacterCasing.Upper;

            this.txtBienSo.Location = new System.Drawing.Point(345, 66);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(160, 23);
            this.txtBienSo.TabIndex = 4;

            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location = new System.Drawing.Point(530, 70);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Size = new System.Drawing.Size(47, 15);
            this.lblLoaiXe.TabIndex = 5;
            this.lblLoaiXe.Text = "Loại xe:";

            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboLoaiXe.FormattingEnabled = true;
            this.cboLoaiXe.Location = new System.Drawing.Point(590, 66);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size = new System.Drawing.Size(130, 23);
            this.cboLoaiXe.TabIndex = 6;

            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(745, 70);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(75, 15);
            this.lblKhachHang.TabIndex = 7;
            this.lblKhachHang.Text = "Khách hàng:";

            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(825, 66);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(215, 23);
            this.cboKhachHang.TabIndex = 8;

            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(25, 110);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 34);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);

            // 
            // btnLichSu
            // 
            this.btnLichSu.Location = new System.Drawing.Point(130, 110);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(110, 34);
            this.btnLichSu.TabIndex = 10;
            this.btnLichSu.Text = "Xem lịch sử";
            this.btnLichSu.UseVisualStyleBackColor = true;
            this.btnLichSu.Click +=
                new System.EventHandler(this.btnLichSu_Click);

            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(250, 110);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 34);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(355, 110);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 34);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click +=
                new System.EventHandler(this.btnLamMoi_Click);

            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(460, 110);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(95, 34);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click +=
                new System.EventHandler(this.btnThoat_Click);

            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(22, 169);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(59, 15);
            this.lblTimKiem.TabIndex = 14;
            this.lblTimKiem.Text = "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(95, 165);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 23);
            this.txtTimKiem.TabIndex = 15;
            this.txtTimKiem.TextChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // lblLocLoaiXe
            // 
            this.lblLocLoaiXe.AutoSize = true;
            this.lblLocLoaiXe.Location = new System.Drawing.Point(400, 169);
            this.lblLocLoaiXe.Name = "lblLocLoaiXe";
            this.lblLocLoaiXe.Size = new System.Drawing.Size(47, 15);
            this.lblLocLoaiXe.TabIndex = 16;
            this.lblLocLoaiXe.Text = "Loại xe:";

            // 
            // cboLocLoaiXe
            // 
            this.cboLocLoaiXe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboLocLoaiXe.FormattingEnabled = true;
            this.cboLocLoaiXe.Location = new System.Drawing.Point(460, 165);
            this.cboLocLoaiXe.Name = "cboLocLoaiXe";
            this.cboLocLoaiXe.Size = new System.Drawing.Size(140, 23);
            this.cboLocLoaiXe.TabIndex = 17;
            this.cboLocLoaiXe.SelectedIndexChanged +=
                new System.EventHandler(this.LocDanhSach);

            // 
            // dgvPhuongTien
            // 
            this.dgvPhuongTien.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dgvPhuongTien.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvPhuongTien.Location =
                new System.Drawing.Point(25, 205);

            this.dgvPhuongTien.Name =
                "dgvPhuongTien";

            this.dgvPhuongTien.Size =
                new System.Drawing.Size(1015, 390);

            this.dgvPhuongTien.TabIndex = 18;

            this.dgvPhuongTien.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvPhuongTien_CellClick
                );

            // 
            // lblTongSo
            // 
            this.lblTongSo.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom |
                  System.Windows.Forms.AnchorStyles.Left)));

            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Location = new System.Drawing.Point(22, 612);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(123, 15);
            this.lblTongSo.TabIndex = 19;
            this.lblTongSo.Text = "Tổng số: 0 bản ghi";

            // 
            // frmPhuongTien
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1064, 641);

            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.dgvPhuongTien);
            this.Controls.Add(this.cboLocLoaiXe);
            this.Controls.Add(this.lblLocLoaiXe);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLichSu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboKhachHang);
            this.Controls.Add(this.lblKhachHang);
            this.Controls.Add(this.cboLoaiXe);
            this.Controls.Add(this.lblLoaiXe);
            this.Controls.Add(this.txtBienSo);
            this.Controls.Add(this.lblBienSo);
            this.Controls.Add(this.txtMaPT);
            this.Controls.Add(this.lblMaPT);
            this.Controls.Add(this.lblTieuDe);

            this.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F
                );

            this.MinimumSize =
                new System.Drawing.Size(1080, 680);

            this.Name =
                "frmPhuongTien";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text =
                "Quản lý phương tiện";

            this.Load +=
                new System.EventHandler(
                    this.frmPhuongTien_Load
                );

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuongTien)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaPT;
        private System.Windows.Forms.TextBox txtMaPT;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLichSu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocLoaiXe;
        private System.Windows.Forms.ComboBox cboLocLoaiXe;
        private System.Windows.Forms.DataGridView dgvPhuongTien;
        private System.Windows.Forms.Label lblTongSo;
    }
}