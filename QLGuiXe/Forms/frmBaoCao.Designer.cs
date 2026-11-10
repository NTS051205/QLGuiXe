namespace QLGuiXe.Forms
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlDieuKienBaoCao;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblLoaiBaoCao;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnThoat;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlDieuKienBaoCao = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblLoaiBaoCao = new System.Windows.Forms.Label();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pnlDieuKienBaoCao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDieuKienBaoCao
            // 
            this.pnlDieuKienBaoCao.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDieuKienBaoCao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDieuKienBaoCao.Controls.Add(this.lblTieuDe);
            this.pnlDieuKienBaoCao.Controls.Add(this.lblMoTa);
            this.pnlDieuKienBaoCao.Controls.Add(this.lblLoaiBaoCao);
            this.pnlDieuKienBaoCao.Controls.Add(this.cboLoaiBaoCao);
            this.pnlDieuKienBaoCao.Controls.Add(this.lblTuNgay);
            this.pnlDieuKienBaoCao.Controls.Add(this.dtpTuNgay);
            this.pnlDieuKienBaoCao.Controls.Add(this.lblDenNgay);
            this.pnlDieuKienBaoCao.Controls.Add(this.dtpDenNgay);
            this.pnlDieuKienBaoCao.Controls.Add(this.btnXemBaoCao);
            this.pnlDieuKienBaoCao.Controls.Add(this.btnThoat);
            this.pnlDieuKienBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDieuKienBaoCao.Location = new System.Drawing.Point(0, 0);
            this.pnlDieuKienBaoCao.Name = "pnlDieuKienBaoCao";
            this.pnlDieuKienBaoCao.Size = new System.Drawing.Size(1100, 150);
            this.pnlDieuKienBaoCao.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(22, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(113, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÁO CÁO";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(24, 48);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(288, 15);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = "Chọn loại báo cáo và khoảng thời gian cần xem.";
            // 
            // lblLoaiBaoCao
            // 
            this.lblLoaiBaoCao.AutoSize = true;
            this.lblLoaiBaoCao.Location = new System.Drawing.Point(24, 98);
            this.lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            this.lblLoaiBaoCao.Size = new System.Drawing.Size(81, 15);
            this.lblLoaiBaoCao.TabIndex = 2;
            this.lblLoaiBaoCao.Text = "Loại báo cáo:";
            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.FormattingEnabled = true;
            this.cboLoaiBaoCao.Items.AddRange(new object[] {
            "Báo cáo nhân viên",
            "Báo cáo phương tiện",
            "Báo cáo doanh thu"});
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(111, 94);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(245, 23);
            this.cboLoaiBaoCao.TabIndex = 3;
            this.cboLoaiBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBaoCao_SelectedIndexChanged);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(382, 98);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(53, 15);
            this.lblTuNgay.TabIndex = 4;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(441, 94);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 23);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(580, 98);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(60, 15);
            this.lblDenNgay.TabIndex = 6;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(646, 94);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 23);
            this.dtpDenNgay.TabIndex = 7;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Location = new System.Drawing.Point(794, 86);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(140, 38);
            this.btnXemBaoCao.TabIndex = 8;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(950, 86);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(125, 38);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát / Quay lại";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer.Location = new System.Drawing.Point(0, 150);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowLogo = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(1100, 570);
            this.crystalReportViewer.TabIndex = 1;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.crystalReportViewer);
            this.Controls.Add(this.pnlDieuKienBaoCao);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo";
            this.pnlDieuKienBaoCao.ResumeLayout(false);
            this.pnlDieuKienBaoCao.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
