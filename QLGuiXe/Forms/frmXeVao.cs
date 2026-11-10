using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmXeVao : Form
    {
        private readonly KETNOICSDL kn = new KETNOICSDL();
        private readonly Timer dongHo = new Timer();

        public frmXeVao()
        {
            InitializeComponent();

            dgvXeDangGui.ReadOnly = true;
            dgvXeDangGui.AllowUserToAddRows = false;
            dgvXeDangGui.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXeDangGui.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvXeDangGui.MultiSelect = false;

            cboLoaiXe.Items.AddRange(new object[] { "Xe máy", "Ô tô" });
            cboLoaiXe.SelectedIndex = 0;

            TaiNhanVien();
            TaiTheXe();
            TaiKhuVuc();
            HienThiXeDangGui();
            KiemTraBienSo();

            dongHo.Interval = 1000;
            dongHo.Tick += CapNhatDongHo;
            dongHo.Start();
            CapNhatDongHo(this, EventArgs.Empty);
        }

        private void TaiNhanVien()
        {
            DataTable dt = kn.GetData("dbo.sp_XeVao_NhanVien");
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = dt;

            cboNhanVien.SelectedValue = PhienDangNhap.MaNhanVien;
            cboNhanVien.Enabled = PhienDangNhap.LaAdmin;
        }

        private void TaiTheXe()
        {
            DataTable dt = kn.GetData("dbo.sp_XeVao_TheTrong");
            cboTheXe.DisplayMember = "MaThe";
            cboTheXe.ValueMember = "MaThe";
            cboTheXe.DataSource = dt;
        }

        private void TaiKhuVuc()
        {
            if (string.IsNullOrWhiteSpace(cboLoaiXe.Text)) return;

            DataTable dt = kn.GetData(
                "dbo.sp_XeVao_KhuVuc",
                new SqlParameter("@LoaiXe", cboLoaiXe.Text));

            cboKhuVuc.DataSource = dt;
            cboKhuVuc.DisplayMember = "TenKhuVuc";
            cboKhuVuc.ValueMember = "MaKhuVuc";
            CapNhatChoTrong();
        }

        private void HienThiXeDangGui()
        {
            DataTable dt = kn.GetData("dbo.sp_XeDangGui_DanhSach");
            dgvXeDangGui.DataSource = dt;

            dgvXeDangGui.Columns["MaLuotGui"].HeaderText = "Mã lượt";
            dgvXeDangGui.Columns["BienSo"].HeaderText = "Biển số";
            dgvXeDangGui.Columns["LoaiXe"].HeaderText = "Loại xe";
            dgvXeDangGui.Columns["MaThe"].HeaderText = "Mã thẻ";
            dgvXeDangGui.Columns["KhuVuc"].HeaderText = "Khu vực";
            dgvXeDangGui.Columns["ThoiGianVao"].HeaderText = "Thời gian vào";
            dgvXeDangGui.Columns["NhanVienVao"].HeaderText = "Tiếp nhận";
            dgvXeDangGui.Columns["LoaiVe"].HeaderText = "Loại vé";
            dgvXeDangGui.Columns["ThoiGianVao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvXeDangGui.Columns["MaPT"].Visible = false;
            dgvXeDangGui.Columns["MaVe"].Visible = false;
            dgvXeDangGui.Columns["MaKhuVuc"].Visible = false;
            dgvXeDangGui.Columns["TienGui"].Visible = false;
            dgvXeDangGui.Columns["TrangThai"].Visible = false;
        }

        private void KiemTraBienSo()
        {
            string bienSo = txtBienSo.Text.Trim();
            if (bienSo.Length == 0)
            {
                lblTrangThaiPhuongTien.Text = "• Chưa nhập biển số";
                lblTrangThaiTrongBai.Text = "• Chưa kiểm tra";
                lblTrangThaiVeThang.Text = "• Chưa kiểm tra";
                lblGiaTriLoaiVe.Text = "LUOT — tính theo bảng giá";
                return;
            }

            try
            {
                DataTable dt = kn.GetData(
                    "dbo.sp_XeVao_KiemTra",
                    new SqlParameter("@BienSo", bienSo));

                DataRow row = dt.Rows[0];
                bool daCo = Convert.ToBoolean(row["DaCoTrongHeThong"]);
                bool dangTrongBai = Convert.ToBoolean(row["DangTrongBai"]);
                bool coVeThang = Convert.ToBoolean(row["CoVeThang"]);

                if (daCo && row["LoaiXe"] != DBNull.Value)
                    cboLoaiXe.Text = Convert.ToString(row["LoaiXe"]);

                lblTrangThaiPhuongTien.Text = daCo
                    ? "✓ Đã có trong hệ thống"
                    : "• Khách vãng lai / phương tiện mới";
                lblTrangThaiPhuongTien.ForeColor = daCo ? Color.Green : Color.DimGray;

                lblTrangThaiTrongBai.Text = dangTrongBai
                    ? "✕ Phương tiện đang ở trong bãi"
                    : "✓ Không có lượt gửi đang mở";
                lblTrangThaiTrongBai.ForeColor = dangTrongBai ? Color.Red : Color.Green;

                lblTrangThaiVeThang.Text = coVeThang
                    ? "✓ Vé tháng hợp lệ, đã thanh toán"
                    : "• Không có vé tháng hợp lệ";
                lblTrangThaiVeThang.ForeColor = coVeThang ? Color.Green : Color.DarkOrange;
                lblGiaTriLoaiVe.Text = coVeThang
                    ? "THANG — phí lượt 0 ₫"
                    : "LUOT — tính theo bảng giá";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra biển số: " + ex.Message);
            }
        }

        private void CapNhatChoTrong()
        {
            DataRowView? row = cboKhuVuc.SelectedItem as DataRowView;
            if (row == null)
            {
                lblGiaTriChoTrong.Text = "—";
                return;
            }

            int conTrong = Convert.ToInt32(row["ConTrong"]);
            lblGiaTriChoTrong.Text = conTrong + " chỗ";
            lblGiaTriChoTrong.ForeColor = conTrong > 0 ? Color.Green : Color.Red;
        }

        private void txtBienSo_TextChanged(object sender, EventArgs e)
        {
            KiemTraBienSo();
        }

        private void Input_Changed(object sender, EventArgs e)
        {
            TaiKhuVuc();
        }

        private void cboKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatChoTrong();
        }

        private void btnXacNhanXeVao_Click(object sender, EventArgs e)
        {
            if (txtBienSo.Text.Trim().Length < 5)
            {
                MessageBox.Show("Vui lòng nhập biển số hợp lệ!");
                txtBienSo.Focus();
                return;
            }
            if (cboTheXe.SelectedValue == null || cboKhuVuc.SelectedValue == null || cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thẻ xe, khu vực và nhân viên!");
                return;
            }

            DataRowView? khuVuc = cboKhuVuc.SelectedItem as DataRowView;
            if (khuVuc == null || Convert.ToInt32(khuVuc["ConTrong"]) <= 0)
            {
                MessageBox.Show("Khu vực đã hết chỗ trống!");
                return;
            }

            SqlParameter maLuotMoi = new SqlParameter("@MaLuotGuiMoi", SqlDbType.VarChar, 20);
            maLuotMoi.Direction = ParameterDirection.Output;

            try
            {
                kn.Execute(
                    "dbo.sp_XeVao",
                    new SqlParameter("@BienSo", txtBienSo.Text.Trim()),
                    new SqlParameter("@LoaiXe", cboLoaiXe.Text),
                    new SqlParameter("@MaThe", cboTheXe.SelectedValue),
                    new SqlParameter("@MaKhuVuc", cboKhuVuc.SelectedValue),
                    new SqlParameter("@MaNVVao", PhienDangNhap.LaAdmin
                        ? cboNhanVien.SelectedValue
                        : (object)PhienDangNhap.MaNhanVien),
                    new SqlParameter("@MaKH", DBNull.Value),
                    maLuotMoi);

                MessageBox.Show("Xác nhận xe vào thành công! Mã lượt: " + Convert.ToString(maLuotMoi.Value));
                HienThiXeDangGui();
                TaiTheXe();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể nhận xe: " + ex.Message);
            }
        }

        private void LamMoiDuLieu()
        {
            txtBienSo.Clear();
            cboLoaiXe.SelectedIndex = 0;
            TaiTheXe();
            TaiKhuVuc();
            KiemTraBienSo();
            txtBienSo.Focus();
        }

        private void CapNhatDongHo(object sender, EventArgs e)
        {
            lblGiaTriThoiGianVao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnLamMoiXeVao_Click(object sender, EventArgs e)
        {
            LamMoiDuLieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dongHo.Dispose();
                if (components != null) components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
