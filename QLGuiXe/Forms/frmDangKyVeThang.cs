using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmDangKyVeThang : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();
        private DataTable dtDangKy = new DataTable();
        private bool dangTaiKhachHang;
        private bool dangTaiPhuongTien;

        public frmDangKyVeThang()
        {
            InitializeComponent();
        }

        private void frmDangKyVeThang_Load(object sender, EventArgs e)
        {
            dgvDangKy.ReadOnly = true;
            dgvDangKy.AllowUserToAddRows = false;
            dgvDangKy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDangKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDangKy.MultiSelect = false;

            cboPhuongThuc.Items.AddRange(new object[] { "TIEN_MAT", "CHUYEN_KHOAN", "THE" });
            cboPhuongThuc.SelectedIndex = 0;
            dtpBatDau.Value = DateTime.Today;
            nudSoThang.Value = 1;

            try
            {
                TaiKhachHang();
                TaiTheThang();
                HienThiDangKy();
                TinhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void HienThiDangKy()
        {
            dtDangKy = kn.GetData("dbo.sp_DANGKYVETHANG_DanhSach");
            dgvDangKy.DataSource = dtDangKy;

            dgvDangKy.Columns["MaDangKy"].HeaderText = "Mã đăng ký";
            dgvDangKy.Columns["MaKH"].HeaderText = "Mã KH";
            dgvDangKy.Columns["KhachHang"].HeaderText = "Khách hàng";
            dgvDangKy.Columns["MaPT"].HeaderText = "Mã PT";
            dgvDangKy.Columns["BienSo"].HeaderText = "Biển số";
            dgvDangKy.Columns["MaThe"].HeaderText = "Mã thẻ tháng";
            dgvDangKy.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
            dgvDangKy.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            dgvDangKy.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvDangKy.Columns["ThanhToan"].HeaderText = "Thanh toán";
            dgvDangKy.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvDangKy.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDangKy.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDangKy.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 ₫";
            dgvDangKy.ClearSelection();
        }

        private void TaiKhachHang()
        {
            DataTable dt = kn.GetData("dbo.sp_DANGKYVETHANG_KhachHang");

            dangTaiKhachHang = true;
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DataSource = dt;
            dangTaiKhachHang = false;

            HienThiKhachHangDangChon();
        }

        private void TaiPhuongTien(string maKhachHang)
        {
            DataTable dt = kn.GetData(
                "dbo.sp_DANGKYVETHANG_PhuongTien",
                new SqlParameter("@MaKH", maKhachHang));

            dangTaiPhuongTien = true;
            cboPhuongTien.DisplayMember = "BienSo";
            cboPhuongTien.ValueMember = "MaPT";
            cboPhuongTien.DataSource = dt;
            dangTaiPhuongTien = false;

            if (dt.Rows.Count == 0)
            {
                txtBienSo.Clear();
                txtLoaiXe.Clear();
            }
            else
            {
                HienThiPhuongTienDangChon();
            }
        }

        private void TaiTheThang()
        {
            DataTable dt = kn.GetData("dbo.sp_DANGKYVETHANG_TheThang");
            cboTheThang.DisplayMember = "MaThe";
            cboTheThang.ValueMember = "MaThe";
            cboTheThang.DataSource = dt;
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiKhachHang) return;
            HienThiKhachHangDangChon();
        }

        private void HienThiKhachHangDangChon()
        {
            DataRowView? row = cboKhachHang.SelectedItem as DataRowView;
            if (row == null)
            {
                txtHoTen.Clear();
                txtSoDienThoai.Clear();
                cboPhuongTien.DataSource = null;
                txtBienSo.Clear();
                txtLoaiXe.Clear();
                return;
            }

            txtHoTen.Text = Convert.ToString(row["HoTen"]);
            txtSoDienThoai.Text = Convert.ToString(row["SoDienThoai"]);
            TaiPhuongTien(Convert.ToString(row["MaKH"]));
        }

        private void cboPhuongTien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTaiPhuongTien) return;
            HienThiPhuongTienDangChon();
        }

        private void HienThiPhuongTienDangChon()
        {
            DataRowView? row = cboPhuongTien.SelectedItem as DataRowView;
            if (row == null)
            {
                txtBienSo.Clear();
                txtLoaiXe.Clear();
                TinhTien();
                return;
            }

            txtBienSo.Text = Convert.ToString(row["BienSo"]);
            txtLoaiXe.Text = Convert.ToString(row["LoaiXe"]);
            TinhTien();
        }

        private void TinhTien()
        {
            DateTime ngayKetThuc = dtpBatDau.Value.Date.AddMonths(Convert.ToInt32(nudSoThang.Value));
            lblNgayKetThucValue.Text = ngayKetThuc.ToString("dd/MM/yyyy");

            if (string.IsNullOrWhiteSpace(txtLoaiXe.Text))
            {
                lblDonGiaValue.Text = "0 ₫";
                lblTongTienValue.Text = "0 ₫";
                return;
            }

            DataTable dt = kn.GetData(
                "dbo.sp_BANGGIA_GiaHienTai",
                new SqlParameter("@LoaiXe", txtLoaiXe.Text),
                new SqlParameter("@LoaiVe", "THANG"));

            decimal donGia = dt.Rows.Count == 0 ? 0 : Convert.ToDecimal(dt.Rows[0]["DonGia"]);
            decimal tongTien = donGia * nudSoThang.Value;
            lblDonGiaValue.Text = donGia.ToString("#,##0 ₫");
            lblTongTienValue.Text = tongTien.ToString("#,##0 ₫");
        }

        private void dtpBatDau_ValueChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void nudSoThang_ValueChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null ||
                cboPhuongTien.SelectedValue == null ||
                cboTheThang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng, phương tiện và thẻ tháng!");
                return;
            }

            TaoDangKy(
                Convert.ToString(cboKhachHang.SelectedValue),
                Convert.ToString(cboPhuongTien.SelectedValue),
                Convert.ToString(cboTheThang.SelectedValue),
                dtpBatDau.Value.Date);
        }

        private void TaoDangKy(string maKH, string maPT, string maThe, DateTime ngayBatDau)
        {
            SqlParameter maDangKy = new SqlParameter("@MaDangKyMoi", SqlDbType.VarChar, 20);
            maDangKy.Direction = ParameterDirection.Output;

            SqlParameter ngayKetThuc = new SqlParameter("@NgayKetThuc", SqlDbType.Date);
            ngayKetThuc.Direction = ParameterDirection.Output;

            SqlParameter tongTien = new SqlParameter("@TongTien", SqlDbType.Decimal);
            tongTien.Precision = 18;
            tongTien.Scale = 2;
            tongTien.Direction = ParameterDirection.Output;

            try
            {
                kn.Execute(
                    "dbo.sp_DangKyVeThang",
                    new SqlParameter("@MaKH", maKH),
                    new SqlParameter("@MaPT", maPT),
                    new SqlParameter("@MaThe", maThe),
                    new SqlParameter("@NgayBatDau", ngayBatDau),
                    new SqlParameter("@SoThang", Convert.ToInt32(nudSoThang.Value)),
                    maDangKy,
                    ngayKetThuc,
                    tongTien);

                MessageBox.Show(
                    "Đăng ký thành công! Mã đăng ký: " + Convert.ToString(maDangKy.Value) +
                    Environment.NewLine + "Tổng tiền: " + Convert.ToDecimal(tongTien.Value).ToString("#,##0 ₫"));

                HienThiDangKy();
                TaiTheThang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DataRow? row = LayDongDangChon();
            if (row == null) return;

            if (Convert.ToString(row["ThanhToan"]) == "DA_THANH_TOAN")
            {
                MessageBox.Show("Đăng ký này đã được thanh toán!");
                return;
            }

            SqlParameter maThanhToan = new SqlParameter("@MaThanhToanMoi", SqlDbType.VarChar, 20);
            maThanhToan.Direction = ParameterDirection.Output;

            try
            {
                kn.Execute(
                    "dbo.sp_ThanhToanVeThang",
                    new SqlParameter("@MaDangKy", row["MaDangKy"]),
                    new SqlParameter("@MaNV", PhienDangNhap.MaNhanVien),
                    new SqlParameter("@PhuongThuc", cboPhuongThuc.Text),
                    new SqlParameter("@MaThamChieu", DBNull.Value),
                    maThanhToan);

                MessageBox.Show("Thanh toán thành công! Mã thanh toán: " + Convert.ToString(maThanhToan.Value));
                HienThiDangKy();
                TaiTheThang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            DataRow? row = LayDongDangChon();
            if (row == null) return;

            if (Convert.ToString(row["ThanhToan"]) != "DA_THANH_TOAN")
            {
                MessageBox.Show("Chỉ gia hạn đăng ký đã thanh toán!");
                return;
            }

            DateTime ngayBatDau = Convert.ToDateTime(row["NgayKetThuc"]);
            if (ngayBatDau < DateTime.Today) ngayBatDau = DateTime.Today;

            TaoDangKy(
                Convert.ToString(row["MaKH"]),
                Convert.ToString(row["MaPT"]),
                Convert.ToString(row["MaThe"]),
                ngayBatDau);
        }

        private DataRow? LayDongDangChon()
        {
            if (dgvDangKy.SelectedRows.Count == 0 ||
                !(dgvDangKy.SelectedRows[0].DataBoundItem is DataRowView))
            {
                MessageBox.Show("Vui lòng chọn một đăng ký trong danh sách!");
                return null;
            }

            return ((DataRowView)dgvDangKy.SelectedRows[0].DataBoundItem).Row;
        }

        private void dgvDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDangKy.Rows[e.RowIndex];
            cboKhachHang.SelectedValue = Convert.ToString(row.Cells["MaKH"].Value);
            cboPhuongTien.SelectedValue = Convert.ToString(row.Cells["MaPT"].Value);
            cboTheThang.SelectedValue = Convert.ToString(row.Cells["MaThe"].Value);

            DateTime ngayBatDau = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
            int soThang = Convert.ToInt32(row.Cells["SoThang"].Value);
            dtpBatDau.Value = ngayBatDau;
            nudSoThang.Value = Math.Min(nudSoThang.Maximum, Math.Max(nudSoThang.Minimum, soThang));
            TinhTien();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiDangKy();
                TaiKhachHang();
                TaiTheThang();
                dtpBatDau.Value = DateTime.Today;
                nudSoThang.Value = 1;
                TinhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi làm mới dữ liệu: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
