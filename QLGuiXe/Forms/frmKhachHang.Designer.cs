namespace QLGuiXe.Forms
{
    partial class frmKhachHang
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
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();

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

            this.lblTieuDe.Name =
                "lblTieuDe";

            this.lblTieuDe.Size =
                new System.Drawing.Size(260, 30);

            this.lblTieuDe.TabIndex =
                0;

            this.lblTieuDe.Text =
                "QUẢN LÝ KHÁCH HÀNG";

            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize =
                true;

            this.lblMaKH.Location =
                new System.Drawing.Point(22, 70);

            this.lblMaKH.Name =
                "lblMaKH";

            this.lblMaKH.Size =
                new System.Drawing.Size(97, 15);

            this.lblMaKH.TabIndex =
                1;

            this.lblMaKH.Text =
                "Mã khách hàng:";

            // 
            // txtMaKH
            // 
            this.txtMaKH.Location =
                new System.Drawing.Point(125, 66);

            this.txtMaKH.Name =
                "txtMaKH";

            this.txtMaKH.ReadOnly =
                true;

            this.txtMaKH.Size =
                new System.Drawing.Size(140, 23);

            this.txtMaKH.TabIndex =
                2;

            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize =
                true;

            this.lblHoTen.Location =
                new System.Drawing.Point(300, 70);

            this.lblHoTen.Name =
                "lblHoTen";

            this.lblHoTen.Size =
                new System.Drawing.Size(43, 15);

            this.lblHoTen.TabIndex =
                3;

            this.lblHoTen.Text =
                "Họ tên:";

            // 
            // txtHoTen
            // 
            this.txtHoTen.Location =
                new System.Drawing.Point(355, 66);

            this.txtHoTen.Name =
                "txtHoTen";

            this.txtHoTen.Size =
                new System.Drawing.Size(260, 23);

            this.txtHoTen.TabIndex =
                4;

            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize =
                true;

            this.lblSoDienThoai.Location =
                new System.Drawing.Point(650, 70);

            this.lblSoDienThoai.Name =
                "lblSoDienThoai";

            this.lblSoDienThoai.Size =
                new System.Drawing.Size(79, 15);

            this.lblSoDienThoai.TabIndex =
                5;

            this.lblSoDienThoai.Text =
                "Số điện thoại:";

            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location =
                new System.Drawing.Point(740, 66);

            this.txtSoDienThoai.Name =
                "txtSoDienThoai";

            this.txtSoDienThoai.Size =
                new System.Drawing.Size(180, 23);

            this.txtSoDienThoai.TabIndex =
                6;

            // 
            // btnThem
            // 
            this.btnThem.Location =
                new System.Drawing.Point(25, 110);

            this.btnThem.Name =
                "btnThem";

            this.btnThem.Size =
                new System.Drawing.Size(95, 34);

            this.btnThem.TabIndex =
                7;

            this.btnThem.Text =
                "Thêm";

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

            this.btnXem.Name =
                "btnXem";

            this.btnXem.Size =
                new System.Drawing.Size(95, 34);

            this.btnXem.TabIndex =
                8;

            this.btnXem.Text =
                "Xem";

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

            this.btnSua.Name =
                "btnSua";

            this.btnSua.Size =
                new System.Drawing.Size(95, 34);

            this.btnSua.TabIndex =
                9;

            this.btnSua.Text =
                "Sửa";

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

            this.btnXoa.Name =
                "btnXoa";

            this.btnXoa.Size =
                new System.Drawing.Size(95, 34);

            this.btnXoa.TabIndex =
                10;

            this.btnXoa.Text =
                "Xóa";

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

            this.btnLamMoi.TabIndex =
                11;

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

            this.btnThoat.Name =
                "btnThoat";

            this.btnThoat.Size =
                new System.Drawing.Size(95, 34);

            this.btnThoat.TabIndex =
                12;

            this.btnThoat.Text =
                "Thoát";

            this.btnThoat.UseVisualStyleBackColor =
                true;

            this.btnThoat.Click +=
                new System.EventHandler(
                    this.btnThoat_Click
                );

            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize =
                true;

            this.lblTimKiem.Location =
                new System.Drawing.Point(22, 169);

            this.lblTimKiem.Name =
                "lblTimKiem";

            this.lblTimKiem.Size =
                new System.Drawing.Size(59, 15);

            this.lblTimKiem.TabIndex =
                13;

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
                new System.Drawing.Size(330, 23);

            this.txtTimKiem.TabIndex =
                14;

            this.txtTimKiem.TextChanged +=
                new System.EventHandler(
                    this.LocDanhSach
                );

            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dgvKhachHang.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvKhachHang.Location =
                new System.Drawing.Point(25, 205);

            this.dgvKhachHang.Name =
                "dgvKhachHang";

            this.dgvKhachHang.Size =
                new System.Drawing.Size(1015, 390);

            this.dgvKhachHang.TabIndex =
                15;

            this.dgvKhachHang.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvKhachHang_CellClick
                );

            // 
            // lblTongSo
            // 
            this.lblTongSo.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom |
                  System.Windows.Forms.AnchorStyles.Left)));

            this.lblTongSo.AutoSize =
                true;

            this.lblTongSo.Location =
                new System.Drawing.Point(22, 612);

            this.lblTongSo.Name =
                "lblTongSo";

            this.lblTongSo.Size =
                new System.Drawing.Size(123, 15);

            this.lblTongSo.TabIndex =
                16;

            this.lblTongSo.Text =
                "Tổng số: 0 bản ghi";

            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1064, 641);

            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.lblTieuDe);

            this.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F
                );

            this.MinimumSize =
                new System.Drawing.Size(1080, 680);

            this.Name =
                "frmKhachHang";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text =
                "Quản lý khách hàng";

            this.Load +=
                new System.EventHandler(
                    this.frmKhachHang_Load
                );

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Label lblTongSo;
    }
}