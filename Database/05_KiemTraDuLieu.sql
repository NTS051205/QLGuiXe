/*
    FILE 05 - KIỂM TRA DỮ LIỆU

    Kiểm tra dữ liệu sau khi đã chạy các file 01, 02, 03 và 04.
*/

USE QLGuiXe;
GO

-- 1. Nhân viên
SELECT * FROM dbo.NHANVIEN;

-- 2. Tài khoản
SELECT * FROM dbo.TAIKHOAN;

-- 3. Ca làm
SELECT * FROM dbo.CALAM;

-- 4. Phân công ca
SELECT * FROM dbo.PHANCONGCA;

-- 5. Khách hàng
SELECT * FROM dbo.KHACHHANG;

-- 6. Phương tiện
SELECT * FROM dbo.PHUONGTIEN;

-- 7. Loại vé
SELECT * FROM dbo.LOAIVE;

-- 8. Vé và thẻ xe
SELECT * FROM dbo.VE;

-- 9. Bảng giá
SELECT * FROM dbo.BANGGIA;

-- 10. Khu vực
SELECT * FROM dbo.KHUVUC;

-- 11. Đăng ký vé tháng
SELECT * FROM dbo.DANGKYVETHANG;

-- 12. Lượt gửi xe
SELECT * FROM dbo.LUOTGUIXE;

-- 13. Thanh toán
SELECT * FROM dbo.THANHTOAN;
GO
