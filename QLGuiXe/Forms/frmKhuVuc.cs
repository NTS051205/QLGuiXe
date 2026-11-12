using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmKhuVuc : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataTable dtKhuVuc = new DataTable();

        public frmKhuVuc()
        {
            InitializeComponent();
        }

        private void frmKhuVuc_Load(object sender, EventArgs e)
        {
            cboLoaiXe.Items.AddRange(
                new object[] { "Xe máy", "Ô tô" }
            );

            cboTrangThai.Items.AddRange(
                new object[] { "HOAT_DONG", "BAO_TRI", "TAM_DONG" }
            );

            cboLocLoaiXe.Items.AddRange(
                new object[] { "Tất cả", "Xe máy", "Ô tô" }
            );

            cboLocTrangThai.Items.AddRange(
                new object[] { "Tất cả", "HOAT_DONG", "BAO_TRI", "TAM_DONG" }
            );

            cboLoaiXe.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            cboLocLoaiXe.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;

            dgvKhuVuc.ReadOnly = true;
            dgvKhuVuc.AllowUserToAddRows = false;
            dgvKhuVuc.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvKhuVuc.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuVuc.MultiSelect = false;

            HienThiKhuVuc();
            LamMoiDuLieu();
        }

        private void HienThiKhuVuc()
        {
            try
            {
                dtKhuVuc =
                    kn.GetData("dbo.sp_KHUVUC_DanhSach");

                dgvKhuVuc.DataSource =
                    dtKhuVuc;

                dgvKhuVuc.Columns["MaKhuVuc"].HeaderText =
                    "Mã khu vực";

                dgvKhuVuc.Columns["TenKhuVuc"].HeaderText =
                    "Tên khu vực";

                dgvKhuVuc.Columns["LoaiXe"].HeaderText =
                    "Loại xe";

                dgvKhuVuc.Columns["SucChua"].HeaderText =
                    "Sức chứa";

                dgvKhuVuc.Columns["DangGui"].HeaderText =
                    "Đang gửi";

                dgvKhuVuc.Columns["ConTrong"].HeaderText =
                    "Còn trống";

                dgvKhuVuc.Columns["TrangThai"].HeaderText =
                    "Trạng thái";

                LocDanhSach(
                    this,
                    EventArgs.Empty
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải khu vực: "
                    + ex.Message
                );
            }
        }

        private bool KiemTraDuLieu()
        {
            if (txtMaKhuVuc.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập mã khu vực!"
                );

                txtMaKhuVuc.Focus();

                return false;
            }

            if (txtTenKhuVuc.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập tên khu vực!"
                );

                txtTenKhuVuc.Focus();

                return false;
            }

            if (nudSucChua.Value <= 0)
            {
                MessageBox.Show(
                    "Sức chứa phải lớn hơn 0!"
                );

                nudSucChua.Focus();

                return false;
            }

            return true;
        }

        private bool KiemTraTrungMaKhuVuc()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_KHUVUC_DanhSach"
                );

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maKhuVuc =
                    Convert.ToString(
                        dt.Rows[i]["MaKhuVuc"]
                    );

                if (maKhuVuc == txtMaKhuVuc.Text.Trim())
                {
                    MessageBox.Show(
                        "Mã khu vực này đã tồn tại!"
                    );

                    txtMaKhuVuc.Focus();

                    return false;
                }
            }

            return true;
        }

        private SqlParameter[] LayThamSo()
        {
            SqlParameter[] thamSo =
            {
                new SqlParameter(
                    "@MaKhuVuc",
                    txtMaKhuVuc.Text.Trim()
                ),

                new SqlParameter(
                    "@TenKhuVuc",
                    txtTenKhuVuc.Text.Trim()
                ),

                new SqlParameter(
                    "@LoaiXe",
                    cboLoaiXe.Text
                ),

                new SqlParameter(
                    "@SucChua",
                    Convert.ToInt32(
                        nudSucChua.Value
                    )
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
            if (KiemTraDuLieu() == false)
            {
                return;
            }

            if (KiemTraTrungMaKhuVuc() == false)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_KHUVUC_Them",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Thêm khu vực thành công!"
                );

                HienThiKhuVuc();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thêm: "
                    + ex.Message
                );
            }
        }

        private void btnSua_Click(
            object sender,
            EventArgs e)
        {
            if (dgvKhuVuc.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khu vực cần sửa!"
                );

                return;
            }

            if (KiemTraDuLieu() == false)
            {
                return;
            }

            if (nudSucChua.Value
                < Convert.ToInt32(
                    lblDangGuiValue.Text
                ))
            {
                MessageBox.Show(
                    "Sức chứa không được nhỏ hơn số xe đang gửi!"
                );

                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_KHUVUC_Sua",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Sửa khu vực thành công!"
                );

                HienThiKhuVuc();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa: "
                    + ex.Message
                );
            }
        }

        private void btnXem_Click(
            object sender,
            EventArgs e)
        {
            if (dgvKhuVuc.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khu vực cần xem!"
                );

                return;
            }

            MessageBox.Show(
                "Mã khu vực: "
                + txtMaKhuVuc.Text
                + Environment.NewLine
                + "Tên khu vực: "
                + txtTenKhuVuc.Text
                + Environment.NewLine
                + "Loại xe: "
                + cboLoaiXe.Text
                + Environment.NewLine
                + "Sức chứa: "
                + nudSucChua.Value
                + Environment.NewLine
                + "Đang gửi: "
                + lblDangGuiValue.Text
                + Environment.NewLine
                + "Còn trống: "
                + lblConTrongValue.Text
                + Environment.NewLine
                + "Trạng thái: "
                + cboTrangThai.Text,
                "Chi tiết khu vực"
            );
        }

        private void dgvKhuVuc_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvKhuVuc.Rows[e.RowIndex];

            txtMaKhuVuc.Text =
                Convert.ToString(
                    row.Cells["MaKhuVuc"].Value
                );

            txtMaKhuVuc.ReadOnly = true;

            txtTenKhuVuc.Text =
                Convert.ToString(
                    row.Cells["TenKhuVuc"].Value
                );

            cboLoaiXe.Text =
                Convert.ToString(
                    row.Cells["LoaiXe"].Value
                );

            nudSucChua.Value =
                Convert.ToDecimal(
                    row.Cells["SucChua"].Value
                );

            lblDangGuiValue.Text =
                Convert.ToString(
                    row.Cells["DangGui"].Value
                );

            lblConTrongValue.Text =
                Convert.ToString(
                    row.Cells["ConTrong"].Value
                );

            cboTrangThai.Text =
                Convert.ToString(
                    row.Cells["TrangThai"].Value
                );
        }

        private void LamMoiDuLieu()
        {
            txtMaKhuVuc.Clear();
            txtTenKhuVuc.Clear();

            cboLoaiXe.SelectedIndex = 0;

            nudSucChua.Value = 1;

            cboTrangThai.SelectedIndex = 0;

            lblDangGuiValue.Text = "0";
            lblConTrongValue.Text = "0";

            txtMaKhuVuc.ReadOnly = false;

            dgvKhuVuc.ClearSelection();
        }

        private void LocDanhSach(
            object sender,
            EventArgs e)
        {
            if (dtKhuVuc.Columns.Count == 0)
            {
                return;
            }

            string tuKhoa =
                txtTimKiem.Text
                .Trim()
                .Replace("'", "''");

            string dieuKien =
                "(MaKhuVuc LIKE '%"
                + tuKhoa
                + "%' OR TenKhuVuc LIKE '%"
                + tuKhoa
                + "%')";

            if (cboLocLoaiXe.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND LoaiXe='"
                    + cboLocLoaiXe.Text
                    + "'";
            }

            if (cboLocTrangThai.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND TrangThai='"
                    + cboLocTrangThai.Text
                    + "'";
            }

            dtKhuVuc.DefaultView.RowFilter =
                dieuKien;

            lblTongSo.Text =
                "Tổng số: "
                + dtKhuVuc.DefaultView.Count
                + " bản ghi";
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();

            cboLocLoaiXe.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;

            HienThiKhuVuc();
            LamMoiDuLieu();
        }

        private void btnThoat_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}