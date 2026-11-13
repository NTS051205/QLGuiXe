namespace QLGuiXe.Forms
{
    partial class frmXeRa
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
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtBienSoHoacMaThe = new System.Windows.Forms.TextBox();
            this.btnTimKiemXe = new System.Windows.Forms.Button();
            this.btnLamMoiXeRa = new System.Windows.Forms.Button();
            this.lblTieuDeLuotGui = new System.Windows.Forms.Label();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.lblGiaTriBienSo = new System.Windows.Forms.Label();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.lblGiaTriLoaiXe = new System.Windows.Forms.Label();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.lblGiaTriMaThe = new System.Windows.Forms.Label();
            this.lblKhuVuc = new System.Windows.Forms.Label();
            this.lblGiaTriKhuVuc = new System.Windows.Forms.Label();
            this.lblThoiGianVao = new System.Windows.Forms.Label();
            this.lblGiaTriThoiGianVao = new System.Windows.Forms.Label();
            this.lblThoiGianRa = new System.Windows.Forms.Label();
            this.lblGiaTriThoiGianRa = new System.Windows.Forms.Label();
            this.lblThoiGianGui = new System.Windows.Forms.Label();
            this.lblGiaTriThoiGianGui = new System.Windows.Forms.Label();
            this.lblLoaiVe = new System.Windows.Forms.Label();
            this.lblGiaTriLoaiVe = new System.Windows.Forms.Label();
            this.lblTieuDeThanhToan = new System.Windows.Forms.Label();
            this.lblSoTienThanhToan = new System.Windows.Forms.Label();
            this.lblGiaTriSoTien = new System.Windows.Forms.Label();
            this.lblPhuongThucThanhToan = new System.Windows.Forms.Label();
            this.cboPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
            this.lblTrangThaiXuLy = new System.Windows.Forms.Label();
            this.btnXacNhanXeRa = new System.Windows.Forms.Button();
            this.btnThanhToanXeRa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblDanhSachXeDangGui = new System.Windows.Forms.Label();
            this.dgvXeDangGui = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvXeDangGui)).BeginInit();
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
            this.lblTieuDe.Size = new System.Drawing.Size(195, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "XÁC NHẬN XE RA";

            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(22, 50);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(329, 15);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text =
                "Tìm theo biển số hoặc mã thẻ, kiểm tra phí và xác nhận xe ra.";

            // 
            // txtBienSoHoacMaThe
            // 
            this.txtBienSoHoacMaThe.Font = new System.Drawing.Font(
                "Segoe UI",
                12F,
                System.Drawing.FontStyle.Bold
            );
            this.txtBienSoHoacMaThe.Location =
                new System.Drawing.Point(25, 85);
            this.txtBienSoHoacMaThe.Name = "txtBienSoHoacMaThe";
            this.txtBienSoHoacMaThe.Size =
                new System.Drawing.Size(300, 29);
            this.txtBienSoHoacMaThe.TabIndex = 2;

            // 
            // btnTimKiemXe
            // 
            this.btnTimKiemXe.Location =
                new System.Drawing.Point(340, 83);
            this.btnTimKiemXe.Name = "btnTimKiemXe";
            this.btnTimKiemXe.Size =
                new System.Drawing.Size(110, 34);
            this.btnTimKiemXe.TabIndex = 3;
            this.btnTimKiemXe.Text = "Tìm kiếm";
            this.btnTimKiemXe.UseVisualStyleBackColor = true;
            this.btnTimKiemXe.Click +=
                new System.EventHandler(this.btnTimKiemXe_Click);

            // 
            // btnLamMoiXeRa
            // 
            this.btnLamMoiXeRa.Location =
                new System.Drawing.Point(460, 83);
            this.btnLamMoiXeRa.Name = "btnLamMoiXeRa";
            this.btnLamMoiXeRa.Size =
                new System.Drawing.Size(100, 34);
            this.btnLamMoiXeRa.TabIndex = 4;
            this.btnLamMoiXeRa.Text = "Làm mới";
            this.btnLamMoiXeRa.UseVisualStyleBackColor = true;
            this.btnLamMoiXeRa.Click +=
                new System.EventHandler(this.btnLamMoiXeRa_Click);

            // 
            // lblTieuDeLuotGui
            // 
            this.lblTieuDeLuotGui.AutoSize = true;
            this.lblTieuDeLuotGui.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold
            );
            this.lblTieuDeLuotGui.Location =
                new System.Drawing.Point(22, 145);
            this.lblTieuDeLuotGui.Name = "lblTieuDeLuotGui";
            this.lblTieuDeLuotGui.Size =
                new System.Drawing.Size(170, 20);
            this.lblTieuDeLuotGui.TabIndex = 5;
            this.lblTieuDeLuotGui.Text = "THÔNG TIN LƯỢT GỬI";

            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Location =
                new System.Drawing.Point(25, 185);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size =
                new System.Drawing.Size(48, 15);
            this.lblBienSo.TabIndex = 6;
            this.lblBienSo.Text = "Biển số:";

            // 
            // lblGiaTriBienSo
            // 
            this.lblGiaTriBienSo.AutoSize = true;
            this.lblGiaTriBienSo.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriBienSo.Location =
                new System.Drawing.Point(125, 185);
            this.lblGiaTriBienSo.Name = "lblGiaTriBienSo";
            this.lblGiaTriBienSo.Size =
                new System.Drawing.Size(19, 15);
            this.lblGiaTriBienSo.TabIndex = 7;
            this.lblGiaTriBienSo.Text = "—";

            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location =
                new System.Drawing.Point(395, 185);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Size =
                new System.Drawing.Size(46, 15);
            this.lblLoaiXe.TabIndex = 8;
            this.lblLoaiXe.Text = "Loại xe:";

            // 
            // lblGiaTriLoaiXe
            // 
            this.lblGiaTriLoaiXe.AutoSize = true;
            this.lblGiaTriLoaiXe.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriLoaiXe.Location =
                new System.Drawing.Point(495, 185);
            this.lblGiaTriLoaiXe.Name = "lblGiaTriLoaiXe";
            this.lblGiaTriLoaiXe.Size =
                new System.Drawing.Size(19, 15);
            this.lblGiaTriLoaiXe.TabIndex = 9;
            this.lblGiaTriLoaiXe.Text = "—";

            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location =
                new System.Drawing.Point(25, 227);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size =
                new System.Drawing.Size(47, 15);
            this.lblMaThe.TabIndex = 10;
            this.lblMaThe.Text = "Mã thẻ:";

            // 
            // lblGiaTriMaThe
            // 
            this.lblGiaTriMaThe.AutoSize = true;
            this.lblGiaTriMaThe.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriMaThe.Location =
                new System.Drawing.Point(125, 227);
            this.lblGiaTriMaThe.Name = "lblGiaTriMaThe";
            this.lblGiaTriMaThe.Size =
                new System.Drawing.Size(19, 15);
            this.lblGiaTriMaThe.TabIndex = 11;
            this.lblGiaTriMaThe.Text = "—";

            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.AutoSize = true;
            this.lblKhuVuc.Location =
                new System.Drawing.Point(395, 227);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size =
                new System.Drawing.Size(53, 15);
            this.lblKhuVuc.TabIndex = 12;
            this.lblKhuVuc.Text = "Khu vực:";

            // 
            // lblGiaTriKhuVuc
            // 
            this.lblGiaTriKhuVuc.AutoSize = true;
            this.lblGiaTriKhuVuc.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriKhuVuc.Location =
                new System.Drawing.Point(495, 227);
            this.lblGiaTriKhuVuc.Name = "lblGiaTriKhuVuc";
            this.lblGiaTriKhuVuc.Size =
                new System.Drawing.Size(19, 15);
            this.lblGiaTriKhuVuc.TabIndex = 13;
            this.lblGiaTriKhuVuc.Text = "—";

            // 
            // lblThoiGianVao
            // 
            this.lblThoiGianVao.AutoSize = true;
            this.lblThoiGianVao.Location =
                new System.Drawing.Point(25, 269);
            this.lblThoiGianVao.Name = "lblThoiGianVao";
            this.lblThoiGianVao.Size =
                new System.Drawing.Size(82, 15);
            this.lblThoiGianVao.TabIndex = 14;
            this.lblThoiGianVao.Text = "Thời gian vào:";

            // 
            // lblGiaTriThoiGianVao
            // 
            this.lblGiaTriThoiGianVao.AutoSize = true;
            this.lblGiaTriThoiGianVao.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriThoiGianVao.Location =
                new System.Drawing.Point(125, 269);
            this.lblGiaTriThoiGianVao.Name =
                "lblGiaTriThoiGianVao";
            this.lblGiaTriThoiGianVao.Size =
                new System.Drawing.Size(19, 15);
            this.lblGiaTriThoiGianVao.TabIndex = 15;
            this.lblGiaTriThoiGianVao.Text = "—";

            // 
            // lblThoiGianRa
            // 
            this.lblThoiGianRa.AutoSize = true;
            this.lblThoiGianRa.Location =
                new System.Drawing.Point(395, 269);
            this.lblThoiGianRa.Name = "lblThoiGianRa";
            this.lblThoiGianRa.Size =
                new System.Drawing.Size(73, 15);
            this.lblThoiGianRa.TabIndex = 16;
            this.lblThoiGianRa.Text = "Thời gian ra:";

            // 
            // lblGiaTriThoiGianRa
            // 
            this.lblGiaTriThoiGianRa.AutoSize = true;
            this.lblGiaTriThoiGianRa.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriThoiGianRa.Location =
                new System.Drawing.Point(495, 269);
            this.lblGiaTriThoiGianRa.Name =
                "lblGiaTriThoiGianRa";
            this.lblGiaTriThoiGianRa.Size =
                new System.Drawing.Size(19, 15);
            this.lblGiaTriThoiGianRa.TabIndex = 17;
            this.lblGiaTriThoiGianRa.Text = "—";

            // 
            // lblThoiGianGui
            // 
            this.lblThoiGianGui.AutoSize = true;
            this.lblThoiGianGui.Location =
                new System.Drawing.Point(25, 311);
            this.lblThoiGianGui.Name = "lblThoiGianGui";
            this.lblThoiGianGui.Size =
                new System.Drawing.Size(80, 15);
            this.lblThoiGianGui.TabIndex = 18;
            this.lblThoiGianGui.Text = "Thời gian gửi:";

            // 
            // lblGiaTriThoiGianGui
            // 
            this.lblGiaTriThoiGianGui.AutoSize = true;
            this.lblGiaTriThoiGianGui.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriThoiGianGui.Location =
                new System.Drawing.Point(125, 311);
            this.lblGiaTriThoiGianGui.Name =
                "lblGiaTriThoiGianGui";
            this.lblGiaTriThoiGianGui.Size =
                new System.Drawing.Size(19, 15);
            this.lblGiaTriThoiGianGui.TabIndex = 19;
            this.lblGiaTriThoiGianGui.Text = "—";

            // 
            // lblLoaiVe
            // 
            this.lblLoaiVe.AutoSize = true;
            this.lblLoaiVe.Location =
                new System.Drawing.Point(395, 311);
            this.lblLoaiVe.Name = "lblLoaiVe";
            this.lblLoaiVe.Size =
                new System.Drawing.Size(47, 15);
            this.lblLoaiVe.TabIndex = 20;
            this.lblLoaiVe.Text = "Loại vé:";

            // 
            // lblGiaTriLoaiVe
            // 
            this.lblGiaTriLoaiVe.AutoSize = true;
            this.lblGiaTriLoaiVe.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriLoaiVe.Location =
                new System.Drawing.Point(495, 311);
            this.lblGiaTriLoaiVe.Name = "lblGiaTriLoaiVe";
            this.lblGiaTriLoaiVe.Size =
                new System.Drawing.Size(19, 15);
            this.lblGiaTriLoaiVe.TabIndex = 21;
            this.lblGiaTriLoaiVe.Text = "—";

            // 
            // lblTieuDeThanhToan
            // 
            this.lblTieuDeThanhToan.AutoSize = true;
            this.lblTieuDeThanhToan.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold
            );
            this.lblTieuDeThanhToan.Location =
                new System.Drawing.Point(25, 370);
            this.lblTieuDeThanhToan.Name =
                "lblTieuDeThanhToan";
            this.lblTieuDeThanhToan.Size =
                new System.Drawing.Size(109, 20);
            this.lblTieuDeThanhToan.TabIndex = 22;
            this.lblTieuDeThanhToan.Text = "THANH TOÁN";

            // 
            // lblSoTienThanhToan
            // 
            this.lblSoTienThanhToan.AutoSize = true;
            this.lblSoTienThanhToan.Location =
                new System.Drawing.Point(25, 410);
            this.lblSoTienThanhToan.Name =
                "lblSoTienThanhToan";
            this.lblSoTienThanhToan.Size =
                new System.Drawing.Size(46, 15);
            this.lblSoTienThanhToan.TabIndex = 23;
            this.lblSoTienThanhToan.Text = "Số tiền:";

            // 
            // lblGiaTriSoTien
            // 
            this.lblGiaTriSoTien.AutoSize = true;
            this.lblGiaTriSoTien.Font = new System.Drawing.Font(
                "Segoe UI",
                16F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriSoTien.Location =
                new System.Drawing.Point(90, 400);
            this.lblGiaTriSoTien.Name = "lblGiaTriSoTien";
            this.lblGiaTriSoTien.Size =
                new System.Drawing.Size(46, 30);
            this.lblGiaTriSoTien.TabIndex = 24;
            this.lblGiaTriSoTien.Text = "0 ₫";

            // 
            // lblPhuongThucThanhToan
            // 
            this.lblPhuongThucThanhToan.AutoSize = true;
            this.lblPhuongThucThanhToan.Location =
                new System.Drawing.Point(300, 410);
            this.lblPhuongThucThanhToan.Name =
                "lblPhuongThucThanhToan";
            this.lblPhuongThucThanhToan.Size =
                new System.Drawing.Size(79, 15);
            this.lblPhuongThucThanhToan.TabIndex = 25;
            this.lblPhuongThucThanhToan.Text = "Phương thức:";

            // 
            // cboPhuongThucThanhToan
            // 
            this.cboPhuongThucThanhToan.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThucThanhToan.Location =
                new System.Drawing.Point(390, 406);
            this.cboPhuongThucThanhToan.Name =
                "cboPhuongThucThanhToan";
            this.cboPhuongThucThanhToan.Size =
                new System.Drawing.Size(160, 23);
            this.cboPhuongThucThanhToan.TabIndex = 26;

            // 
            // lblTrangThaiXuLy
            // 
            this.lblTrangThaiXuLy.AutoSize = true;
            this.lblTrangThaiXuLy.Location =
                new System.Drawing.Point(25, 455);
            this.lblTrangThaiXuLy.Name = "lblTrangThaiXuLy";
            this.lblTrangThaiXuLy.Size =
                new System.Drawing.Size(202, 15);
            this.lblTrangThaiXuLy.TabIndex = 27;
            this.lblTrangThaiXuLy.Text =
                "Nhập biển số hoặc mã thẻ để tra cứu";

            // 
            // btnXacNhanXeRa
            // 
            this.btnXacNhanXeRa.Location =
                new System.Drawing.Point(25, 495);
            this.btnXacNhanXeRa.Name = "btnXacNhanXeRa";
            this.btnXacNhanXeRa.Size =
                new System.Drawing.Size(180, 42);
            this.btnXacNhanXeRa.TabIndex = 28;
            this.btnXacNhanXeRa.Text = "XÁC NHẬN XE RA";
            this.btnXacNhanXeRa.UseVisualStyleBackColor = true;
            this.btnXacNhanXeRa.Click +=
                new System.EventHandler(this.btnXacNhanXeRa_Click);

            // 
            // btnThanhToanXeRa
            // 
            this.btnThanhToanXeRa.Location =
                new System.Drawing.Point(220, 495);
            this.btnThanhToanXeRa.Name = "btnThanhToanXeRa";
            this.btnThanhToanXeRa.Size =
                new System.Drawing.Size(150, 42);
            this.btnThanhToanXeRa.TabIndex = 29;
            this.btnThanhToanXeRa.Text = "THANH TOÁN";
            this.btnThanhToanXeRa.UseVisualStyleBackColor = true;
            this.btnThanhToanXeRa.Click +=
                new System.EventHandler(this.btnThanhToanXeRa_Click);

            // 
            // btnThoat
            // 
            this.btnThoat.Location =
                new System.Drawing.Point(385, 495);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size =
                new System.Drawing.Size(110, 42);
            this.btnThoat.TabIndex = 30;
            this.btnThoat.Text = "Thoát / Quay lại";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click +=
                new System.EventHandler(this.btnThoat_Click);

            // 
            // lblDanhSachXeDangGui
            // 
            this.lblDanhSachXeDangGui.AutoSize = true;
            this.lblDanhSachXeDangGui.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold
            );
            this.lblDanhSachXeDangGui.Location =
                new System.Drawing.Point(25, 570);
            this.lblDanhSachXeDangGui.Name =
                "lblDanhSachXeDangGui";
            this.lblDanhSachXeDangGui.Size =
                new System.Drawing.Size(406, 20);
            this.lblDanhSachXeDangGui.TabIndex = 31;
            this.lblDanhSachXeDangGui.Text =
                "DANH SÁCH XE ĐANG GỬI - BẤM MỘT DÒNG ĐỂ CHỌN";

            // 
            // dgvXeDangGui
            // 
            this.dgvXeDangGui.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));

            this.dgvXeDangGui.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvXeDangGui.Location =
                new System.Drawing.Point(25, 600);

            this.dgvXeDangGui.Name = "dgvXeDangGui";

            this.dgvXeDangGui.Size =
                new System.Drawing.Size(1100, 210);

            this.dgvXeDangGui.TabIndex = 32;

            this.dgvXeDangGui.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvXeDangGui_CellClick
                );

            // 
            // frmXeRa
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1150, 781);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtBienSoHoacMaThe);
            this.Controls.Add(this.btnTimKiemXe);
            this.Controls.Add(this.btnLamMoiXeRa);
            this.Controls.Add(this.lblTieuDeLuotGui);
            this.Controls.Add(this.lblBienSo);
            this.Controls.Add(this.lblGiaTriBienSo);
            this.Controls.Add(this.lblLoaiXe);
            this.Controls.Add(this.lblGiaTriLoaiXe);
            this.Controls.Add(this.lblMaThe);
            this.Controls.Add(this.lblGiaTriMaThe);
            this.Controls.Add(this.lblKhuVuc);
            this.Controls.Add(this.lblGiaTriKhuVuc);
            this.Controls.Add(this.lblThoiGianVao);
            this.Controls.Add(this.lblGiaTriThoiGianVao);
            this.Controls.Add(this.lblThoiGianRa);
            this.Controls.Add(this.lblGiaTriThoiGianRa);
            this.Controls.Add(this.lblThoiGianGui);
            this.Controls.Add(this.lblGiaTriThoiGianGui);
            this.Controls.Add(this.lblLoaiVe);
            this.Controls.Add(this.lblGiaTriLoaiVe);
            this.Controls.Add(this.lblTieuDeThanhToan);
            this.Controls.Add(this.lblSoTienThanhToan);
            this.Controls.Add(this.lblGiaTriSoTien);
            this.Controls.Add(this.lblPhuongThucThanhToan);
            this.Controls.Add(this.cboPhuongThucThanhToan);
            this.Controls.Add(this.lblTrangThaiXuLy);
            this.Controls.Add(this.btnXacNhanXeRa);
            this.Controls.Add(this.btnThanhToanXeRa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblDanhSachXeDangGui);
            this.Controls.Add(this.dgvXeDangGui);

            this.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.MinimumSize =
                new System.Drawing.Size(1000, 750);

            this.Name = "frmXeRa";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Xe ra";

            this.Load +=
                new System.EventHandler(this.frmXeRa_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvXeDangGui)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTieuDeLuotGui;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.Label lblGiaTriBienSo;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.Label lblGiaTriLoaiXe;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.Label lblGiaTriMaThe;
        private System.Windows.Forms.Label lblKhuVuc;
        private System.Windows.Forms.Label lblGiaTriKhuVuc;
        private System.Windows.Forms.Label lblThoiGianVao;
        private System.Windows.Forms.Label lblGiaTriThoiGianVao;
        private System.Windows.Forms.Label lblThoiGianRa;
        private System.Windows.Forms.Label lblGiaTriThoiGianRa;
        private System.Windows.Forms.Label lblThoiGianGui;
        private System.Windows.Forms.Label lblGiaTriThoiGianGui;
        private System.Windows.Forms.Label lblLoaiVe;
        private System.Windows.Forms.Label lblGiaTriLoaiVe;
        private System.Windows.Forms.Label lblTieuDeThanhToan;
        private System.Windows.Forms.Label lblSoTienThanhToan;
        private System.Windows.Forms.Label lblGiaTriSoTien;
        private System.Windows.Forms.Label lblPhuongThucThanhToan;
        private System.Windows.Forms.Label lblTrangThaiXuLy;
        private System.Windows.Forms.Label lblDanhSachXeDangGui;

        private System.Windows.Forms.TextBox txtBienSoHoacMaThe;

        private System.Windows.Forms.Button btnTimKiemXe;
        private System.Windows.Forms.Button btnLamMoiXeRa;
        private System.Windows.Forms.Button btnXacNhanXeRa;
        private System.Windows.Forms.Button btnThanhToanXeRa;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.ComboBox cboPhuongThucThanhToan;

        private System.Windows.Forms.DataGridView dgvXeDangGui;
    }
}