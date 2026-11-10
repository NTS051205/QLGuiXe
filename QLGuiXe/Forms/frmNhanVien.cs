using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmNhanVien : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();
        private DataTable dtNhanVien = new DataTable();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            cboTrangThai.Items.AddRange(new object[] { "HOAT_DONG", "TAM_NGHI", "VO_HIEU" });
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "HOAT_DONG", "TAM_NGHI", "VO_HIEU" });
            cboTrangThai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;

            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.MultiSelect = false;

            HienThiNhanVien();
            LamMoiDuLieu();
        }

        private void HienThiNhanVien()
        {
            try
            {
                dtNhanVien = kn.GetData("dbo.sp_NHANVIEN_DanhSach");
                dgvNhanVien.DataSource = dtNhanVien;

                dgvNhanVien.Columns["MaNV"].HeaderText = "Mã nhân viên";
                dgvNhanVien.Columns["HoTen"].HeaderText = "Họ tên";
                dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                dgvNhanVien.Columns["TrangThai"].HeaderText = "Trạng thái";

                LocDanhSach(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhân viên: " + ex.Message);
            }
        }

        private string LayMaMoi()
        {
            DataTable dt = kn.GetData("dbo.sp_NHANVIEN_MaMoi");
            return Convert.ToString(dt.Rows[0]["MaMoi"]);
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!");
                txtHoTen.Focus();
                return false;
            }

            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (soDienThoai.Length < 9 || soDienThoai.Length > 11 || !soDienThoai.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải gồm 9 đến 11 chữ số!");
                txtSoDienThoai.Focus();
                return false;
            }

            return true;
        }

        private SqlParameter[] LayThamSo()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@MaNV", txtMaNV.Text.Trim()),
                new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                new SqlParameter("@SoDienThoai", txtSoDienThoai.Text.Trim()),
                new SqlParameter("@TrangThai", cboTrangThai.Text)
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            try
            {
                kn.Execute("dbo.sp_NHANVIEN_Them", LayThamSo());
                MessageBox.Show("Thêm nhân viên thành công!");
                HienThiNhanVien();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }
            if (!KiemTraDuLieu()) return;

            try
            {
                kn.Execute("dbo.sp_NHANVIEN_Sua", LayThamSo());
                MessageBox.Show("Sửa nhân viên thành công!");
                HienThiNhanVien();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btnVoHieu_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần vô hiệu hóa!");
                return;
            }

            if (MessageBox.Show("Vô hiệu hóa nhân viên đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                kn.Execute("dbo.sp_NHANVIEN_VoHieu",
                    new SqlParameter("@MaNV", txtMaNV.Text));
                HienThiNhanVien();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi vô hiệu hóa: " + ex.Message);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xem!");
                return;
            }

            MessageBox.Show(
                "Mã nhân viên: " + txtMaNV.Text + Environment.NewLine +
                "Họ tên: " + txtHoTen.Text + Environment.NewLine +
                "Số điện thoại: " + txtSoDienThoai.Text + Environment.NewLine +
                "Trạng thái: " + cboTrangThai.Text,
                "Chi tiết nhân viên");
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            txtMaNV.Text = Convert.ToString(row.Cells["MaNV"].Value);
            txtHoTen.Text = Convert.ToString(row.Cells["HoTen"].Value);
            txtSoDienThoai.Text = Convert.ToString(row.Cells["SoDienThoai"].Value);
            cboTrangThai.Text = Convert.ToString(row.Cells["TrangThai"].Value);
        }

        private void LamMoiDuLieu()
        {
            try { txtMaNV.Text = LayMaMoi(); }
            catch { txtMaNV.Clear(); }

            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            cboTrangThai.SelectedIndex = 0;
            dgvNhanVien.ClearSelection();
            txtHoTen.Focus();
        }

        private void LocDanhSach(object sender, EventArgs e)
        {
            if (dtNhanVien.Columns.Count == 0) return;

            string tuKhoa = txtTimKiem.Text.Trim().Replace("'", "''");
            string dieuKien = "(MaNV LIKE '%" + tuKhoa + "%' OR HoTen LIKE '%" + tuKhoa
                + "%' OR SoDienThoai LIKE '%" + tuKhoa + "%')";

            if (cboLocTrangThai.SelectedIndex > 0)
                dieuKien += " AND TrangThai='" + cboLocTrangThai.Text + "'";

            dtNhanVien.DefaultView.RowFilter = dieuKien;
            lblTongSo.Text = "Tổng số: " + dtNhanVien.DefaultView.Count + " bản ghi";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThai.SelectedIndex = 0;
            HienThiNhanVien();
            LamMoiDuLieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
