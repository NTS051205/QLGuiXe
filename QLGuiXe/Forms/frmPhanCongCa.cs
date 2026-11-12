using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmPhanCongCa : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataTable dtPhanCong = new DataTable();

        public frmPhanCongCa()
        {
            InitializeComponent();
        }

        private void frmPhanCongCa_Load(object sender, EventArgs e)
        {
            dtpNgayLam.Value = DateTime.Today;
            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today.AddDays(7);

            dgvPhanCong.ReadOnly = true;
            dgvPhanCong.AllowUserToAddRows = false;
            dgvPhanCong.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPhanCong.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhanCong.MultiSelect = false;

            TaiComboBox();
            HienThiPhanCong();
            LamMoiDuLieu();
        }

        private void TaiComboBox()
        {
            DataTable dtNhanVien =
                kn.GetData("dbo.sp_PHANCONGCA_NhanVien");

            cboNhanVien.DataSource = dtNhanVien;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";

            DataTable dtCaLam =
                kn.GetData("dbo.sp_PHANCONGCA_CaLam");

            cboCaLam.DataSource = dtCaLam;
            cboCaLam.DisplayMember = "TenCa";
            cboCaLam.ValueMember = "MaCa";

            cboLocNhanVien.Items.Clear();
            cboLocNhanVien.Items.Add("Tất cả");

            for (int i = 0; i < dtNhanVien.Rows.Count; i++)
            {
                cboLocNhanVien.Items.Add(
                    Convert.ToString(
                        dtNhanVien.Rows[i]["HoTen"]
                    )
                );
            }

            cboLocNhanVien.SelectedIndex = 0;

            cboLocCaLam.Items.Clear();
            cboLocCaLam.Items.Add("Tất cả");

            for (int i = 0; i < dtCaLam.Rows.Count; i++)
            {
                cboLocCaLam.Items.Add(
                    Convert.ToString(
                        dtCaLam.Rows[i]["TenCa"]
                    )
                );
            }

            cboLocCaLam.SelectedIndex = 0;
        }

        private void HienThiPhanCong()
        {
            try
            {
                dtPhanCong =
                    kn.GetData(
                        "dbo.sp_PHANCONGCA_DanhSach"
                    );

                dgvPhanCong.DataSource =
                    dtPhanCong;

                dgvPhanCong.Columns["MaPhanCong"].HeaderText =
                    "Mã phân công";

                dgvPhanCong.Columns["NhanVien"].HeaderText =
                    "Nhân viên";

                dgvPhanCong.Columns["CaLam"].HeaderText =
                    "Ca làm";

                dgvPhanCong.Columns["NgayLam"].HeaderText =
                    "Ngày làm";

                dgvPhanCong.Columns["NgayLam"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy";

                dgvPhanCong.Columns["MaNV"].Visible =
                    false;

                dgvPhanCong.Columns["MaCa"].Visible =
                    false;

                LocDanhSach(
                    this,
                    EventArgs.Empty
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải phân công: "
                    + ex.Message
                );
            }
        }

        private string LayMaMoi()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_PHANCONGCA_MaMoi"
                );

            return Convert.ToString(
                dt.Rows[0]["MaMoi"]
            );
        }

        private bool KiemTraDuLieu()
        {
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên!"
                );

                cboNhanVien.Focus();

                return false;
            }

            if (cboCaLam.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn ca làm!"
                );

                cboCaLam.Focus();

                return false;
            }

            return true;
        }

        private bool KiemTraTrungPhanCong()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_PHANCONGCA_DanhSach"
                );

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maPhanCong =
                    Convert.ToString(
                        dt.Rows[i]["MaPhanCong"]
                    );

                if (maPhanCong
                    == txtMaPhanCong.Text.Trim())
                {
                    MessageBox.Show(
                        "Mã phân công này đã tồn tại!"
                    );

                    return true;
                }

                string maNV =
                    Convert.ToString(
                        dt.Rows[i]["MaNV"]
                    );

                string maCa =
                    Convert.ToString(
                        dt.Rows[i]["MaCa"]
                    );

                DateTime ngayLam =
                    Convert.ToDateTime(
                        dt.Rows[i]["NgayLam"]
                    );

                if (maNV
                    == Convert.ToString(
                        cboNhanVien.SelectedValue
                    )
                    && maCa
                    == Convert.ToString(
                        cboCaLam.SelectedValue
                    )
                    && ngayLam.Date
                    == dtpNgayLam.Value.Date)
                {
                    MessageBox.Show(
                        "Nhân viên này đã được phân công ca này trong ngày đã chọn!"
                    );

                    return true;
                }
            }

            return false;
        }

        private SqlParameter[] LayThamSo()
        {
            SqlParameter[] thamSo =
            {
                new SqlParameter(
                    "@MaPhanCong",
                    txtMaPhanCong.Text
                ),

                new SqlParameter(
                    "@MaNV",
                    cboNhanVien.SelectedValue
                ),

                new SqlParameter(
                    "@MaCa",
                    cboCaLam.SelectedValue
                ),

                new SqlParameter(
                    "@NgayLam",
                    dtpNgayLam.Value.Date
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

            if (KiemTraTrungPhanCong() == true)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_PHANCONGCA_Them",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Thêm phân công thành công!"
                );

                HienThiPhanCong();
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
            if (dgvPhanCong.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phân công cần sửa!"
                );

                return;
            }

            if (KiemTraDuLieu() == false)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_PHANCONGCA_Sua",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Sửa phân công thành công!"
                );

                HienThiPhanCong();
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

        private void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPhanCong.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phân công cần xóa!"
                );

                return;
            }

            DialogResult ketQua =
                MessageBox.Show(
                    "Xóa phân công đã chọn?",
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
                    "dbo.sp_PHANCONGCA_Xoa",

                    new SqlParameter(
                        "@MaPhanCong",
                        txtMaPhanCong.Text
                    )
                );

                MessageBox.Show(
                    "Xóa phân công thành công!"
                );

                HienThiPhanCong();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xóa: "
                    + ex.Message
                );
            }
        }

        private void btnXem_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPhanCong.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phân công cần xem!"
                );

                return;
            }

            MessageBox.Show(
                "Mã phân công: "
                + txtMaPhanCong.Text
                + Environment.NewLine
                + "Nhân viên: "
                + cboNhanVien.Text
                + Environment.NewLine
                + "Ca làm: "
                + cboCaLam.Text
                + Environment.NewLine
                + "Ngày làm: "
                + dtpNgayLam.Value.ToString(
                    "dd/MM/yyyy"
                ),
                "Chi tiết phân công"
            );
        }

        private void dgvPhanCong_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvPhanCong.Rows[e.RowIndex];

            txtMaPhanCong.Text =
                Convert.ToString(
                    row.Cells["MaPhanCong"].Value
                );

            cboNhanVien.SelectedValue =
                Convert.ToString(
                    row.Cells["MaNV"].Value
                );

            cboCaLam.SelectedValue =
                Convert.ToString(
                    row.Cells["MaCa"].Value
                );

            dtpNgayLam.Value =
                Convert.ToDateTime(
                    row.Cells["NgayLam"].Value
                );
        }

        private void LamMoiDuLieu()
        {
            try
            {
                txtMaPhanCong.Text =
                    LayMaMoi();
            }
            catch
            {
                txtMaPhanCong.Clear();
            }

            if (cboNhanVien.Items.Count > 0)
            {
                cboNhanVien.SelectedIndex = 0;
            }

            if (cboCaLam.Items.Count > 0)
            {
                cboCaLam.SelectedIndex = 0;
            }

            dtpNgayLam.Value =
                DateTime.Today;

            dgvPhanCong.ClearSelection();
        }

        private void LocDanhSach(
            object sender,
            EventArgs e)
        {
            if (dtPhanCong.Columns.Count == 0)
            {
                return;
            }

            string tuKhoa =
                txtTimKiem.Text
                .Trim()
                .Replace("'", "''");

            string tuNgay =
                dtpTuNgay.Value.Date
                .ToString("MM/dd/yyyy");

            string denNgay =
                dtpDenNgay.Value.Date
                .AddDays(1)
                .ToString("MM/dd/yyyy");

            string dieuKien =
                "(MaPhanCong LIKE '%"
                + tuKhoa
                + "%' OR NhanVien LIKE '%"
                + tuKhoa
                + "%') AND NgayLam >= #"
                + tuNgay
                + "# AND NgayLam < #"
                + denNgay
                + "#";

            if (cboLocNhanVien.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND NhanVien='"
                    + cboLocNhanVien.Text
                    .Replace("'", "''")
                    + "'";
            }

            if (cboLocCaLam.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND CaLam='"
                    + cboLocCaLam.Text
                    .Replace("'", "''")
                    + "'";
            }

            dtPhanCong.DefaultView.RowFilter =
                dieuKien;

            lblTongSo.Text =
                "Tổng số: "
                + dtPhanCong.DefaultView.Count
                + " bản ghi";
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();

            cboLocNhanVien.SelectedIndex = 0;
            cboLocCaLam.SelectedIndex = 0;

            dtpTuNgay.Value =
                DateTime.Today.AddDays(-7);

            dtpDenNgay.Value =
                DateTime.Today.AddDays(7);

            HienThiPhanCong();
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