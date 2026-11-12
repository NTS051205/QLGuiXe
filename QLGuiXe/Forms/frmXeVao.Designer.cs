namespace QLGuiXe.Forms
{
    partial class frmXeVao
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
            this.lblBienSo = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblTheGuiXe = new System.Windows.Forms.Label();
            this.cboTheXe = new System.Windows.Forms.ComboBox();
            this.lblLoaiVe = new System.Windows.Forms.Label();
            this.lblGiaTriLoaiVe = new System.Windows.Forms.Label();
            this.lblKhuVuc = new System.Windows.Forms.Label();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.lblSoChoTrong = new System.Windows.Forms.Label();
            this.lblGiaTriChoTrong = new System.Windows.Forms.Label();
            this.lblThoiGianVao = new System.Windows.Forms.Label();
            this.lblGiaTriThoiGianVao = new System.Windows.Forms.Label();
            this.lblNhanVienTiepNhan = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.btnXacNhanXeVao = new System.Windows.Forms.Button();
            this.btnLamMoiXeVao = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTieuDeKiemTra = new System.Windows.Forms.Label();
            this.lblTrangThaiPhuongTien = new System.Windows.Forms.Label();
            this.lblTrangThaiTrongBai = new System.Windows.Forms.Label();
            this.lblTrangThaiVeThang = new System.Windows.Forms.Label();
            this.lblGhiChuNghiepVu = new System.Windows.Forms.Label();
            this.lblTieuDeDanhSach = new System.Windows.Forms.Label();
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
            this.lblTieuDe.Location = new System.Drawing.Point(20, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(215, 30);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "TIẾP NHẬN XE VÀO";

            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(22, 47);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(227, 15);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Nhập biển số, chọn thẻ và khu vực gửi xe.";

            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Location = new System.Drawing.Point(22, 85);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(48, 15);
            this.lblBienSo.TabIndex = 3;
            this.lblBienSo.Text = "Biển số:";

            // 
            // txtBienSo
            // 
            this.txtBienSo.CharacterCasing =
                System.Windows.Forms.CharacterCasing.Upper;
            this.txtBienSo.Font = new System.Drawing.Font(
                "Segoe UI",
                12F,
                System.Drawing.FontStyle.Bold
            );
            this.txtBienSo.Location = new System.Drawing.Point(90, 80);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(190, 29);
            this.txtBienSo.TabIndex = 4;
            this.txtBienSo.TextChanged +=
                new System.EventHandler(this.txtBienSo_TextChanged);

            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location = new System.Drawing.Point(305, 85);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Size = new System.Drawing.Size(46, 15);
            this.lblLoaiXe.TabIndex = 5;
            this.lblLoaiXe.Text = "Loại xe:";

            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.Location = new System.Drawing.Point(365, 82);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size = new System.Drawing.Size(130, 23);
            this.cboLoaiXe.TabIndex = 6;
            this.cboLoaiXe.SelectedIndexChanged +=
                new System.EventHandler(this.Input_Changed);

            // 
            // lblTheGuiXe
            // 
            this.lblTheGuiXe.AutoSize = true;
            this.lblTheGuiXe.Location = new System.Drawing.Point(520, 85);
            this.lblTheGuiXe.Name = "lblTheGuiXe";
            this.lblTheGuiXe.Size = new System.Drawing.Size(64, 15);
            this.lblTheGuiXe.TabIndex = 7;
            this.lblTheGuiXe.Text = "Thẻ gửi xe:";

            // 
            // cboTheXe
            // 
            this.cboTheXe.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheXe.Location = new System.Drawing.Point(595, 82);
            this.cboTheXe.Name = "cboTheXe";
            this.cboTheXe.Size = new System.Drawing.Size(145, 23);
            this.cboTheXe.TabIndex = 8;

            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.AutoSize = true;
            this.lblKhuVuc.Location = new System.Drawing.Point(765, 85);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(53, 15);
            this.lblKhuVuc.TabIndex = 9;
            this.lblKhuVuc.Text = "Khu vực:";

            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.Location = new System.Drawing.Point(825, 82);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(190, 23);
            this.cboKhuVuc.TabIndex = 10;
            this.cboKhuVuc.SelectedIndexChanged +=
                new System.EventHandler(this.cboKhuVuc_SelectedIndexChanged);

            // 
            // lblLoaiVe
            // 
            this.lblLoaiVe.AutoSize = true;
            this.lblLoaiVe.Location = new System.Drawing.Point(22, 130);
            this.lblLoaiVe.Name = "lblLoaiVe";
            this.lblLoaiVe.Size = new System.Drawing.Size(47, 15);
            this.lblLoaiVe.TabIndex = 11;
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
            this.lblGiaTriLoaiVe.Location = new System.Drawing.Point(90, 130);
            this.lblGiaTriLoaiVe.Name = "lblGiaTriLoaiVe";
            this.lblGiaTriLoaiVe.Size = new System.Drawing.Size(38, 15);
            this.lblGiaTriLoaiVe.TabIndex = 12;
            this.lblGiaTriLoaiVe.Text = "LUOT";

            // 
            // lblSoChoTrong
            // 
            this.lblSoChoTrong.AutoSize = true;
            this.lblSoChoTrong.Location = new System.Drawing.Point(305, 130);
            this.lblSoChoTrong.Name = "lblSoChoTrong";
            this.lblSoChoTrong.Size = new System.Drawing.Size(87, 15);
            this.lblSoChoTrong.TabIndex = 13;
            this.lblSoChoTrong.Text = "Chỗ còn trống:";

            // 
            // lblGiaTriChoTrong
            // 
            this.lblGiaTriChoTrong.AutoSize = true;
            this.lblGiaTriChoTrong.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold
            );
            this.lblGiaTriChoTrong.Location =
                new System.Drawing.Point(400, 130);
            this.lblGiaTriChoTrong.Name = "lblGiaTriChoTrong";
            this.lblGiaTriChoTrong.Size = new System.Drawing.Size(19, 15);
            this.lblGiaTriChoTrong.TabIndex = 14;
            this.lblGiaTriChoTrong.Text = "—";

            // 
            // lblThoiGianVao
            // 
            this.lblThoiGianVao.AutoSize = true;
            this.lblThoiGianVao.Location = new System.Drawing.Point(520, 130);
            this.lblThoiGianVao.Name = "lblThoiGianVao";
            this.lblThoiGianVao.Size = new System.Drawing.Size(82, 15);
            this.lblThoiGianVao.TabIndex = 15;
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
                new System.Drawing.Point(610, 130);
            this.lblGiaTriThoiGianVao.Name = "lblGiaTriThoiGianVao";
            this.lblGiaTriThoiGianVao.Size = new System.Drawing.Size(19, 15);
            this.lblGiaTriThoiGianVao.TabIndex = 16;
            this.lblGiaTriThoiGianVao.Text = "—";

            // 
            // lblNhanVienTiepNhan
            // 
            this.lblNhanVienTiepNhan.AutoSize = true;
            this.lblNhanVienTiepNhan.Location =
                new System.Drawing.Point(765, 130);
            this.lblNhanVienTiepNhan.Name = "lblNhanVienTiepNhan";
            this.lblNhanVienTiepNhan.Size = new System.Drawing.Size(64, 15);
            this.lblNhanVienTiepNhan.TabIndex = 17;
            this.lblNhanVienTiepNhan.Text = "Nhân viên:";

            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Location = new System.Drawing.Point(835, 126);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(180, 23);
            this.cboNhanVien.TabIndex = 18;

            // 
            // btnXacNhanXeVao
            // 
            this.btnXacNhanXeVao.Location =
                new System.Drawing.Point(25, 170);
            this.btnXacNhanXeVao.Name = "btnXacNhanXeVao";
            this.btnXacNhanXeVao.Size =
                new System.Drawing.Size(190, 40);
            this.btnXacNhanXeVao.TabIndex = 19;
            this.btnXacNhanXeVao.Text = "XÁC NHẬN XE VÀO";
            this.btnXacNhanXeVao.UseVisualStyleBackColor = true;
            this.btnXacNhanXeVao.Click +=
                new System.EventHandler(this.btnXacNhanXeVao_Click);

            // 
            // btnLamMoiXeVao
            // 
            this.btnLamMoiXeVao.Location =
                new System.Drawing.Point(225, 170);
            this.btnLamMoiXeVao.Name = "btnLamMoiXeVao";
            this.btnLamMoiXeVao.Size =
                new System.Drawing.Size(100, 40);
            this.btnLamMoiXeVao.TabIndex = 20;
            this.btnLamMoiXeVao.Text = "Làm mới";
            this.btnLamMoiXeVao.UseVisualStyleBackColor = true;
            this.btnLamMoiXeVao.Click +=
                new System.EventHandler(this.btnLamMoiXeVao_Click);

            // 
            // btnThoat
            // 
            this.btnThoat.Location =
                new System.Drawing.Point(885, 20);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size =
                new System.Drawing.Size(130, 34);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát / Quay lại";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click +=
                new System.EventHandler(this.btnThoat_Click);

            // 
            // lblTieuDeKiemTra
            // 
            this.lblTieuDeKiemTra.AutoSize = true;
            this.lblTieuDeKiemTra.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.lblTieuDeKiemTra.Location =
                new System.Drawing.Point(365, 175);
            this.lblTieuDeKiemTra.Name = "lblTieuDeKiemTra";
            this.lblTieuDeKiemTra.Size = new System.Drawing.Size(124, 19);
            this.lblTieuDeKiemTra.TabIndex = 21;
            this.lblTieuDeKiemTra.Text = "Kết quả kiểm tra:";

            // 
            // lblTrangThaiPhuongTien
            // 
            this.lblTrangThaiPhuongTien.AutoSize = true;
            this.lblTrangThaiPhuongTien.Location =
                new System.Drawing.Point(500, 177);
            this.lblTrangThaiPhuongTien.Name = "lblTrangThaiPhuongTien";
            this.lblTrangThaiPhuongTien.Size = new System.Drawing.Size(19, 15);
            this.lblTrangThaiPhuongTien.TabIndex = 22;
            this.lblTrangThaiPhuongTien.Text = "—";

            // 
            // lblTrangThaiTrongBai
            // 
            this.lblTrangThaiTrongBai.AutoSize = true;
            this.lblTrangThaiTrongBai.Location =
                new System.Drawing.Point(500, 197);
            this.lblTrangThaiTrongBai.Name = "lblTrangThaiTrongBai";
            this.lblTrangThaiTrongBai.Size = new System.Drawing.Size(19, 15);
            this.lblTrangThaiTrongBai.TabIndex = 23;
            this.lblTrangThaiTrongBai.Text = "—";

            // 
            // lblTrangThaiVeThang
            // 
            this.lblTrangThaiVeThang.AutoSize = true;
            this.lblTrangThaiVeThang.Location =
                new System.Drawing.Point(750, 177);
            this.lblTrangThaiVeThang.Name = "lblTrangThaiVeThang";
            this.lblTrangThaiVeThang.Size = new System.Drawing.Size(19, 15);
            this.lblTrangThaiVeThang.TabIndex = 24;
            this.lblTrangThaiVeThang.Text = "—";

            // 
            // lblGhiChuNghiepVu
            // 
            this.lblGhiChuNghiepVu.AutoSize = true;
            this.lblGhiChuNghiepVu.Location =
                new System.Drawing.Point(750, 197);
            this.lblGhiChuNghiepVu.Name = "lblGhiChuNghiepVu";
            this.lblGhiChuNghiepVu.Size = new System.Drawing.Size(235, 15);
            this.lblGhiChuNghiepVu.TabIndex = 25;
            this.lblGhiChuNghiepVu.Text =
                "Kiểm tra mô phỏng trên dữ liệu SQL Server.";

            // 
            // lblTieuDeDanhSach
            // 
            this.lblTieuDeDanhSach.AutoSize = true;
            this.lblTieuDeDanhSach.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold
            );
            this.lblTieuDeDanhSach.Location =
                new System.Drawing.Point(22, 235);
            this.lblTieuDeDanhSach.Name = "lblTieuDeDanhSach";
            this.lblTieuDeDanhSach.Size = new System.Drawing.Size(195, 20);
            this.lblTieuDeDanhSach.TabIndex = 26;
            this.lblTieuDeDanhSach.Text = "XE ĐANG GỬI TRONG BÃI";

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
                new System.Drawing.Point(25, 265);
            this.dgvXeDangGui.Name = "dgvXeDangGui";
            this.dgvXeDangGui.Size =
                new System.Drawing.Size(990, 350);
            this.dgvXeDangGui.TabIndex = 27;

            // 
            // frmXeVao
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1040, 640);

            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblBienSo);
            this.Controls.Add(this.txtBienSo);
            this.Controls.Add(this.lblLoaiXe);
            this.Controls.Add(this.cboLoaiXe);
            this.Controls.Add(this.lblTheGuiXe);
            this.Controls.Add(this.cboTheXe);
            this.Controls.Add(this.lblKhuVuc);
            this.Controls.Add(this.cboKhuVuc);
            this.Controls.Add(this.lblLoaiVe);
            this.Controls.Add(this.lblGiaTriLoaiVe);
            this.Controls.Add(this.lblSoChoTrong);
            this.Controls.Add(this.lblGiaTriChoTrong);
            this.Controls.Add(this.lblThoiGianVao);
            this.Controls.Add(this.lblGiaTriThoiGianVao);
            this.Controls.Add(this.lblNhanVienTiepNhan);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.btnXacNhanXeVao);
            this.Controls.Add(this.btnLamMoiXeVao);
            this.Controls.Add(this.lblTieuDeKiemTra);
            this.Controls.Add(this.lblTrangThaiPhuongTien);
            this.Controls.Add(this.lblTrangThaiTrongBai);
            this.Controls.Add(this.lblTrangThaiVeThang);
            this.Controls.Add(this.lblGhiChuNghiepVu);
            this.Controls.Add(this.lblTieuDeDanhSach);
            this.Controls.Add(this.dgvXeDangGui);

            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize =
                new System.Drawing.Size(1056, 679);
            this.Name = "frmXeVao";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Xe vào";

            this.Load +=
                new System.EventHandler(this.frmXeVao_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvXeDangGui)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.Label lblTheGuiXe;
        private System.Windows.Forms.Label lblLoaiVe;
        private System.Windows.Forms.Label lblGiaTriLoaiVe;
        private System.Windows.Forms.Label lblKhuVuc;
        private System.Windows.Forms.Label lblSoChoTrong;
        private System.Windows.Forms.Label lblGiaTriChoTrong;
        private System.Windows.Forms.Label lblThoiGianVao;
        private System.Windows.Forms.Label lblGiaTriThoiGianVao;
        private System.Windows.Forms.Label lblNhanVienTiepNhan;
        private System.Windows.Forms.Label lblTieuDeKiemTra;
        private System.Windows.Forms.Label lblTrangThaiPhuongTien;
        private System.Windows.Forms.Label lblTrangThaiTrongBai;
        private System.Windows.Forms.Label lblTrangThaiVeThang;
        private System.Windows.Forms.Label lblGhiChuNghiepVu;
        private System.Windows.Forms.Label lblTieuDeDanhSach;

        private System.Windows.Forms.TextBox txtBienSo;

        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.ComboBox cboTheXe;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.ComboBox cboNhanVien;

        private System.Windows.Forms.Button btnXacNhanXeVao;
        private System.Windows.Forms.Button btnLamMoiXeVao;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.DataGridView dgvXeDangGui;
    }
}