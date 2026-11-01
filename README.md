# QLGuiXe — Parking Management System

Ứng dụng desktop C# WinForms phục vụ đồ án Lập trình .NET. Bản hiện tại đã kết nối SQL Server, đọc/ghi dữ liệu thật và dùng stored procedure cho các luồng xe vào, xe ra, đăng ký và thanh toán vé tháng.

## Yêu cầu môi trường

- Windows 10/11.
- Visual Studio có workload **.NET Desktop Development**.
- .NET Framework 4.8 Developer Pack (đã có sẵn khi cài workload .NET Desktop Development).
- SQL Server Express tại `.\SQLEXPRESS`, database `QLGuiXe` (có thể đổi trong `App.config`).

Thư mục `Database/` chứa schema SQL Server, dữ liệu mẫu, view và stored procedure nghiệp vụ. Trong SSMS, chạy lần lượt `01_TaoBang_RangBuoc.sql`, `02_ThemDuLieuMau.sql`, `03_View_ThuTucNghiepVu.sql`, sau đó có thể chạy `04_KiemTraDuLieu.sql` để xem dữ liệu. File `01` được viết theo kiểu bài thực hành và chỉ chạy một lần khi database `QLGuiXe` chưa tồn tại.

## Chạy bằng Visual Studio

1. Mở `QLGuiXe.sln`.
2. Đặt project `QLGuiXe` làm Startup Project.
3. Build Solution (`Ctrl+Shift+B`).
4. Nhấn `F5`.
5. Đăng nhập bằng `admin / Admin@123` hoặc `quocbao / NhanVien@123`.

Kết nối mặc định:

```text
Server=.\SQLEXPRESS;Database=QLGuiXe;Integrated Security=True;MultipleActiveResultSets=True
```

Nếu máy khác dùng tên instance khác, sửa mục `connectionStrings` trong `QLGuiXe/App.config` hoặc đặt biến môi trường `QLGUIXE_CONNECTION_STRING`. Không cần sửa Designer hay code Form.

## Sử dụng Windows Forms Designer

- Nhấp phải `frmTenForm.cs` và chọn **View Designer**, hoặc nhấn `Shift+F7`.
- Nhấp một lần vào control chỉ để chọn control và hiện Properties; thao tác này không tự nhảy sang file `.cs`.
- Nhấp đúp control để mở/tạo event mặc định. Muốn chọn event cụ thể, mở Properties, bấm biểu tượng tia sét và chọn `Click`, `TextChanged` hoặc `SelectedIndexChanged`.
- Các trang CRUD khai báo trực tiếp `TextBox`, `ComboBox`, `Button` và `DataGridView` trong `.Designer.cs` của từng Form. Mở Form bằng **View Designer** là có thể chọn và chỉnh từng control.
- `frmDangNhap` và Dashboard chỉ dùng control WinForms chuẩn như `GroupBox`, `Label`, `Button`, `TableLayoutPanel` và `DataGridView`; có thể chọn, kéo và chỉnh trực tiếp trong Designer.
- `F7` mở code-behind; `Shift+F7` quay lại Designer.

Build bằng Developer PowerShell for Visual Studio:

```powershell
msbuild QLGuiXe.sln /t:Rebuild /p:Configuration=Debug
```

## Cấu trúc

- `Forms/`: các form nghiệp vụ/chức năng, mỗi form có `.cs`, `.Designer.cs`, `.resx`.
- `KetNoiCSDL.cs`: chuỗi kết nối, `SqlConnection`, truy vấn tham số hóa và các hàm thao tác SQL dùng chung. Các Form gọi trực tiếp file này.
- `App.config`: chuỗi kết nối SQL Server theo cách thường dùng trong bài thực hành .NET Framework.
- `Database/`: script tạo database, insert dữ liệu mẫu, view, procedure và truy vấn kiểm tra.

## Đã hoạt động với SQL Server

- Đăng nhập từ bảng `TAIKHOAN`, dashboard, sidebar và điều hướng form nhúng.
- Dashboard cơ bản: số xe đang gửi, chỗ trống, tình trạng khu vực, xe vào gần nhất và vé tháng sắp hết hạn.
- Tìm kiếm/lọc, thêm/sửa/xóa/khóa và tải lại dữ liệu trên các trang CRUD.
- Xe vào: kiểm tra xe đang ở bãi, thẻ đang dùng, vé tháng hợp lệ, chỗ trống.
- Xe ra: tra biển số/mã thẻ, tính phí, miễn phí vé tháng và ghi thanh toán.
- Đăng ký/gia hạn/thanh toán vé tháng; ngày kết thúc dùng cận trên không bao gồm.
- Lịch sử gửi xe và báo cáo theo khoảng ngày.
- Tiền hiển thị dạng VNĐ; thời gian hiển thị theo giờ địa phương Việt Nam.

## Chưa tích hợp

- Trang báo cáo doanh thu đã được bỏ khỏi project để giao diện và source gọn hơn.
- Xuất Excel (nút đã đặt sẵn và có thông báo giai đoạn tiếp theo).
- Phân trang, in hóa đơn, camera/nhận diện biển số và đọc thẻ vật lý.
