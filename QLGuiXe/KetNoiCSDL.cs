using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QLGuiXe
{
    public class KETNOICSDL
    {
        private readonly string chuoiKetNoi =
            ConfigurationManager.ConnectionStrings["QLGuiXe"].ConnectionString;

        public SqlConnection TaoKetNoi()
        {
            return new SqlConnection(chuoiKetNoi);
        }

        public DataTable GetData(
            string tenThuTuc,
            params SqlParameter[] thamSo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(tenThuTuc, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (thamSo != null && thamSo.Length > 0)
                    cmd.Parameters.AddRange(thamSo);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public int Execute(
            string tenThuTuc,
            params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(tenThuTuc, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (thamSo != null && thamSo.Length > 0)
                    cmd.Parameters.AddRange(thamSo);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public static class PhienDangNhap
    {
        public static string MaNhanVien { get; private set; } = string.Empty;
        public static string HoTen { get; private set; } = string.Empty;
        public static string VaiTro { get; private set; } = string.Empty;
        public static string TenDangNhap { get; private set; } = string.Empty;

        public static bool LaAdmin
        {
            get { return VaiTro == "ADMIN"; }
        }

        public static void LuuThongTin(
            string maNhanVien,
            string hoTen,
            string vaiTro,
            string tenDangNhap)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            VaiTro = (vaiTro ?? string.Empty).Trim().ToUpperInvariant();
            TenDangNhap = tenDangNhap;
        }

        public static void DangXuat()
        {
            MaNhanVien = string.Empty;
            HoTen = string.Empty;
            VaiTro = string.Empty;
            TenDangNhap = string.Empty;
        }
    }
}
