# QLGuiXe — Hệ thống quản lý gửi xe

Đồ án môn Lập trình .NET xây dựng bằng C# Windows Forms và Microsoft SQL Server. Ứng dụng quản lý xe vào, xe ra, khách hàng, phương tiện, vé lượt, vé tháng, bảng giá, khu vực đỗ xe, nhân sự và báo cáo Crystal Reports.

## Công nghệ sử dụng

- C# Windows Forms.
- .NET Framework 4.8.
- Microsoft SQL Server/SQL Server Express.
- ADO.NET với `System.Data.SqlClient`.
- Stored Procedure và View.
- SAP Crystal Reports for Visual Studio, thư viện `CrystalDecisions` 13.0.4000.0.
- Cấu hình chạy `x64` để tương thích Crystal Reports 64-bit.

Không sử dụng WPF, ASP.NET hoặc thư viện giao diện thương mại.

## Chức năng chính

- Đăng nhập và phân quyền `ADMIN`/`NHANVIEN`.
- Tổng quan số xe đang gửi, chỗ còn trống, vé tháng và doanh thu.
- Tiếp nhận xe vào, kiểm tra biển số, thẻ xe, khu vực và vé tháng.
- Xe ra, tính thời gian gửi, tính phí vé lượt và ghi nhận thanh toán.
- Đăng ký, thanh toán và gia hạn vé tháng.
- Quản lý khách hàng, phương tiện, loại vé, thẻ xe, bảng giá và khu vực.
- Quản lý nhân viên, tài khoản, ca làm và phân công ca.
- Tra cứu lịch sử gửi xe.
- Báo cáo nhân viên, phương tiện và doanh thu bằng Crystal Reports.

## Phân quyền

| Chức năng | ADMIN | NHANVIEN |
|---|:---:|:---:|
| Xe vào, xe ra | Có | Có |
| Lịch sử gửi xe | Có | Có |
| Đăng ký/thanh toán vé tháng | Có | Có |
| Quản lý danh mục | Có | Không |
| Quản lý nhân sự, tài khoản | Có | Không |
| Báo cáo | Có | Không |

Vai trò được đọc từ bảng `TAIKHOAN` khi đăng nhập. Nhân viên xử lý xe vào, xe ra và thanh toán được lấy từ phiên đăng nhập hiện tại.

## Yêu cầu môi trường

1. Windows 10 hoặc Windows 11 64-bit.
2. Visual Studio với workload **.NET Desktop Development**.
3. .NET Framework 4.8 Developer Pack.
4. SQL Server hoặc SQL Server Express.
5. SQL Server Management Studio (SSMS).
6. SAP Crystal Reports for Visual Studio và Crystal Reports Runtime 64-bit tương ứng phiên bản 13.0.4000.0.

Nếu chưa cài Crystal Reports, project có thể báo thiếu `CrystalDecisions.*` khi build hoặc chạy Form báo cáo.

## Tạo cơ sở dữ liệu

Trong SSMS, mở và chạy lần lượt đúng thứ tự:

1. [`01_TaoDatabase_VaBang.sql`](Database/01_TaoDatabase_VaBang.sql) — tạo database, bảng, khóa và ràng buộc.
2. [`02_ThemDuLieuMau.sql`](Database/02_ThemDuLieuMau.sql) — thêm toàn bộ dữ liệu mẫu.
3. [`03_TaoView_VaThuTucNghiepVu.sql`](Database/03_TaoView_VaThuTucNghiepVu.sql) — tạo View và thủ tục nghiệp vụ.
4. [`04_ThuTucCRUDChoForm.sql`](Database/04_ThuTucCRUDChoForm.sql) — tạo thủ tục đăng nhập, CRUD và báo cáo.
5. [`05_KiemTraDuLieu.sql`](Database/05_KiemTraDuLieu.sql) — truy vấn kiểm tra sau khi cài đặt.

File `01` chỉ chạy khi database `QLGuiXe` chưa tồn tại. Muốn làm lại hoàn toàn, xóa database cũ trong SSMS rồi chạy lại từ `01` đến `05`. Không chạy lặp riêng file `02` vì dữ liệu mẫu sử dụng khóa chính cố định.

Chi tiết schema và quy tắc nghiệp vụ xem tại [`Database/README.md`](Database/README.md).

## Cấu hình kết nối SQL Server

Kết nối mặc định trong `QLGuiXe/App.config`:

```text
Server=.\SQLEXPRESS;Database=QLGuiXe;Integrated Security=True;MultipleActiveResultSets=True
```

Nếu máy thành viên dùng instance khác, chỉ sửa giá trị `Server`, ví dụ:

```text
Server=TENMAY\SQLEXPRESS;Database=QLGuiXe;Integrated Security=True;MultipleActiveResultSets=True
```

Không cần sửa Designer hoặc code của từng Form.

## Chạy ứng dụng

1. Clone repository:

   ```powershell
   git clone https://github.com/NTS051205/QLGuiXe.git
   ```

2. Tạo database theo năm file SQL ở trên.
3. Mở `QLGuiXe.sln` bằng Visual Studio.
4. Chọn project `QLGuiXe` làm **Startup Project**.
5. Kiểm tra **Platform target** là `x64`.
6. Chọn **Build > Rebuild Solution**.
7. Nhấn `F5` để chạy.

Có thể build bằng Developer PowerShell for Visual Studio:

```powershell
msbuild QLGuiXe.sln /t:Rebuild /p:Configuration=Debug
```

## Tài khoản dữ liệu mẫu

| Tên đăng nhập | Mật khẩu | Vai trò | Trạng thái |
|---|---|---|---|
| `admin` | `Admin@123` | ADMIN | Hoạt động |
| `quocbao` | `NhanVien@123` | NHANVIEN | Hoạt động |
| `duclong` | `NhanVien@123` | NHANVIEN | Hoạt động |
| `thuha` | `NhanVien@123` | NHANVIEN | Khóa |

Nút **Đăng nhập thử** dùng để trình diễn giao diện. Muốn kiểm tra đúng phân quyền, hãy đăng nhập bằng tài khoản trong bảng trên.

## Windows Forms Designer

Mỗi Form được tổ chức theo đúng cấu trúc Designer:

```text
frmTenForm.cs           — xử lý sự kiện và gọi SQL
frmTenForm.Designer.cs  — khai báo, khởi tạo và bố trí control
frmTenForm.resx         — tài nguyên của Form
```

- Nhấp phải `frmTenForm.cs` rồi chọn **View Designer**, hoặc nhấn `Shift+F7`.
- Nhấn `F7` để mở code xử lý.
- Nhấp một lần vào control để chỉnh trong cửa sổ Properties.
- Nhấp đúp control để mở event mặc định.
- Tên control sử dụng tiền tố dễ đọc như `btn`, `txt`, `cbo`, `dgv`, `lbl`, `chk`, `dtp`, `pnl`.
- Các control chính được đặt trực tiếp trong `.Designer.cs`, không dựng toàn bộ Form bằng code động.

## Crystal Reports

Thư mục `QLGuiXe/Reports` chứa ba báo cáo:

```text
BaoCaoNhanVien.rpt
BaoCaoPhuongTien.rpt
BaoCaoDoanhThu.rpt
```

Các file `.rpt` được thêm vào project dưới dạng `EmbeddedResource` và có lớp báo cáo tương ứng. `frmBaoCao` lấy dữ liệu từ Stored Procedure, gọi `SetDataSource()` rồi hiển thị trong `CrystalReportViewer`.

Để sửa giao diện báo cáo, mở file `.rpt` trực tiếp trong Visual Studio có cài Crystal Reports. Form báo cáo chỉ gồm vùng điều kiện ở phía trên và viewer ở phía dưới, không chiếm toàn bộ luồng điều hướng của ứng dụng.

## Cấu trúc source code

```text
QLGuiXe/
├── Forms/              Các Form và file Designer
├── Reports/            File Crystal Reports và lớp báo cáo
├── KetNoiCSDL.cs       Kết nối và hàm ADO.NET dùng chung
├── App.config          Chuỗi kết nối SQL Server
├── Program.cs          Điểm khởi chạy ứng dụng
└── QLGuiXe.csproj      Cấu hình project .NET Framework 4.8 x64

Database/
├── 01_TaoDatabase_VaBang.sql
├── 02_ThemDuLieuMau.sql
├── 03_TaoView_VaThuTucNghiepVu.sql
├── 04_ThuTucCRUDChoForm.sql
├── 05_KiemTraDuLieu.sql
└── README.md
```

## Quy tắc nghiệp vụ đã mô phỏng

- Khách vãng lai có thể có phương tiện với `MaKH = NULL`.
- Một xe không có hai lượt gửi đang mở.
- Một thẻ không dùng cho hai lượt gửi chưa hoàn thành.
- Vé tháng chỉ hợp lệ khi đã thanh toán và còn trong thời hạn.
- Ngày kết thúc vé tháng là cận trên không bao gồm.
- Vé tháng hợp lệ có phí lượt bằng `0 ₫`.
- Vé lượt áp dụng giá thường, giá sau 19 giờ hoặc giá qua đêm.
- Doanh thu chỉ tính thanh toán có trạng thái `THANH_CONG`.
- Dữ liệu thời gian nghiệp vụ lưu UTC và hiển thị theo giờ Việt Nam.

## Chức năng chưa triển khai

- Xuất Excel hoàn chỉnh.
- Camera và nhận diện biển số.
- Đọc thẻ xe vật lý.
- In hóa đơn.
- Phân trang dữ liệu lớn.

Các vị trí giao diện dành cho chức năng giai đoạn sau sẽ hiển thị thông báo thay vì ghi dữ liệu ngoài dự kiến.

## Làm việc nhóm với Git

Trước khi bắt đầu làm:

```powershell
git pull origin main
```

Sau khi hoàn thành một phần chức năng:

```powershell
git add .
git commit -m "Mô tả phần đã làm"
git push origin main
```

Không commit thư mục `.vs`, `bin`, `obj` hoặc file cấu hình cá nhân. Các thư mục này đã được loại trừ trong `.gitignore`.
