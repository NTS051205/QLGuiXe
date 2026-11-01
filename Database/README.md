# Database QLGuiXe

Thư mục này chứa bộ SQL Server đầy đủ cho phiên bản hiện tại của ứng dụng.

Schema này khớp với các bảng và trường dữ liệu mà giao diện QLGuiXe đang sử dụng.

## Thứ tự chạy

1. `01_TaoBang_RangBuoc.sql`: tạo database, 13 bảng, khóa ngoại, `CHECK` và index.
2. `02_ThemDuLieuMau.sql`: thêm dữ liệu trình diễn nhất quán.
3. `03_View_ThuTucNghiepVu.sql`: tạo view dành cho giao diện và procedure nghiệp vụ.
4. `04_KiemTraDuLieu.sql`: chạy các câu `SELECT *` để xem dữ liệu.

Với bài thực hành thông thường, mở và chạy riêng từng file trong SSMS theo đúng thứ tự trên. File `00_ChayToanBo.sql` chỉ là lựa chọn thêm nếu đã biết sử dụng **SQLCMD Mode**.

File `01` dùng câu lệnh `CREATE DATABASE QLGuiXe` trực tiếp nên chỉ chạy một lần khi database chưa tồn tại. Các script không tự `DROP DATABASE` và không tự xóa dữ liệu cũ.

## Quy tắc đã đặt ở SQL

- `MaKH` trong `PHUONGTIEN` được phép `NULL` cho khách vãng lai.
- Một phương tiện và một thẻ chỉ có tối đa một lượt gửi `DANG_GUI`.
- Vé tháng hợp lệ phải đã thanh toán và thỏa `NgayBatDau <= ngày hiện tại < NgayKetThuc`.
- Xe dùng vé tháng hợp lệ có phí lượt bằng `0`.
- Sức chứa khu vực được tính từ lượt gửi đang mở, không lưu số đếm dư thừa.
- Doanh thu lấy từ `THANHTOAN` có trạng thái `THANH_CONG`.
- Các thời điểm nghiệp vụ dùng `DATETIME2` UTC; view đổi sang múi giờ Việt Nam để hiển thị.
- Không cascade delete dữ liệu lịch sử.

Hai tài khoản trong dữ liệu mẫu là `admin / Admin@123` và `quocbao / NhanVien@123`. Hash SHA2 trong seed chỉ dùng để minh họa; khi làm đăng nhập thật cần băm mật khẩu bằng PBKDF2, BCrypt hoặc Argon2 ở tầng C#.
