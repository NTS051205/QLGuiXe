using System.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class frmLoaiVe : Form
{
    private readonly KetNoiCSDL _data = KetNoiCSDL.Instance;
    private DataTable _ticketTypes;
    private DataTable _cards;
    private QuanLyDanhSach pageLoaiVe = null!;
    private QuanLyDanhSach pageTheXe = null!;

    public frmLoaiVe()
    {
        InitializeComponent();
        pageLoaiVe = new QuanLyDanhSach(lblTieuDeLoaiVe, lblMoTaLoaiVe, btnThemLoaiVe, txtTimKiemLoaiVe, lblBoLocLoaiVe, cboBoLocLoaiVe, lblBoLocPhuLoaiVe, cboBoLocPhuLoaiVe, lblTuNgayLoaiVe, dtpTuNgayLoaiVe, lblDenNgayLoaiVe, dtpDenNgayLoaiVe, btnLamMoiLoaiVe, dgvLoaiVe, lblTongLoaiVe, btnXemLoaiVe, btnSuaLoaiVe, btnXoaLoaiVe);
        pageTheXe = new QuanLyDanhSach(lblTieuDeTheXe, lblMoTaTheXe, btnThemTheXe, txtTimKiemTheXe, lblBoLocTheXe, cboBoLocTheXe, lblBoLocPhuTheXe, cboBoLocPhuTheXe, lblTuNgayTheXe, dtpTuNgayTheXe, lblDenNgayTheXe, dtpDenNgayTheXe, btnLamMoiTheXe, dgvTheXe, lblTongTheXe, btnXemTheXe, btnSuaTheXe, btnXoaTheXe);
        _ticketTypes = _data.GetTable("LOAIVE"); _cards = _data.GetTable("VE");
        pageLoaiVe.Configure("Loại vé", "Phân loại vé lượt và vé tháng theo đúng ký hiệu nghiệp vụ.", "+ Thêm loại vé", "Tìm loại vé...");
        pageLoaiVe.Bind(_ticketTypes, "MaLoaiVe", "TenLoaiVe", "KyHieu");
        DuLieuForm.RenameColumns(pageLoaiVe.Grid, ("MaLoaiVe", "Mã loại vé"), ("TenLoaiVe", "Tên loại vé"), ("KyHieu", "Ký hiệu"));
        pageLoaiVe.AddButton.Click += AddType_Click; pageLoaiVe.EditButton.Click += EditType_Click; pageLoaiVe.DeleteButton.Visible = false;
        pageLoaiVe.RefreshButton.Click += (_, _) => ReloadTypes();
        pageLoaiVe.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(pageLoaiVe) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết loại vé"); };

        pageTheXe.Configure("Quản lý thẻ xe", "Theo dõi thẻ gửi xe và trạng thái sử dụng.", "+ Cấp thẻ", "Tìm mã thẻ hoặc mã vé...");
        pageTheXe.ConfigureFilter("Trạng thái:", new[] { "HOAT_DONG", "KHOA", "HONG" }, "TrangThai");
        pageTheXe.ConfigureSecondFilter("Loại vé:", new[] { "LUOT", "THANG" }, "LoaiVe");
        pageTheXe.Bind(_cards, "MaVe", "MaThe");
        DuLieuForm.RenameColumns(pageTheXe.Grid, ("MaVe", "Mã vé"), ("MaThe", "Mã thẻ"), ("LoaiVe", "Loại vé"), ("NgayCap", "Ngày cấp"), ("TrangThai", "Trạng thái"));
        pageTheXe.Grid.Columns["NgayCap"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
        pageTheXe.AddButton.Click += AddCard_Click; pageTheXe.EditButton.Click += EditCard_Click; pageTheXe.DeleteButton.Text = "Khóa"; pageTheXe.DeleteButton.Click += LockCard_Click;
        pageTheXe.RefreshButton.Click += (_, _) => ReloadCards();
        pageTheXe.ViewButton.Click += (_, _) => { if (DuLieuForm.RequireSelection(pageTheXe) is { } row) DuLieuForm.ShowDetails(row, "Chi tiết thẻ xe"); };
    }

    private static RecordEditorDialog TypeEditor(string title, DataRow? row) => new(title, new[]
    {
        new EditorField("TenLoaiVe", "Tên loại vé", row?["TenLoaiVe"]?.ToString()),
        new EditorField("KyHieu", "Ký hiệu", row?["KyHieu"]?.ToString() ?? "LUOT", Options: new[] { "LUOT", "THANG" })
    });
    private static RecordEditorDialog CardEditor(string title, DataRow? row) => new(title, new[]
    {
        new EditorField("MaThe", "Mã thẻ", row?["MaThe"]?.ToString()),
        new EditorField("LoaiVe", "Loại vé", row?["LoaiVe"]?.ToString() ?? "LUOT", Options: new[] { "LUOT", "THANG" }),
        new EditorField("NgayCap", "Ngày cấp", row?["NgayCap"]?.ToString(), Kind: EditorKind.Date),
        new EditorField("TrangThai", "Trạng thái", row?["TrangThai"]?.ToString() ?? "HOAT_DONG", Options: new[] { "HOAT_DONG", "KHOA", "HONG" })
    });
    private void AddType_Click(object? s, EventArgs e) { using var d = TypeEditor("Thêm loại vé", null); if (d.ShowDialog(this) != DialogResult.OK) return; try { _data.Execute("INSERT dbo.LOAIVE(MaLoaiVe,TenLoaiVe,KyHieu) VALUES(@Ma,@Ten,@KyHieu)", KetNoiCSDL.Param("@Ma", _data.NextCode("LOAIVE", "MaLoaiVe", "LV", 2)), KetNoiCSDL.Param("@Ten", d.Values["TenLoaiVe"]), KetNoiCSDL.Param("@KyHieu", d.Values["KyHieu"])); ReloadTypes(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void EditType_Click(object? s, EventArgs e) { var r = DuLieuForm.RequireSelection(pageLoaiVe); if (r is null) return; using var d = TypeEditor("Sửa loại vé", r); if (d.ShowDialog(this) != DialogResult.OK) return; try { _data.Execute("UPDATE dbo.LOAIVE SET TenLoaiVe=@Ten,KyHieu=@KyHieu WHERE MaLoaiVe=@Ma", KetNoiCSDL.Param("@Ten", d.Values["TenLoaiVe"]), KetNoiCSDL.Param("@KyHieu", d.Values["KyHieu"]), KetNoiCSDL.Param("@Ma", r["MaLoaiVe"])); ReloadTypes(); ReloadCards(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void AddCard_Click(object? s, EventArgs e) { using var d = CardEditor("Cấp thẻ xe", null); if (d.ShowDialog(this) != DialogResult.OK) return; try { _data.Execute("INSERT dbo.VE(MaVe,MaThe,MaLoaiVe,NgayCap,TrangThai) VALUES(@Ma,UPPER(@MaThe),(SELECT MaLoaiVe FROM dbo.LOAIVE WHERE KyHieu=@LoaiVe),@NgayCap,@TrangThai)", KetNoiCSDL.Param("@Ma", _data.NextCode("VE", "MaVe", "VE")), KetNoiCSDL.Param("@MaThe", d.Values["MaThe"]), KetNoiCSDL.Param("@LoaiVe", d.Values["LoaiVe"]), KetNoiCSDL.Param("@NgayCap", DateTime.Parse(d.Values["NgayCap"]).Date), KetNoiCSDL.Param("@TrangThai", d.Values["TrangThai"])); ReloadCards(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void EditCard_Click(object? s, EventArgs e) { var r = DuLieuForm.RequireSelection(pageTheXe); if (r is null) return; using var d = CardEditor("Sửa thẻ xe", r); if (d.ShowDialog(this) != DialogResult.OK) return; try { _data.Execute("UPDATE dbo.VE SET MaThe=UPPER(@MaThe),MaLoaiVe=(SELECT MaLoaiVe FROM dbo.LOAIVE WHERE KyHieu=@LoaiVe),NgayCap=@NgayCap,TrangThai=@TrangThai WHERE MaVe=@Ma", KetNoiCSDL.Param("@MaThe", d.Values["MaThe"]), KetNoiCSDL.Param("@LoaiVe", d.Values["LoaiVe"]), KetNoiCSDL.Param("@NgayCap", DateTime.Parse(d.Values["NgayCap"]).Date), KetNoiCSDL.Param("@TrangThai", d.Values["TrangThai"]), KetNoiCSDL.Param("@Ma", r["MaVe"])); ReloadCards(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void LockCard_Click(object? s, EventArgs e) { var r = DuLieuForm.RequireSelection(pageTheXe); if (r is null || !DuLieuForm.Confirm("Khóa thẻ đã chọn?")) return; try { _data.Execute("UPDATE dbo.VE SET TrangThai='KHOA' WHERE MaVe=@Ma", KetNoiCSDL.Param("@Ma", r["MaVe"])); ReloadCards(); } catch (Exception ex) { ShowDatabaseError(ex); } }
    private void ReloadTypes() { _ticketTypes = _data.GetTable("LOAIVE"); pageLoaiVe.Bind(_ticketTypes, "MaLoaiVe", "TenLoaiVe", "KyHieu"); }
    private void ReloadCards() { _cards = _data.GetTable("VE"); pageTheXe.Bind(_cards, "MaVe", "MaThe"); }
    private void ShowDatabaseError(Exception ex) => MessageBox.Show(ex.Message, "Không thể cập nhật SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}


