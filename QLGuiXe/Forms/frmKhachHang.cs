using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmKhachHang : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataTable dtKhachHang = new DataTable();

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(
            object sender,
            EventArgs e)
        {
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.MultiSelect = false;

            HienThiKhachHang();
            LamMoiDuLieu();
        }

        private void HienThiKhachHang()
        {
            try
            {
                dtKhachHang =
                    kn.GetData(
                        "dbo.sp_KHACHHANG_DanhSach"
                    );

                dgvKhachHang.DataSource =
                    dtKhachHang;

                dgvKhachHang.Columns["MaKH"].HeaderText =
                    "Mã khách hàng";

                dgvKhachHang.Columns["HoTen"].HeaderText =
                    "Họ tên";

                dgvKhachHang.Columns["SoDienThoai"].HeaderText =
                    "Số điện thoại";

                LocDanhSach(
                    this,
                    EventArgs.Empty
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải khách hàng: "
                    + ex.Message
                );
            }
        }

        private string LayMaMoi()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_KHACHHANG_MaMoi"
                );

            if (dt.Rows.Count > 0)
            {
                return Convert.ToString(
                    dt.Rows[0]["MaMoi"]
                );
            }

            return "";
        }

        private bool KiemTraDuLieu()
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên khách hàng!"
                );

                txtHoTen.Focus();

                return false;
            }

            if (txtSoDienThoai.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại!"
                );

                txtSoDienThoai.Focus();

                return false;
            }

            string soDienThoai =
                txtSoDienThoai.Text.Trim();

            if (soDienThoai.Length < 9
                || soDienThoai.Length > 11)
            {
                MessageBox.Show(
                    "Số điện thoại phải gồm từ 9 đến 11 chữ số!"
                );

                txtSoDienThoai.Focus();

                return false;
            }

            for (int i = 0;
                i < soDienThoai.Length;
                i++)
            {
                if (char.IsDigit(
                    soDienThoai[i]) == false)
                {
                    MessageBox.Show(
                        "Số điện thoại chỉ được nhập chữ số!"
                    );

                    txtSoDienThoai.Focus();

                    return false;
                }
            }

            return true;
        }

        private bool KiemTraTrungKhiThem()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_KHACHHANG_DanhSach"
                );

            for (int i = 0;
                i < dt.Rows.Count;
                i++)
            {
                if (Convert.ToString(
                    dt.Rows[i]["MaKH"])
                    .Trim()
                    == txtMaKH.Text.Trim())
                {
                    MessageBox.Show(
                        "Mã khách hàng đã tồn tại!"
                    );

                    return true;
                }

                if (Convert.ToString(
                    dt.Rows[i]["SoDienThoai"])
                    .Trim()
                    == txtSoDienThoai.Text.Trim())
                {
                    MessageBox.Show(
                        "Số điện thoại này đã tồn tại!"
                    );

                    txtSoDienThoai.Focus();

                    return true;
                }
            }

            return false;
        }

        private bool KiemTraTrungKhiSua()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_KHACHHANG_DanhSach"
                );

            for (int i = 0;
                i < dt.Rows.Count;
                i++)
            {
                string maKH =
                    Convert.ToString(
                        dt.Rows[i]["MaKH"]
                    ).Trim();

                string soDienThoai =
                    Convert.ToString(
                        dt.Rows[i]["SoDienThoai"]
                    ).Trim();

                if (maKH != txtMaKH.Text.Trim())
                {
                    if (soDienThoai
                        == txtSoDienThoai.Text.Trim())
                    {
                        MessageBox.Show(
                            "Số điện thoại này đã tồn tại!"
                        );

                        txtSoDienThoai.Focus();

                        return true;
                    }
                }
            }

            return false;
        }

        private SqlParameter[] LayThamSo()
        {
            SqlParameter[] thamSo =
            {
                new SqlParameter(
                    "@MaKH",
                    txtMaKH.Text.Trim()
                ),

                new SqlParameter(
                    "@HoTen",
                    txtHoTen.Text.Trim()
                ),

                new SqlParameter(
                    "@SoDienThoai",
                    txtSoDienThoai.Text.Trim()
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

            try
            {
                if (KiemTraTrungKhiThem() == true)
                {
                    return;
                }

                kn.Execute(
                    "dbo.sp_KHACHHANG_Them",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Thêm khách hàng thành công!"
                );

                HienThiKhachHang();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thêm khách hàng: "
                    + ex.Message
                );
            }
        }

        private void btnSua_Click(
            object sender,
            EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần sửa!"
                );

                return;
            }

            if (KiemTraDuLieu() == false)
            {
                return;
            }

            try
            {
                if (KiemTraTrungKhiSua() == true)
                {
                    return;
                }

                kn.Execute(
                    "dbo.sp_KHACHHANG_Sua",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Sửa khách hàng thành công!"
                );

                HienThiKhachHang();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa khách hàng: "
                    + ex.Message
                );
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần xóa!"
                );

                return;
            }

            if (MessageBox.Show(
                "Xóa khách hàng đã chọn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                ) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_KHACHHANG_Xoa",
                    new SqlParameter(
                        "@MaKH",
                        txtMaKH.Text
                    )
                );

                MessageBox.Show(
                    "Xóa khách hàng thành công!"
                );

                HienThiKhachHang();
                LamMoiDuLieu();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "Không thể xóa khách hàng này vì khách hàng đã có phương tiện hoặc dữ liệu liên quan!",
                        "Không thể xóa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Lỗi xóa khách hàng: "
                        + ex.Message
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xóa khách hàng: "
                    + ex.Message
                );
            }
        }

        private void btnXem_Click(
            object sender,
            EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần xem!"
                );

                return;
            }

            MessageBox.Show(
                "Mã khách hàng: "
                + txtMaKH.Text
                + Environment.NewLine
                + "Họ tên: "
                + txtHoTen.Text
                + Environment.NewLine
                + "Số điện thoại: "
                + txtSoDienThoai.Text,
                "Chi tiết khách hàng"
            );
        }

        private void dgvKhachHang_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvKhachHang.Rows[e.RowIndex];

            txtMaKH.Text =
                Convert.ToString(
                    row.Cells["MaKH"].Value
                );

            txtHoTen.Text =
                Convert.ToString(
                    row.Cells["HoTen"].Value
                );

            txtSoDienThoai.Text =
                Convert.ToString(
                    row.Cells["SoDienThoai"].Value
                );
        }

        private void LamMoiDuLieu()
        {
            try
            {
                txtMaKH.Text =
                    LayMaMoi();
            }
            catch
            {
                txtMaKH.Clear();
            }

            txtHoTen.Clear();
            txtSoDienThoai.Clear();

            dgvKhachHang.ClearSelection();

            txtHoTen.Focus();
        }

        private void LocDanhSach(
            object sender,
            EventArgs e)
        {
            if (dtKhachHang.Columns.Count == 0)
            {
                return;
            }

            string tuKhoa =
                txtTimKiem.Text
                .Trim()
                .Replace(
                    "'",
                    "''"
                );

            dtKhachHang.DefaultView.RowFilter =
                "MaKH LIKE '%"
                + tuKhoa
                + "%' OR HoTen LIKE '%"
                + tuKhoa
                + "%' OR SoDienThoai LIKE '%"
                + tuKhoa
                + "%'";

            lblTongSo.Text =
                "Tổng số: "
                + dtKhachHang.DefaultView.Count
                + " bản ghi";
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();

            HienThiKhachHang();
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