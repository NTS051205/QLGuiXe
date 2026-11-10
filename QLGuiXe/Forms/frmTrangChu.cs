using System;
using System.Data;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmTrangChu : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();

        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            lblNguoiDung.Text = "Người dùng: " + PhienDangNhap.HoTen
                + " - " + PhienDangNhap.VaiTro;
            ApDungPhanQuyen();
            HienThiTongQuan();
        }

        private void ApDungPhanQuyen()
        {
            bool laAdmin = PhienDangNhap.LaAdmin;

            // Nhân viên chỉ thực hiện các nghiệp vụ gửi xe.
            mnuDanhMuc.Enabled = laAdmin;
            mnuNhanSu.Enabled = laAdmin;
            mnuBaoCaoMenu.Enabled = laAdmin;

            if (!laAdmin)
            {
                mnuDanhMuc.ToolTipText = "Chỉ tài khoản ADMIN được sử dụng";
                mnuNhanSu.ToolTipText = "Chỉ tài khoản ADMIN được sử dụng";
                mnuBaoCaoMenu.ToolTipText = "Chỉ tài khoản ADMIN được sử dụng";
                lblNguoiDung.Text += " - Quyền nghiệp vụ gửi xe";
            }
        }

        private bool KiemTraQuyenAdmin()
        {
            if (PhienDangNhap.LaAdmin)
                return true;

            MessageBox.Show(
                "Chức năng này chỉ dành cho tài khoản ADMIN.",
                "Không có quyền truy cập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
        }

        private void HienThiTongQuan()
        {
            try
            {
                DataTable dtThongKe = kn.GetData("dbo.sp_TrangChu_ThongKe");
                DataRow thongKe = dtThongKe.Rows[0];

                lblXeDangGuiValue.Text = Convert.ToString(thongKe["XeDangGui"]);
                lblChoTrongValue.Text = Convert.ToString(thongKe["ChoTrong"]);
                lblVeThangValue.Text = Convert.ToString(thongKe["VeThangHieuLuc"]);
                lblDoanhThuValue.Text = Convert.ToDecimal(thongKe["DoanhThuHomNay"]).ToString("#,##0 ₫");

                dgvTongQuan.DataSource = kn.GetData("dbo.sp_TrangChu_KhuVuc");
                dgvTongQuan.ReadOnly = true;
                dgvTongQuan.AllowUserToAddRows = false;
                dgvTongQuan.AllowUserToDeleteRows = false;
                dgvTongQuan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTongQuan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTongQuan.RowHeadersVisible = false;

                dgvTongQuan.Columns["MaKhuVuc"].HeaderText = "Mã khu vực";
                dgvTongQuan.Columns["TenKhuVuc"].HeaderText = "Tên khu vực";
                dgvTongQuan.Columns["LoaiXe"].HeaderText = "Loại xe";
                dgvTongQuan.Columns["SucChua"].HeaderText = "Sức chứa";
                dgvTongQuan.Columns["DangGui"].HeaderText = "Đang gửi";
                dgvTongQuan.Columns["ConTrong"].HeaderText = "Còn trống";
                dgvTongQuan.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu tổng quan: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiTongQuan_Click(object sender, EventArgs e)
        {
            HienThiTongQuan();
        }

        private void mnuXeVao_Click(object sender, EventArgs e)
        {
            using (frmXeVao frm = new frmXeVao())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuXeRa_Click(object sender, EventArgs e)
        {
            using (frmXeRa frm = new frmXeRa())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuLichSu_Click(object sender, EventArgs e)
        {
            using (frmLichSuGuiXe frm = new frmLichSuGuiXe())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuDangKyVeThang_Click(object sender, EventArgs e)
        {
            using (frmDangKyVeThang frm = new frmDangKyVeThang())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmKhachHang frm = new frmKhachHang())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuPhuongTien_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmPhuongTien frm = new frmPhuongTien())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuLoaiVe_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmLoaiVe frm = new frmLoaiVe())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuBangGia_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmBangGia frm = new frmBangGia())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuKhuVuc_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmKhuVuc frm = new frmKhuVuc())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmNhanVien frm = new frmNhanVien())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuTaiKhoan_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmTaiKhoan frm = new frmTaiKhoan())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuCaLam_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmCaLam frm = new frmCaLam())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuPhanCongCa_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            using (frmPhanCongCa frm = new frmPhanCongCa())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {
            if (!KiemTraQuyenAdmin()) return;
            try
            {
                using (frmBaoCao frm = new frmBaoCao())
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở Form báo cáo: " + ex.Message,
                    "Lỗi báo cáo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.Yes)
            {
                DialogResult = DialogResult.Retry;
                Close();
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
