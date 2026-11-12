using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmXeVao : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        Timer dongHo = new Timer();

        public frmXeVao()
        {
            InitializeComponent();
        }

        private void TaiNhanVien()
        {
            DataTable dt = kn.GetData("dbo.sp_XeVao_NhanVien");

            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";

            if (PhienDangNhap.MaNhanVien != "")
            {
                cboNhanVien.SelectedValue = PhienDangNhap.MaNhanVien;
            }

            cboNhanVien.Enabled = PhienDangNhap.LaAdmin;
        }

        private void TaiTheXe()
        {
            DataTable dt = kn.GetData("dbo.sp_XeVao_TheTrong");

            cboTheXe.DataSource = dt;
            cboTheXe.DisplayMember = "MaThe";
            cboTheXe.ValueMember = "MaThe";
        }

        private void TaiKhuVuc()
        {
            if (cboLoaiXe.Text == "")
            {
                return;
            }

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

            if (bienSo == "")
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

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin kiểm tra biển số!");
                    return;
                }

                DataRow row = dt.Rows[0];

                bool daCo = Convert.ToBoolean(row["DaCoTrongHeThong"]);
                bool dangTrongBai = Convert.ToBoolean(row["DangTrongBai"]);
                bool coVeThang = Convert.ToBoolean(row["CoVeThang"]);

                if (daCo == true && row["LoaiXe"] != DBNull.Value)
                {
                    cboLoaiXe.Text = row["LoaiXe"].ToString();
                }

                if (daCo == true)
                {
                    lblTrangThaiPhuongTien.Text = "✓ Đã có trong hệ thống";
                    lblTrangThaiPhuongTien.ForeColor = Color.Green;
                }
                else
                {
                    lblTrangThaiPhuongTien.Text = "• Khách vãng lai / phương tiện mới";
                    lblTrangThaiPhuongTien.ForeColor = Color.DimGray;
                }

                if (dangTrongBai == true)
                {
                    lblTrangThaiTrongBai.Text = "✕ Phương tiện đang ở trong bãi";
                    lblTrangThaiTrongBai.ForeColor = Color.Red;
                }
                else
                {
                    lblTrangThaiTrongBai.Text = "✓ Không có lượt gửi đang mở";
                    lblTrangThaiTrongBai.ForeColor = Color.Green;
                }

                if (coVeThang == true)
                {
                    lblTrangThaiVeThang.Text = "✓ Vé tháng hợp lệ, đã thanh toán";
                    lblTrangThaiVeThang.ForeColor = Color.Green;
                    lblGiaTriLoaiVe.Text = "THANG — phí lượt 0 ₫";
                }
                else
                {
                    lblTrangThaiVeThang.Text = "• Không có vé tháng hợp lệ";
                    lblTrangThaiVeThang.ForeColor = Color.DarkOrange;
                    lblGiaTriLoaiVe.Text = "LUOT — tính theo bảng giá";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra biển số: " + ex.Message);
            }
        }

        private void CapNhatChoTrong()
        {
            DataRowView row = cboKhuVuc.SelectedItem as DataRowView;

            if (row == null)
            {
                lblGiaTriChoTrong.Text = "—";
                return;
            }

            int conTrong = Convert.ToInt32(row["ConTrong"]);

            lblGiaTriChoTrong.Text = conTrong + " chỗ";

            if (conTrong > 0)
            {
                lblGiaTriChoTrong.ForeColor = Color.Green;
            }
            else
            {
                lblGiaTriChoTrong.ForeColor = Color.Red;
            }
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
            if (txtBienSo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập biển số xe!");
                txtBienSo.Focus();
                return;
            }

            if (txtBienSo.Text.Trim().Length < 5)
            {
                MessageBox.Show("Biển số xe không hợp lệ!");
                txtBienSo.Focus();
                return;
            }

            if (cboLoaiXe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại xe!");
                cboLoaiXe.Focus();
                return;
            }

            if (cboTheXe.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thẻ xe!");
                cboTheXe.Focus();
                return;
            }

            if (cboKhuVuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khu vực gửi xe!");
                cboKhuVuc.Focus();
                return;
            }

            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên tiếp nhận!");
                cboNhanVien.Focus();
                return;
            }

            if (PhienDangNhap.MaNhanVien == "")
            {
                MessageBox.Show("Vui lòng đăng nhập trước khi nhận xe!");
                return;
            }

            DataRowView khuVuc = cboKhuVuc.SelectedItem as DataRowView;

            if (khuVuc == null || Convert.ToInt32(khuVuc["ConTrong"]) <= 0)
            {
                MessageBox.Show("Khu vực đã hết chỗ trống!");
                return;
            }

            SqlParameter maLuotMoi = new SqlParameter("@MaLuotGuiMoi", SqlDbType.VarChar, 20);
            maLuotMoi.Direction = ParameterDirection.Output;

            try
            {
                object maNhanVien = PhienDangNhap.MaNhanVien;

                if (PhienDangNhap.LaAdmin == true)
                {
                    maNhanVien = cboNhanVien.SelectedValue;
                }

                kn.Execute(
                    "dbo.sp_XeVao",
                    new SqlParameter("@BienSo", txtBienSo.Text.Trim()),
                    new SqlParameter("@LoaiXe", cboLoaiXe.Text),
                    new SqlParameter("@MaThe", cboTheXe.SelectedValue),
                    new SqlParameter("@MaKhuVuc", cboKhuVuc.SelectedValue),
                    new SqlParameter("@MaNVVao", maNhanVien),
                    new SqlParameter("@MaKH", DBNull.Value),
                    maLuotMoi
                );

                MessageBox.Show("Xác nhận xe vào thành công! Mã lượt: "
                    + maLuotMoi.Value.ToString());

                HienThiXeDangGui();
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

        private void frmXeVao_Load(object sender, EventArgs e)
        {
            dgvXeDangGui.ReadOnly = true;
            dgvXeDangGui.AllowUserToAddRows = false;
            dgvXeDangGui.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXeDangGui.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvXeDangGui.MultiSelect = false;

            cboLoaiXe.Items.Clear();
            cboLoaiXe.Items.Add("Xe máy");
            cboLoaiXe.Items.Add("Ô tô");
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
    }
}
