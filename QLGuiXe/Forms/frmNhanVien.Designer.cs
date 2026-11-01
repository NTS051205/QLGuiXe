#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;
partial class frmNhanVien
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlTieuDe; private Label lblTieuDe; private Label lblMoTa; private Button btnThem;
    private FlowLayoutPanel flpBoLoc; private TextBox txtTimKiem; private Label lblBoLoc; private ComboBox cboBoLoc; private Label lblBoLocPhu; private ComboBox cboBoLocPhu; private Label lblTuNgay; private DateTimePicker dtpTuNgay; private Label lblDenNgay; private DateTimePicker dtpDenNgay; private Button btnLamMoi;
    private DataGridView dgvDuLieu; private Panel pnlChanTrang; private Label lblTongSo; private FlowLayoutPanel flpHanhDong; private Button btnXem; private Button btnSua; private Button btnXoa;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        pnlTieuDe=new Panel(); lblTieuDe=new Label(); lblMoTa=new Label(); btnThem=new Button(); flpBoLoc=new FlowLayoutPanel(); txtTimKiem=new TextBox(); lblBoLoc=new Label(); cboBoLoc=new ComboBox(); lblBoLocPhu=new Label(); cboBoLocPhu=new ComboBox(); lblTuNgay=new Label(); dtpTuNgay=new DateTimePicker(); lblDenNgay=new Label(); dtpDenNgay=new DateTimePicker(); btnLamMoi=new Button(); dgvDuLieu=new DataGridView(); pnlChanTrang=new Panel(); lblTongSo=new Label(); flpHanhDong=new FlowLayoutPanel(); btnXem=new Button(); btnSua=new Button(); btnXoa=new Button();
        pnlTieuDe.SuspendLayout(); flpBoLoc.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)dgvDuLieu).BeginInit(); pnlChanTrang.SuspendLayout(); flpHanhDong.SuspendLayout(); SuspendLayout();
        pnlTieuDe.Controls.Add(lblTieuDe); pnlTieuDe.Controls.Add(lblMoTa); pnlTieuDe.Controls.Add(btnThem); pnlTieuDe.Dock=DockStyle.Top; pnlTieuDe.Height=80; pnlTieuDe.Name="pnlTieuDe";
        lblTieuDe.Font=new Font("Segoe UI",16F,FontStyle.Bold); lblTieuDe.Location=new Point(15,8); lblTieuDe.Size=new Size(650,35); lblTieuDe.Name="lblTieuDe"; lblMoTa.Location=new Point(17,45); lblMoTa.Size=new Size(700,25); lblMoTa.Name="lblMoTa"; btnThem.Anchor=AnchorStyles.Top|AnchorStyles.Right; btnThem.Location=new Point(900,20); btnThem.Size=new Size(140,38); btnThem.Name="btnThem"; btnThem.Text="Thêm mới";
        flpBoLoc.Controls.Add(txtTimKiem); flpBoLoc.Controls.Add(lblBoLoc); flpBoLoc.Controls.Add(cboBoLoc); flpBoLoc.Controls.Add(lblBoLocPhu); flpBoLoc.Controls.Add(cboBoLocPhu); flpBoLoc.Controls.Add(lblTuNgay); flpBoLoc.Controls.Add(dtpTuNgay); flpBoLoc.Controls.Add(lblDenNgay); flpBoLoc.Controls.Add(dtpDenNgay); flpBoLoc.Controls.Add(btnLamMoi); flpBoLoc.Dock=DockStyle.Top; flpBoLoc.Height=60; flpBoLoc.Padding=new Padding(12); flpBoLoc.Name="flpBoLoc";
        txtTimKiem.Size=new Size(230,27); txtTimKiem.Name="txtTimKiem"; lblBoLoc.Text="Lọc:"; lblBoLoc.AutoSize=true; lblBoLoc.Margin=new Padding(12,6,5,0); lblBoLoc.Visible=false; lblBoLoc.Name="lblBoLoc"; cboBoLoc.Size=new Size(130,28); cboBoLoc.DropDownStyle=ComboBoxStyle.DropDownList; cboBoLoc.Visible=false; cboBoLoc.Name="cboBoLoc"; lblBoLocPhu.Text="Lọc 2:"; lblBoLocPhu.AutoSize=true; lblBoLocPhu.Margin=new Padding(12,6,5,0); lblBoLocPhu.Visible=false; lblBoLocPhu.Name="lblBoLocPhu"; cboBoLocPhu.Size=new Size(130,28); cboBoLocPhu.DropDownStyle=ComboBoxStyle.DropDownList; cboBoLocPhu.Visible=false; cboBoLocPhu.Name="cboBoLocPhu";
        lblTuNgay.Text="Từ ngày:"; lblTuNgay.AutoSize=true; lblTuNgay.Margin=new Padding(12,6,5,0); lblTuNgay.Visible=false; lblTuNgay.Name="lblTuNgay"; dtpTuNgay.Size=new Size(115,28); dtpTuNgay.Format=DateTimePickerFormat.Custom; dtpTuNgay.CustomFormat="dd/MM/yyyy"; dtpTuNgay.Visible=false; dtpTuNgay.Name="dtpTuNgay"; lblDenNgay.Text="Đến:"; lblDenNgay.AutoSize=true; lblDenNgay.Margin=new Padding(12,6,5,0); lblDenNgay.Visible=false; lblDenNgay.Name="lblDenNgay"; dtpDenNgay.Size=new Size(115,28); dtpDenNgay.Format=DateTimePickerFormat.Custom; dtpDenNgay.CustomFormat="dd/MM/yyyy"; dtpDenNgay.Visible=false; dtpDenNgay.Name="dtpDenNgay"; btnLamMoi.Size=new Size(100,30); btnLamMoi.Text="Làm mới"; btnLamMoi.Name="btnLamMoi";
        dgvDuLieu.Dock=DockStyle.Fill; dgvDuLieu.Name="dgvNhanVien"; dgvDuLieu.ReadOnly=true;
        pnlChanTrang.Controls.Add(lblTongSo); pnlChanTrang.Controls.Add(flpHanhDong); pnlChanTrang.Dock=DockStyle.Bottom; pnlChanTrang.Height=58; pnlChanTrang.Name="pnlChanTrang"; lblTongSo.Dock=DockStyle.Left; lblTongSo.Width=280; lblTongSo.Padding=new Padding(15,0,0,0); lblTongSo.Text="Tổng số: 0 bản ghi"; lblTongSo.TextAlign=ContentAlignment.MiddleLeft; lblTongSo.Name="lblTongSo"; flpHanhDong.Controls.Add(btnXem); flpHanhDong.Controls.Add(btnSua); flpHanhDong.Controls.Add(btnXoa); flpHanhDong.Dock=DockStyle.Right; flpHanhDong.Width=330; flpHanhDong.Padding=new Padding(0,10,8,0); flpHanhDong.Name="flpHanhDong"; btnXem.Size=new Size(90,34); btnXem.Text="Xem"; btnXem.Name="btnXem"; btnSua.Size=new Size(90,34); btnSua.Text="Sửa"; btnSua.Name="btnSua"; btnXoa.Size=new Size(110,34); btnXoa.Text="Xóa"; btnXoa.Name="btnXoa";
        AutoScaleDimensions=new SizeF(96F,96F); AutoScaleMode=AutoScaleMode.Dpi; ClientSize=new Size(1064,650); Controls.Add(dgvDuLieu); Controls.Add(pnlChanTrang); Controls.Add(flpBoLoc); Controls.Add(pnlTieuDe); Font=new Font("Segoe UI",9F); Name="frmNhanVien"; Text="Quản lý nhân viên";
        pnlTieuDe.ResumeLayout(false); flpBoLoc.ResumeLayout(false); flpBoLoc.PerformLayout(); ((System.ComponentModel.ISupportInitialize)dgvDuLieu).EndInit(); pnlChanTrang.ResumeLayout(false); flpHanhDong.ResumeLayout(false); ResumeLayout(false);
    }
}
