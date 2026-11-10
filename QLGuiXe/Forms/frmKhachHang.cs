using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmKhachHang : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();
        private DataTable dtKhachHang = new DataTable();

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.MultiSelect = false;

            HienThiKhachHang();
            LamMoiDuLieu();
        }

        private void HienThiKhachHang()
        {
            try
            {
                dtKhachHang = kn.GetData("dbo.sp_KHACHHANG_DanhSach");
                dgvKhachHang.DataSource = dtKhachHang;
                dgvKhachHang.Columns["MaKH"].HeaderText = "Mã khách hàng";
                dgvKhachHang.Columns["HoTen"].HeaderText = "Họ tên";
                dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                LocDanhSach(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
            }
        }

        private string LayMaMoi()
        {
            DataTable dt = kn.GetData("dbo.sp_KHACHHANG_MaMoi");
            return Convert.ToString(dt.Rows[0]["MaMoi"]);
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!");
                return false;
            }

            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (soDienThoai.Length < 9 || soDienThoai.Length > 11 || !soDienThoai.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải gồm 9 đến 11 chữ số!");
                return false;
            }

            return true;
        }

        private SqlParameter[] LayThamSo()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@MaKH", txtMaKH.Text.Trim()),
                new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                new SqlParameter("@SoDienThoai", txtSoDienThoai.Text.Trim())
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            try
            {
                kn.Execute("dbo.sp_KHACHHANG_Them", LayThamSo());
                MessageBox.Show("Thêm khách hàng thành công!");
                HienThiKhachHang();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
                return;
            }
            if (!KiemTraDuLieu()) return;

            try
            {
                kn.Execute("dbo.sp_KHACHHANG_Sua", LayThamSo());
                MessageBox.Show("Sửa khách hàng thành công!");
                HienThiKhachHang();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
                return;
            }

            if (MessageBox.Show("Xóa khách hàng đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                kn.Execute("dbo.sp_KHACHHANG_Xoa",
                    new SqlParameter("@MaKH", txtMaKH.Text));
                HienThiKhachHang();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xem!");
                return;
            }

            MessageBox.Show(
                "Mã khách hàng: " + txtMaKH.Text + Environment.NewLine +
                "Họ tên: " + txtHoTen.Text + Environment.NewLine +
                "Số điện thoại: " + txtSoDienThoai.Text,
                "Chi tiết khách hàng");
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
            txtMaKH.Text = Convert.ToString(row.Cells["MaKH"].Value);
            txtHoTen.Text = Convert.ToString(row.Cells["HoTen"].Value);
            txtSoDienThoai.Text = Convert.ToString(row.Cells["SoDienThoai"].Value);
        }

        private void LamMoiDuLieu()
        {
            try { txtMaKH.Text = LayMaMoi(); }
            catch { txtMaKH.Clear(); }

            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dgvKhachHang.ClearSelection();
            txtHoTen.Focus();
        }

        private void LocDanhSach(object sender, EventArgs e)
        {
            if (dtKhachHang.Columns.Count == 0) return;

            string tuKhoa = txtTimKiem.Text.Trim().Replace("'", "''");
            dtKhachHang.DefaultView.RowFilter =
                "MaKH LIKE '%" + tuKhoa + "%' OR HoTen LIKE '%" + tuKhoa
                + "%' OR SoDienThoai LIKE '%" + tuKhoa + "%'";
            lblTongSo.Text = "Tổng số: " + dtKhachHang.DefaultView.Count + " bản ghi";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            HienThiKhachHang();
            LamMoiDuLieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
