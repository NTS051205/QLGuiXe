using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmBangGia : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataTable dtBangGia = new DataTable();

        public frmBangGia()
        {
            InitializeComponent();
        }

        private void frmBangGia_Load(object sender, EventArgs e)
        {
            cboLoaiXe.Items.AddRange(
                new object[] { "Xe máy", "Ô tô" }
            );

            cboLoaiVe.Items.AddRange(
                new object[] { "LUOT", "THANG" }
            );

            cboLocLoaiXe.Items.AddRange(
                new object[] { "Tất cả", "Xe máy", "Ô tô" }
            );

            cboLocLoaiVe.Items.AddRange(
                new object[] { "Tất cả", "LUOT", "THANG" }
            );

            cboLoaiXe.SelectedIndex = 0;
            cboLoaiVe.SelectedIndex = 0;
            cboLocLoaiXe.SelectedIndex = 0;
            cboLocLoaiVe.SelectedIndex = 0;

            dgvBangGia.ReadOnly = true;
            dgvBangGia.AllowUserToAddRows = false;
            dgvBangGia.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvBangGia.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangGia.MultiSelect = false;

            HienThiBangGia();
            LamMoiDuLieu();
        }

        private void HienThiBangGia()
        {
            try
            {
                dtBangGia =
                    kn.GetData("dbo.sp_BANGGIA_DanhSach");

                dgvBangGia.DataSource = dtBangGia;

                dgvBangGia.Columns["MaBangGia"].HeaderText =
                    "Mã bảng giá";

                dgvBangGia.Columns["LoaiXe"].HeaderText =
                    "Loại xe";

                dgvBangGia.Columns["LoaiVe"].HeaderText =
                    "Loại vé";

                dgvBangGia.Columns["DonGia"].HeaderText =
                    "Giá thường";

                dgvBangGia.Columns["DonGiaSau19Gio"].HeaderText =
                    "Giá sau 19 giờ";

                dgvBangGia.Columns["DonGiaQuaDem"].HeaderText =
                    "Giá qua đêm";

                dgvBangGia.Columns["NgayApDung"].HeaderText =
                    "Ngày áp dụng";

                dgvBangGia.Columns["DonGia"]
                    .DefaultCellStyle.Format =
                    "#,##0 ₫";

                dgvBangGia.Columns["DonGiaSau19Gio"]
                    .DefaultCellStyle.Format =
                    "#,##0 ₫";

                dgvBangGia.Columns["DonGiaQuaDem"]
                    .DefaultCellStyle.Format =
                    "#,##0 ₫";

                dgvBangGia.Columns["NgayApDung"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy";

                LocDanhSach(
                    this,
                    EventArgs.Empty
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải bảng giá: "
                    + ex.Message
                );
            }
        }

        private string LayMaMoi()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_BANGGIA_MaMoi"
                );

            return Convert.ToString(
                dt.Rows[0]["MaMoi"]
            );
        }

        private bool KiemTraDuLieu()
        {
            if (nudDonGia.Value <= 0)
            {
                MessageBox.Show(
                    "Đơn giá phải lớn hơn 0!"
                );

                nudDonGia.Focus();

                return false;
            }

            if (cboLoaiVe.Text == "LUOT")
            {
                if (nudGiaSau19Gio.Value <= 0)
                {
                    MessageBox.Show(
                        "Giá sau 19 giờ phải lớn hơn 0!"
                    );

                    nudGiaSau19Gio.Focus();

                    return false;
                }

                if (nudGiaQuaDem.Value <= 0)
                {
                    MessageBox.Show(
                        "Giá qua đêm phải lớn hơn 0!"
                    );

                    nudGiaQuaDem.Focus();

                    return false;
                }
            }

            return true;
        }

        private bool KiemTraTrungBangGia()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_BANGGIA_DanhSach"
                );

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string loaiXe =
                    Convert.ToString(
                        dt.Rows[i]["LoaiXe"]
                    );

                string loaiVe =
                    Convert.ToString(
                        dt.Rows[i]["LoaiVe"]
                    );

                DateTime ngayApDung =
                    Convert.ToDateTime(
                        dt.Rows[i]["NgayApDung"]
                    );

                if (loaiXe == cboLoaiXe.Text
                    && loaiVe == cboLoaiVe.Text
                    && ngayApDung.Date
                    == dtpNgayApDung.Value.Date)
                {
                    MessageBox.Show(
                        "Bảng giá cho loại xe, loại vé và ngày áp dụng này đã tồn tại!"
                    );

                    return false;
                }
            }

            return true;
        }

        private SqlParameter[] LayThamSo()
        {
            object giaSau19Gio;
            object giaQuaDem;

            if (cboLoaiVe.Text == "LUOT")
            {
                giaSau19Gio =
                    nudGiaSau19Gio.Value;

                giaQuaDem =
                    nudGiaQuaDem.Value;
            }
            else
            {
                giaSau19Gio =
                    DBNull.Value;

                giaQuaDem =
                    DBNull.Value;
            }

            SqlParameter[] thamSo =
            {
                new SqlParameter(
                    "@MaBangGia",
                    txtMaBangGia.Text
                ),

                new SqlParameter(
                    "@LoaiXe",
                    cboLoaiXe.Text
                ),

                new SqlParameter(
                    "@LoaiVe",
                    cboLoaiVe.Text
                ),

                new SqlParameter(
                    "@DonGia",
                    nudDonGia.Value
                ),

                new SqlParameter(
                    "@DonGiaSau19Gio",
                    giaSau19Gio
                ),

                new SqlParameter(
                    "@DonGiaQuaDem",
                    giaQuaDem
                ),

                new SqlParameter(
                    "@NgayApDung",
                    dtpNgayApDung.Value.Date
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

            if (KiemTraTrungBangGia() == false)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_BANGGIA_Them",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Thêm bảng giá thành công!"
                );

                HienThiBangGia();
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
            if (dgvBangGia.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn mức giá cần sửa!"
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
                    "dbo.sp_BANGGIA_Sua",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Sửa bảng giá thành công!"
                );

                HienThiBangGia();
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
            if (dgvBangGia.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn mức giá cần xem!"
                );

                return;
            }

            string giaSau19;
            string giaQuaDem;

            if (cboLoaiVe.Text == "LUOT")
            {
                giaSau19 =
                    DinhDangTien(
                        nudGiaSau19Gio.Value
                    );

                giaQuaDem =
                    DinhDangTien(
                        nudGiaQuaDem.Value
                    );
            }
            else
            {
                giaSau19 =
                    "Không áp dụng";

                giaQuaDem =
                    "Không áp dụng";
            }

            MessageBox.Show(
                "Mã bảng giá: "
                + txtMaBangGia.Text
                + Environment.NewLine
                + "Loại xe: "
                + cboLoaiXe.Text
                + Environment.NewLine
                + "Loại vé: "
                + cboLoaiVe.Text
                + Environment.NewLine
                + "Giá thường: "
                + DinhDangTien(
                    nudDonGia.Value
                )
                + Environment.NewLine
                + "Giá sau 19 giờ: "
                + giaSau19
                + Environment.NewLine
                + "Giá qua đêm: "
                + giaQuaDem,
                "Chi tiết bảng giá"
            );
        }

        private void dgvBangGia_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvBangGia.Rows[e.RowIndex];

            txtMaBangGia.Text =
                Convert.ToString(
                    row.Cells["MaBangGia"].Value
                );

            cboLoaiXe.Text =
                Convert.ToString(
                    row.Cells["LoaiXe"].Value
                );

            cboLoaiVe.Text =
                Convert.ToString(
                    row.Cells["LoaiVe"].Value
                );

            nudDonGia.Value =
                Convert.ToDecimal(
                    row.Cells["DonGia"].Value
                );

            if (row.Cells["DonGiaSau19Gio"].Value
                == DBNull.Value)
            {
                nudGiaSau19Gio.Value = 0;
            }
            else
            {
                nudGiaSau19Gio.Value =
                    Convert.ToDecimal(
                        row.Cells["DonGiaSau19Gio"].Value
                    );
            }

            if (row.Cells["DonGiaQuaDem"].Value
                == DBNull.Value)
            {
                nudGiaQuaDem.Value = 0;
            }
            else
            {
                nudGiaQuaDem.Value =
                    Convert.ToDecimal(
                        row.Cells["DonGiaQuaDem"].Value
                    );
            }

            dtpNgayApDung.Value =
                Convert.ToDateTime(
                    row.Cells["NgayApDung"].Value
                );

            CapNhatLoaiGia(
                this,
                EventArgs.Empty
            );
        }

        private void CapNhatLoaiGia(
            object sender,
            EventArgs e)
        {
            if (cboLoaiVe.Text == "LUOT")
            {
                nudGiaSau19Gio.Enabled = true;
                nudGiaQuaDem.Enabled = true;

                lblGiaSau19Gio.Enabled = true;
                lblGiaQuaDem.Enabled = true;
            }
            else
            {
                nudGiaSau19Gio.Enabled = false;
                nudGiaQuaDem.Enabled = false;

                lblGiaSau19Gio.Enabled = false;
                lblGiaQuaDem.Enabled = false;
            }
        }

        private void LamMoiDuLieu()
        {
            try
            {
                txtMaBangGia.Text =
                    LayMaMoi();
            }
            catch
            {
                txtMaBangGia.Clear();
            }

            cboLoaiXe.SelectedIndex = 0;
            cboLoaiVe.SelectedIndex = 0;

            nudDonGia.Value = 5000;
            nudGiaSau19Gio.Value = 10000;
            nudGiaQuaDem.Value = 20000;

            dtpNgayApDung.Value =
                DateTime.Today;

            CapNhatLoaiGia(
                this,
                EventArgs.Empty
            );

            dgvBangGia.ClearSelection();
        }

        private void LocDanhSach(
            object sender,
            EventArgs e)
        {
            if (dtBangGia.Columns.Count == 0)
            {
                return;
            }

            string tuKhoa =
                txtTimKiem.Text
                .Trim()
                .Replace("'", "''");

            string dieuKien =
                "MaBangGia LIKE '%"
                + tuKhoa
                + "%'";

            if (cboLocLoaiXe.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND LoaiXe='"
                    + cboLocLoaiXe.Text
                    + "'";
            }

            if (cboLocLoaiVe.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND LoaiVe='"
                    + cboLocLoaiVe.Text
                    + "'";
            }

            dtBangGia.DefaultView.RowFilter =
                dieuKien;

            lblTongSo.Text =
                "Tổng số: "
                + dtBangGia.DefaultView.Count
                + " bản ghi";
        }

        private string DinhDangTien(
            decimal soTien)
        {
            return soTien.ToString(
                "#,##0 ₫"
            );
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();

            cboLocLoaiXe.SelectedIndex = 0;
            cboLocLoaiVe.SelectedIndex = 0;

            HienThiBangGia();
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