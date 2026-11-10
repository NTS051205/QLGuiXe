/*
    FILE 03 - TẠO VIEW VÀ THỦ TỤC NGHIỆP VỤ

    QLGuiXe - View cho UI va stored procedure nghiep vu demo
    Chay sau 01 va 02.
*/

USE QLGuiXe;
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

CREATE OR ALTER VIEW dbo.vw_TaiKhoan
AS
    SELECT tk.MaTK, tk.TenDangNhap, nv.HoTen AS NhanVien,
           tk.VaiTro, tk.TrangThai, tk.NgayTaoUtc, tk.LanDangNhapCuoiUtc
    FROM dbo.TAIKHOAN AS tk
    INNER JOIN dbo.NHANVIEN AS nv ON nv.MaNV = tk.MaNV;
GO

CREATE OR ALTER VIEW dbo.vw_CaLam
AS
    SELECT MaCa, TenCa, GioBatDau, GioKetThuc,
           CONVERT(BIT, CASE WHEN GioKetThuc <= GioBatDau THEN 1 ELSE 0 END) AS QuaDem
    FROM dbo.CALAM;
GO

CREATE OR ALTER VIEW dbo.vw_PhanCongCa
AS
    SELECT pc.MaPhanCong, pc.MaNV, nv.HoTen AS NhanVien,
           pc.MaCa, ca.TenCa AS CaLam, pc.NgayLam, pc.GhiChu
    FROM dbo.PHANCONGCA AS pc
    INNER JOIN dbo.NHANVIEN AS nv ON nv.MaNV = pc.MaNV
    INNER JOIN dbo.CALAM AS ca ON ca.MaCa = pc.MaCa;
GO

CREATE OR ALTER VIEW dbo.vw_PhuongTien
AS
    SELECT pt.MaPT, pt.BienSo, pt.LoaiXe, pt.MaKH,
           kh.HoTen AS KhachHang, kh.SoDienThoai
    FROM dbo.PHUONGTIEN AS pt
    LEFT JOIN dbo.KHACHHANG AS kh ON kh.MaKH = pt.MaKH;
GO

CREATE OR ALTER VIEW dbo.vw_BangGia
AS
    SELECT bg.MaBangGia, bg.LoaiXe, lv.KyHieu AS LoaiVe,
           bg.DonGia, bg.DonGiaSau19Gio, bg.DonGiaQuaDem, bg.NgayApDung
    FROM dbo.BANGGIA AS bg
    INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe = bg.MaLoaiVe;
GO

CREATE OR ALTER VIEW dbo.vw_Ve
AS
    SELECT v.MaVe, v.MaThe, lv.KyHieu AS LoaiVe,
           lv.TenLoaiVe, v.NgayCap, v.TrangThai
    FROM dbo.VE AS v
    INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe = v.MaLoaiVe;
GO

CREATE OR ALTER VIEW dbo.vw_KhuVucTinhTrang
AS
    SELECT kv.MaKhuVuc, kv.TenKhuVuc, kv.LoaiXe, kv.SucChua,
           COUNT_BIG(lgx.MaLuotGui) AS DangGui,
           CONVERT(BIGINT, kv.SucChua) - COUNT_BIG(lgx.MaLuotGui) AS ConTrong,
           kv.TrangThai
    FROM dbo.KHUVUC AS kv
    LEFT JOIN dbo.LUOTGUIXE AS lgx
        ON lgx.MaKhuVuc = kv.MaKhuVuc
       AND lgx.TrangThai = 'DANG_GUI'
    GROUP BY kv.MaKhuVuc, kv.TenKhuVuc, kv.LoaiXe, kv.SucChua, kv.TrangThai;
GO

CREATE OR ALTER VIEW dbo.vw_DangKyVeThang
AS
    SELECT dk.MaDangKy, dk.MaKH, kh.HoTen AS KhachHang,
           dk.MaPT, pt.BienSo, pt.LoaiXe,
           dk.MaVe, v.MaThe,
           dk.NgayBatDau, dk.NgayKetThuc, dk.SoThang,
           dk.DonGiaThang, dk.TongTien, dk.ThanhToan,
           CASE
               WHEN dk.TrangThai = 'HUY' THEN 'HUY'
               WHEN dk.ThanhToan <> 'DA_THANH_TOAN' THEN 'CHO_THANH_TOAN'
               WHEN CONVERT(DATE, (SYSUTCDATETIME() AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time') >= dk.NgayKetThuc THEN 'HET_HAN'
               ELSE 'HIEU_LUC'
           END AS TrangThai
    FROM dbo.DANGKYVETHANG AS dk
    INNER JOIN dbo.KHACHHANG AS kh ON kh.MaKH = dk.MaKH
    INNER JOIN dbo.PHUONGTIEN AS pt ON pt.MaPT = dk.MaPT
    INNER JOIN dbo.VE AS v ON v.MaVe = dk.MaVe;
GO

CREATE OR ALTER VIEW dbo.vw_LichSuGuiXe
AS
    SELECT lg.MaLuotGui, pt.MaPT, pt.BienSo, pt.LoaiXe,
           v.MaVe, v.MaThe, kv.MaKhuVuc, kv.TenKhuVuc AS KhuVuc,
           CONVERT(DATETIME2(0), (lg.ThoiGianVaoUtc AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time') AS ThoiGianVao,
           CASE WHEN lg.ThoiGianRaUtc IS NULL THEN NULL
                ELSE CONVERT(DATETIME2(0), (lg.ThoiGianRaUtc AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time') END AS ThoiGianRa,
           lg.TienGui,
           nvVao.HoTen AS NhanVienVao,
           nvRa.HoTen AS NhanVienRa,
           lg.TrangThai, lg.LoaiVe,
           lg.ThoiGianVaoUtc, lg.ThoiGianRaUtc
    FROM dbo.LUOTGUIXE AS lg
    INNER JOIN dbo.PHUONGTIEN AS pt ON pt.MaPT = lg.MaPT
    INNER JOIN dbo.VE AS v ON v.MaVe = lg.MaVe
    INNER JOIN dbo.KHUVUC AS kv ON kv.MaKhuVuc = lg.MaKhuVuc
    INNER JOIN dbo.NHANVIEN AS nvVao ON nvVao.MaNV = lg.MaNVVao
    LEFT JOIN dbo.NHANVIEN AS nvRa ON nvRa.MaNV = lg.MaNVRa;
GO

CREATE OR ALTER VIEW dbo.vw_ThanhToan
AS
    SELECT tt.MaThanhToan, tt.LoaiThanhToan,
           tt.MaLuotGui, tt.MaDangKy, tt.SoTien,
           CONVERT(DATETIME2(0), (tt.ThoiGianUtc AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time') AS ThoiGian,
           tt.PhuongThuc, tt.TrangThai, tt.MaNV, nv.HoTen AS NhanVien,
           tt.MaThamChieu, tt.GhiChu, tt.ThoiGianUtc
    FROM dbo.THANHTOAN AS tt
    INNER JOIN dbo.NHANVIEN AS nv ON nv.MaNV = tt.MaNV;
GO

CREATE OR ALTER PROCEDURE dbo.sp_XeVao
    @BienSo       VARCHAR(20),
    @LoaiXe       NVARCHAR(20),
    @MaThe        VARCHAR(30),
    @MaKhuVuc     VARCHAR(20),
    @MaNVVao      VARCHAR(20),
    @MaKH         VARCHAR(20) = NULL,
    @MaLuotGuiMoi VARCHAR(20) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @BienSo = UPPER(LTRIM(RTRIM(@BienSo)));
    SET @MaThe = UPPER(LTRIM(RTRIM(@MaThe)));

    IF @LoaiXe NOT IN (N'Ô tô', N'Xe máy')
        THROW 50100, N'Loại xe không hợp lệ.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @MaPT VARCHAR(20);
        DECLARE @MaVe VARCHAR(20);
        DECLARE @KyHieuThe VARCHAR(10);
        DECLARE @LoaiVe VARCHAR(10);
        DECLARE @SucChua INT;
        DECLARE @DangGui INT;
        DECLARE @TodayVn DATE = CONVERT(DATE, (SYSUTCDATETIME() AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time');

        SELECT @MaPT = MaPT
        FROM dbo.PHUONGTIEN WITH (UPDLOCK, HOLDLOCK)
        WHERE BienSo = @BienSo;

        IF @MaPT IS NULL
        BEGIN
            IF @MaKH IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.KHACHHANG WHERE MaKH = @MaKH)
                THROW 50101, N'Khách hàng không tồn tại.', 1;

            DECLARE @SoThuTuPT INT;
            SELECT @SoThuTuPT = ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaPT, 3, 18))), 0) + 1
            FROM dbo.PHUONGTIEN WITH (UPDLOCK, HOLDLOCK);

            SET @MaPT = 'PT' + RIGHT('000' + CONVERT(VARCHAR(18), @SoThuTuPT), 3);
            INSERT dbo.PHUONGTIEN (MaPT, BienSo, LoaiXe, MaKH)
            VALUES (@MaPT, @BienSo, @LoaiXe, @MaKH);
        END
        ELSE IF NOT EXISTS (SELECT 1 FROM dbo.PHUONGTIEN WHERE MaPT = @MaPT AND LoaiXe = @LoaiXe)
            THROW 50102, N'Loại xe không khớp với phương tiện đã lưu.', 1;

        IF EXISTS
        (
            SELECT 1 FROM dbo.LUOTGUIXE WITH (UPDLOCK, HOLDLOCK)
            WHERE MaPT = @MaPT AND TrangThai = 'DANG_GUI'
        )
            THROW 50103, N'Phương tiện đang có một lượt gửi chưa kết thúc.', 1;

        SELECT @MaVe = v.MaVe, @KyHieuThe = lv.KyHieu
        FROM dbo.VE AS v WITH (UPDLOCK, HOLDLOCK)
        INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe = v.MaLoaiVe
        WHERE v.MaThe = @MaThe AND v.TrangThai = 'HOAT_DONG';

        IF @MaVe IS NULL
            THROW 50104, N'Thẻ xe không tồn tại, bị khóa hoặc bị hỏng.', 1;

        IF EXISTS
        (
            SELECT 1 FROM dbo.LUOTGUIXE WITH (UPDLOCK, HOLDLOCK)
            WHERE MaVe = @MaVe AND TrangThai = 'DANG_GUI'
        )
            THROW 50105, N'Thẻ đang được dùng cho một lượt gửi khác.', 1;

        SELECT @SucChua = kv.SucChua,
               @DangGui = COUNT(lg.MaLuotGui)
        FROM dbo.KHUVUC AS kv WITH (UPDLOCK, HOLDLOCK)
        LEFT JOIN dbo.LUOTGUIXE AS lg WITH (UPDLOCK, HOLDLOCK)
            ON lg.MaKhuVuc = kv.MaKhuVuc AND lg.TrangThai = 'DANG_GUI'
        WHERE kv.MaKhuVuc = @MaKhuVuc
          AND kv.LoaiXe = @LoaiXe
          AND kv.TrangThai = 'HOAT_DONG'
        GROUP BY kv.SucChua;

        IF @SucChua IS NULL
            THROW 50106, N'Khu vực không tồn tại, không hoạt động hoặc không đúng loại xe.', 1;
        IF @DangGui >= @SucChua
            THROW 50107, N'Khu vực đã hết chỗ trống.', 1;

        IF EXISTS
        (
            SELECT 1
            FROM dbo.DANGKYVETHANG AS dk WITH (UPDLOCK, HOLDLOCK)
            WHERE dk.MaPT = @MaPT
              AND dk.MaVe = @MaVe
              AND dk.ThanhToan = 'DA_THANH_TOAN'
              AND dk.TrangThai <> 'HUY'
              AND dk.NgayBatDau <= @TodayVn
              AND @TodayVn < dk.NgayKetThuc
        )
            SET @LoaiVe = 'THANG';
        ELSE
        BEGIN
            IF @KyHieuThe <> 'LUOT'
                THROW 50108, N'Xe không có đăng ký hợp lệ với thẻ tháng này. Hãy sử dụng thẻ lượt.', 1;
            SET @LoaiVe = 'LUOT';
        END;

        DECLARE @SoThuTuLuot INT;
        SELECT @SoThuTuLuot = ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaLuotGui, 3, 18))), 0) + 1
        FROM dbo.LUOTGUIXE WITH (UPDLOCK, HOLDLOCK);

        SET @MaLuotGuiMoi = 'LG' + RIGHT('000' + CONVERT(VARCHAR(18), @SoThuTuLuot), 3);

        INSERT dbo.LUOTGUIXE
            (MaLuotGui, MaPT, MaVe, MaKhuVuc, MaNVVao, LoaiVe, TrangThai)
        VALUES
            (@MaLuotGuiMoi, @MaPT, @MaVe, @MaKhuVuc, @MaNVVao, @LoaiVe, 'DANG_GUI');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_XeRa
    @BienSoHoacMaThe VARCHAR(30),
    @MaNVRa          VARCHAR(20),
    @PhuongThuc      VARCHAR(20),
    @MaLuotGui       VARCHAR(20) OUTPUT,
    @TienGui         DECIMAL(18,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @PhuongThuc NOT IN ('TIEN_MAT', 'CHUYEN_KHOAN', 'THE')
        THROW 50200, N'Phương thức thanh toán không hợp lệ.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @LoaiVe VARCHAR(10);
        DECLARE @LoaiXe NVARCHAR(20);
        DECLARE @NowUtc DATETIME2(0) = SYSUTCDATETIME();
        DECLARE @ThoiGianVaoUtc DATETIME2(0);
        DECLARE @ThoiGianVaoVn DATETIME2(0);
        DECLARE @ThoiGianRaVn DATETIME2(0);

        SELECT TOP (1)
            @MaLuotGui = lg.MaLuotGui,
            @LoaiVe = lg.LoaiVe,
            @LoaiXe = pt.LoaiXe,
            @ThoiGianVaoUtc = lg.ThoiGianVaoUtc
        FROM dbo.LUOTGUIXE AS lg WITH (UPDLOCK, HOLDLOCK)
        INNER JOIN dbo.PHUONGTIEN AS pt ON pt.MaPT = lg.MaPT
        INNER JOIN dbo.VE AS v ON v.MaVe = lg.MaVe
        WHERE lg.TrangThai = 'DANG_GUI'
          AND (pt.BienSo = UPPER(LTRIM(RTRIM(@BienSoHoacMaThe))) OR v.MaThe = UPPER(LTRIM(RTRIM(@BienSoHoacMaThe))));

        IF @MaLuotGui IS NULL
            THROW 50201, N'Không tìm thấy lượt gửi đang mở.', 1;

        IF @LoaiVe = 'THANG'
            SET @TienGui = 0;
        ELSE
        BEGIN
            SET @ThoiGianVaoVn = CONVERT(DATETIME2(0),
                (@ThoiGianVaoUtc AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time');
            SET @ThoiGianRaVn = CONVERT(DATETIME2(0),
                (@NowUtc AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time');

            SELECT TOP (1) @TienGui =
                CASE
                    WHEN CONVERT(DATE, @ThoiGianVaoVn) < CONVERT(DATE, @ThoiGianRaVn)
                        THEN ISNULL(bg.DonGiaQuaDem, bg.DonGia)
                    WHEN CONVERT(TIME, @ThoiGianRaVn) >= '19:00'
                        THEN ISNULL(bg.DonGiaSau19Gio, bg.DonGia)
                    ELSE bg.DonGia
                END
            FROM dbo.BANGGIA AS bg
            INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe = bg.MaLoaiVe
            WHERE bg.LoaiXe = @LoaiXe
              AND lv.KyHieu = 'LUOT'
              AND bg.NgayApDung <= CONVERT(DATE, (@NowUtc AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time')
            ORDER BY bg.NgayApDung DESC;

            IF @TienGui IS NULL
                THROW 50202, N'Không tìm thấy bảng giá vé lượt đang áp dụng.', 1;
        END;

        UPDATE dbo.LUOTGUIXE
        SET ThoiGianRaUtc = @NowUtc,
            TienGui = @TienGui,
            MaNVRa = @MaNVRa,
            TrangThai = 'DA_RA'
        WHERE MaLuotGui = @MaLuotGui;

        IF @TienGui > 0
        BEGIN
            INSERT dbo.THANHTOAN
                (MaThanhToan, LoaiThanhToan, MaLuotGui, MaDangKy,
                 SoTien, ThoiGianUtc, PhuongThuc, TrangThai, MaNV)
            VALUES
                ('TT' + RIGHT(REPLACE(CONVERT(VARCHAR(36), NEWID()), '-', ''), 18),
                 'VE_LUOT', @MaLuotGui, NULL,
                 @TienGui, @NowUtc, @PhuongThuc, 'THANH_CONG', @MaNVRa);
        END;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_DangKyVeThang
    @MaKH          VARCHAR(20),
    @MaPT          VARCHAR(20),
    @MaThe         VARCHAR(30),
    @NgayBatDau    DATE,
    @SoThang       TINYINT,
    @MaDangKyMoi   VARCHAR(20) OUTPUT,
    @NgayKetThuc   DATE OUTPUT,
    @TongTien      DECIMAL(18,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @SoThang NOT BETWEEN 1 AND 24
        THROW 50300, N'Số tháng đăng ký phải từ 1 đến 24.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @MaVe VARCHAR(20);
        DECLARE @LoaiXe NVARCHAR(20);
        DECLARE @DonGia DECIMAL(18,2);
        DECLARE @SoDangKyMoi INT;

        SELECT @LoaiXe = pt.LoaiXe
        FROM dbo.PHUONGTIEN AS pt WITH (UPDLOCK, HOLDLOCK)
        WHERE pt.MaPT = @MaPT AND pt.MaKH = @MaKH;

        IF @LoaiXe IS NULL
            THROW 50301, N'Phương tiện không tồn tại hoặc không thuộc khách hàng đã chọn.', 1;

        SELECT @MaVe = v.MaVe
        FROM dbo.VE AS v WITH (UPDLOCK, HOLDLOCK)
        INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe = v.MaLoaiVe
        WHERE v.MaThe = UPPER(LTRIM(RTRIM(@MaThe)))
          AND v.TrangThai = 'HOAT_DONG'
          AND lv.KyHieu = 'THANG';

        IF @MaVe IS NULL
            THROW 50302, N'Thẻ tháng không tồn tại hoặc không hoạt động.', 1;

        SET @NgayKetThuc = DATEADD(MONTH, @SoThang, @NgayBatDau);

        IF EXISTS
        (
            SELECT 1 FROM dbo.DANGKYVETHANG WITH (UPDLOCK, HOLDLOCK)
            WHERE TrangThai <> 'HUY'
              AND (MaPT = @MaPT OR MaVe = @MaVe)
              AND @NgayBatDau < NgayKetThuc
              AND NgayBatDau < @NgayKetThuc
        )
            THROW 50303, N'Phương tiện hoặc thẻ đã có kỳ đăng ký bị chồng thời hạn.', 1;

        SELECT TOP (1) @DonGia = bg.DonGia
        FROM dbo.BANGGIA AS bg
        INNER JOIN dbo.LOAIVE AS lv ON lv.MaLoaiVe = bg.MaLoaiVe
        WHERE bg.LoaiXe = @LoaiXe
          AND lv.KyHieu = 'THANG'
          AND bg.NgayApDung <= @NgayBatDau
        ORDER BY bg.NgayApDung DESC;

        IF @DonGia IS NULL
            THROW 50304, N'Không tìm thấy giá vé tháng đang áp dụng.', 1;

        SET @TongTien = @DonGia * @SoThang;

        /* Sinh mã dễ đọc: DK001, DK002, ... */
        SELECT @SoDangKyMoi = ISNULL(MAX(SoThuTu), 0) + 1
        FROM
        (
            SELECT TRY_CONVERT(INT, SUBSTRING(MaDangKy, 3, 10)) AS SoThuTu
            FROM dbo.DANGKYVETHANG WITH (UPDLOCK, HOLDLOCK)
        ) AS ds
        WHERE SoThuTu IS NOT NULL;

        SET @MaDangKyMoi = 'DK' + RIGHT('000' + CONVERT(VARCHAR(10), @SoDangKyMoi), 3);

        INSERT dbo.DANGKYVETHANG
            (MaDangKy, MaKH, MaPT, MaVe, NgayBatDau, NgayKetThuc,
             SoThang, DonGiaThang, TongTien, ThanhToan, TrangThai)
        VALUES
            (@MaDangKyMoi, @MaKH, @MaPT, @MaVe, @NgayBatDau, @NgayKetThuc,
             @SoThang, @DonGia, @TongTien, 'CHUA_THANH_TOAN', 'CHO_THANH_TOAN');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThanhToanVeThang
    @MaDangKy       VARCHAR(20),
    @MaNV           VARCHAR(20),
    @PhuongThuc     VARCHAR(20),
    @MaThamChieu    VARCHAR(100) = NULL,
    @MaThanhToanMoi VARCHAR(20) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @PhuongThuc NOT IN ('TIEN_MAT', 'CHUYEN_KHOAN', 'THE')
        THROW 50400, N'Phương thức thanh toán không hợp lệ.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @TongTien DECIMAL(18,2);
        DECLARE @ThanhToan VARCHAR(20);
        DECLARE @SoThanhToanMoi INT;

        SELECT @TongTien = TongTien, @ThanhToan = ThanhToan
        FROM dbo.DANGKYVETHANG WITH (UPDLOCK, HOLDLOCK)
        WHERE MaDangKy = @MaDangKy AND TrangThai <> 'HUY';

        IF @TongTien IS NULL
            THROW 50401, N'Đăng ký vé tháng không tồn tại hoặc đã hủy.', 1;
        IF @ThanhToan = 'DA_THANH_TOAN'
            THROW 50402, N'Đăng ký vé tháng đã được thanh toán.', 1;

        /* Sinh mã dễ đọc: TT001, TT002, ... */
        SELECT @SoThanhToanMoi = ISNULL(MAX(SoThuTu), 0) + 1
        FROM
        (
            SELECT TRY_CONVERT(INT, SUBSTRING(MaThanhToan, 3, 10)) AS SoThuTu
            FROM dbo.THANHTOAN WITH (UPDLOCK, HOLDLOCK)
        ) AS ds
        WHERE SoThuTu IS NOT NULL;

        SET @MaThanhToanMoi = 'TT' + RIGHT('000' + CONVERT(VARCHAR(10), @SoThanhToanMoi), 3);

        INSERT dbo.THANHTOAN
            (MaThanhToan, LoaiThanhToan, MaLuotGui, MaDangKy,
             SoTien, PhuongThuc, TrangThai, MaNV, MaThamChieu)
        VALUES
            (@MaThanhToanMoi, 'VE_THANG', NULL, @MaDangKy,
             @TongTien, @PhuongThuc, 'THANH_CONG', @MaNV, @MaThamChieu);

        UPDATE dbo.DANGKYVETHANG
        SET ThanhToan = 'DA_THANH_TOAN',
            TrangThai = CASE
                WHEN CONVERT(DATE, (SYSUTCDATETIME() AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time') >= NgayKetThuc
                    THEN 'HET_HAN'
                ELSE 'HIEU_LUC'
            END
        WHERE MaDangKy = @MaDangKy;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

PRINT N'Đã tạo các view cho UI và stored procedure nghiệp vụ.';
GO
