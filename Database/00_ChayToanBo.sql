/*
    Chay file nay bang SQLCMD hoac bat SQLCMD Mode trong SSMS.
    Thu tu: schema -> data mau -> view/procedure -> kiem tra.
*/

:ON ERROR EXIT
:r .\01_TaoBang_RangBuoc.sql
:r .\02_ThemDuLieuMau.sql
:r .\03_View_ThuTucNghiepVu.sql
:r .\04_KiemTraDuLieu.sql

PRINT N'QLGuiXe đã được khởi tạo hoàn tất.';
GO
