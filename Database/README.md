# Database QLGuiXe

Thư mục này chứa bộ SQL Server đầy đủ cho phiên bản hiện tại của ứng dụng.

Schema này khớp với các bảng và trường dữ liệu mà giao diện QLGuiXe đang sử dụng.

## Cấu trúc SQL

```text
Database/
├── 01_TaoDatabase_VaBang.sql
├── 02_ThemDuLieuMau.sql
├── 03_TaoView_VaThuTucNghiepVu.sql
├── 04_ThuTucCRUDChoForm.sql
└── 05_KiemTraDuLieu.sql
```

## Tạo database mới

Mở SSMS và chạy lần lượt đúng 5 file:

1. `01_TaoDatabase_VaBang.sql`: tạo database, bảng, khóa và ràng buộc.
2. `02_ThemDuLieuMau.sql`: thêm dữ liệu trình diễn.
3. `03_TaoView_VaThuTucNghiepVu.sql`: tạo View và các thủ tục xe vào, xe ra, vé tháng.
4. `04_ThuTucCRUDChoForm.sql`: tạo đăng nhập và các thủ tục CRUD mà Form gọi.
5. `05_KiemTraDuLieu.sql`: hiển thị dữ liệu để kiểm tra.

File `01` chỉ chạy một lần khi database `QLGuiXe` chưa tồn tại. Toàn bộ dữ liệu cần trình diễn đã được gộp vào file `02`; không còn script bổ sung riêng.

Nếu muốn làm lại dữ liệu từ đầu, xóa database `QLGuiXe` rồi chạy lại đúng thứ tự `01` đến `05`.

## Quy tắc đã đặt ở SQL

- `MaKH` trong `PHUONGTIEN` được phép `NULL` cho khách vãng lai.
- Một phương tiện và một thẻ chỉ có tối đa một lượt gửi `DANG_GUI`.
- Vé tháng hợp lệ phải đã thanh toán và thỏa `NgayBatDau <= ngày hiện tại < NgayKetThuc`.
- Xe dùng vé tháng hợp lệ có phí lượt bằng `0`.
- Vé lượt xe máy có giá mẫu: thường `5.000 ₫`, sau 19 giờ `10.000 ₫`, qua đêm `20.000 ₫`.
- Vé lượt ô tô có giá mẫu: thường `30.000 ₫`, sau 19 giờ `40.000 ₫`, qua đêm `50.000 ₫`.
- Nếu thời gian vào và ra khác ngày thì dùng giá qua đêm; nếu cùng ngày và ra từ 19:00 thì dùng giá sau 19 giờ.
- Sức chứa khu vực được tính từ lượt gửi đang mở, không lưu số đếm dư thừa.
- Doanh thu lấy từ `THANHTOAN` có trạng thái `THANH_CONG`.
- Các thời điểm nghiệp vụ dùng `DATETIME2` UTC; view đổi sang múi giờ Việt Nam để hiển thị.
- Không cascade delete dữ liệu lịch sử.

## Phân quyền trong ứng dụng

- `ADMIN`: sử dụng tất cả chức năng.
- `NHANVIEN`: xe vào, xe ra, lịch sử gửi xe và đăng ký/thanh toán vé tháng.
- Danh mục, nhân sự, tài khoản và báo cáo chỉ dành cho `ADMIN`.

Vai trò được lấy từ bảng `TAIKHOAN` khi đăng nhập. Giao diện khóa các menu quản trị đối với nhân viên; mã nhân viên lập phiếu xe vào/xe ra và thanh toán lấy từ phiên đăng nhập hiện tại.

Các câu `IF` và `THROW` trong `03_TaoView_VaThuTucNghiepVu.sql` chỉ dùng để ngăn dữ liệu sai ở những nghiệp vụ quan trọng như một xe vào hai lần, dùng trùng thẻ, đăng ký vé tháng chồng thời hạn hoặc thanh toán hai lần. Các thủ tục danh sách và CRUD trong `04_ThuTucCRUDChoForm.sql` giữ cách viết đơn giản để dễ học và dễ gọi từ Form.

Ba tài khoản hoạt động trong dữ liệu mẫu là `admin / Admin@123`, `quocbao / NhanVien@123` và `duclong / NhanVien@123`. Tài khoản `thuha` được giữ ở trạng thái khóa để minh họa bộ lọc. Hash SHA2 trong seed chỉ dùng để minh họa; khi làm đăng nhập thật cần băm mật khẩu bằng PBKDF2, BCrypt hoặc Argon2 ở tầng C#.
