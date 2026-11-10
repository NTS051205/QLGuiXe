using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmBangGia : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();
        private DataTable dtBangGia = new DataTable();

        public frmBangGia()
        {
            InitializeComponent();
        }

        private void frmBangGia_Load(object sender, EventArgs e)
        {
            cboLoaiXe.Items.AddRange(new object[] { "Xe máy", "Ô tô" });
            cboLoaiVe.Items.AddRange(new object[] { "LUOT", "THANG" });
            cboLocLoaiXe.Items.AddRange(new object[] { "Tất cả", "Xe máy", "Ô tô" });
            cboLocLoaiVe.Items.AddRange(new object[] { "Tất cả", "LUOT", "THANG" });
            cboLoaiXe.SelectedIndex = 0;
            cboLoaiVe.SelectedIndex = 0;
            cboLocLoaiXe.SelectedIndex = 0;
            cboLocLoaiVe.SelectedIndex = 0;

            dgvBangGia.ReadOnly = true;
            dgvBangGia.AllowUserToAddRows = false;
            dgvBangGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangGia.MultiSelect = false;

            HienThiBangGia();
            LamMoiDuLieu();
        }

        private void HienThiBangGia()
        {
            try
            {
                dtBangGia = kn.GetData("dbo.sp_BANGGIA_DanhSach");
                dgvBangGia.DataSource = dtBangGia;
                dgvBangGia.Columns["MaBangGia"].HeaderText = "Mã bảng giá";
                dgvBangGia.Columns["LoaiXe"].HeaderText = "Loại xe";
                dgvBangGia.Columns["LoaiVe"].HeaderText = "Loại vé";
                dgvBangGia.Columns["DonGia"].HeaderText = "Giá thường";
                dgvBangGia.Columns["DonGiaSau19Gio"].HeaderText = "Giá sau 19 giờ";
                dgvBangGia.Columns["DonGiaQuaDem"].HeaderText = "Giá qua đêm";
                dgvBangGia.Columns["NgayApDung"].HeaderText = "Ngày áp dụng";
                dgvBangGia.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 ₫";
                dgvBangGia.Columns["DonGiaSau19Gio"].DefaultCellStyle.Format = "#,##0 ₫";
                dgvBangGia.Columns["DonGiaQuaDem"].DefaultCellStyle.Format = "#,##0 ₫";
                dgvBangGia.Columns["NgayApDung"].DefaultCellStyle.Format = "dd/MM/yyyy";
                LocDanhSach(this, EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải bảng giá: " + ex.Message); }
        }

        private string LayMaMoi()
        {
            DataTable dt = kn.GetData("dbo.sp_BANGGIA_MaMoi");
            return Convert.ToString(dt.Rows[0]["MaMoi"]);
        }

        private bool KiemTraDuLieu()
        {
            if (nudDonGia.Value <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0!");
                return false;
            }
            if (cboLoaiVe.Text == "LUOT" &&
                (nudGiaSau19Gio.Value <= 0 || nudGiaQuaDem.Value <= 0))
            {
                MessageBox.Show("Vé lượt phải có giá sau 19 giờ và giá qua đêm!");
                return false;
            }
            return true;
        }

        private SqlParameter[] LayThamSo()
        {
            object giaSau19Gio = cboLoaiVe.Text == "LUOT" ? (object)nudGiaSau19Gio.Value : DBNull.Value;
            object giaQuaDem = cboLoaiVe.Text == "LUOT" ? (object)nudGiaQuaDem.Value : DBNull.Value;

            return new SqlParameter[]
            {
                new SqlParameter("@MaBangGia", txtMaBangGia.Text),
                new SqlParameter("@LoaiXe", cboLoaiXe.Text),
                new SqlParameter("@LoaiVe", cboLoaiVe.Text),
                new SqlParameter("@DonGia", nudDonGia.Value),
                new SqlParameter("@DonGiaSau19Gio", giaSau19Gio),
                new SqlParameter("@DonGiaQuaDem", giaQuaDem),
                new SqlParameter("@NgayApDung", dtpNgayApDung.Value.Date)
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;
            try
            {
                kn.Execute("dbo.sp_BANGGIA_Them", LayThamSo());
                MessageBox.Show("Thêm bảng giá thành công!");
                HienThiBangGia();
                LamMoiDuLieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvBangGia.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn mức giá cần sửa!");
                return;
            }
            if (!KiemTraDuLieu()) return;
            try
            {
                kn.Execute("dbo.sp_BANGGIA_Sua", LayThamSo());
                MessageBox.Show("Sửa bảng giá thành công!");
                HienThiBangGia();
                LamMoiDuLieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvBangGia.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn mức giá cần xem!");
                return;
            }

            string giaSau19 = cboLoaiVe.Text == "LUOT" ? DinhDangTien(nudGiaSau19Gio.Value) : "Không áp dụng";
            string giaQuaDem = cboLoaiVe.Text == "LUOT" ? DinhDangTien(nudGiaQuaDem.Value) : "Không áp dụng";
            MessageBox.Show(
                "Mã bảng giá: " + txtMaBangGia.Text + Environment.NewLine +
                "Loại xe: " + cboLoaiXe.Text + Environment.NewLine +
                "Loại vé: " + cboLoaiVe.Text + Environment.NewLine +
                "Giá thường: " + DinhDangTien(nudDonGia.Value) + Environment.NewLine +
                "Giá sau 19 giờ: " + giaSau19 + Environment.NewLine +
                "Giá qua đêm: " + giaQuaDem,
                "Chi tiết bảng giá");
        }

        private void dgvBangGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvBangGia.Rows[e.RowIndex];
            txtMaBangGia.Text = Convert.ToString(row.Cells["MaBangGia"].Value);
            cboLoaiXe.Text = Convert.ToString(row.Cells["LoaiXe"].Value);
            cboLoaiVe.Text = Convert.ToString(row.Cells["LoaiVe"].Value);
            nudDonGia.Value = Convert.ToDecimal(row.Cells["DonGia"].Value);
            nudGiaSau19Gio.Value = row.Cells["DonGiaSau19Gio"].Value == DBNull.Value ? 0 : Convert.ToDecimal(row.Cells["DonGiaSau19Gio"].Value);
            nudGiaQuaDem.Value = row.Cells["DonGiaQuaDem"].Value == DBNull.Value ? 0 : Convert.ToDecimal(row.Cells["DonGiaQuaDem"].Value);
            dtpNgayApDung.Value = Convert.ToDateTime(row.Cells["NgayApDung"].Value);
            CapNhatLoaiGia(this, EventArgs.Empty);
        }

        private void CapNhatLoaiGia(object sender, EventArgs e)
        {
            bool laVeLuot = cboLoaiVe.Text == "LUOT";
            nudGiaSau19Gio.Enabled = laVeLuot;
            nudGiaQuaDem.Enabled = laVeLuot;
            lblGiaSau19Gio.Enabled = laVeLuot;
            lblGiaQuaDem.Enabled = laVeLuot;
        }

        private void LamMoiDuLieu()
        {
            try { txtMaBangGia.Text = LayMaMoi(); }
            catch { txtMaBangGia.Clear(); }
            cboLoaiXe.SelectedIndex = 0;
            cboLoaiVe.SelectedIndex = 0;
            nudDonGia.Value = 5000;
            nudGiaSau19Gio.Value = 10000;
            nudGiaQuaDem.Value = 20000;
            dtpNgayApDung.Value = DateTime.Today;
            CapNhatLoaiGia(this, EventArgs.Empty);
            dgvBangGia.ClearSelection();
        }

        private void LocDanhSach(object sender, EventArgs e)
        {
            if (dtBangGia.Columns.Count == 0) return;
            string tuKhoa = txtTimKiem.Text.Trim().Replace("'", "''");
            string dieuKien = "MaBangGia LIKE '%" + tuKhoa + "%'";
            if (cboLocLoaiXe.SelectedIndex > 0) dieuKien += " AND LoaiXe='" + cboLocLoaiXe.Text + "'";
            if (cboLocLoaiVe.SelectedIndex > 0) dieuKien += " AND LoaiVe='" + cboLocLoaiVe.Text + "'";
            dtBangGia.DefaultView.RowFilter = dieuKien;
            lblTongSo.Text = "Tổng số: " + dtBangGia.DefaultView.Count + " bản ghi";
        }

        private string DinhDangTien(decimal soTien)
        {
            return string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0} ₫", soTien);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocLoaiXe.SelectedIndex = 0;
            cboLocLoaiVe.SelectedIndex = 0;
            HienThiBangGia();
            LamMoiDuLieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
