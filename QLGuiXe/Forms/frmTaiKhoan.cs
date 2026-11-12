using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmTaiKhoan : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataTable dtTaiKhoan = new DataTable();

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            cboVaiTro.Items.AddRange(
                new object[] { "ADMIN", "NHANVIEN" }
            );

            cboTrangThai.Items.AddRange(
                new object[] { "HOAT_DONG", "KHOA" }
            );

            cboLocVaiTro.Items.AddRange(
                new object[] { "Tất cả", "ADMIN", "NHANVIEN" }
            );

            cboLocTrangThai.Items.AddRange(
                new object[] { "Tất cả", "HOAT_DONG", "KHOA" }
            );

            LoadNhanVien();

            cboVaiTro.SelectedIndex = 1;
            cboTrangThai.SelectedIndex = 0;
            cboLocVaiTro.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;

            CauHinhLuoi();
            LoadDanhSach();
            LamMoiNhapLieu();
        }

        private void LoadNhanVien()
        {
            DataTable dt =
                kn.GetData("dbo.sp_TAIKHOAN_NhanVien");

            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
        }

        private void CauHinhLuoi()
        {
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.AllowUserToDeleteRows = false;

            dgvTaiKhoan.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTaiKhoan.MultiSelect = false;

            dgvTaiKhoan.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTaiKhoan.RowHeadersVisible = false;
        }

        private void LoadDanhSach()
        {
            try
            {
                dtTaiKhoan =
                    kn.GetData("dbo.sp_TAIKHOAN_DanhSach");

                dgvTaiKhoan.DataSource =
                    dtTaiKhoan;

                dgvTaiKhoan.Columns["MaTK"].HeaderText =
                    "Mã tài khoản";

                dgvTaiKhoan.Columns["TenDangNhap"].HeaderText =
                    "Tên đăng nhập";

                dgvTaiKhoan.Columns["NhanVien"].HeaderText =
                    "Nhân viên sở hữu";

                dgvTaiKhoan.Columns["VaiTro"].HeaderText =
                    "Vai trò";

                dgvTaiKhoan.Columns["TrangThai"].HeaderText =
                    "Trạng thái";

                LocDanhSach(
                    this,
                    EventArgs.Empty
                );
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void LamMoiNhapLieu()
        {
            try
            {
                DataTable dt =
                    kn.GetData(
                        "dbo.sp_TAIKHOAN_MaMoi"
                    );

                txtMaTK.Text =
                    Convert.ToString(
                        dt.Rows[0]["MaMoi"]
                    );
            }
            catch
            {
                txtMaTK.Clear();
            }

            if (cboNhanVien.Items.Count > 0)
            {
                cboNhanVien.SelectedIndex = 0;
            }

            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtXacNhan.Clear();

            cboVaiTro.SelectedIndex = 1;
            cboTrangThai.SelectedIndex = 0;

            dgvTaiKhoan.ClearSelection();
        }

        private bool KiemTraNhapLieu(
            bool batBuocMatKhau)
        {
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên."
                );

                cboNhanVien.Focus();

                return false;
            }

            if (txtTenDangNhap.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập tên đăng nhập."
                );

                txtTenDangNhap.Focus();

                return false;
            }

            if (batBuocMatKhau == true)
            {
                if (txtMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Vui lòng nhập mật khẩu."
                    );

                    txtMatKhau.Focus();

                    return false;
                }
            }

            if (txtMatKhau.Text != txtXacNhan.Text)
            {
                MessageBox.Show(
                    "Mật khẩu xác nhận không khớp."
                );

                txtXacNhan.Focus();

                return false;
            }

            return true;
        }

        private SqlParameter[] LayThamSo()
        {
            SqlParameter[] thamSo =
            {
                new SqlParameter(
                    "@MaTK",
                    txtMaTK.Text
                ),

                new SqlParameter(
                    "@TenDangNhap",
                    txtTenDangNhap.Text.Trim()
                ),

                new SqlParameter(
                    "@MatKhau",
                    txtMatKhau.Text
                ),

                new SqlParameter(
                    "@MaNV",
                    cboNhanVien.SelectedValue
                ),

                new SqlParameter(
                    "@VaiTro",
                    cboVaiTro.Text
                ),

                new SqlParameter(
                    "@TrangThai",
                    cboTrangThai.Text
                )
            };

            return thamSo;
        }

        private void btnThem_Click(
            object sender,
            EventArgs e)
        {
            if (KiemTraNhapLieu(true) == false)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_TAIKHOAN_Them",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Tạo tài khoản thành công."
                );

                LoadDanhSach();
                LamMoiNhapLieu();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnSua_Click(
            object sender,
            EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn tài khoản cần sửa."
                );

                return;
            }

            if (KiemTraNhapLieu(false) == false)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_TAIKHOAN_Sua",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Cập nhật tài khoản thành công."
                );

                LoadDanhSach();
                LamMoiNhapLieu();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnKhoa_Click(
            object sender,
            EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn tài khoản cần khóa."
                );

                return;
            }

            DialogResult ketQua =
                MessageBox.Show(
                    "Khóa tài khoản đã chọn?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_TAIKHOAN_Khoa",

                    new SqlParameter(
                        "@MaTK",
                        txtMaTK.Text
                    )
                );

                MessageBox.Show(
                    "Khóa tài khoản thành công."
                );

                LoadDanhSach();
                LamMoiNhapLieu();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnXem_Click(
            object sender,
            EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn tài khoản cần xem."
                );

                return;
            }

            MessageBox.Show(
                "Mã tài khoản: "
                + txtMaTK.Text
                + Environment.NewLine
                + "Tên đăng nhập: "
                + txtTenDangNhap.Text
                + Environment.NewLine
                + "Nhân viên: "
                + cboNhanVien.Text
                + Environment.NewLine
                + "Vai trò: "
                + cboVaiTro.Text
                + Environment.NewLine
                + "Trạng thái: "
                + cboTrangThai.Text,
                "Chi tiết tài khoản",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void dgvTaiKhoan_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvTaiKhoan.Rows[e.RowIndex];

            txtMaTK.Text =
                Convert.ToString(
                    row.Cells["MaTK"].Value
                );

            txtTenDangNhap.Text =
                Convert.ToString(
                    row.Cells["TenDangNhap"].Value
                );

            cboNhanVien.Text =
                Convert.ToString(
                    row.Cells["NhanVien"].Value
                );

            cboVaiTro.Text =
                Convert.ToString(
                    row.Cells["VaiTro"].Value
                );

            cboTrangThai.Text =
                Convert.ToString(
                    row.Cells["TrangThai"].Value
                );

            txtMatKhau.Clear();
            txtXacNhan.Clear();
        }

        private void LocDanhSach(
            object sender,
            EventArgs e)
        {
            if (dtTaiKhoan.Columns.Count == 0)
            {
                return;
            }

            string tuKhoa =
                txtTimKiem.Text
                .Trim()
                .Replace("'", "''");

            string dieuKien =
                "(MaTK LIKE '%"
                + tuKhoa
                + "%' OR TenDangNhap LIKE '%"
                + tuKhoa
                + "%' OR NhanVien LIKE '%"
                + tuKhoa
                + "%')";

            if (cboLocVaiTro.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND VaiTro='"
                    + cboLocVaiTro.Text
                    + "'";
            }

            if (cboLocTrangThai.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND TrangThai='"
                    + cboLocTrangThai.Text
                    + "'";
            }

            dtTaiKhoan.DefaultView.RowFilter =
                dieuKien;

            lblTongSo.Text =
                "Tổng số: "
                + dtTaiKhoan.DefaultView.Count
                + " bản ghi";
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();

            cboLocVaiTro.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;

            LoadDanhSach();
            LamMoiNhapLieu();
        }

        private void btnThoat_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void BaoLoi(Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Không thể cập nhật SQL Server",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }
}