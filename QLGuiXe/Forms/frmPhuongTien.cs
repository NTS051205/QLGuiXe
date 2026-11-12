using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmPhuongTien : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataTable dtPhuongTien = new DataTable();

        string maKhachHangDuocChon = "";

        public frmPhuongTien()
        {
            InitializeComponent();
        }

        public frmPhuongTien(
            string maKhachHang)
        {
            InitializeComponent();

            maKhachHangDuocChon =
                maKhachHang;
        }

        private void frmPhuongTien_Load(
            object sender,
            EventArgs e)
        {
            cboLoaiXe.Items.AddRange(
                new object[]
                {
                    "Xe máy",
                    "Ô tô"
                }
            );

            cboLocLoaiXe.Items.AddRange(
                new object[]
                {
                    "Tất cả",
                    "Xe máy",
                    "Ô tô"
                }
            );

            LoadKhachHang();

            cboLoaiXe.SelectedIndex = 0;
            cboLocLoaiXe.SelectedIndex = 0;

            CauHinhLuoi();
            LoadDanhSach();
            LamMoiNhapLieu();

            if (maKhachHangDuocChon != "")
            {
                cboKhachHang.SelectedValue =
                    maKhachHangDuocChon;
            }
        }

        private void LoadKhachHang()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_PHUONGTIEN_KhachHang"
                );

            DataRow khachVangLai =
                dt.NewRow();

            khachVangLai["MaKH"] =
                DBNull.Value;

            khachVangLai["HoTen"] =
                "— Khách vãng lai —";

            dt.Rows.InsertAt(
                khachVangLai,
                0
            );

            cboKhachHang.DisplayMember =
                "HoTen";

            cboKhachHang.ValueMember =
                "MaKH";

            cboKhachHang.DataSource =
                dt;
        }

        private void CauHinhLuoi()
        {
            dgvPhuongTien.ReadOnly = true;
            dgvPhuongTien.AllowUserToAddRows = false;
            dgvPhuongTien.AllowUserToDeleteRows = false;

            dgvPhuongTien.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPhuongTien.MultiSelect = false;

            dgvPhuongTien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPhuongTien.RowHeadersVisible =
                false;
        }

        private void LoadDanhSach()
        {
            try
            {
                dtPhuongTien =
                    kn.GetData(
                        "dbo.sp_PHUONGTIEN_DanhSach"
                    );

                dgvPhuongTien.DataSource =
                    dtPhuongTien;

                dgvPhuongTien.Columns["MaPT"].HeaderText =
                    "Mã phương tiện";

                dgvPhuongTien.Columns["BienSo"].HeaderText =
                    "Biển số";

                dgvPhuongTien.Columns["LoaiXe"].HeaderText =
                    "Loại xe";

                dgvPhuongTien.Columns["KhachHang"].HeaderText =
                    "Khách hàng sở hữu";

                dgvPhuongTien.Columns["MaKH"].Visible =
                    false;

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
                        "dbo.sp_PHUONGTIEN_MaMoi"
                    );

                txtMaPT.Text =
                    Convert.ToString(
                        dt.Rows[0]["MaMoi"]
                    );
            }
            catch
            {
                txtMaPT.Clear();
            }

            txtBienSo.Clear();

            cboLoaiXe.SelectedIndex =
                0;

            if (maKhachHangDuocChon != "")
            {
                cboKhachHang.SelectedValue =
                    maKhachHangDuocChon;
            }
            else
            {
                cboKhachHang.SelectedIndex =
                    0;
            }

            dgvPhuongTien.ClearSelection();

            txtBienSo.Focus();
        }

        private bool KiemTraNhapLieu()
        {
            if (txtBienSo.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập biển số."
                );

                txtBienSo.Focus();

                return false;
            }

            return true;
        }

        private object MaKhachHangDaChon()
        {
            if (cboKhachHang.SelectedValue == null)
            {
                return null;
            }

            if (cboKhachHang.SelectedValue
                == DBNull.Value)
            {
                return null;
            }

            return cboKhachHang.SelectedValue;
        }

        private SqlParameter[] LayThamSo()
        {
            object maKhachHang =
                MaKhachHangDaChon();

            if (maKhachHang == null)
            {
                maKhachHang =
                    DBNull.Value;
            }

            SqlParameter[] thamSo =
            {
                new SqlParameter(
                    "@MaPT",
                    txtMaPT.Text
                ),

                new SqlParameter(
                    "@BienSo",
                    txtBienSo.Text.Trim()
                ),

                new SqlParameter(
                    "@LoaiXe",
                    cboLoaiXe.Text
                ),

                new SqlParameter(
                    "@MaKH",
                    maKhachHang
                )
            };

            return thamSo;
        }

        private void btnThem_Click(
            object sender,
            EventArgs e)
        {
            if (KiemTraNhapLieu() == false)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_PHUONGTIEN_Them",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Thêm phương tiện thành công."
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
            if (dgvPhuongTien.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phương tiện cần sửa."
                );

                return;
            }

            if (KiemTraNhapLieu() == false)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_PHUONGTIEN_Sua",
                    LayThamSo()
                );

                MessageBox.Show(
                    "Cập nhật phương tiện thành công."
                );

                LoadDanhSach();
                LamMoiNhapLieu();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnLichSu_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPhuongTien.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phương tiện cần xem lịch sử."
                );

                return;
            }

            try
            {
                DataTable dt =
                    kn.GetData(
                        "dbo.sp_PHUONGTIEN_LichSu",

                        new SqlParameter(
                            "@MaPT",
                            txtMaPT.Text
                        )
                    );

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Phương tiện chưa có lịch sử gửi xe."
                    );

                    return;
                }

                string noiDung = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row =
                        dt.Rows[i];

                    noiDung +=
                        Convert.ToDateTime(
                            row["ThoiGianVao"]
                        ).ToString(
                            "dd/MM/yyyy HH:mm"
                        )
                        + " - "
                        + Convert.ToString(
                            row["TrangThai"]
                        )
                        + " - "
                        + Convert.ToDecimal(
                            row["TienGui"]
                        ).ToString(
                            "#,##0 ₫"
                        )
                        + Environment.NewLine;
                }

                MessageBox.Show(
                    noiDung,
                    "Lịch sử "
                    + txtBienSo.Text
                );
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void dgvPhuongTien_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                DataRowView dongDuLieu =
                    dgvPhuongTien.Rows[e.RowIndex]
                    .DataBoundItem
                    as DataRowView;

                if (dongDuLieu == null)
                {
                    return;
                }

                txtMaPT.Text =
                    Convert.ToString(
                        dongDuLieu["MaPT"]
                    );

                txtBienSo.Text =
                    Convert.ToString(
                        dongDuLieu["BienSo"]
                    );

                cboLoaiXe.Text =
                    Convert.ToString(
                        dongDuLieu["LoaiXe"]
                    );

                object maKhachHang =
                    dongDuLieu["MaKH"];

                if (maKhachHang
                    == DBNull.Value)
                {
                    cboKhachHang.SelectedIndex =
                        0;
                }
                else
                {
                    if (Convert.ToString(
                        maKhachHang).Trim() == "")
                    {
                        cboKhachHang.SelectedIndex =
                            0;
                    }
                    else
                    {
                        cboKhachHang.SelectedValue =
                            Convert.ToString(
                                maKhachHang
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể hiển thị thông tin phương tiện: "
                    + ex.Message,
                    "Lỗi chọn dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void LocDanhSach(
            object sender,
            EventArgs e)
        {
            if (dtPhuongTien.Columns.Count == 0)
            {
                return;
            }

            string tuKhoa =
                txtTimKiem.Text
                .Trim()
                .Replace("'", "''");

            string dieuKien =
                "(MaPT LIKE '%"
                + tuKhoa
                + "%' OR BienSo LIKE '%"
                + tuKhoa
                + "%')";

            if (cboLocLoaiXe.SelectedIndex > 0)
            {
                dieuKien +=
                    " AND LoaiXe='"
                    + cboLocLoaiXe.Text
                    + "'";
            }

            dtPhuongTien.DefaultView.RowFilter =
                dieuKien;

            lblTongSo.Text =
                "Tổng số: "
                + dtPhuongTien.DefaultView.Count
                + " bản ghi";
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();

            cboLocLoaiXe.SelectedIndex =
                0;

            LoadDanhSach();
            LamMoiNhapLieu();
        }

        private void btnThoat_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void BaoLoi(
            Exception ex)
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