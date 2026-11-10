using System;
using System.Data;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmLichSuGuiXe : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();
        private DataTable dtLichSu = new DataTable();

        public frmLichSuGuiXe()
        {
            InitializeComponent();
        }

        private void frmLichSuGuiXe_Load(object sender, EventArgs e)
        {
            cboTrangThai.Items.AddRange(new object[] { "Tất cả", "DANG_GUI", "DA_RA" });
            cboLoaiXe.Items.AddRange(new object[] { "Tất cả", "Xe máy", "Ô tô" });
            cboTrangThai.SelectedIndex = 0;
            cboLoaiXe.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;

            dgvLichSu.ReadOnly = true;
            dgvLichSu.AllowUserToAddRows = false;
            dgvLichSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvLichSu.MultiSelect = false;

            HienThiLichSu();
        }

        private void HienThiLichSu()
        {
            try
            {
                dtLichSu = kn.GetData("dbo.sp_LUOTGUIXE_DanhSach");
                dgvLichSu.DataSource = dtLichSu;

                dgvLichSu.Columns["MaLuotGui"].HeaderText = "Mã lượt gửi";
                dgvLichSu.Columns["BienSo"].HeaderText = "Biển số";
                dgvLichSu.Columns["LoaiXe"].HeaderText = "Loại xe";
                dgvLichSu.Columns["MaThe"].HeaderText = "Mã thẻ";
                dgvLichSu.Columns["KhuVuc"].HeaderText = "Khu vực";
                dgvLichSu.Columns["ThoiGianVao"].HeaderText = "Thời gian vào";
                dgvLichSu.Columns["ThoiGianRa"].HeaderText = "Thời gian ra";
                dgvLichSu.Columns["TienGui"].HeaderText = "Tiền gửi";
                dgvLichSu.Columns["NhanVienVao"].HeaderText = "Nhân viên vào";
                dgvLichSu.Columns["NhanVienRa"].HeaderText = "Nhân viên ra";

                dgvLichSu.Columns["ThoiGianVao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvLichSu.Columns["ThoiGianRa"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvLichSu.Columns["TienGui"].DefaultCellStyle.Format = "#,##0 ₫";

                LocDanhSach(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
        }

        private void LocDanhSach(object sender, EventArgs e)
        {
            if (dtLichSu.Columns.Count == 0) return;

            string tuKhoa = txtBienSo.Text.Trim().Replace("'", "''");
            string tuNgay = dtpTuNgay.Value.Date.ToString("MM/dd/yyyy");
            string denNgay = dtpDenNgay.Value.Date.AddDays(1).ToString("MM/dd/yyyy");
            string dieuKien = "(BienSo LIKE '%" + tuKhoa + "%' OR MaThe LIKE '%" + tuKhoa
                + "%') AND ThoiGianVao >= #" + tuNgay + "# AND ThoiGianVao < #" + denNgay + "#";

            if (cboTrangThai.SelectedIndex > 0)
                dieuKien += " AND TrangThai='" + cboTrangThai.Text + "'";
            if (cboLoaiXe.SelectedIndex > 0)
                dieuKien += " AND LoaiXe='" + cboLoaiXe.Text + "'";

            dtLichSu.DefaultView.RowFilter = dieuKien;
            lblTongSo.Text = "Tổng số: " + dtLichSu.DefaultView.Count + " bản ghi";
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn lượt gửi cần xem!");
                return;
            }

            DataRowView row = (DataRowView)dgvLichSu.CurrentRow.DataBoundItem;
            string noiDung = string.Empty;
            foreach (DataColumn cot in row.DataView.Table.Columns)
                noiDung += cot.ColumnName + ": " + Convert.ToString(row[cot.ColumnName]) + Environment.NewLine;

            MessageBox.Show(noiDung, "Chi tiết lượt gửi");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtBienSo.Clear();
            cboTrangThai.SelectedIndex = 0;
            cboLoaiXe.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;
            HienThiLichSu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
