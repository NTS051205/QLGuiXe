/*
    QLGuiXe - Dữ liệu mẫu
    Chạy sau file 01_TaoDatabase_VaBang.sql.

    Tài khoản demo:
      admin    / Admin@123
      quocbao  / NhanVien@123
      duclong   / NhanVien@123
*/

USE QLGuiXe;
GO

DECLARE @NowUtc DATETIME2(0) = SYSUTCDATETIME();
DECLARE @TodayVn DATE =
    CONVERT(DATE, (@NowUtc AT TIME ZONE 'UTC') AT TIME ZONE 'SE Asia Standard Time');

INSERT INTO dbo.NHANVIEN (MaNV, HoTen, SoDienThoai, TrangThai)
VALUES
    ('NV001', N'Nguyễn Minh Anh', '0901234567', 'HOAT_DONG'),
    ('NV002', N'Trần Quốc Bảo',   '0912345678', 'HOAT_DONG'),
    ('NV003', N'Lê Thu Hà',       '0987654321', 'TAM_NGHI'),
    ('NV004', N'Phạm Đức Long',   '0934567890', 'HOAT_DONG');

INSERT INTO dbo.TAIKHOAN (MaTK, TenDangNhap, MatKhauHash, MaNV, VaiTro, TrangThai)
VALUES
    ('TK001', 'admin',
     CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'Admin@123'), 2),
     'NV001', 'ADMIN', 'HOAT_DONG'),
    ('TK002', 'quocbao',
     CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'NhanVien@123'), 2),
     'NV002', 'NHANVIEN', 'HOAT_DONG'),
    ('TK003', 'thuha',
     CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'Demo@123'), 2),
     'NV003', 'NHANVIEN', 'KHOA'),
    ('TK004', 'duclong',
     CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'NhanVien@123'), 2),
     'NV004', 'NHANVIEN', 'HOAT_DONG');

INSERT INTO dbo.CALAM (MaCa, TenCa, GioBatDau, GioKetThuc)
VALUES
    ('CA01', N'Ca sáng',  '06:00', '14:00'),
    ('CA02', N'Ca chiều', '14:00', '22:00'),
    ('CA03', N'Ca đêm',   '22:00', '06:00');

INSERT INTO dbo.PHANCONGCA (MaPhanCong, MaNV, MaCa, NgayLam, GhiChu)
VALUES
    ('PC001', 'NV001', 'CA01', DATEADD(DAY, 0, @TodayVn), N'Trực cổng chính'),
    ('PC002', 'NV002', 'CA02', DATEADD(DAY, 0, @TodayVn), N'Trực thu phí'),
    ('PC003', 'NV004', 'CA03', DATEADD(DAY, 0, @TodayVn), N'Ca qua đêm'),
    ('PC004', 'NV002', 'CA01', DATEADD(DAY, 1, @TodayVn), N'Trực cổng chính'),
    ('PC005', 'NV004', 'CA02', DATEADD(DAY, 1, @TodayVn), N'Trực thu phí'),
    ('PC006', 'NV001', 'CA03', DATEADD(DAY, 1, @TodayVn), N'Ca qua đêm'),
    ('PC007', 'NV004', 'CA01', DATEADD(DAY, 2, @TodayVn), N'Trực cổng chính'),
    ('PC008', 'NV001', 'CA02', DATEADD(DAY, 2, @TodayVn), N'Trực thu phí'),
    ('PC009', 'NV002', 'CA03', DATEADD(DAY, 2, @TodayVn), N'Ca qua đêm'),
    ('PC010', 'NV001', 'CA01', DATEADD(DAY, 3, @TodayVn), N'Trực cổng chính'),
    ('PC011', 'NV002', 'CA02', DATEADD(DAY, 3, @TodayVn), N'Trực thu phí'),
    ('PC012', 'NV004', 'CA03', DATEADD(DAY, 3, @TodayVn), N'Ca qua đêm'),
    ('PC013', 'NV002', 'CA01', DATEADD(DAY, 4, @TodayVn), N'Trực cổng chính'),
    ('PC014', 'NV004', 'CA02', DATEADD(DAY, 4, @TodayVn), N'Trực thu phí'),
    ('PC015', 'NV001', 'CA03', DATEADD(DAY, 4, @TodayVn), N'Ca qua đêm'),
    ('PC016', 'NV004', 'CA01', DATEADD(DAY, 5, @TodayVn), N'Trực cổng chính'),
    ('PC017', 'NV001', 'CA02', DATEADD(DAY, 5, @TodayVn), N'Trực thu phí'),
    ('PC018', 'NV002', 'CA03', DATEADD(DAY, 5, @TodayVn), N'Ca qua đêm'),
    ('PC019', 'NV001', 'CA01', DATEADD(DAY, 6, @TodayVn), N'Trực cổng chính'),
    ('PC020', 'NV002', 'CA02', DATEADD(DAY, 6, @TodayVn), N'Trực thu phí'),
    ('PC021', 'NV004', 'CA03', DATEADD(DAY, 6, @TodayVn), N'Ca qua đêm');

INSERT INTO dbo.KHACHHANG (MaKH, HoTen, SoDienThoai)
VALUES
    ('KH001', N'Võ Hoàng Nam',   '0909123456'),
    ('KH002', N'Đặng Ngọc Lan',  '0918111222'),
    ('KH003', N'Bùi Thanh Tùng', '0933555777'),
    ('KH004', N'Nguyễn Hải Yến', '0977666555'),
    ('KH005', N'Phan Gia Hân',    '0903444555'),
    ('KH006', N'Đỗ Quốc Huy',     '0915666777'),
    ('KH007', N'Trương Mỹ Linh',  '0937888999'),
    ('KH008', N'Hoàng Anh Tuấn',  '0963111222');

INSERT INTO dbo.PHUONGTIEN (MaPT, BienSo, LoaiXe, MaKH)
VALUES
    ('PT001', '51H-123.45',   N'Ô tô',   'KH001'),
    ('PT002', '59X3-456.78',  N'Xe máy', 'KH002'),
    ('PT003', '51K-888.99',   N'Ô tô',   'KH003'),
    ('PT004', '59P2-135.79',  N'Xe máy', NULL),
    ('PT005', '50F-246.80',   N'Ô tô',   'KH004'),
    ('PT006', '59A1-222.33',  N'Xe máy', 'KH005'),
    ('PT007', '59M1-126.45',  N'Xe máy', 'KH006'),
    ('PT008', '51A-707.88',   N'Ô tô',   'KH007'),
    ('PT009', '59M1-128.45',  N'Xe máy', NULL),
    ('PT010', '51A-709.88',   N'Ô tô',   'KH008'),
    ('PT011', '59M1-130.45',  N'Xe máy', 'KH005'),
    ('PT012', '51A-711.88',   N'Ô tô',   'KH006'),
    ('PT013', '59M1-132.45',  N'Xe máy', NULL),
    ('PT014', '51A-713.88',   N'Ô tô',   NULL),
    ('PT015', '59M1-134.45',  N'Xe máy', NULL);

INSERT INTO dbo.LOAIVE (MaLoaiVe, TenLoaiVe, KyHieu)
VALUES
    ('LV01', N'Vé lượt', 'LUOT'),
    ('LV02', N'Vé tháng', 'THANG');

INSERT INTO dbo.VE (MaVe, MaThe, MaLoaiVe, NgayCap, TrangThai)
VALUES
    ('VE001', 'THE-L001', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE002', 'THE-L002', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE003', 'THE-T001', 'LV02', DATEADD(MONTH, -2, @TodayVn), 'HOAT_DONG'),
    ('VE004', 'THE-T002', 'LV02', DATEADD(MONTH, -1, @TodayVn), 'HOAT_DONG'),
    ('VE005', 'THE-L003', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HONG'),
    ('VE006', 'THE-L004', 'LV01', DATEADD(DAY, -20, @TodayVn), 'HOAT_DONG'),
    ('VE007', 'THE-T003', 'LV02', DATEADD(MONTH, -2, @TodayVn), 'HOAT_DONG'),
    ('VE008', 'THE-T004', 'LV02', DATEADD(DAY, -10, @TodayVn), 'HOAT_DONG'),
    ('VE009', 'THE-L005', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE010', 'THE-L006', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE011', 'THE-L007', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE012', 'THE-L008', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE013', 'THE-L009', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE014', 'THE-L010', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE015', 'THE-L011', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE016', 'THE-L012', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG'),
    ('VE017', 'THE-L013', 'LV01', DATEADD(MONTH, -3, @TodayVn), 'HOAT_DONG');

INSERT INTO dbo.BANGGIA
    (MaBangGia, LoaiXe, MaLoaiVe, DonGia, DonGiaSau19Gio, DonGiaQuaDem, NgayApDung)
VALUES
    ('BG001', N'Xe máy', 'LV01',    5000, 10000, 20000, DATEADD(MONTH, -6, @TodayVn)),
    ('BG002', N'Ô tô',   'LV01',   30000, 40000, 50000, DATEADD(MONTH, -6, @TodayVn)),
    ('BG003', N'Xe máy', 'LV02',  150000,  NULL,  NULL, DATEADD(MONTH, -6, @TodayVn)),
    ('BG004', N'Ô tô',   'LV02', 1200000,  NULL,  NULL, DATEADD(MONTH, -6, @TodayVn));

INSERT INTO dbo.KHUVUC (MaKhuVuc, TenKhuVuc, LoaiXe, SucChua, TrangThai)
VALUES
    ('KV-A', N'Khu A - Xe máy', N'Xe máy', 120, 'HOAT_DONG'),
    ('KV-B', N'Khu B - Ô tô',   N'Ô tô',    60, 'HOAT_DONG'),
    ('KV-C', N'Khu C - Ô tô',   N'Ô tô',    30, 'BAO_TRI');

INSERT INTO dbo.DANGKYVETHANG
    (MaDangKy, MaKH, MaPT, MaVe, NgayBatDau, NgayKetThuc, SoThang, DonGiaThang, TongTien, ThanhToan, TrangThai)
VALUES
    ('DK001', 'KH001', 'PT001', 'VE003', DATEADD(DAY, -12, @TodayVn), DATEADD(DAY, 18, @TodayVn), 1, 1200000, 1200000, 'DA_THANH_TOAN', 'HIEU_LUC'),
    ('DK002', 'KH002', 'PT002', 'VE004', DATEADD(DAY, -25, @TodayVn), DATEADD(DAY,  5, @TodayVn), 1,  150000,  150000, 'DA_THANH_TOAN', 'HIEU_LUC'),
    ('DK003', 'KH003', 'PT003', 'VE007', DATEADD(MONTH, -1, @TodayVn), @TodayVn,                  1, 1200000, 1200000, 'DA_THANH_TOAN', 'HET_HAN');

/* Ba luot dang gui. */
INSERT INTO dbo.LUOTGUIXE
    (MaLuotGui, MaPT, MaVe, MaKhuVuc, ThoiGianVaoUtc, ThoiGianRaUtc, TienGui, MaNVVao, MaNVRa, LoaiVe, TrangThai)
VALUES
    ('LG001', 'PT001', 'VE003', 'KV-B', DATEADD(HOUR, -3,  @NowUtc), NULL, 0, 'NV001', NULL, 'THANG', 'DANG_GUI'),
    ('LG002', 'PT004', 'VE001', 'KV-A', DATEADD(HOUR, -2,  @NowUtc), NULL, 0, 'NV001', NULL, 'LUOT',  'DANG_GUI'),
    ('LG003', 'PT005', 'VE002', 'KV-B', DATEADD(MINUTE, -45, @NowUtc), NULL, 0, 'NV002', NULL, 'LUOT', 'DANG_GUI');

/* Lich su da ra. */
INSERT INTO dbo.LUOTGUIXE
    (MaLuotGui, MaPT, MaVe, MaKhuVuc, ThoiGianVaoUtc, ThoiGianRaUtc, TienGui, MaNVVao, MaNVRa, LoaiVe, TrangThai)
VALUES
    ('LG004', 'PT006', 'VE006', 'KV-A', DATEADD(HOUR, -26, @NowUtc), DATEADD(HOUR, -24, @NowUtc),  5000, 'NV001', 'NV002', 'LUOT', 'DA_RA'),
    ('LG005', 'PT003', 'VE005', 'KV-B', DATEADD(HOUR, -53, @NowUtc), DATEADD(HOUR, -48, @NowUtc), 30000, 'NV004', 'NV001', 'LUOT', 'DA_RA'),
    ('LG006', 'PT007', 'VE009', 'KV-A', DATEADD(HOUR, -75, @NowUtc), DATEADD(HOUR, -72, @NowUtc),  5000, 'NV001', 'NV002', 'LUOT', 'DA_RA'),
    ('LG007', 'PT008', 'VE010', 'KV-B', DATEADD(HOUR, -99, @NowUtc), DATEADD(HOUR, -96, @NowUtc), 30000, 'NV001', 'NV002', 'LUOT', 'DA_RA'),
    ('LG008', 'PT009', 'VE011', 'KV-A', DATEADD(HOUR, -123,@NowUtc), DATEADD(HOUR, -120,@NowUtc),  5000, 'NV002', 'NV004', 'LUOT', 'DA_RA'),
    ('LG009', 'PT010', 'VE012', 'KV-B', DATEADD(HOUR, -147,@NowUtc), DATEADD(HOUR, -144,@NowUtc), 30000, 'NV001', 'NV002', 'LUOT', 'DA_RA'),
    ('LG010', 'PT011', 'VE013', 'KV-A', DATEADD(HOUR, -171,@NowUtc), DATEADD(HOUR, -168,@NowUtc),  5000, 'NV001', 'NV002', 'LUOT', 'DA_RA'),
    ('LG011', 'PT012', 'VE014', 'KV-B', DATEADD(HOUR, -195,@NowUtc), DATEADD(HOUR, -192,@NowUtc), 30000, 'NV002', 'NV001', 'LUOT', 'DA_RA'),
    ('LG012', 'PT013', 'VE015', 'KV-A', DATEADD(HOUR, -219,@NowUtc), DATEADD(HOUR, -216,@NowUtc),  5000, 'NV001', 'NV004', 'LUOT', 'DA_RA'),
    ('LG013', 'PT014', 'VE016', 'KV-B', DATEADD(HOUR, -243,@NowUtc), DATEADD(HOUR, -240,@NowUtc), 30000, 'NV002', 'NV001', 'LUOT', 'DA_RA'),
    ('LG014', 'PT015', 'VE017', 'KV-A', DATEADD(HOUR, -267,@NowUtc), DATEADD(HOUR, -264,@NowUtc),  5000, 'NV001', 'NV002', 'LUOT', 'DA_RA');

INSERT INTO dbo.THANHTOAN
    (MaThanhToan, LoaiThanhToan, MaLuotGui, MaDangKy, SoTien, ThoiGianUtc, PhuongThuc, TrangThai, MaNV, MaThamChieu, GhiChu)
VALUES
    ('TT001', 'VE_THANG', NULL,    'DK001', 1200000, DATEADD(DAY, -12, @NowUtc), 'CHUYEN_KHOAN', 'THANH_CONG', 'NV001', 'DEMO-DK001', N'Đăng ký vé tháng ô tô'),
    ('TT002', 'VE_THANG', NULL,    'DK002',  150000, DATEADD(DAY, -25, @NowUtc), 'CHUYEN_KHOAN', 'THANH_CONG', 'NV002', 'DEMO-DK002', N'Đăng ký vé tháng xe máy'),
    ('TT003', 'VE_THANG', NULL,    'DK003', 1200000, DATEADD(MONTH,-1, @NowUtc), 'THE',           'THANH_CONG', 'NV001', 'DEMO-DK003', N'Đăng ký đã hết hạn'),
    ('TT004', 'VE_LUOT',  'LG004', NULL,       5000, DATEADD(HOUR, -24, @NowUtc), 'TIEN_MAT',     'THANH_CONG', 'NV002', NULL, NULL),
    ('TT005', 'VE_LUOT',  'LG005', NULL,      30000, DATEADD(HOUR, -48, @NowUtc), 'CHUYEN_KHOAN', 'THANH_CONG', 'NV001', NULL, NULL),
    ('TT006', 'VE_LUOT',  'LG006', NULL,       5000, DATEADD(HOUR, -72, @NowUtc), 'TIEN_MAT',     'THANH_CONG', 'NV002', NULL, NULL),
    ('TT007', 'VE_LUOT',  'LG007', NULL,      30000, DATEADD(HOUR, -96, @NowUtc), 'THE',           'THANH_CONG', 'NV002', NULL, NULL),
    ('TT008', 'VE_LUOT',  'LG008', NULL,       5000, DATEADD(HOUR,-120, @NowUtc), 'TIEN_MAT',      'THANH_CONG', 'NV004', NULL, NULL),
    ('TT009', 'VE_LUOT',  'LG009', NULL,      30000, DATEADD(HOUR,-144, @NowUtc), 'CHUYEN_KHOAN',  'THANH_CONG', 'NV002', NULL, NULL),
    ('TT010', 'VE_LUOT',  'LG010', NULL,       5000, DATEADD(HOUR,-168, @NowUtc), 'TIEN_MAT',      'THANH_CONG', 'NV002', NULL, NULL),
    ('TT011', 'VE_LUOT',  'LG011', NULL,      30000, DATEADD(HOUR,-192, @NowUtc), 'THE',            'THANH_CONG', 'NV001', NULL, NULL),
    ('TT012', 'VE_LUOT',  'LG012', NULL,       5000, DATEADD(HOUR,-216, @NowUtc), 'TIEN_MAT',       'THANH_CONG', 'NV004', NULL, NULL),
    ('TT013', 'VE_LUOT',  'LG013', NULL,      30000, DATEADD(HOUR,-240, @NowUtc), 'CHUYEN_KHOAN',   'THANH_CONG', 'NV001', NULL, NULL),
    ('TT014', 'VE_LUOT',  'LG014', NULL,       5000, DATEADD(HOUR,-264, @NowUtc), 'TIEN_MAT',       'THANH_CONG', 'NV002', NULL, NULL);
GO

PRINT N'Đã thêm dữ liệu mẫu cho QLGuiXe.';
GO

