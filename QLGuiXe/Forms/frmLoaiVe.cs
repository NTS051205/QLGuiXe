using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmLoaiVe : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();
        private DataTable dtLoaiVe = new DataTable();
        private DataTable dtTheXe = new DataTable();

        public frmLoaiVe()
        {
            InitializeComponent();
        }

        private void frmLoaiVe_Load(object sender, EventArgs e)
        {
            CauHinhDataGridView(dgvLoaiVe);
            CauHinhDataGridView(dgvTheXe);

            cboKyHieu.Items.Add("LUOT");
            cboKyHieu.Items.Add("THANG");
            cboKyHieu.DropDownStyle = ComboBoxStyle.DropDownList;

            cboTrangThai.Items.Add("HOAT_DONG");
            cboTrangThai.Items.Add("KHOA");
            cboTrangThai.Items.Add("HONG");
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            cboLocTrangThai.Items.Add("Tất cả");
            cboLocTrangThai.Items.Add("HOAT_DONG");
            cboLocTrangThai.Items.Add("KHOA");
            cboLocTrangThai.Items.Add("HONG");
            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            cboLocLoaiVe.Items.Add("Tất cả");
            cboLocLoaiVe.Items.Add("LUOT");
            cboLocLoaiVe.Items.Add("THANG");
            cboLocLoaiVe.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpNgayCap.Format = DateTimePickerFormat.Custom;
            dtpNgayCap.CustomFormat = "dd/MM/yyyy";

            try
            {
                LoadLoaiVe();
                LoadTheXe();
                LamMoiLoaiVe();
                LamMoiTheXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
        }

        private void LoadLoaiVe()
        {
            dtLoaiVe = kn.GetData("dbo.sp_LOAIVE_DanhSach");
            dgvLoaiVe.DataSource = dtLoaiVe;
            dgvLoaiVe.Columns["MaLoaiVe"].HeaderText = "Mã loại vé";
            dgvLoaiVe.Columns["TenLoaiVe"].HeaderText = "Tên loại vé";
            dgvLoaiVe.Columns["KyHieu"].HeaderText = "Ký hiệu";

            lblTongLoaiVe.Text = "Tổng số: " + dtLoaiVe.Rows.Count + " bản ghi";
            LoadComboLoaiVe();
            dgvLoaiVe.ClearSelection();
        }

        private void LoadTheXe()
        {
            dtTheXe = kn.GetData("dbo.sp_VE_DanhSach");
            dgvTheXe.DataSource = dtTheXe;
            dgvTheXe.Columns["MaVe"].HeaderText = "Mã vé";
            dgvTheXe.Columns["MaThe"].HeaderText = "Mã thẻ";
            dgvTheXe.Columns["LoaiVe"].HeaderText = "Loại vé";
            dgvTheXe.Columns["NgayCap"].HeaderText = "Ngày cấp";
            dgvTheXe.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvTheXe.Columns["TenLoaiVe"].Visible = false;

            if (dgvTheXe.Columns.Contains("NgayCap"))
                dgvTheXe.Columns["NgayCap"].DefaultCellStyle.Format = "dd/MM/yyyy";

            lblTongTheXe.Text = "Tổng số: " + dtTheXe.Rows.Count + " bản ghi";
            dgvTheXe.ClearSelection();
        }

        private void LoadComboLoaiVe()
        {
            DataTable dt = kn.GetData("dbo.sp_LOAIVE_DanhSach");
            cboLoaiVe.DisplayMember = "KyHieu";
            cboLoaiVe.ValueMember = "MaLoaiVe";
            cboLoaiVe.DataSource = dt;
            cboLoaiVe.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LamMoiLoaiVe()
        {
            txtMaLoaiVe.Text = Convert.ToString(kn.GetData("dbo.sp_LOAIVE_MaMoi").Rows[0]["MaMoi"]);
            txtTenLoaiVe.Clear();
            cboKyHieu.SelectedIndex = 0;
            txtMaLoaiVe.ReadOnly = true;
            dgvLoaiVe.ClearSelection();
            txtTenLoaiVe.Focus();
        }

        private void LamMoiTheXe()
        {
            txtMaVe.Text = Convert.ToString(kn.GetData("dbo.sp_VE_MaMoi").Rows[0]["MaMoi"]);
            txtMaThe.Clear();
            dtpNgayCap.Value = DateTime.Today;
            cboTrangThai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;
            cboLocLoaiVe.SelectedIndex = 0;
            txtMaVe.ReadOnly = true;
            dgvTheXe.ClearSelection();
            txtMaThe.Focus();
        }

        private bool KiemTraLoaiVe()
        {
            if (string.IsNullOrWhiteSpace(txtTenLoaiVe.Text)
                || cboKyHieu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập tên loại vé và chọn ký hiệu.");
                return false;
            }
            return true;
        }

        private bool KiemTraTheXe()
        {
            if (string.IsNullOrWhiteSpace(txtMaThe.Text)
                || cboLoaiVe.SelectedValue == null
                || cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập mã thẻ, loại vé và trạng thái.");
                return false;
            }
            return true;
        }

        private void btnThemLoaiVe_Click(object sender, EventArgs e)
        {
            if (!KiemTraLoaiVe()) return;

            try
            {
                kn.Execute("dbo.sp_LOAIVE_Them", LayThamSoLoaiVe());

                MessageBox.Show("Thêm loại vé thành công.");
                LoadLoaiVe();
                LamMoiLoaiVe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm loại vé: " + ex.Message);
            }
        }

        private void btnSuaLoaiVe_Click(object sender, EventArgs e)
        {
            if (!KiemTraLoaiVe()) return;

            try
            {
                kn.Execute("dbo.sp_LOAIVE_Sua", LayThamSoLoaiVe());

                MessageBox.Show("Sửa loại vé thành công.");
                LoadLoaiVe();
                LoadTheXe();
                LamMoiLoaiVe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa loại vé: " + ex.Message);
            }
        }

        private void btnXoaLoaiVe_Click(object sender, EventArgs e)
        {
            if (dgvLoaiVe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại vé cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa loại vé này?",
                "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                kn.Execute("dbo.sp_LOAIVE_Xoa",
                    new SqlParameter("@MaLoaiVe", txtMaLoaiVe.Text));

                MessageBox.Show("Xóa loại vé thành công.");
                LoadLoaiVe();
                LamMoiLoaiVe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa loại vé đang được sử dụng: " + ex.Message);
            }
        }

        private void btnThemTheXe_Click(object sender, EventArgs e)
        {
            if (!KiemTraTheXe()) return;

            try
            {
                kn.Execute("dbo.sp_VE_Them", LayThamSoTheXe());

                MessageBox.Show("Cấp thẻ xe thành công.");
                LoadTheXe();
                LamMoiTheXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấp thẻ xe: " + ex.Message);
            }
        }

        private void btnSuaTheXe_Click(object sender, EventArgs e)
        {
            if (!KiemTraTheXe()) return;

            try
            {
                kn.Execute("dbo.sp_VE_Sua", LayThamSoTheXe());

                MessageBox.Show("Sửa thẻ xe thành công.");
                LoadTheXe();
                LamMoiTheXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa thẻ xe: " + ex.Message);
            }
        }

        private void btnKhoaTheXe_Click(object sender, EventArgs e)
        {
            if (dgvTheXe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thẻ cần khóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn khóa thẻ này?",
                "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                kn.Execute("dbo.sp_VE_Khoa", new SqlParameter("@MaVe", txtMaVe.Text));
                MessageBox.Show("Khóa thẻ thành công.");
                LoadTheXe();
                LamMoiTheXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khóa thẻ: " + ex.Message);
            }
        }

        private void dgvLoaiVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLoaiVe.Rows[e.RowIndex];
            txtMaLoaiVe.Text = Convert.ToString(row.Cells["MaLoaiVe"].Value);
            txtTenLoaiVe.Text = Convert.ToString(row.Cells["TenLoaiVe"].Value);
            cboKyHieu.Text = Convert.ToString(row.Cells["KyHieu"].Value);
        }

        private void dgvTheXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvTheXe.Rows[e.RowIndex];
            txtMaVe.Text = Convert.ToString(row.Cells["MaVe"].Value);
            txtMaThe.Text = Convert.ToString(row.Cells["MaThe"].Value);
            cboLoaiVe.Text = Convert.ToString(row.Cells["LoaiVe"].Value);
            dtpNgayCap.Value = Convert.ToDateTime(row.Cells["NgayCap"].Value);
            cboTrangThai.Text = Convert.ToString(row.Cells["TrangThai"].Value);
        }

        private void txtTimKiemLoaiVe_TextChanged(object sender, EventArgs e)
        {
            if (dtLoaiVe.DefaultView == null) return;
            string tuKhoa = txtTimKiemLoaiVe.Text.Trim().Replace("'", "''");
            dtLoaiVe.DefaultView.RowFilter =
                "MaLoaiVe LIKE '%" + tuKhoa + "%' OR TenLoaiVe LIKE '%" + tuKhoa + "%'";
            lblTongLoaiVe.Text = "Tổng số: " + dtLoaiVe.DefaultView.Count + " bản ghi";
        }

        private void LocTheXe(object sender, EventArgs e)
        {
            if (dtTheXe.DefaultView == null) return;

            string tuKhoa = txtTimKiemTheXe.Text.Trim().Replace("'", "''");
            string dieuKien = "(MaVe LIKE '%" + tuKhoa
                + "%' OR MaThe LIKE '%" + tuKhoa + "%')";

            if (cboLocTrangThai.SelectedIndex > 0)
                dieuKien += " AND TrangThai = '" + cboLocTrangThai.Text + "'";
            if (cboLocLoaiVe.SelectedIndex > 0)
                dieuKien += " AND LoaiVe = '" + cboLocLoaiVe.Text + "'";

            dtTheXe.DefaultView.RowFilter = dieuKien;
            lblTongTheXe.Text = "Tổng số: " + dtTheXe.DefaultView.Count + " bản ghi";
        }

        private void btnLamMoiLoaiVe_Click(object sender, EventArgs e)
        {
            txtTimKiemLoaiVe.Clear();
            LoadLoaiVe();
            LamMoiLoaiVe();
        }

        private void btnLamMoiTheXe_Click(object sender, EventArgs e)
        {
            txtTimKiemTheXe.Clear();
            LoadTheXe();
            LamMoiTheXe();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private SqlParameter[] LayThamSoLoaiVe()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@MaLoaiVe", txtMaLoaiVe.Text.Trim()),
                new SqlParameter("@TenLoaiVe", txtTenLoaiVe.Text.Trim()),
                new SqlParameter("@KyHieu", cboKyHieu.Text)
            };
        }

        private SqlParameter[] LayThamSoTheXe()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@MaVe", txtMaVe.Text.Trim()),
                new SqlParameter("@MaThe", txtMaThe.Text.Trim()),
                new SqlParameter("@MaLoaiVe", cboLoaiVe.SelectedValue),
                new SqlParameter("@NgayCap", dtpNgayCap.Value.Date),
                new SqlParameter("@TrangThai", cboTrangThai.Text)
            };
        }
    }
}
