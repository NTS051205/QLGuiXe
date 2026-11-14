using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLGuiXe.Forms
{
    public partial class frmDangKyVeThang : Form
    {
        KETNOICSDL kn = new KETNOICSDL();
        DataTable dtDangKy = new DataTable();

        bool dangTaiKhachHang;
        bool dangTaiPhuongTien;

        public frmDangKyVeThang()
        {
            InitializeComponent();
        }

        private void frmDangKyVeThang_Load(
            object sender,
            EventArgs e)
        {
            dgvDangKy.ReadOnly = true;
            dgvDangKy.AllowUserToAddRows = false;

            dgvDangKy.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDangKy.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDangKy.MultiSelect = false;

            cboPhuongThuc.Items.Add("TIEN_MAT");
            cboPhuongThuc.Items.Add("CHUYEN_KHOAN");
            cboPhuongThuc.Items.Add("THE");

            cboPhuongThuc.SelectedIndex = 0;

            dtpBatDau.Value = DateTime.Today;
            nudSoThang.Value = 1;
            nudSoThangHoan.Value = 1;

            btnHoanTien.Enabled =
                PhienDangNhap.LaAdmin;

            try
            {
                TaiKhachHang();
                HienThiDangKy();
                TaiTheThang();
                TinhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu: "
                    + ex.Message
                );
            }
        }

        private void HienThiDangKy()
        {
            dtDangKy =
                kn.GetData(
                    "dbo.sp_DANGKYVETHANG_DanhSach"
                );

            dgvDangKy.DataSource = dtDangKy;

            dgvDangKy.Columns["MaDangKy"].HeaderText =
                "Mã đăng ký";

            dgvDangKy.Columns["MaKH"].HeaderText =
                "Mã KH";

            dgvDangKy.Columns["KhachHang"].HeaderText =
                "Khách hàng";

            dgvDangKy.Columns["MaPT"].HeaderText =
                "Mã PT";

            dgvDangKy.Columns["BienSo"].HeaderText =
                "Biển số";

            dgvDangKy.Columns["MaThe"].HeaderText =
                "Mã thẻ tháng";

            dgvDangKy.Columns["NgayBatDau"].HeaderText =
                "Ngày bắt đầu";

            dgvDangKy.Columns["NgayKetThuc"].HeaderText =
                "Ngày kết thúc";

            dgvDangKy.Columns["TongTien"].HeaderText =
                "Tổng tiền";

            dgvDangKy.Columns["ThanhToan"].HeaderText =
                "Thanh toán";

            dgvDangKy.Columns["TrangThai"].HeaderText =
                "Trạng thái";

            dgvDangKy.Columns["NgayBatDau"]
                .DefaultCellStyle.Format =
                "dd/MM/yyyy";

            dgvDangKy.Columns["NgayKetThuc"]
                .DefaultCellStyle.Format =
                "dd/MM/yyyy";

            dgvDangKy.Columns["TongTien"]
                .DefaultCellStyle.Format =
                "#,##0 ₫";

            dgvDangKy.ClearSelection();
        }

        private void ChonDangKyVuaTao(string maDangKy)
        {
            if (maDangKy == "")
            {
                return;
            }

            foreach (DataGridViewRow row in dgvDangKy.Rows)
            {
                string maDangKyTrenLuoi =
                    Convert.ToString(
                        row.Cells["MaDangKy"].Value
                    );

                if (maDangKyTrenLuoi == maDangKy)
                {
                    dgvDangKy.ClearSelection();
                    row.Selected = true;
                    dgvDangKy.CurrentCell =
                        row.Cells["MaDangKy"];
                    dgvDangKy.FirstDisplayedScrollingRowIndex =
                        row.Index;

                    return;
                }
            }
        }

        private void TaiKhachHang()
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_DANGKYVETHANG_KhachHang"
                );

            dangTaiKhachHang = true;

            cboKhachHang.DisplayMember =
                "HoTen";

            cboKhachHang.ValueMember =
                "MaKH";

            cboKhachHang.DataSource =
                dt;

            dangTaiKhachHang = false;

            HienThiKhachHangDangChon();
        }

        private void TaiPhuongTien(
            string maKhachHang)
        {
            DataTable dt =
                kn.GetData(
                    "dbo.sp_DANGKYVETHANG_PhuongTien",
                    new SqlParameter(
                        "@MaKH",
                        maKhachHang
                    )
                );

            dangTaiPhuongTien = true;

            cboPhuongTien.DisplayMember =
                "BienSo";

            cboPhuongTien.ValueMember =
                "MaPT";

            cboPhuongTien.DataSource =
                dt;

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
            DataTable dtThe =
                kn.GetData(
                    "dbo.sp_DANGKYVETHANG_TheThang"
                );

            DataTable dtConTrong =
                dtThe.Clone();

            DateTime ngayBatDau =
                dtpBatDau.Value.Date;

            DateTime ngayKetThuc =
                ngayBatDau.AddMonths(
                    Convert.ToInt32(
                        nudSoThang.Value
                    )
                );

            for (int i = 0;
                i < dtThe.Rows.Count;
                i++)
            {
                string maThe =
                    Convert.ToString(
                        dtThe.Rows[i]["MaThe"]
                    );

                bool dangDuocSuDung =
                    false;

                for (int j = 0;
                    j < dtDangKy.Rows.Count;
                    j++)
                {
                    string maTheDangKy =
                        Convert.ToString(
                            dtDangKy.Rows[j]["MaThe"]
                        );

                    string trangThai =
                        Convert.ToString(
                            dtDangKy.Rows[j]["TrangThai"]
                        );

                    if (maTheDangKy == maThe
                        &&
                        trangThai != "HUY")
                    {
                        if (dtDangKy.Rows[j]["NgayBatDau"]
                            != DBNull.Value
                            &&
                            dtDangKy.Rows[j]["NgayKetThuc"]
                            != DBNull.Value)
                        {
                            DateTime tuNgay =
                                Convert.ToDateTime(
                                    dtDangKy.Rows[j]["NgayBatDau"]
                                );

                            DateTime denNgay =
                                Convert.ToDateTime(
                                    dtDangKy.Rows[j]["NgayKetThuc"]
                                );

                            if (ngayBatDau < denNgay
                                &&
                                tuNgay < ngayKetThuc)
                            {
                                dangDuocSuDung =
                                    true;

                                break;
                            }
                        }
                    }
                }

                if (dangDuocSuDung == false)
                {
                    dtConTrong.ImportRow(
                        dtThe.Rows[i]
                    );
                }
            }

            cboTheThang.DisplayMember =
                "MaThe";

            cboTheThang.ValueMember =
                "MaThe";

            cboTheThang.DataSource =
                dtConTrong;
        }

        private void cboKhachHang_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (dangTaiKhachHang == true)
            {
                return;
            }

            HienThiKhachHangDangChon();
        }

        private void HienThiKhachHangDangChon()
        {
            DataRowView? row =
                cboKhachHang.SelectedItem
                as DataRowView;

            if (row == null)
            {
                txtHoTen.Clear();
                txtSoDienThoai.Clear();

                cboPhuongTien.DataSource =
                    null;

                txtBienSo.Clear();
                txtLoaiXe.Clear();

                return;
            }

            if (row["HoTen"] != DBNull.Value)
            {
                txtHoTen.Text =
                    Convert.ToString(
                        row["HoTen"]
                    );
            }
            else
            {
                txtHoTen.Clear();
            }

            if (row["SoDienThoai"]
                != DBNull.Value)
            {
                txtSoDienThoai.Text =
                    Convert.ToString(
                        row["SoDienThoai"]
                    );
            }
            else
            {
                txtSoDienThoai.Clear();
            }

            if (row["MaKH"]
                == DBNull.Value)
            {
                cboPhuongTien.DataSource =
                    null;

                txtBienSo.Clear();
                txtLoaiXe.Clear();

                return;
            }

            string maKH =
                Convert.ToString(
                    row["MaKH"]
                );

            if (maKH == "")
            {
                cboPhuongTien.DataSource =
                    null;

                txtBienSo.Clear();
                txtLoaiXe.Clear();

                return;
            }

            TaiPhuongTien(maKH);
        }

        private void cboPhuongTien_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (dangTaiPhuongTien == true)
            {
                return;
            }

            HienThiPhuongTienDangChon();
        }

        private void HienThiPhuongTienDangChon()
        {
            DataRowView? row =
                cboPhuongTien.SelectedItem
                as DataRowView;

            if (row == null)
            {
                txtBienSo.Clear();
                txtLoaiXe.Clear();

                TinhTien();

                return;
            }

            if (row["BienSo"]
                != DBNull.Value)
            {
                txtBienSo.Text =
                    Convert.ToString(
                        row["BienSo"]
                    );
            }
            else
            {
                txtBienSo.Clear();
            }

            if (row["LoaiXe"]
                != DBNull.Value)
            {
                txtLoaiXe.Text =
                    Convert.ToString(
                        row["LoaiXe"]
                    );
            }
            else
            {
                txtLoaiXe.Clear();
            }

            TinhTien();
        }

        private void TinhTien()
        {
            DateTime ngayKetThuc =
                dtpBatDau.Value.Date
                .AddMonths(
                    Convert.ToInt32(
                        nudSoThang.Value
                    )
                );

            lblNgayKetThucValue.Text =
                ngayKetThuc.ToString(
                    "dd/MM/yyyy"
                );

            if (txtLoaiXe.Text.Trim() == "")
            {
                lblDonGiaValue.Text =
                    "0 ₫";

                lblTongTienValue.Text =
                    "0 ₫";

                return;
            }

            DataTable dt =
                kn.GetData(
                    "dbo.sp_BANGGIA_GiaHienTai",

                    new SqlParameter(
                        "@LoaiXe",
                        txtLoaiXe.Text
                    ),

                    new SqlParameter(
                        "@LoaiVe",
                        "THANG"
                    )
                );

            decimal donGia = 0;

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DonGia"]
                    != DBNull.Value)
                {
                    donGia =
                        Convert.ToDecimal(
                            dt.Rows[0]["DonGia"]
                        );
                }
            }

            decimal tongTien =
                donGia
                * nudSoThang.Value;

            lblDonGiaValue.Text =
                donGia.ToString(
                    "#,##0 ₫"
                );

            lblTongTienValue.Text =
                tongTien.ToString(
                    "#,##0 ₫"
                );
        }

        private void dtpBatDau_ValueChanged(
            object sender,
            EventArgs e)
        {
            TinhTien();
            TaiTheThang();
        }

        private void nudSoThang_ValueChanged(
            object sender,
            EventArgs e)
        {
            TinhTien();
            TaiTheThang();
        }

        private void btnDangKy_Click(
            object sender,
            EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng!"
                );

                cboKhachHang.Focus();

                return;
            }

            if (cboPhuongTien.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phương tiện!"
                );

                cboPhuongTien.Focus();

                return;
            }

            if (cboTheThang.SelectedValue == null)
            {
                MessageBox.Show(
                    "Không còn thẻ tháng trống trong thời gian đã chọn!"
                );

                cboTheThang.Focus();

                return;
            }

            string maKH =
                Convert.ToString(
                    cboKhachHang.SelectedValue
                );

            string maPT =
                Convert.ToString(
                    cboPhuongTien.SelectedValue
                );

            string maThe =
                Convert.ToString(
                    cboTheThang.SelectedValue
                );

            if (maKH == ""
                || maPT == ""
                || maThe == "")
            {
                MessageBox.Show(
                    "Thông tin đăng ký không hợp lệ!"
                );

                return;
            }

            TaoDangKy(
                maKH,
                maPT,
                maThe,
                dtpBatDau.Value.Date
            );
        }

        private void TaoDangKy(
            string maKH,
            string maPT,
            string maThe,
            DateTime ngayBatDau)
        {
            SqlParameter maDangKy =
                new SqlParameter(
                    "@MaDangKyMoi",
                    SqlDbType.VarChar,
                    20
                );

            maDangKy.Direction =
                ParameterDirection.Output;

            SqlParameter ngayKetThuc =
                new SqlParameter(
                    "@NgayKetThuc",
                    SqlDbType.Date
                );

            ngayKetThuc.Direction =
                ParameterDirection.Output;

            SqlParameter tongTien =
                new SqlParameter(
                    "@TongTien",
                    SqlDbType.Decimal
                );

            tongTien.Precision = 18;
            tongTien.Scale = 2;

            tongTien.Direction =
                ParameterDirection.Output;

            try
            {
                kn.Execute(
                    "dbo.sp_DangKyVeThang",

                    new SqlParameter(
                        "@MaKH",
                        maKH
                    ),

                    new SqlParameter(
                        "@MaPT",
                        maPT
                    ),

                    new SqlParameter(
                        "@MaThe",
                        maThe
                    ),

                    new SqlParameter(
                        "@NgayBatDau",
                        ngayBatDau
                    ),

                    new SqlParameter(
                        "@SoThang",
                        Convert.ToInt32(
                            nudSoThang.Value
                        )
                    ),

                    maDangKy,
                    ngayKetThuc,
                    tongTien
                );

                decimal soTien = 0;

                if (tongTien.Value != null
                    &&
                    tongTien.Value != DBNull.Value)
                {
                    soTien =
                        Convert.ToDecimal(
                            tongTien.Value
                        );
                }

                string maDangKyMoi =
                    Convert.ToString(
                        maDangKy.Value
                    );

                MessageBox.Show(
                    "Đăng ký vé tháng thành công!"
                    + Environment.NewLine
                    + "Mã đăng ký: "
                    + maDangKyMoi
                    + Environment.NewLine
                    + "Tổng tiền: "
                    + soTien.ToString(
                        "#,##0 ₫"
                    )
                    + Environment.NewLine
                    + "Trạng thái: Chờ thanh toán."
                );

                HienThiDangKy();
                ChonDangKyVuaTao(
                    maDangKyMoi
                );
                TaiTheThang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đăng ký: "
                    + ex.Message
                );
            }
        }

        private void btnThanhToan_Click(
            object sender,
            EventArgs e)
        {
            DataRow? row =
                LayDongDangChon();

            if (row == null)
            {
                return;
            }

            if (Convert.ToString(
                row["ThanhToan"])
                == "DA_THANH_TOAN")
            {
                MessageBox.Show(
                    "Đăng ký này đã được thanh toán!"
                );

                return;
            }

            if (Convert.ToString(
                row["TrangThai"])
                == "HUY"
                || Convert.ToString(
                    row["ThanhToan"])
                    == "HOAN_TIEN")
            {
                MessageBox.Show(
                    "Đăng ký đã bị hủy hoặc hoàn tiền nên không thể thanh toán!"
                );

                return;
            }

            if (row["MaDangKy"]
                == DBNull.Value)
            {
                MessageBox.Show(
                    "Không xác định được mã đăng ký!"
                );

                return;
            }

            if (PhienDangNhap.MaNhanVien == "")
            {
                MessageBox.Show(
                    "Không xác định được nhân viên thanh toán!"
                );

                return;
            }

            SqlParameter maThanhToan =
                new SqlParameter(
                    "@MaThanhToanMoi",
                    SqlDbType.VarChar,
                    20
                );

            maThanhToan.Direction =
                ParameterDirection.Output;

            try
            {
                kn.Execute(
                    "dbo.sp_ThanhToanVeThang",

                    new SqlParameter(
                        "@MaDangKy",
                        Convert.ToString(
                            row["MaDangKy"]
                        )
                    ),

                    new SqlParameter(
                        "@MaNV",
                        PhienDangNhap.MaNhanVien
                    ),

                    new SqlParameter(
                        "@PhuongThuc",
                        cboPhuongThuc.Text
                    ),

                    new SqlParameter(
                        "@MaThamChieu",
                        DBNull.Value
                    ),

                    maThanhToan
                );

                MessageBox.Show(
                    "Thanh toán thành công!"
                    + Environment.NewLine
                    + "Mã thanh toán: "
                    + Convert.ToString(
                        maThanhToan.Value
                    )
                    + Environment.NewLine
                    + "Vé tháng đã được kích hoạt."
                );

                HienThiDangKy();
                TaiTheThang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thanh toán: "
                    + ex.Message
                );
            }
        }

        private void btnGiaHan_Click(
            object sender,
            EventArgs e)
        {
            DataRow? row =
                LayDongDangChon();

            if (row == null)
            {
                return;
            }

            if (Convert.ToString(
                row["ThanhToan"])
                != "DA_THANH_TOAN")
            {
                MessageBox.Show(
                    "Chỉ gia hạn đăng ký đã thanh toán!"
                );

                return;
            }

            if (row["NgayKetThuc"]
                == DBNull.Value)
            {
                MessageBox.Show(
                    "Không xác định được ngày kết thúc!"
                );

                return;
            }

            if (row["MaKH"] == DBNull.Value
                ||
                row["MaPT"] == DBNull.Value
                ||
                row["MaThe"] == DBNull.Value)
            {
                MessageBox.Show(
                    "Thông tin đăng ký không đầy đủ!"
                );

                return;
            }

            DateTime ngayBatDau =
                Convert.ToDateTime(
                    row["NgayKetThuc"]
                );

            if (ngayBatDau < DateTime.Today)
            {
                ngayBatDau =
                    DateTime.Today;
            }

            TaoDangKy(
                Convert.ToString(
                    row["MaKH"]
                ),

                Convert.ToString(
                    row["MaPT"]
                ),

                Convert.ToString(
                    row["MaThe"]
                ),

                ngayBatDau
            );
        }

        private void btnSuaDangKy_Click(
            object sender,
            EventArgs e)
        {
            DataRow? row =
                LayDongDangChon();

            if (row == null)
            {
                return;
            }

            string thanhToan =
                Convert.ToString(
                    row["ThanhToan"]
                );

            string trangThai =
                Convert.ToString(
                    row["TrangThai"]
                );

            if (thanhToan != "CHUA_THANH_TOAN"
                || trangThai == "HUY")
            {
                MessageBox.Show(
                    "Chỉ được sửa đăng ký chưa thanh toán và chưa hủy!"
                );

                return;
            }

            int soThangCu =
                Convert.ToInt32(
                    row["SoThang"]
                );

            int soThangMoi =
                Convert.ToInt32(
                    nudSoThang.Value
                );

            if (soThangCu == soThangMoi)
            {
                MessageBox.Show(
                    "Số tháng chưa thay đổi."
                );

                return;
            }

            DialogResult ketQua =
                MessageBox.Show(
                    "Đổi số tháng từ "
                    + soThangCu
                    + " thành "
                    + soThangMoi
                    + " tháng?",
                    "Xác nhận sửa đăng ký",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            SqlParameter ngayKetThuc =
                new SqlParameter(
                    "@NgayKetThuc",
                    SqlDbType.Date
                );

            ngayKetThuc.Direction =
                ParameterDirection.Output;

            SqlParameter tongTien =
                new SqlParameter(
                    "@TongTien",
                    SqlDbType.Decimal
                );

            tongTien.Precision = 18;
            tongTien.Scale = 2;
            tongTien.Direction =
                ParameterDirection.Output;

            string maDangKy =
                Convert.ToString(
                    row["MaDangKy"]
                );

            try
            {
                kn.Execute(
                    "dbo.sp_SuaDangKyVeThang",

                    new SqlParameter(
                        "@MaDangKy",
                        maDangKy
                    ),

                    new SqlParameter(
                        "@SoThang",
                        soThangMoi
                    ),

                    ngayKetThuc,
                    tongTien
                );

                MessageBox.Show(
                    "Sửa đăng ký thành công!"
                    + Environment.NewLine
                    + "Ngày kết thúc mới: "
                    + Convert.ToDateTime(
                        ngayKetThuc.Value
                    ).ToString("dd/MM/yyyy")
                    + Environment.NewLine
                    + "Tổng tiền mới: "
                    + Convert.ToDecimal(
                        tongTien.Value
                    ).ToString("#,##0 ₫")
                );

                HienThiDangKy();
                ChonDangKyVuaTao(
                    maDangKy
                );
                TaiTheThang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa đăng ký: "
                    + ex.Message
                );
            }
        }

        private void btnHuyDangKy_Click(
            object sender,
            EventArgs e)
        {
            DataRow? row =
                LayDongDangChon();

            if (row == null)
            {
                return;
            }

            if (Convert.ToString(
                row["ThanhToan"])
                != "CHUA_THANH_TOAN")
            {
                MessageBox.Show(
                    "Đăng ký đã thanh toán. Hãy dùng chức năng hoàn tiền."
                );

                return;
            }

            if (Convert.ToString(
                row["TrangThai"])
                == "HUY")
            {
                MessageBox.Show(
                    "Đăng ký này đã được hủy."
                );

                return;
            }

            string maDangKy =
                Convert.ToString(
                    row["MaDangKy"]
                );

            DialogResult ketQua =
                MessageBox.Show(
                    "Hủy đăng ký "
                    + maDangKy
                    + "? Thao tác này không xóa lịch sử.",
                    "Xác nhận hủy đăng ký",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            try
            {
                kn.Execute(
                    "dbo.sp_HuyDangKyVeThang",
                    new SqlParameter(
                        "@MaDangKy",
                        maDangKy
                    )
                );

                MessageBox.Show(
                    "Đã hủy đăng ký "
                    + maDangKy
                    + "."
                );

                HienThiDangKy();
                TaiTheThang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi hủy đăng ký: "
                    + ex.Message
                );
            }
        }

        private void btnHoanTien_Click(
            object sender,
            EventArgs e)
        {
            if (PhienDangNhap.LaAdmin == false)
            {
                MessageBox.Show(
                    "Chỉ tài khoản ADMIN được hoàn tiền."
                );

                return;
            }

            DataRow? row =
                LayDongDangChon();

            if (row == null)
            {
                return;
            }

            if (Convert.ToString(
                row["ThanhToan"])
                != "DA_THANH_TOAN")
            {
                MessageBox.Show(
                    "Chỉ hoàn tiền cho đăng ký đã thanh toán."
                );

                return;
            }

            if (txtLyDoHoanTien.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập lý do hoàn tiền."
                );

                txtLyDoHoanTien.Focus();
                return;
            }

            string maDangKy =
                Convert.ToString(
                    row["MaDangKy"]
                );

            if (row["NgayBatDau"] == DBNull.Value
                || row["NgayKetThuc"] == DBNull.Value
                || row["TongTien"] == DBNull.Value
                || row["DonGiaThang"] == DBNull.Value
                || row["SoThang"] == DBNull.Value)
            {
                MessageBox.Show(
                    "Thông tin thời hạn hoặc số tiền không đầy đủ."
                );

                return;
            }

            DateTime ngayBatDau =
                Convert.ToDateTime(
                    row["NgayBatDau"]
                ).Date;

            DateTime ngayKetThuc =
                Convert.ToDateTime(
                    row["NgayKetThuc"]
                ).Date;

            decimal tongTien =
                Convert.ToDecimal(
                    row["TongTien"]
                );

            decimal donGiaThang =
                Convert.ToDecimal(
                    row["DonGiaThang"]
                );

            int soThangHienTai =
                Convert.ToInt32(
                    row["SoThang"]
                );

            int soThangHoan =
                Convert.ToInt32(
                    nudSoThangHoan.Value
                );

            if (soThangHoan > soThangHienTai)
            {
                MessageBox.Show(
                    "Số tháng hoàn lớn hơn số tháng của đăng ký."
                );

                return;
            }

            int soThangConLaiDuKien =
                soThangHienTai - soThangHoan;

            DateTime ngayKetThucMoiDuKien =
                ngayBatDau.AddMonths(
                    soThangConLaiDuKien
                );

            DateTime ngayBatDauPhanHoan =
                ngayKetThucMoiDuKien;

            if (DateTime.Today
                > ngayBatDauPhanHoan)
            {
                ngayBatDauPhanHoan =
                    DateTime.Today;
            }

            int tongSoNgayPhanHoan =
                (ngayKetThuc
                - ngayKetThucMoiDuKien).Days;

            int soNgayChuaSuDung =
                (ngayKetThuc
                - ngayBatDauPhanHoan).Days;

            if (tongSoNgayPhanHoan <= 0
                || soNgayChuaSuDung <= 0)
            {
                MessageBox.Show(
                    "Phần tháng đã chọn không còn ngày chưa sử dụng để hoàn tiền."
                );

                return;
            }

            decimal soTienHoanDuKien =
                Math.Round(
                    donGiaThang
                    * soThangHoan
                    * soNgayChuaSuDung
                    / tongSoNgayPhanHoan,
                    0,
                    MidpointRounding.AwayFromZero
                );

            DialogResult ketQua =
                MessageBox.Show(
                    "Đăng ký: "
                    + maDangKy
                    + Environment.NewLine
                    + "Số tháng chọn hoàn: "
                    + soThangHoan
                    + Environment.NewLine
                    + "Số ngày của phần hoàn: "
                    + tongSoNgayPhanHoan
                    + Environment.NewLine
                    + "Số ngày chưa sử dụng: "
                    + soNgayChuaSuDung
                    + Environment.NewLine
                    + "Số tiền đã trả: "
                    + tongTien.ToString("#,##0 ₫")
                    + Environment.NewLine
                    + "Số tiền dự kiến hoàn: "
                    + soTienHoanDuKien.ToString("#,##0 ₫")
                    + Environment.NewLine
                    + Environment.NewLine
                    + "Bạn có chắc muốn hoàn tiền "
                    + "và cập nhật lại thời hạn vé?",
                    "Xác nhận hoàn tiền",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            SqlParameter soThangConLai =
                new SqlParameter(
                    "@SoThangConLai",
                    SqlDbType.TinyInt
                );

            soThangConLai.Direction =
                ParameterDirection.Output;

            SqlParameter ngayKetThucMoi =
                new SqlParameter(
                    "@NgayKetThucMoi",
                    SqlDbType.Date
                );

            ngayKetThucMoi.Direction =
                ParameterDirection.Output;

            SqlParameter soTienHoan =
                new SqlParameter(
                    "@SoTienHoan",
                    SqlDbType.Decimal
                );

            soTienHoan.Precision = 18;
            soTienHoan.Scale = 2;
            soTienHoan.Direction =
                ParameterDirection.Output;

            SqlParameter maThanhToanHoan =
                new SqlParameter(
                    "@MaThanhToanHoanMoi",
                    SqlDbType.VarChar,
                    20
                );

            maThanhToanHoan.Direction =
                ParameterDirection.Output;

            try
            {
                kn.Execute(
                    "dbo.sp_HoanTienVeThang",

                    new SqlParameter(
                        "@MaDangKy",
                        maDangKy
                    ),

                    new SqlParameter(
                        "@MaNV",
                        PhienDangNhap.MaNhanVien
                    ),

                    new SqlParameter(
                        "@LyDo",
                        txtLyDoHoanTien.Text.Trim()
                    ),

                    new SqlParameter(
                        "@SoThangHoan",
                        soThangHoan
                    ),

                    soThangConLai,
                    ngayKetThucMoi,
                    soTienHoan,
                    maThanhToanHoan
                );

                MessageBox.Show(
                    "Hoàn tiền thành công!"
                    + Environment.NewLine
                    + "Mã giao dịch hoàn: "
                    + Convert.ToString(
                        maThanhToanHoan.Value
                    )
                    + Environment.NewLine
                    + "Số tháng đã hoàn: "
                    + soThangHoan
                    + Environment.NewLine
                    + "Số tháng còn lại: "
                    + Convert.ToInt32(
                        soThangConLai.Value
                    )
                    + " tháng"
                    + Environment.NewLine
                    + "Số tiền hoàn: "
                    + Convert.ToDecimal(
                        soTienHoan.Value
                    ).ToString("#,##0 ₫")
                    + Environment.NewLine
                    + (
                        Convert.ToInt32(
                            soThangConLai.Value
                        ) == 0
                        || Convert.ToDateTime(
                            ngayKetThucMoi.Value
                        ).Date <= DateTime.Today
                        ? "Đăng ký đã chuyển sang HỦY."
                        : "Ngày kết thúc mới: "
                          + Convert.ToDateTime(
                              ngayKetThucMoi.Value
                          ).ToString("dd/MM/yyyy")
                    )
                );

                txtLyDoHoanTien.Clear();
                HienThiDangKy();
                TaiTheThang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi hoàn tiền: "
                    + ex.Message
                );
            }
        }

        private DataRow? LayDongDangChon()
        {
            if (dgvDangKy.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn một đăng ký trong danh sách!"
                );

                return null;
            }

            object duLieu =
                dgvDangKy.SelectedRows[0]
                .DataBoundItem;

            if (duLieu == null)
            {
                MessageBox.Show(
                    "Không đọc được thông tin đăng ký!"
                );

                return null;
            }

            DataRowView? row =
                duLieu as DataRowView;

            if (row == null)
            {
                MessageBox.Show(
                    "Không đọc được thông tin đăng ký!"
                );

                return null;
            }

            return row.Row;
        }

        private void dgvDangKy_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvDangKy.Rows[e.RowIndex];

            if (row.Cells["MaKH"].Value != null
                &&
                row.Cells["MaKH"].Value != DBNull.Value)
            {
                cboKhachHang.SelectedValue =
                    Convert.ToString(
                        row.Cells["MaKH"].Value
                    );
            }

            if (row.Cells["MaPT"].Value != null
                &&
                row.Cells["MaPT"].Value != DBNull.Value)
            {
                cboPhuongTien.SelectedValue =
                    Convert.ToString(
                        row.Cells["MaPT"].Value
                    );
            }

            if (row.Cells["MaThe"].Value != null
                &&
                row.Cells["MaThe"].Value != DBNull.Value)
            {
                cboTheThang.SelectedValue =
                    Convert.ToString(
                        row.Cells["MaThe"].Value
                    );
            }

            if (row.Cells["NgayBatDau"].Value != null
                &&
                row.Cells["NgayBatDau"].Value != DBNull.Value)
            {
                dtpBatDau.Value =
                    Convert.ToDateTime(
                        row.Cells["NgayBatDau"].Value
                    );
            }

            if (row.Cells["SoThang"].Value != null
                &&
                row.Cells["SoThang"].Value != DBNull.Value)
            {
                int soThang =
                    Convert.ToInt32(
                        row.Cells["SoThang"].Value
                    );

                if (soThang
                    < nudSoThang.Minimum)
                {
                    soThang =
                        Convert.ToInt32(
                            nudSoThang.Minimum
                        );
                }

                if (soThang
                    > nudSoThang.Maximum)
                {
                    soThang =
                        Convert.ToInt32(
                            nudSoThang.Maximum
                        );
                }

                nudSoThang.Value =
                    soThang;

                nudSoThangHoan.Maximum =
                    soThang;

                nudSoThangHoan.Value =
                    1;
            }

            TinhTien();
            TaiTheThang();
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                HienThiDangKy();
                TaiKhachHang();

                dtpBatDau.Value =
                    DateTime.Today;

                nudSoThang.Value =
                    1;

                nudSoThangHoan.Maximum =
                    24;

                nudSoThangHoan.Value =
                    1;

                txtLyDoHoanTien.Clear();

                TaiTheThang();
                TinhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi làm mới dữ liệu: "
                    + ex.Message
                );
            }
        }

        private void btnThemKhachHang_Click(
            object sender,
            EventArgs e)
        {
            frmKhachHang frm =
                new frmKhachHang();

            frm.ShowDialog();

            TaiKhachHang();
        }

        private void btnThemPhuongTien_Click(
            object sender,
            EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng trước khi thêm phương tiện!"
                );

                cboKhachHang.Focus();

                return;
            }

            string maKhachHang =
                Convert.ToString(
                    cboKhachHang.SelectedValue
                );

            if (maKhachHang == "")
            {
                MessageBox.Show(
                    "Không xác định được khách hàng!"
                );

                return;
            }

            frmPhuongTien frm =
                new frmPhuongTien(
                    maKhachHang
                );

            frm.ShowDialog();

            TaiPhuongTien(
                maKhachHang
            );
        }

        private void btnThoat_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}
