#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;
partial class frmBangGia
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlTieuDe; private Label lblTieuDe; private Label lblMoTa; private Button btnThem;
    private FlowLayoutPanel flpBoLoc; private TextBox txtTimKiem; private Label lblBoLoc; private ComboBox cboBoLoc; private Label lblBoLocPhu; private ComboBox cboBoLocPhu; private Label lblTuNgay; private DateTimePicker dtpTuNgay; private Label lblDenNgay; private DateTimePicker dtpDenNgay; private Button btnLamMoi;
    private DataGridView dgvDuLieu; private Panel pnlChanTrang; private Label lblTongSo; private FlowLayoutPanel flpHanhDong; private Button btnXem; private Button btnSua; private Button btnXoa;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        pnlTieuDe = new Panel(); lblTieuDe = new Label(); lblMoTa = new Label(); btnThem = new Button();
        flpBoLoc = new FlowLayoutPanel(); txtTimKiem = new TextBox(); lblBoLoc = new Label(); cboBoLoc = new ComboBox(); lblBoLocPhu = new Label(); cboBoLocPhu = new ComboBox(); lblTuNgay = new Label(); dtpTuNgay = new DateTimePicker(); lblDenNgay = new Label(); dtpDenNgay = new DateTimePicker(); btnLamMoi = new Button();
        dgvDuLieu = new DataGridView(); pnlChanTrang = new Panel(); lblTongSo = new Label(); flpHanhDong = new FlowLayoutPanel(); btnXem = new Button(); btnSua = new Button(); btnXoa = new Button();
        pnlTieuDe.SuspendLayout(); flpBoLoc.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)dgvDuLieu).BeginInit(); pnlChanTrang.SuspendLayout(); flpHanhDong.SuspendLayout(); SuspendLayout();
        pnlTieuDe.Controls.Add(lblTieuDe); pnlTieuDe.Controls.Add(lblMoTa); pnlTieuDe.Controls.Add(btnThem); pnlTieuDe.Dock = DockStyle.Top; pnlTieuDe.Height = 80; pnlTieuDe.Name = "pnlTieuDe";
        lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold); lblTieuDe.Location = new Point(15, 8); lblTieuDe.Name = "lblTieuDe"; lblTieuDe.Size = new Size(650, 35);
        lblMoTa.Location = new Point(17, 45); lblMoTa.Name = "lblMoTa"; lblMoTa.Size = new Size(700, 25);
        btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right; btnThem.Location = new Point(900, 20); btnThem.Name = "btnThem"; btnThem.Size = new Size(140, 38); btnThem.Text = "Thêm mới";
        flpBoLoc.Controls.Add(txtTimKiem); flpBoLoc.Controls.Add(lblBoLoc); flpBoLoc.Controls.Add(cboBoLoc); flpBoLoc.Controls.Add(lblBoLocPhu); flpBoLoc.Controls.Add(cboBoLocPhu); flpBoLoc.Controls.Add(lblTuNgay); flpBoLoc.Controls.Add(dtpTuNgay); flpBoLoc.Controls.Add(lblDenNgay); flpBoLoc.Controls.Add(dtpDenNgay); flpBoLoc.Controls.Add(btnLamMoi); flpBoLoc.Dock = DockStyle.Top; flpBoLoc.Height = 60; flpBoLoc.Name = "flpBoLoc"; flpBoLoc.Padding = new Padding(12);
        txtTimKiem.Name = "txtTimKiem"; txtTimKiem.Size = new Size(230, 27);
        lblBoLoc.AutoSize = true; lblBoLoc.Name = "lblBoLoc"; lblBoLoc.Text = "Lọc:"; lblBoLoc.Visible = false; cboBoLoc.DropDownStyle = ComboBoxStyle.DropDownList; cboBoLoc.Name = "cboBoLoc"; cboBoLoc.Size = new Size(130, 28); cboBoLoc.Visible = false;
        lblBoLocPhu.AutoSize = true; lblBoLocPhu.Name = "lblBoLocPhu"; lblBoLocPhu.Text = "Lọc 2:"; lblBoLocPhu.Visible = false; cboBoLocPhu.DropDownStyle = ComboBoxStyle.DropDownList; cboBoLocPhu.Name = "cboBoLocPhu"; cboBoLocPhu.Size = new Size(130, 28); cboBoLocPhu.Visible = false;
        lblTuNgay.AutoSize = true; lblTuNgay.Name = "lblTuNgay"; lblTuNgay.Text = "Từ ngày:"; lblTuNgay.Visible = false; dtpTuNgay.CustomFormat = "dd/MM/yyyy"; dtpTuNgay.Format = DateTimePickerFormat.Custom; dtpTuNgay.Name = "dtpTuNgay"; dtpTuNgay.Size = new Size(115, 28); dtpTuNgay.Visible = false;
        lblDenNgay.AutoSize = true; lblDenNgay.Name = "lblDenNgay"; lblDenNgay.Text = "Đến:"; lblDenNgay.Visible = false; dtpDenNgay.CustomFormat = "dd/MM/yyyy"; dtpDenNgay.Format = DateTimePickerFormat.Custom; dtpDenNgay.Name = "dtpDenNgay"; dtpDenNgay.Size = new Size(115, 28); dtpDenNgay.Visible = false;
        btnLamMoi.Name = "btnLamMoi"; btnLamMoi.Size = new Size(100, 30); btnLamMoi.Text = "Làm mới";
        dgvDuLieu.Dock = DockStyle.Fill; dgvDuLieu.Name = "dgvBangGia"; dgvDuLieu.ReadOnly = true;
        pnlChanTrang.Controls.Add(lblTongSo); pnlChanTrang.Controls.Add(flpHanhDong); pnlChanTrang.Dock = DockStyle.Bottom; pnlChanTrang.Height = 58; pnlChanTrang.Name = "pnlChanTrang";
        lblTongSo.Dock = DockStyle.Left; lblTongSo.Name = "lblTongSo"; lblTongSo.Size = new Size(280, 58); lblTongSo.Text = "Tổng số: 0 bản ghi"; lblTongSo.TextAlign = ContentAlignment.MiddleLeft;
        flpHanhDong.Controls.Add(btnXem); flpHanhDong.Controls.Add(btnSua); flpHanhDong.Controls.Add(btnXoa); flpHanhDong.Dock = DockStyle.Right; flpHanhDong.Name = "flpHanhDong"; flpHanhDong.Padding = new Padding(0, 10, 8, 0); flpHanhDong.Size = new Size(330, 58);
        btnXem.Name = "btnXem"; btnXem.Size = new Size(90, 34); btnXem.Text = "Xem"; btnSua.Name = "btnSua"; btnSua.Size = new Size(90, 34); btnSua.Text = "Sửa"; btnXoa.Name = "btnXoa"; btnXoa.Size = new Size(110, 34); btnXoa.Text = "Xóa";
        AutoScaleDimensions = new SizeF(96F, 96F); AutoScaleMode = AutoScaleMode.Dpi; ClientSize = new Size(1064, 650); Controls.Add(dgvDuLieu); Controls.Add(pnlChanTrang); Controls.Add(flpBoLoc); Controls.Add(pnlTieuDe); Font = new Font("Segoe UI", 9F); Name = "frmBangGia"; Text = "Bảng giá";
        pnlTieuDe.ResumeLayout(false); flpBoLoc.ResumeLayout(false); flpBoLoc.PerformLayout(); ((System.ComponentModel.ISupportInitialize)dgvDuLieu).EndInit(); pnlChanTrang.ResumeLayout(false); flpHanhDong.ResumeLayout(false); ResumeLayout(false);
    }
}

