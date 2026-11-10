using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmCaLam : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();
        private DataTable dtCaLam = new DataTable();

        public frmCaLam()
        {
            InitializeComponent();
        }

        private void frmCaLam_Load(object sender, EventArgs e)
        {
            dtpGioBatDau.Format = DateTimePickerFormat.Custom;
            dtpGioBatDau.CustomFormat = "HH:mm";
            dtpGioBatDau.ShowUpDown = true;
            dtpGioKetThuc.Format = DateTimePickerFormat.Custom;
            dtpGioKetThuc.CustomFormat = "HH:mm";
            dtpGioKetThuc.ShowUpDown = true;

            dgvCaLam.ReadOnly = true;
            dgvCaLam.AllowUserToAddRows = false;
            dgvCaLam.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCaLam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCaLam.MultiSelect = false;

            HienThiCaLam();
            LamMoiDuLieu();
        }

        private void HienThiCaLam()
        {
            try
            {
                dtCaLam = kn.GetData("dbo.sp_CALAM_DanhSach");
                dgvCaLam.DataSource = dtCaLam;
                dgvCaLam.Columns["MaCa"].HeaderText = "Mã ca";
                dgvCaLam.Columns["TenCa"].HeaderText = "Tên ca";
                dgvCaLam.Columns["GioBatDau"].HeaderText = "Giờ bắt đầu";
                dgvCaLam.Columns["GioKetThuc"].HeaderText = "Giờ kết thúc";
                dgvCaLam.Columns["QuaDem"].HeaderText = "Qua đêm";
                LocDanhSach(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ca làm: " + ex.Message);
            }
        }

        private string LayMaMoi()
        {
            DataTable dt = kn.GetData("dbo.sp_CALAM_MaMoi");
            return Convert.ToString(dt.Rows[0]["MaMoi"]);
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtTenCa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên ca làm!");
                return false;
            }
            if (dtpGioBatDau.Value.TimeOfDay == dtpGioKetThuc.Value.TimeOfDay)
            {
                MessageBox.Show("Giờ bắt đầu và giờ kết thúc không được trùng nhau!");
                return false;
            }
            return true;
        }

        private SqlParameter[] LayThamSo()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@MaCa", txtMaCa.Text),
                new SqlParameter("@TenCa", txtTenCa.Text.Trim()),
                new SqlParameter("@GioBatDau", dtpGioBatDau.Value.TimeOfDay),
                new SqlParameter("@GioKetThuc", dtpGioKetThuc.Value.TimeOfDay)
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;
            try
            {
                kn.Execute("dbo.sp_CALAM_Them", LayThamSo());
                MessageBox.Show("Thêm ca làm thành công!");
                HienThiCaLam();
                LamMoiDuLieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvCaLam.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm cần sửa!");
                return;
            }
            if (!KiemTraDuLieu()) return;
            try
            {
                kn.Execute("dbo.sp_CALAM_Sua", LayThamSo());
                MessageBox.Show("Sửa ca làm thành công!");
                HienThiCaLam();
                LamMoiDuLieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvCaLam.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm cần xóa!");
                return;
            }
            if (MessageBox.Show("Xóa ca làm đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                kn.Execute("dbo.sp_CALAM_Xoa", new SqlParameter("@MaCa", txtMaCa.Text));
                HienThiCaLam();
                LamMoiDuLieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvCaLam.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm cần xem!");
                return;
            }
            MessageBox.Show(
                "Mã ca: " + txtMaCa.Text + Environment.NewLine +
                "Tên ca: " + txtTenCa.Text + Environment.NewLine +
                "Giờ bắt đầu: " + dtpGioBatDau.Value.ToString("HH:mm") + Environment.NewLine +
                "Giờ kết thúc: " + dtpGioKetThuc.Value.ToString("HH:mm") + Environment.NewLine +
                "Qua đêm: " + (chkQuaDem.Checked ? "Có" : "Không"),
                "Chi tiết ca làm");
        }

        private void dgvCaLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvCaLam.Rows[e.RowIndex];
            txtMaCa.Text = Convert.ToString(row.Cells["MaCa"].Value);
            txtTenCa.Text = Convert.ToString(row.Cells["TenCa"].Value);
            dtpGioBatDau.Value = DateTime.Today.Add(TimeSpan.Parse(Convert.ToString(row.Cells["GioBatDau"].Value)));
            dtpGioKetThuc.Value = DateTime.Today.Add(TimeSpan.Parse(Convert.ToString(row.Cells["GioKetThuc"].Value)));
            CapNhatQuaDem(this, EventArgs.Empty);
        }

        private void CapNhatQuaDem(object sender, EventArgs e)
        {
            chkQuaDem.Checked = dtpGioKetThuc.Value.TimeOfDay <= dtpGioBatDau.Value.TimeOfDay;
        }

        private void LamMoiDuLieu()
        {
            try { txtMaCa.Text = LayMaMoi(); }
            catch { txtMaCa.Clear(); }
            txtTenCa.Clear();
            dtpGioBatDau.Value = DateTime.Today.AddHours(6);
            dtpGioKetThuc.Value = DateTime.Today.AddHours(14);
            CapNhatQuaDem(this, EventArgs.Empty);
            dgvCaLam.ClearSelection();
            txtTenCa.Focus();
        }

        private void LocDanhSach(object sender, EventArgs e)
        {
            if (dtCaLam.Columns.Count == 0) return;
            string tuKhoa = txtTimKiem.Text.Trim().Replace("'", "''");
            dtCaLam.DefaultView.RowFilter = "MaCa LIKE '%" + tuKhoa + "%' OR TenCa LIKE '%" + tuKhoa + "%'";
            lblTongSo.Text = "Tổng số: " + dtCaLam.DefaultView.Count + " bản ghi";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            HienThiCaLam();
            LamMoiDuLieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
