using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmXeRa : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataRow luotGuiDangChon;

        public frmXeRa()
        {
            InitializeComponent();
        }

        private void frmXeRa_Load(object sender, EventArgs e)
        {
            cboPhuongThucThanhToan.Items.Clear();
            cboPhuongThucThanhToan.Items.Add("TIEN_MAT");
            cboPhuongThucThanhToan.Items.Add("CHUYEN_KHOAN");
            cboPhuongThucThanhToan.Items.Add("THE");
            cboPhuongThucThanhToan.SelectedIndex = 0;

            dgvXeDangGui.ReadOnly = true;
            dgvXeDangGui.AllowUserToAddRows = false;
            dgvXeDangGui.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXeDangGui.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvXeDangGui.MultiSelect = false;

            HienThiXeDangGui();
            LamMoiDuLieu();
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
            dgvXeDangGui.Columns["NhanVienVao"].HeaderText = "Nhân viên vào";
            dgvXeDangGui.Columns["LoaiVe"].HeaderText = "Loại vé";

            dgvXeDangGui.Columns["ThoiGianVao"].DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";

            dgvXeDangGui.Columns["MaPT"].Visible = false;
            dgvXeDangGui.Columns["MaVe"].Visible = false;
            dgvXeDangGui.Columns["MaKhuVuc"].Visible = false;
            dgvXeDangGui.Columns["TienGui"].Visible = false;
            dgvXeDangGui.Columns["TrangThai"].Visible = false;

            dgvXeDangGui.ClearSelection();
        }

        private void TimXeDangGui(string tuKhoa)
        {
            DataTable dt = kn.GetData(
                "dbo.sp_XeRa_TimKiem",
                new SqlParameter("@TuKhoa", tuKhoa.Trim()));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy lượt gửi đang mở theo biển số hoặc mã thẻ!");

                LamMoiDuLieu(false);
                return;
            }

            luotGuiDangChon = dt.Rows[0];

            HienThiThongTinXe();
        }

        private void HienThiThongTinXe()
        {
            if (luotGuiDangChon == null)
            {
                return;
            }

            DateTime thoiGianVao =
                Convert.ToDateTime(luotGuiDangChon["ThoiGianVao"]);

            DateTime thoiGianRa = DateTime.Now;

            TimeSpan thoiGianGui =
                thoiGianRa - thoiGianVao;

            decimal tienDuKien =
                Convert.ToDecimal(luotGuiDangChon["TienDuKien"]);

            lblGiaTriBienSo.Text =
                Convert.ToString(luotGuiDangChon["BienSo"]);

            lblGiaTriLoaiXe.Text =
                Convert.ToString(luotGuiDangChon["LoaiXe"]);

            lblGiaTriMaThe.Text =
                Convert.ToString(luotGuiDangChon["MaThe"]);

            lblGiaTriKhuVuc.Text =
                Convert.ToString(luotGuiDangChon["KhuVuc"]);

            lblGiaTriThoiGianVao.Text =
                thoiGianVao.ToString("dd/MM/yyyy HH:mm:ss");

            lblGiaTriThoiGianRa.Text =
                thoiGianRa.ToString("dd/MM/yyyy HH:mm:ss");

            lblGiaTriThoiGianGui.Text =
                (int)thoiGianGui.TotalHours
                + " giờ "
                + thoiGianGui.Minutes
                + " phút";

            lblGiaTriLoaiVe.Text =
                Convert.ToString(luotGuiDangChon["LoaiVe"]);

            lblGiaTriSoTien.Text =
                tienDuKien.ToString("#,##0 ₫");

            if (tienDuKien == 0)
            {
                lblGiaTriSoTien.ForeColor = Color.Green;
                lblTrangThaiXuLy.Text =
                    "Vé tháng hợp lệ — không thu phí lượt";
            }
            else
            {
                lblGiaTriSoTien.ForeColor = Color.Red;
                lblTrangThaiXuLy.Text =
                    "Chờ xác nhận và thanh toán";
            }

            btnXacNhanXeRa.Enabled = true;
            btnThanhToanXeRa.Enabled = false;
        }

        private void btnTimKiemXe_Click(object sender, EventArgs e)
        {
            if (txtBienSoHoacMaThe.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập biển số hoặc mã thẻ!");
                txtBienSoHoacMaThe.Focus();
                return;
            }

            TimXeDangGui(txtBienSoHoacMaThe.Text);
        }

        private void dgvXeDangGui_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txtBienSoHoacMaThe.Text =
                Convert.ToString(
                    dgvXeDangGui.Rows[e.RowIndex]
                    .Cells["BienSo"].Value);

            TimXeDangGui(txtBienSoHoacMaThe.Text);
        }

        private void btnXacNhanXeRa_Click(object sender, EventArgs e)
        {
            if (luotGuiDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn xe cần xác nhận ra!");
                return;
            }

            if (Convert.ToString(luotGuiDangChon["LoaiVe"]) == "THANG")
            {
                XacNhanXeRa("TIEN_MAT");
                return;
            }

            btnThanhToanXeRa.Enabled = true;
            btnXacNhanXeRa.Enabled = false;

            lblTrangThaiXuLy.Text =
                "Đã xác nhận thông tin — vui lòng thu tiền và thanh toán";
        }

        private void btnThanhToanXeRa_Click(object sender, EventArgs e)
        {
            if (luotGuiDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn xe cần thanh toán!");
                return;
            }

            if (cboPhuongThucThanhToan.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!");
                cboPhuongThucThanhToan.Focus();
                return;
            }

            XacNhanXeRa(cboPhuongThucThanhToan.Text);
        }

        private void XacNhanXeRa(string phuongThuc)
        {
            if (luotGuiDangChon == null)
            {
                return;
            }

            if (PhienDangNhap.MaNhanVien == "")
            {
                MessageBox.Show(
                    "Vui lòng đăng nhập trước khi xác nhận xe ra!");

                return;
            }

            SqlParameter maLuotGui =
                new SqlParameter(
                    "@MaLuotGui",
                    SqlDbType.VarChar,
                    20);

            maLuotGui.Direction =
                ParameterDirection.Output;

            SqlParameter tienGui =
                new SqlParameter(
                    "@TienGui",
                    SqlDbType.Decimal);

            tienGui.Precision = 18;
            tienGui.Scale = 2;
            tienGui.Direction =
                ParameterDirection.Output;

            try
            {
                kn.Execute(
                    "dbo.sp_XeRa",

                    new SqlParameter(
                        "@BienSoHoacMaThe",
                        Convert.ToString(
                            luotGuiDangChon["BienSo"])),

                    new SqlParameter(
                        "@MaNVRa",
                        PhienDangNhap.MaNhanVien),

                    new SqlParameter(
                        "@PhuongThuc",
                        phuongThuc),

                    maLuotGui,
                    tienGui
                );

                decimal soTien =
                    Convert.ToDecimal(tienGui.Value);

                if (soTien == 0)
                {
                    MessageBox.Show(
                        "Đã xác nhận xe ra. Vé tháng hợp lệ, phí lượt 0 ₫.");
                }
                else
                {
                    MessageBox.Show(
                        "Thanh toán thành công "
                        + soTien.ToString("#,##0 ₫")
                        + ".");
                }

                HienThiXeDangGui();
                LamMoiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xác nhận xe ra: "
                    + ex.Message);
            }
        }

        private void LamMoiDuLieu()
        {
            LamMoiDuLieu(true);
        }

        private void LamMoiDuLieu(bool xoaTimKiem)
        {
            luotGuiDangChon = null;

            if (xoaTimKiem == true)
            {
                txtBienSoHoacMaThe.Clear();
            }

            lblGiaTriBienSo.Text = "—";
            lblGiaTriLoaiXe.Text = "—";
            lblGiaTriMaThe.Text = "—";
            lblGiaTriKhuVuc.Text = "—";
            lblGiaTriThoiGianVao.Text = "—";
            lblGiaTriThoiGianRa.Text = "—";
            lblGiaTriThoiGianGui.Text = "—";
            lblGiaTriLoaiVe.Text = "—";
            lblGiaTriSoTien.Text = "0 ₫";

            lblGiaTriSoTien.ForeColor =
                SystemColors.ControlText;

            lblTrangThaiXuLy.Text =
                "Nhập biển số hoặc mã thẻ để tra cứu";

            btnXacNhanXeRa.Enabled = false;
            btnThanhToanXeRa.Enabled = false;
        }

        private void btnLamMoiXeRa_Click(object sender, EventArgs e)
        {
            HienThiXeDangGui();
            LamMoiDuLieu();
            txtBienSoHoacMaThe.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}