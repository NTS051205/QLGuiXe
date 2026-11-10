using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using QLGuiXe.Reports;

namespace QLGuiXe.Forms;

public partial class frmBaoCao : Form
{
    private readonly KETNOICSDL kn = new KETNOICSDL();
    private ReportDocument? baoCaoDangXem;

    public frmBaoCao()
    {
        InitializeComponent();
        cboLoaiBaoCao.SelectedIndex = 0;
        dtpTuNgay.Value = DateTime.Today.AddDays(-30);
        dtpDenNgay.Value = DateTime.Today;
        CapNhatBoLocNgay();
    }

    private void cboLoaiBaoCao_SelectedIndexChanged(object? sender, EventArgs e)
    {
        CapNhatBoLocNgay();
    }

    private void CapNhatBoLocNgay()
    {
        bool laBaoCaoDoanhThu = cboLoaiBaoCao.SelectedIndex == 2;
        lblTuNgay.Enabled = dtpTuNgay.Enabled = laBaoCaoDoanhThu;
        lblDenNgay.Enabled = dtpDenNgay.Enabled = laBaoCaoDoanhThu;
    }

    private void btnXemBaoCao_Click(object? sender, EventArgs e)
    {
        if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
        {
            MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Dữ liệu chưa hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            ReportDocument baoCao;
            DataTable duLieu;

            switch (cboLoaiBaoCao.SelectedIndex)
            {
                case 0:
                    baoCao = new BaoCaoNhanVien();
                    duLieu = LayDuLieuNhanVien();
                    break;
                case 1:
                    baoCao = new BaoCaoPhuongTien();
                    duLieu = LayDuLieuPhuongTien();
                    break;
                case 2:
                    baoCao = new BaoCaoDoanhThu();
                    duLieu = LayDuLieuDoanhThu();
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn loại báo cáo.");
                    return;
            }

            HienThiBaoCao(baoCao, duLieu);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Không thể mở báo cáo Crystal Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private DataTable LayDuLieuNhanVien()
    {
        DataTable table = kn.GetData("dbo.sp_BaoCao_NhanVien");
        table.TableName = "sp_BaoCao_NhanVien;1";
        return table;
    }

    private DataTable LayDuLieuPhuongTien()
    {
        DataTable table = kn.GetData("dbo.sp_BaoCao_PhuongTien");
        table.TableName = "sp_BaoCao_PhongGD;1";
        return table;
    }

    private DataTable LayDuLieuDoanhThu()
    {
        DataTable table = kn.GetData(
            "dbo.sp_BaoCao_DoanhThu",
            new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
            new SqlParameter("@DenNgay", dtpDenNgay.Value.Date));
        table.TableName = "sp_BaoCao_LoaiTK;1";
        return table;
    }

    private void HienThiBaoCao(ReportDocument baoCao, DataTable duLieu)
    {
        crystalReportViewer.ReportSource = null;
        baoCaoDangXem?.Close();
        baoCaoDangXem?.Dispose();

        baoCao.SetDataSource(duLieu);
        baoCaoDangXem = baoCao;
        crystalReportViewer.ReportSource = baoCaoDangXem;
        crystalReportViewer.RefreshReport();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        crystalReportViewer.ReportSource = null;
        baoCaoDangXem?.Close();
        baoCaoDangXem?.Dispose();
        base.OnFormClosed(e);
    }

    private void btnThoat_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
