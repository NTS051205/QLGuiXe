using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmLoaiVe : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataTable dtLoaiVe = new DataTable();
        DataTable dtTheXe = new DataTable();

        public frmLoaiVe()
        {
            InitializeComponent();
        }

        private void frmLoaiVe_Load(
            object sender,
            EventArgs e)
        {
            CauHinhDataGridView(dgvLoaiVe);
            CauHinhDataGridView(dgvTheXe);

            cboKyHieu.Items.Add("LUOT");
            cboKyHieu.Items.Add("THANG");

            cboTrangThai.Items.Add("HOAT_DONG");
            cboTrangThai.Items.Add("KHOA");
            cboTrangThai.Items.Add("HONG");

            cboLocTrangThai.Items.Add("Tất cả");
            cboLocTrangThai.Items.Add("HOAT_DONG");
            cboLocTrangThai.Items.Add("KHOA");
            cboLocTrangThai.Items.Add("HONG");

            cboLocLoaiVe.Items.Add("Tất cả");
            cboLocLoaiVe.Items.Add("LUOT");
            cboLocLoaiVe.Items.Add("THANG");

            dtpNgayCap.Format =
                DateTimePickerFormat.Custom;

            dtpNgayCap.CustomFormat =
                "dd/MM/yyyy";

            try
            {
                LoadLoaiVe();
                LoadTheXe();

                LamMoiLoaiVe();
                LamMoiTheXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu: "
                    + ex.Message
                );
            }
        }

        private void CauHinhDataGridView(
            DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv.MultiSelect = false;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.RowHeadersVisible = false;
        }

        private void LoadLoaiVe()
        {
            dtLoaiVe =
                kn.GetData(
                    "dbo.sp_LOAIVE_DanhSach"
                );

            dgvLoaiVe.DataSource =
                dtLoaiVe;

            dgvLoaiVe.Columns["MaLoaiVe"].HeaderText =
                "Mã loại vé";

            dgvLoaiVe.Columns["TenLoaiVe"].HeaderText =
                "Tên loại vé";

            dgvLoaiVe.Columns["KyHieu"].HeaderText =
                "Ký hiệu";

            lblTongLoaiVe.Text =
                "Tổng số: "
                + dtLoaiVe.Rows.Count
                + " bản ghi";

            LoadComboLoaiVe();

            dgvLoaiVe.ClearSelection();
        }

        private void LoadTheXe()
        {
            dtTheXe =
                kn.GetData(
                    "dbo.sp_VE_DanhSach"
                );

            dgvTheXe.DataSource =
                dtTheXe;

            dgvTheXe.Columns["MaVe"].HeaderText =
                "Mã vé";

            dgvTheXe.Columns["MaThe"].HeaderText =
                "Mã thẻ";

            dgvTheXe.Columns["LoaiVe"].HeaderText =
                "Loại vé";

            dgvTheXe.Columns["NgayCap"].HeaderText =
                "Ngày cấp";

            dgvTheXe.Columns["TrangThai"].HeaderText =
                "Trạng thái";

            if (dgvTheXe.Columns.Contains("TenLoaiVe"))
            {
                dgvTheXe.Columns["TenLoaiVe"].Visible =
                    false;
            }

            if (dgvTheXe.Columns.Contains("NgayCap"))
            {
                dgvTheXe.Columns["NgayCap"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy";
            }

            lblTongTheXe.Text =
                "Tổng số: "
                + dtTheXe.Rows.Count
                + " bản ghi";

            dgvTheXe.ClearSelection();
        }

        private void LoadComboLoaiVe()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_LOAIVE_DanhSach"
                );

            cboLoaiVe.DisplayMember =
                "KyHieu";

            cboLoaiVe.ValueMember =
                "MaLoaiVe";

            cboLoaiVe.DataSource =
                dt;
        }

        private void LamMoiLoaiVe()
        {
            txtMaLoaiVe.Clear();
            txtTenLoaiVe.Clear();

            if (cboKyHieu.Items.Count > 0)
            {
                cboKyHieu.SelectedIndex =
                    0;
            }

            cboKyHieu.Enabled =
                true;

            dgvLoaiVe.ClearSelection();

            txtTenLoaiVe.Focus();
        }

        private void LamMoiTheXe()
        {
            try
            {
                DataTable dt =
                    kn.GetData(
                        "dbo.sp_VE_MaMoi"
                    );

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["MaMoi"]
                        != DBNull.Value)
                    {
                        txtMaVe.Text =
                            Convert.ToString(
                                dt.Rows[0]["MaMoi"]
                            );
                    }
                    else
                    {
                        txtMaVe.Clear();
                    }
                }
                else
                {
                    txtMaVe.Clear();
                }
            }
            catch
            {
                txtMaVe.Clear();
            }

            txtMaThe.Clear();

            dtpNgayCap.Value =
                DateTime.Today;

            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex =
                    0;
            }

            if (cboLocTrangThai.Items.Count > 0)
            {
                cboLocTrangThai.SelectedIndex =
                    0;
            }

            if (cboLocLoaiVe.Items.Count > 0)
            {
                cboLocLoaiVe.SelectedIndex =
                    0;
            }

            if (cboLoaiVe.Items.Count > 0)
            {
                cboLoaiVe.SelectedIndex =
                    0;
            }

            dgvTheXe.ClearSelection();

            txtMaThe.Focus();
        }

        private bool KiemTraLoaiVe()
        {
            if (txtMaLoaiVe.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng chọn loại vé cần sửa."
                );

                return false;
            }

            if (txtTenLoaiVe.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập tên loại vé."
                );

                txtTenLoaiVe.Focus();

                return false;
            }

            if (cboKyHieu.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Không xác định được ký hiệu loại vé."
                );

                return false;
            }

            return true;
        }

        private bool KiemTraTheXe()
        {
            if (txtMaThe.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập mã thẻ."
                );

                txtMaThe.Focus();

                return false;
            }

            if (cboLoaiVe.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn loại vé."
                );

                cboLoaiVe.Focus();

                return false;
            }

            if (cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn trạng thái."
                );

                cboTrangThai.Focus();

                return false;
            }

            return true;
        }

        private bool KiemTraTrungLoaiVeKhiSua()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_LOAIVE_DanhSach"
                );

            for (int i = 0;
                i < dt.Rows.Count;
                i++)
            {
                string maLoaiVe =
                    Convert.ToString(
                        dt.Rows[i]["MaLoaiVe"]
                    ).Trim();

                if (maLoaiVe
                    != txtMaLoaiVe.Text.Trim())
                {
                    if (Convert.ToString(
                        dt.Rows[i]["TenLoaiVe"])
                        .Trim()
                        .ToUpper()
                        ==
                        txtTenLoaiVe.Text
                        .Trim()
                        .ToUpper())
                    {
                        MessageBox.Show(
                            "Tên loại vé đã tồn tại!"
                        );

                        txtTenLoaiVe.Focus();

                        return true;
                    }
                }
            }

            return false;
        }

        private bool KiemTraTrungTheXeKhiThem()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_VE_DanhSach"
                );

            for (int i = 0;
                i < dt.Rows.Count;
                i++)
            {
                if (Convert.ToString(
                    dt.Rows[i]["MaVe"])
                    .Trim()
                    == txtMaVe.Text.Trim())
                {
                    MessageBox.Show(
                        "Mã vé đã tồn tại!"
                    );

                    return true;
                }

                if (Convert.ToString(
                    dt.Rows[i]["MaThe"])
                    .Trim()
                    .ToUpper()
                    ==
                    txtMaThe.Text
                    .Trim()
                    .ToUpper())
                {
                    MessageBox.Show(
                        "Mã thẻ đã tồn tại!"
                    );

                    txtMaThe.Focus();

                    return true;
                }
            }

            return false;
        }

        private bool KiemTraTrungTheXeKhiSua()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_VE_DanhSach"
                );

            for (int i = 0;
                i < dt.Rows.Count;
                i++)
            {
                string maVe =
                    Convert.ToString(
                        dt.Rows[i]["MaVe"]
                    ).Trim();

                if (maVe
                    != txtMaVe.Text.Trim())
                {
                    if (Convert.ToString(
                        dt.Rows[i]["MaThe"])
                        .Trim()
                        .ToUpper()
                        ==
                        txtMaThe.Text
                        .Trim()
                        .ToUpper())
                    {
                        MessageBox.Show(
                            "Mã thẻ đã tồn tại!"
                        );

                        txtMaThe.Focus();

                        return true;
                    }
                }
            }

            return false;
        }

        private SqlParameter[] LayThamSoLoaiVe()
        {
            SqlParameter[] thamSo =
            {
                new SqlParameter(
                    "@MaLoaiVe",
                    txtMaLoaiVe.Text.Trim()
                ),

                new SqlParameter(
                    "@TenLoaiVe",
                    txtTenLoaiVe.Text.Trim()
                ),

                new SqlParameter(
                    "@KyHieu",
                    cboKyHieu.Text
                )
            };

            return thamSo;
        }

        private SqlParameter[] LayThamSoTheXe()
        {
            SqlParameter[] thamSo =
            {
                new SqlParameter(
                    "@MaVe",
                    txtMaVe.Text.Trim()
                ),

                new SqlParameter(
                    "@MaThe",
                    txtMaThe.Text.Trim()
                ),

                new SqlParameter(
                    "@MaLoaiVe",
                    cboLoaiVe.SelectedValue
                ),

                new SqlParameter(
                    "@NgayCap",
                    dtpNgayCap.Value.Date
                ),

                new SqlParameter(
                    "@TrangThai",
                    cboTrangThai.Text
                )
            };

            return thamSo;
        }

        private void btnSuaLoaiVe_Click(
            object sender,
            EventArgs e)
        {
            if (dgvLoaiVe.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn loại vé cần sửa."
                );

                return;
            }

            if (KiemTraLoaiVe() == false)
            {
                return;
            }

            try
            {
                if (KiemTraTrungLoaiVeKhiSua() == true)
                {
                    return;
                }

                kn.Execute(
                    "dbo.sp_LOAIVE_Sua",
                    LayThamSoLoaiVe()
                );

                MessageBox.Show(
                    "Sửa loại vé thành công."
                );

                LoadLoaiVe();
                LoadTheXe();
                LamMoiLoaiVe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa loại vé: "
                    + ex.Message
                );
            }
        }

        private void btnThemTheXe_Click(
            object sender,
            EventArgs e)
        {
            if (KiemTraTheXe() == false)
            {
                return;
            }

            try
            {
                if (KiemTraTrungTheXeKhiThem() == true)
                {
                    return;
                }

                kn.Execute(
                    "dbo.sp_VE_Them",
                    LayThamSoTheXe()
                );

                MessageBox.Show(
                    "Cấp thẻ xe thành công."
                );

                LoadTheXe();
                LamMoiTheXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi cấp thẻ xe: "
                    + ex.Message
                );
            }
        }

        private void btnSuaTheXe_Click(
            object sender,
            EventArgs e)
        {
            if (dgvTheXe.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn thẻ xe cần sửa."
                );

                return;
            }

            if (KiemTraTheXe() == false)
            {
                return;
            }

            try
            {
                if (KiemTraTrungTheXeKhiSua() == true)
                {
                    return;
                }

                kn.Execute(
                    "dbo.sp_VE_Sua",
                    LayThamSoTheXe()
                );

                MessageBox.Show(
                    "Sửa thẻ xe thành công."
                );

                LoadTheXe();
                LamMoiTheXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa thẻ xe: "
                    + ex.Message
                );
            }
        }

        private void btnKhoaTheXe_Click(
            object sender,
            EventArgs e)
        {
            if (dgvTheXe.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn thẻ cần khóa."
                );

                return;
            }

            DialogResult ketQua =
                MessageBox.Show(
                    "Bạn có chắc chắn muốn khóa thẻ này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (ketQua == DialogResult.No)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_VE_Khoa",

                    new SqlParameter(
                        "@MaVe",
                        txtMaVe.Text.Trim()
                    )
                );

                MessageBox.Show(
                    "Khóa thẻ thành công."
                );

                LoadTheXe();
                LamMoiTheXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khóa thẻ: "
                    + ex.Message
                );
            }
        }

        private void dgvLoaiVe_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvLoaiVe.Rows[e.RowIndex];

            txtMaLoaiVe.Text =
                Convert.ToString(
                    row.Cells["MaLoaiVe"].Value
                );

            txtTenLoaiVe.Text =
                Convert.ToString(
                    row.Cells["TenLoaiVe"].Value
                );

            cboKyHieu.Text =
                Convert.ToString(
                    row.Cells["KyHieu"].Value
                );

            cboKyHieu.Enabled =
                false;

            txtTenLoaiVe.Focus();
        }

        private void dgvTheXe_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvTheXe.Rows[e.RowIndex];

            txtMaVe.Text =
                Convert.ToString(
                    row.Cells["MaVe"].Value
                );

            txtMaThe.Text =
                Convert.ToString(
                    row.Cells["MaThe"].Value
                );

            cboLoaiVe.Text =
                Convert.ToString(
                    row.Cells["LoaiVe"].Value
                );

            if (row.Cells["NgayCap"].Value
                != null
                &&
                row.Cells["NgayCap"].Value
                != DBNull.Value)
            {
                dtpNgayCap.Value =
                    Convert.ToDateTime(
                        row.Cells["NgayCap"].Value
                    );
            }

            cboTrangThai.Text =
                Convert.ToString(
                    row.Cells["TrangThai"].Value
                );
        }

        private void txtTimKiemLoaiVe_TextChanged(
            object sender,
            EventArgs e)
        {
            if (dtLoaiVe.Columns.Count == 0)
            {
                return;
            }

            string tuKhoa =
                txtTimKiemLoaiVe.Text
                .Trim()
                .Replace(
                    "'",
                    "''"
                );

            dtLoaiVe.DefaultView.RowFilter =
                "MaLoaiVe LIKE '%"
                + tuKhoa
                + "%' OR TenLoaiVe LIKE '%"
                + tuKhoa
                + "%'";

            lblTongLoaiVe.Text =
                "Tổng số: "
                + dtLoaiVe.DefaultView.Count
                + " bản ghi";
        }

        private void btnLamMoiLoaiVe_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiemLoaiVe.Clear();

            LoadLoaiVe();
            LoadTheXe();
            LamMoiLoaiVe();
        }

        private void LocTheXe(
            object sender,
            EventArgs e)
        {
            if (dtTheXe.Columns.Count == 0)
            {
                return;
            }

            string tuKhoa =
                txtTimKiemTheXe.Text
                .Trim()
                .Replace(
                    "'",
                    "''"
                );

            string dieuKien =
                "(MaVe LIKE '%"
                + tuKhoa
                + "%' OR MaThe LIKE '%"
                + tuKhoa
                + "%')";

            if (cboLocTrangThai.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND TrangThai = '"
                    + cboLocTrangThai.Text
                    + "'";
            }

            if (cboLocLoaiVe.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND LoaiVe = '"
                    + cboLocLoaiVe.Text
                    + "'";
            }

            dtTheXe.DefaultView.RowFilter =
                dieuKien;

            lblTongTheXe.Text =
                "Tổng số: "
                + dtTheXe.DefaultView.Count
                + " bản ghi";
        }

        private void btnLamMoiTheXe_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiemTheXe.Clear();

            LoadTheXe();
            LamMoiTheXe();
        }

        private void btnThoat_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}