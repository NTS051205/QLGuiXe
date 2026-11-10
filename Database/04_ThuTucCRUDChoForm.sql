/*
    FILE 04 - TẠO STORED PROCEDURE CHO CÁC FORM

    Các Stored Procedure được gọi trực tiếp từ từng Form.
    Cách tổ chức này giống bài thực hành: Form -> KETNOICSDL -> Stored Procedure.
*/

USE QLGuiXe;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KiemTraKetNoi
AS
BEGIN
    SELECT DB_NAME() AS TenCSDL;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_DangNhap
    @TenDangNhap VARCHAR(50),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tk
    SET tk.LanDangNhapCuoiUtc = SYSUTCDATETIME()
    FROM dbo.TAIKHOAN AS tk
    INNER JOIN dbo.NHANVIEN AS nv ON nv.MaNV = tk.MaNV
    WHERE tk.TenDangNhap = @TenDangNhap
      AND tk.MatKhauHash = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2)
      AND tk.TrangThai = 'HOAT_DONG'
      AND nv.TrangThai = 'HOAT_DONG';

    SELECT TOP (1) tk.MaTK, tk.TenDangNhap, tk.MaNV, nv.HoTen, tk.VaiTro
    FROM dbo.TAIKHOAN AS tk
    INNER JOIN dbo.NHANVIEN AS nv ON nv.MaNV = tk.MaNV
    WHERE tk.TenDangNhap = @TenDangNhap
      AND tk.MatKhauHash = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2)
      AND tk.TrangThai = 'HOAT_DONG'
      AND nv.TrangThai = 'HOAT_DONG';
END;
GO

/* NHÂN VIÊN */
CREATE OR ALTER PROCEDURE dbo.sp_NHANVIEN_DanhSach AS
    SELECT MaNV, HoTen, SoDienThoai, TrangThai FROM dbo.NHANVIEN ORDER BY MaNV;
GO
CREATE OR ALTER PROCEDURE dbo.sp_NHANVIEN_MaMoi AS
    SELECT 'NV' + RIGHT('000' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaNV, 3, 20))), 0) + 1), 3) AS MaMoi FROM dbo.NHANVIEN;
GO
CREATE OR ALTER PROCEDURE dbo.sp_NHANVIEN_Them @MaNV VARCHAR(20), @HoTen NVARCHAR(100), @SoDienThoai VARCHAR(15), @TrangThai VARCHAR(20) AS
    INSERT dbo.NHANVIEN(MaNV, HoTen, SoDienThoai, TrangThai) VALUES(UPPER(@MaNV), @HoTen, @SoDienThoai, @TrangThai);
GO
CREATE OR ALTER PROCEDURE dbo.sp_NHANVIEN_Sua @MaNV VARCHAR(20), @HoTen NVARCHAR(100), @SoDienThoai VARCHAR(15), @TrangThai VARCHAR(20) AS
    UPDATE dbo.NHANVIEN SET HoTen=@HoTen, SoDienThoai=@SoDienThoai, TrangThai=@TrangThai WHERE MaNV=@MaNV;
GO
CREATE OR ALTER PROCEDURE dbo.sp_NHANVIEN_VoHieu @MaNV VARCHAR(20) AS
    UPDATE dbo.NHANVIEN SET TrangThai='VO_HIEU' WHERE MaNV=@MaNV;
GO

/* TÀI KHOẢN */
CREATE OR ALTER PROCEDURE dbo.sp_TAIKHOAN_DanhSach AS
    SELECT MaTK, TenDangNhap, NhanVien, VaiTro, TrangThai FROM dbo.vw_TaiKhoan ORDER BY MaTK;
GO
CREATE OR ALTER PROCEDURE dbo.sp_TAIKHOAN_NhanVien AS
    SELECT MaNV, HoTen FROM dbo.NHANVIEN WHERE TrangThai='HOAT_DONG' ORDER BY HoTen;
GO
CREATE OR ALTER PROCEDURE dbo.sp_TAIKHOAN_MaMoi AS
    SELECT 'TK' + RIGHT('000' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaTK, 3, 20))), 0) + 1), 3) AS MaMoi FROM dbo.TAIKHOAN;
GO
CREATE OR ALTER PROCEDURE dbo.sp_TAIKHOAN_Them
    @MaTK VARCHAR(20), @TenDangNhap VARCHAR(50), @MatKhau NVARCHAR(100),
    @MaNV VARCHAR(20), @VaiTro VARCHAR(20), @TrangThai VARCHAR(20)
AS
    INSERT dbo.TAIKHOAN(MaTK, TenDangNhap, MatKhauHash, MaNV, VaiTro, TrangThai)
    VALUES(UPPER(@MaTK), @TenDangNhap, CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2), @MaNV, @VaiTro, @TrangThai);
GO
CREATE OR ALTER PROCEDURE dbo.sp_TAIKHOAN_Sua
    @MaTK VARCHAR(20), @TenDangNhap VARCHAR(50), @MatKhau NVARCHAR(100)=NULL,
    @MaNV VARCHAR(20), @VaiTro VARCHAR(20), @TrangThai VARCHAR(20)
AS
BEGIN
    UPDATE dbo.TAIKHOAN
    SET TenDangNhap=@TenDangNhap, MaNV=@MaNV, VaiTro=@VaiTro, TrangThai=@TrangThai,
        MatKhauHash=CASE WHEN NULLIF(@MatKhau, N'') IS NULL THEN MatKhauHash ELSE CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2) END
    WHERE MaTK=@MaTK;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_TAIKHOAN_Khoa @MaTK VARCHAR(20) AS
    UPDATE dbo.TAIKHOAN SET TrangThai='KHOA' WHERE MaTK=@MaTK;
GO

/* CA LÀM VÀ PHÂN CÔNG */
CREATE OR ALTER PROCEDURE dbo.sp_CALAM_DanhSach AS
    SELECT MaCa, TenCa, CONVERT(VARCHAR(5), GioBatDau, 108) AS GioBatDau,
           CONVERT(VARCHAR(5), GioKetThuc, 108) AS GioKetThuc, QuaDem
    FROM dbo.vw_CaLam ORDER BY MaCa;
GO
CREATE OR ALTER PROCEDURE dbo.sp_CALAM_MaMoi AS
    SELECT 'CA' + RIGHT('00' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaCa, 3, 20))), 0) + 1), 2) AS MaMoi FROM dbo.CALAM;
GO
CREATE OR ALTER PROCEDURE dbo.sp_CALAM_Them @MaCa VARCHAR(20), @TenCa NVARCHAR(50), @GioBatDau TIME(0), @GioKetThuc TIME(0) AS
    INSERT dbo.CALAM(MaCa, TenCa, GioBatDau, GioKetThuc) VALUES(UPPER(@MaCa), @TenCa, @GioBatDau, @GioKetThuc);
GO
CREATE OR ALTER PROCEDURE dbo.sp_CALAM_Sua @MaCa VARCHAR(20), @TenCa NVARCHAR(50), @GioBatDau TIME(0), @GioKetThuc TIME(0) AS
    UPDATE dbo.CALAM SET TenCa=@TenCa, GioBatDau=@GioBatDau, GioKetThuc=@GioKetThuc WHERE MaCa=@MaCa;
GO
CREATE OR ALTER PROCEDURE dbo.sp_CALAM_Xoa @MaCa VARCHAR(20) AS DELETE dbo.CALAM WHERE MaCa=@MaCa;
GO

CREATE OR ALTER PROCEDURE dbo.sp_PHANCONGCA_DanhSach AS
    SELECT MaPhanCong, MaNV, NhanVien, MaCa, CaLam, NgayLam FROM dbo.vw_PhanCongCa ORDER BY NgayLam DESC, MaPhanCong;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHANCONGCA_MaMoi AS
    SELECT 'PC' + RIGHT('000' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaPhanCong, 3, 20))), 0) + 1), 3) AS MaMoi FROM dbo.PHANCONGCA;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHANCONGCA_NhanVien AS SELECT MaNV, HoTen FROM dbo.NHANVIEN WHERE TrangThai='HOAT_DONG' ORDER BY HoTen;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHANCONGCA_CaLam AS SELECT MaCa, TenCa FROM dbo.CALAM ORDER BY MaCa;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHANCONGCA_Them @MaPhanCong VARCHAR(20), @MaNV VARCHAR(20), @MaCa VARCHAR(20), @NgayLam DATE AS
    INSERT dbo.PHANCONGCA(MaPhanCong, MaNV, MaCa, NgayLam) VALUES(UPPER(@MaPhanCong), @MaNV, @MaCa, @NgayLam);
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHANCONGCA_Sua @MaPhanCong VARCHAR(20), @MaNV VARCHAR(20), @MaCa VARCHAR(20), @NgayLam DATE AS
    UPDATE dbo.PHANCONGCA SET MaNV=@MaNV, MaCa=@MaCa, NgayLam=@NgayLam WHERE MaPhanCong=@MaPhanCong;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHANCONGCA_Xoa @MaPhanCong VARCHAR(20) AS DELETE dbo.PHANCONGCA WHERE MaPhanCong=@MaPhanCong;
GO

/* KHÁCH HÀNG VÀ PHƯƠNG TIỆN */
CREATE OR ALTER PROCEDURE dbo.sp_KHACHHANG_DanhSach AS SELECT MaKH, HoTen, SoDienThoai FROM dbo.KHACHHANG ORDER BY MaKH;
GO
CREATE OR ALTER PROCEDURE dbo.sp_KHACHHANG_MaMoi AS
    SELECT 'KH' + RIGHT('000' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaKH, 3, 20))), 0) + 1), 3) AS MaMoi FROM dbo.KHACHHANG;
GO
CREATE OR ALTER PROCEDURE dbo.sp_KHACHHANG_Them @MaKH VARCHAR(20), @HoTen NVARCHAR(100), @SoDienThoai VARCHAR(15) AS
    INSERT dbo.KHACHHANG(MaKH, HoTen, SoDienThoai) VALUES(UPPER(@MaKH), @HoTen, @SoDienThoai);
GO
CREATE OR ALTER PROCEDURE dbo.sp_KHACHHANG_Sua @MaKH VARCHAR(20), @HoTen NVARCHAR(100), @SoDienThoai VARCHAR(15) AS
    UPDATE dbo.KHACHHANG SET HoTen=@HoTen, SoDienThoai=@SoDienThoai WHERE MaKH=@MaKH;
GO
CREATE OR ALTER PROCEDURE dbo.sp_KHACHHANG_Xoa @MaKH VARCHAR(20) AS DELETE dbo.KHACHHANG WHERE MaKH=@MaKH;
GO

CREATE OR ALTER PROCEDURE dbo.sp_PHUONGTIEN_DanhSach AS
    SELECT MaPT, BienSo, LoaiXe, MaKH, KhachHang FROM dbo.vw_PhuongTien ORDER BY MaPT;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHUONGTIEN_KhachHang AS SELECT MaKH, HoTen FROM dbo.KHACHHANG ORDER BY HoTen;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHUONGTIEN_MaMoi AS
    SELECT 'PT' + RIGHT('000' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaPT, 3, 20))), 0) + 1), 3) AS MaMoi FROM dbo.PHUONGTIEN;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHUONGTIEN_Them @MaPT VARCHAR(20), @BienSo VARCHAR(20), @LoaiXe NVARCHAR(20), @MaKH VARCHAR(20)=NULL AS
    INSERT dbo.PHUONGTIEN(MaPT, BienSo, LoaiXe, MaKH) VALUES(UPPER(@MaPT), UPPER(@BienSo), @LoaiXe, @MaKH);
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHUONGTIEN_Sua @MaPT VARCHAR(20), @BienSo VARCHAR(20), @LoaiXe NVARCHAR(20), @MaKH VARCHAR(20)=NULL AS
    UPDATE dbo.PHUONGTIEN SET BienSo=UPPER(@BienSo), LoaiXe=@LoaiXe, MaKH=@MaKH WHERE MaPT=@MaPT;
GO
CREATE OR ALTER PROCEDURE dbo.sp_PHUONGTIEN_LichSu @MaPT VARCHAR(20) AS
    SELECT MaLuotGui, BienSo, ThoiGianVao, ThoiGianRa, TienGui, TrangThai FROM dbo.vw_LichSuGuiXe WHERE MaPT=@MaPT ORDER BY ThoiGianVaoUtc DESC;
GO

/* LOẠI VÉ, THẺ XE VÀ BẢNG GIÁ */
CREATE OR ALTER PROCEDURE dbo.sp_LOAIVE_DanhSach AS SELECT MaLoaiVe, TenLoaiVe, KyHieu FROM dbo.LOAIVE ORDER BY MaLoaiVe;
GO
CREATE OR ALTER PROCEDURE dbo.sp_LOAIVE_MaMoi AS
    SELECT 'LV' + RIGHT('00' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaLoaiVe, 3, 20))), 0) + 1), 2) AS MaMoi FROM dbo.LOAIVE;
GO
CREATE OR ALTER PROCEDURE dbo.sp_LOAIVE_Them @MaLoaiVe VARCHAR(20), @TenLoaiVe NVARCHAR(50), @KyHieu VARCHAR(10) AS
    INSERT dbo.LOAIVE(MaLoaiVe, TenLoaiVe, KyHieu) VALUES(UPPER(@MaLoaiVe), @TenLoaiVe, @KyHieu);
GO
CREATE OR ALTER PROCEDURE dbo.sp_LOAIVE_Sua @MaLoaiVe VARCHAR(20), @TenLoaiVe NVARCHAR(50), @KyHieu VARCHAR(10) AS
    UPDATE dbo.LOAIVE SET TenLoaiVe=@TenLoaiVe, KyHieu=@KyHieu WHERE MaLoaiVe=@MaLoaiVe;
GO
CREATE OR ALTER PROCEDURE dbo.sp_LOAIVE_Xoa @MaLoaiVe VARCHAR(20) AS DELETE dbo.LOAIVE WHERE MaLoaiVe=@MaLoaiVe;
GO

CREATE OR ALTER PROCEDURE dbo.sp_VE_DanhSach AS SELECT MaVe, MaThe, LoaiVe, TenLoaiVe, NgayCap, TrangThai FROM dbo.vw_Ve ORDER BY MaVe;
GO
CREATE OR ALTER PROCEDURE dbo.sp_VE_MaMoi AS
    SELECT 'VE' + RIGHT('000' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaVe, 3, 20))), 0) + 1), 3) AS MaMoi FROM dbo.VE;
GO
CREATE OR ALTER PROCEDURE dbo.sp_VE_Them @MaVe VARCHAR(20), @MaThe VARCHAR(30), @MaLoaiVe VARCHAR(20), @NgayCap DATE, @TrangThai VARCHAR(20) AS
    INSERT dbo.VE(MaVe, MaThe, MaLoaiVe, NgayCap, TrangThai) VALUES(UPPER(@MaVe), UPPER(@MaThe), @MaLoaiVe, @NgayCap, @TrangThai);
GO
CREATE OR ALTER PROCEDURE dbo.sp_VE_Sua @MaVe VARCHAR(20), @MaThe VARCHAR(30), @MaLoaiVe VARCHAR(20), @NgayCap DATE, @TrangThai VARCHAR(20) AS
    UPDATE dbo.VE SET MaThe=UPPER(@MaThe), MaLoaiVe=@MaLoaiVe, NgayCap=@NgayCap, TrangThai=@TrangThai WHERE MaVe=@MaVe;
GO
CREATE OR ALTER PROCEDURE dbo.sp_VE_Khoa @MaVe VARCHAR(20) AS UPDATE dbo.VE SET TrangThai='KHOA' WHERE MaVe=@MaVe;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BANGGIA_DanhSach AS
    SELECT MaBangGia, LoaiXe, LoaiVe, DonGia, DonGiaSau19Gio, DonGiaQuaDem, NgayApDung FROM dbo.vw_BangGia ORDER BY NgayApDung DESC, MaBangGia;
GO
CREATE OR ALTER PROCEDURE dbo.sp_BANGGIA_MaMoi AS
    SELECT 'BG' + RIGHT('000' + CONVERT(VARCHAR(10), ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaBangGia, 3, 20))), 0) + 1), 3) AS MaMoi FROM dbo.BANGGIA;
GO
CREATE OR ALTER PROCEDURE dbo.sp_BANGGIA_Them
    @MaBangGia VARCHAR(20), @LoaiXe NVARCHAR(20), @LoaiVe VARCHAR(10), @DonGia DECIMAL(18,2),
    @DonGiaSau19Gio DECIMAL(18,2)=NULL, @DonGiaQuaDem DECIMAL(18,2)=NULL, @NgayApDung DATE
AS
    INSERT dbo.BANGGIA(MaBangGia, LoaiXe, MaLoaiVe, DonGia, DonGiaSau19Gio, DonGiaQuaDem, NgayApDung)
    VALUES(UPPER(@MaBangGia), @LoaiXe, (SELECT MaLoaiVe FROM dbo.LOAIVE WHERE KyHieu=@LoaiVe), @DonGia, @DonGiaSau19Gio, @DonGiaQuaDem, @NgayApDung);
GO
CREATE OR ALTER PROCEDURE dbo.sp_BANGGIA_Sua
    @MaBangGia VARCHAR(20), @LoaiXe NVARCHAR(20), @LoaiVe VARCHAR(10), @DonGia DECIMAL(18,2),
    @DonGiaSau19Gio DECIMAL(18,2)=NULL, @DonGiaQuaDem DECIMAL(18,2)=NULL, @NgayApDung DATE
AS
    UPDATE dbo.BANGGIA SET LoaiXe=@LoaiXe, MaLoaiVe=(SELECT MaLoaiVe FROM dbo.LOAIVE WHERE KyHieu=@LoaiVe),
        DonGia=@DonGia, DonGiaSau19Gio=@DonGiaSau19Gio, DonGiaQuaDem=@DonGiaQuaDem, NgayApDung=@NgayApDung
    WHERE MaBangGia=@MaBangGia;
GO
CREATE OR ALTER PROCEDURE dbo.sp_BANGGIA_GiaHienTai @LoaiXe NVARCHAR(20), @LoaiVe VARCHAR(10) AS
    SELECT TOP (1) DonGia FROM dbo.vw_BangGia WHERE LoaiXe=@LoaiXe AND LoaiVe=@LoaiVe AND NgayApDung<=CONVERT(DATE, GETDATE()) ORDER BY NgayApDung DESC;
GO

/* KHU VỰC */
CREATE OR ALTER PROCEDURE dbo.sp_KHUVUC_DanhSach AS
    SELECT MaKhuVuc, TenKhuVuc, LoaiXe, CONVERT(INT, SucChua) AS SucChua,
           CONVERT(INT, DangGui) AS DangGui, CONVERT(INT, ConTrong) AS ConTrong, TrangThai
    FROM dbo.vw_KhuVucTinhTrang ORDER BY MaKhuVuc;
GO
CREATE OR ALTER PROCEDURE dbo.sp_KHUVUC_Them @MaKhuVuc VARCHAR(20), @TenKhuVuc NVARCHAR(100), @LoaiXe NVARCHAR(20), @SucChua INT, @TrangThai VARCHAR(20) AS
    INSERT dbo.KHUVUC(MaKhuVuc, TenKhuVuc, LoaiXe, SucChua, TrangThai) VALUES(UPPER(@MaKhuVuc), @TenKhuVuc, @LoaiXe, @SucChua, @TrangThai);
GO
CREATE OR ALTER PROCEDURE dbo.sp_KHUVUC_Sua @MaKhuVuc VARCHAR(20), @TenKhuVuc NVARCHAR(100), @LoaiXe NVARCHAR(20), @SucChua INT, @TrangThai VARCHAR(20) AS
    UPDATE dbo.KHUVUC SET TenKhuVuc=@TenKhuVuc, LoaiXe=@LoaiXe, SucChua=@SucChua, TrangThai=@TrangThai WHERE MaKhuVuc=@MaKhuVuc;
GO

/* NGHIỆP VỤ GỬI XE */
CREATE OR ALTER PROCEDURE dbo.sp_LUOTGUIXE_DanhSach AS
    SELECT MaLuotGui, MaPT, BienSo, LoaiXe, MaVe, MaThe, MaKhuVuc, KhuVuc,
           ThoiGianVao, ThoiGianRa, TienGui, NhanVienVao, NhanVienRa, TrangThai, LoaiVe
    FROM dbo.vw_LichSuGuiXe ORDER BY ThoiGianVaoUtc DESC;
GO
CREATE OR ALTER PROCEDURE dbo.sp_XeDangGui_DanhSach AS
    SELECT MaLuotGui, MaPT, BienSo, LoaiXe, MaVe, MaThe, MaKhuVuc, KhuVuc,
           ThoiGianVao, TienGui, NhanVienVao, TrangThai, LoaiVe
    FROM dbo.vw_LichSuGuiXe WHERE TrangThai='DANG_GUI' ORDER BY ThoiGianVaoUtc DESC;
GO
CREATE OR ALTER PROCEDURE dbo.sp_XeVao_NhanVien AS SELECT MaNV, HoTen FROM dbo.NHANVIEN WHERE TrangThai='HOAT_DONG' ORDER BY HoTen;
GO
CREATE OR ALTER PROCEDURE dbo.sp_XeVao_TheTrong AS
    SELECT v.MaVe, v.MaThe, lv.KyHieu AS LoaiVe
    FROM dbo.VE AS v INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe=v.MaLoaiVe
    WHERE v.TrangThai='HOAT_DONG'
      AND NOT EXISTS (SELECT 1 FROM dbo.LUOTGUIXE AS lg WHERE lg.MaVe=v.MaVe AND lg.TrangThai='DANG_GUI')
    ORDER BY v.MaThe;
GO
CREATE OR ALTER PROCEDURE dbo.sp_XeVao_KhuVuc @LoaiXe NVARCHAR(20) AS
    SELECT MaKhuVuc, TenKhuVuc, CONVERT(INT, ConTrong) AS ConTrong
    FROM dbo.vw_KhuVucTinhTrang WHERE LoaiXe=@LoaiXe AND TrangThai='HOAT_DONG' ORDER BY TenKhuVuc;
GO
CREATE OR ALTER PROCEDURE dbo.sp_XeVao_KiemTra @BienSo VARCHAR(20) AS
BEGIN
    DECLARE @Today DATE = CONVERT(DATE, (SYSUTCDATETIME() AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time');
    SELECT
        CONVERT(BIT, CASE WHEN EXISTS(SELECT 1 FROM dbo.PHUONGTIEN WHERE BienSo=UPPER(@BienSo)) THEN 1 ELSE 0 END) AS DaCoTrongHeThong,
        CONVERT(BIT, CASE WHEN EXISTS(SELECT 1 FROM dbo.LUOTGUIXE lg INNER JOIN dbo.PHUONGTIEN pt ON pt.MaPT=lg.MaPT WHERE pt.BienSo=UPPER(@BienSo) AND lg.TrangThai='DANG_GUI') THEN 1 ELSE 0 END) AS DangTrongBai,
        CONVERT(BIT, CASE WHEN EXISTS(SELECT 1 FROM dbo.DANGKYVETHANG dk INNER JOIN dbo.PHUONGTIEN pt ON pt.MaPT=dk.MaPT WHERE pt.BienSo=UPPER(@BienSo) AND dk.ThanhToan='DA_THANH_TOAN' AND dk.TrangThai<>'HUY' AND dk.NgayBatDau<=@Today AND @Today<dk.NgayKetThuc) THEN 1 ELSE 0 END) AS CoVeThang,
        (SELECT TOP (1) LoaiXe FROM dbo.PHUONGTIEN WHERE BienSo=UPPER(@BienSo)) AS LoaiXe;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_XeRa_TimKiem @TuKhoa VARCHAR(30) AS
BEGIN
    DECLARE @NowVn DATETIME2(0)=CONVERT(DATETIME2(0), (SYSUTCDATETIME() AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time');
    SELECT TOP (1) ls.MaLuotGui, ls.BienSo, ls.LoaiXe, ls.MaThe, ls.KhuVuc, ls.ThoiGianVao, ls.LoaiVe,
           CASE WHEN ls.LoaiVe='THANG' THEN CONVERT(DECIMAL(18,2), 0)
                WHEN CONVERT(DATE, ls.ThoiGianVao)<CONVERT(DATE, @NowVn) THEN ISNULL(bg.DonGiaQuaDem, bg.DonGia)
                WHEN CONVERT(TIME, @NowVn)>='19:00' THEN ISNULL(bg.DonGiaSau19Gio, bg.DonGia)
                ELSE bg.DonGia END AS TienDuKien
    FROM dbo.vw_LichSuGuiXe AS ls
    OUTER APPLY
    (
        SELECT TOP (1) bg.DonGia, bg.DonGiaSau19Gio, bg.DonGiaQuaDem
        FROM dbo.BANGGIA AS bg INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe=bg.MaLoaiVe
        WHERE bg.LoaiXe=ls.LoaiXe AND lv.KyHieu='LUOT' AND bg.NgayApDung<=CONVERT(DATE, @NowVn)
        ORDER BY bg.NgayApDung DESC
    ) AS bg
    WHERE ls.TrangThai='DANG_GUI' AND (ls.BienSo LIKE '%' + @TuKhoa + '%' OR ls.MaThe LIKE '%' + @TuKhoa + '%')
    ORDER BY ls.ThoiGianVaoUtc DESC;
END;
GO

/* VÉ THÁNG */
CREATE OR ALTER PROCEDURE dbo.sp_DANGKYVETHANG_DanhSach
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaDangKy, MaKH, KhachHang, MaPT, BienSo, LoaiXe, MaVe, MaThe,
           NgayBatDau, NgayKetThuc, SoThang, DonGiaThang, TongTien, ThanhToan, TrangThai
    FROM dbo.vw_DangKyVeThang ORDER BY NgayKetThuc DESC;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_DANGKYVETHANG_KhachHang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaKH, HoTen, SoDienThoai
    FROM dbo.KHACHHANG
    ORDER BY HoTen;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_DANGKYVETHANG_PhuongTien
    @MaKH VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaPT, BienSo, LoaiXe
    FROM dbo.PHUONGTIEN
    WHERE MaKH = @MaKH
    ORDER BY BienSo;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_DANGKYVETHANG_TheThang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT v.MaVe, v.MaThe
    FROM dbo.VE AS v
    INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe = v.MaLoaiVe
    WHERE lv.KyHieu = 'THANG'
      AND v.TrangThai = 'HOAT_DONG'
    ORDER BY v.MaThe;
END;
GO

/* TRANG CHỦ VÀ BÁO CÁO */
CREATE OR ALTER PROCEDURE dbo.sp_TrangChu_ThongKe AS
BEGIN
    DECLARE @Today DATE=CONVERT(DATE, (SYSUTCDATETIME() AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time');
    SELECT
        (SELECT COUNT(*) FROM dbo.LUOTGUIXE WHERE TrangThai='DANG_GUI') AS XeDangGui,
        (SELECT ISNULL(SUM(CONVERT(INT, ConTrong)),0) FROM dbo.vw_KhuVucTinhTrang WHERE TrangThai='HOAT_DONG') AS ChoTrong,
        (SELECT COUNT(*) FROM dbo.vw_DangKyVeThang WHERE TrangThai='HIEU_LUC') AS VeThangHieuLuc,
        (SELECT ISNULL(SUM(SoTien),0) FROM dbo.vw_ThanhToan WHERE TrangThai='THANH_CONG' AND CONVERT(DATE, ThoiGian)=@Today) AS DoanhThuHomNay;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_TrangChu_KhuVuc AS EXEC dbo.sp_KHUVUC_DanhSach;
GO
CREATE OR ALTER PROCEDURE dbo.sp_BaoCao_NhanVien AS
    SELECT nv.MaNV AS MANV, nv.HoTen AS HOTEN,
           CONVERT(DATETIME, ISNULL(tk.NgayTaoUtc, SYSUTCDATETIME())) AS NGAYSINH,
           ISNULL(tk.VaiTro, N'CHƯA CẤP') AS DIACHI, nv.SoDienThoai AS DIENTHOAI, nv.TrangThai AS TENPHONG
    FROM dbo.NHANVIEN AS nv LEFT JOIN dbo.TAIKHOAN AS tk ON tk.MaNV=nv.MaNV ORDER BY nv.MaNV;
GO
CREATE OR ALTER PROCEDURE dbo.sp_BaoCao_PhuongTien AS
    SELECT pt.MaPT AS MAPHONG, pt.BienSo AS TENPHONG, pt.LoaiXe AS DIADIEM,
           ISNULL(kh.HoTen, N'Khách vãng lai') AS DIENTHOAI, CONVERT(INT, COUNT(lg.MaLuotGui)) AS SoNhanVien
    FROM dbo.PHUONGTIEN AS pt LEFT JOIN dbo.KHACHHANG AS kh ON kh.MaKH=pt.MaKH LEFT JOIN dbo.LUOTGUIXE AS lg ON lg.MaPT=pt.MaPT
    GROUP BY pt.MaPT, pt.BienSo, pt.LoaiXe, kh.HoTen ORDER BY pt.MaPT;
GO
CREATE OR ALTER PROCEDURE dbo.sp_BaoCao_DoanhThu @TuNgay DATE, @DenNgay DATE AS
    SELECT CONVERT(VARCHAR(10), CONVERT(DATE, tt.ThoiGian), 103) AS MALOAI,
           tt.LoaiThanhToan AS TENLOAI, CONVERT(INT, COUNT(*)) AS KYHAN,
           tt.PhuongThuc AS LOAITIEN, CONVERT(INT, SUM(tt.SoTien)) AS LAISUAT
    FROM dbo.vw_ThanhToan AS tt
    WHERE tt.TrangThai='THANH_CONG' AND tt.ThoiGian>=@TuNgay AND tt.ThoiGian<DATEADD(DAY,1,@DenNgay)
    GROUP BY CONVERT(DATE, tt.ThoiGian), tt.LoaiThanhToan, tt.PhuongThuc
    ORDER BY CONVERT(DATE, tt.ThoiGian), tt.LoaiThanhToan;
GO
