using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe;

public sealed class KetNoiCSDL
{
    public static string ChuoiKetNoi
    {
        get
        {
            var chuoiTuMay = Environment.GetEnvironmentVariable("QLGUIXE_CONNECTION_STRING");
            if (!string.IsNullOrWhiteSpace(chuoiTuMay))
                return chuoiTuMay;

            var cauHinh = ConfigurationManager.ConnectionStrings["QLGuiXe"];
            return cauHinh?.ConnectionString
                ?? @"Server=.\SQLEXPRESS;Database=QLGuiXe;Integrated Security=True;MultipleActiveResultSets=True;";
        }
    }
    public static KetNoiCSDL Instance { get; } = new();

    public KetNoiCSDL() { }

    public bool CanConnect(out string message)
    {
        try
        {
            using var connection = OpenConnection();
            message = $"Đã kết nối {connection.DataSource} / {connection.Database}";
            return true;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return false;
        }
    }

    public SqlConnection OpenConnection()
    {
        var connection = new SqlConnection(ChuoiKetNoi);
        connection.Open();
        return connection;
    }

    public DataTable Query(string sql, params SqlParameter[] parameters)
    {
        using var connection = OpenConnection();
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters);
        using var adapter = new SqlDataAdapter(command);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public int Execute(string sql, params SqlParameter[] parameters)
    {
        using var connection = OpenConnection();
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters);
        return command.ExecuteNonQuery();
    }

    public object? Scalar(string sql, params SqlParameter[] parameters)
    {
        using var connection = OpenConnection();
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters);
        var value = command.ExecuteScalar();
        return value is DBNull ? null : value;
    }

    public DataTable ExecuteProcedure(string procedureName, params SqlParameter[] parameters)
    {
        using var connection = OpenConnection();
        using var command = new SqlCommand(procedureName, connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.AddRange(parameters);
        using var adapter = new SqlDataAdapter(command);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public DataTable GetTable(string tableName) => tableName.ToUpperInvariant() switch
    {
        "NHANVIEN" => Query("SELECT MaNV, HoTen, SoDienThoai, TrangThai FROM dbo.NHANVIEN ORDER BY MaNV"),
        "TAIKHOAN" => Query("SELECT MaTK, TenDangNhap, NhanVien, VaiTro, TrangThai FROM dbo.vw_TaiKhoan ORDER BY MaTK"),
        "CALAM" => Query("SELECT MaCa, TenCa, CONVERT(varchar(5), GioBatDau, 108) AS GioBatDau, CONVERT(varchar(5), GioKetThuc, 108) AS GioKetThuc, QuaDem FROM dbo.vw_CaLam ORDER BY MaCa"),
        "PHANCONGCA" => Query("SELECT MaPhanCong, NhanVien, CaLam, NgayLam FROM dbo.vw_PhanCongCa ORDER BY NgayLam DESC, MaPhanCong"),
        "KHACHHANG" => Query("SELECT MaKH, HoTen, SoDienThoai FROM dbo.KHACHHANG ORDER BY MaKH"),
        "PHUONGTIEN" => Query("SELECT MaPT, BienSo, LoaiXe, KhachHang FROM dbo.vw_PhuongTien ORDER BY MaPT"),
        "BANGGIA" => Query("SELECT MaBangGia, LoaiXe, LoaiVe, DonGia, NgayApDung FROM dbo.vw_BangGia ORDER BY NgayApDung DESC, MaBangGia"),
        "LOAIVE" => Query("SELECT MaLoaiVe, TenLoaiVe, KyHieu FROM dbo.LOAIVE ORDER BY MaLoaiVe"),
        "VE" => Query("SELECT MaVe, MaThe, LoaiVe, NgayCap, TrangThai FROM dbo.vw_Ve ORDER BY MaVe"),
        "KHUVUC" => Query("SELECT MaKhuVuc, TenKhuVuc, LoaiXe, CONVERT(int, SucChua) AS SucChua, CONVERT(int, DangGui) AS DangGui, CONVERT(int, ConTrong) AS ConTrong, TrangThai FROM dbo.vw_KhuVucTinhTrang ORDER BY MaKhuVuc"),
        "DANGKYVETHANG" => Query("SELECT MaDangKy, MaKH, KhachHang, MaPT, BienSo, MaVe, MaThe, NgayBatDau, NgayKetThuc, TongTien, ThanhToan, TrangThai FROM dbo.vw_DangKyVeThang ORDER BY NgayKetThuc DESC"),
        "LUOTGUIXE" => Query("SELECT MaLuotGui, MaPT, BienSo, LoaiXe, MaVe, MaThe, MaKhuVuc, KhuVuc, ThoiGianVao, ThoiGianRa, TienGui, NhanVienVao, NhanVienRa, TrangThai, LoaiVe FROM dbo.vw_LichSuGuiXe ORDER BY ThoiGianVaoUtc DESC"),
        "THANHTOAN" => Query("SELECT MaThanhToan, LoaiThanhToan, SoTien, ThoiGian, PhuongThuc, TrangThai FROM dbo.vw_ThanhToan ORDER BY ThoiGianUtc DESC"),
        _ => throw new ArgumentOutOfRangeException(nameof(tableName), tableName, "Bảng chưa được khai báo trong KetNoiCSDL.")
    };

    public static SqlParameter Param(string name, object? value) =>
        new(name, value ?? DBNull.Value);

    public string NextCode(string table, string column, string prefix, int width = 3)
    {
        var allowed = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["NHANVIEN.MaNV"] = "dbo.NHANVIEN.MaNV",
            ["TAIKHOAN.MaTK"] = "dbo.TAIKHOAN.MaTK",
            ["CALAM.MaCa"] = "dbo.CALAM.MaCa",
            ["PHANCONGCA.MaPhanCong"] = "dbo.PHANCONGCA.MaPhanCong",
            ["KHACHHANG.MaKH"] = "dbo.KHACHHANG.MaKH",
            ["PHUONGTIEN.MaPT"] = "dbo.PHUONGTIEN.MaPT",
            ["BANGGIA.MaBangGia"] = "dbo.BANGGIA.MaBangGia",
            ["LOAIVE.MaLoaiVe"] = "dbo.LOAIVE.MaLoaiVe",
            ["VE.MaVe"] = "dbo.VE.MaVe"
        };

        if (!allowed.TryGetValue($"{table}.{column}", out var target))
            throw new InvalidOperationException("Không cho phép sinh mã cho bảng/cột này.");

        var parts = target.Split('.');
        var sql = $"SELECT ISNULL(MAX(TRY_CONVERT(int, SUBSTRING({parts[2]}, {prefix.Length + 1}, 20))), 0) + 1 FROM {parts[0]}.{parts[1]}";
        var next = Convert.ToInt32(Scalar(sql));
        return prefix + next.ToString().PadLeft(width, '0');
    }

    public bool IsVehicleInside(string plate) => Convert.ToInt32(Scalar(
        "SELECT COUNT(*) FROM dbo.LUOTGUIXE lg INNER JOIN dbo.PHUONGTIEN pt ON pt.MaPT=lg.MaPT WHERE lg.TrangThai='DANG_GUI' AND pt.BienSo=@BienSo",
        Param("@BienSo", plate.ToUpperInvariant()))) > 0;

    public bool HasValidMonthlyPass(string plate) => Convert.ToInt32(Scalar(
        "SELECT COUNT(*) FROM dbo.DANGKYVETHANG dk INNER JOIN dbo.PHUONGTIEN pt ON pt.MaPT=dk.MaPT WHERE pt.BienSo=@BienSo AND dk.ThanhToan='DA_THANH_TOAN' AND dk.TrangThai<>'HUY' AND dk.NgayBatDau<=CONVERT(date,GETDATE()) AND CONVERT(date,GETDATE())<dk.NgayKetThuc",
        Param("@BienSo", plate.ToUpperInvariant()))) > 0;

    public decimal CurrentPrice(string vehicleType, string ticketType) => Convert.ToDecimal(Scalar(
        "SELECT TOP(1) bg.DonGia FROM dbo.BANGGIA bg INNER JOIN dbo.LOAIVE lv ON lv.MaLoaiVe=bg.MaLoaiVe WHERE bg.LoaiXe=@LoaiXe AND lv.KyHieu=@LoaiVe AND bg.NgayApDung<=CONVERT(date,GETDATE()) ORDER BY bg.NgayApDung DESC",
        Param("@LoaiXe", vehicleType), Param("@LoaiVe", ticketType)) ?? 0m);

    public DataRow? Authenticate(string userName, string password)
    {
        var result = Query(
            "SELECT TOP(1) tk.MaTK, tk.TenDangNhap, tk.MaNV, nv.HoTen, tk.VaiTro " +
            "FROM dbo.TAIKHOAN tk INNER JOIN dbo.NHANVIEN nv ON nv.MaNV=tk.MaNV " +
            "WHERE tk.TenDangNhap=@TenDangNhap AND tk.MatKhauHash=CONVERT(varchar(64), HASHBYTES('SHA2_256', @MatKhau), 2) " +
            "AND tk.TrangThai='HOAT_DONG' AND nv.TrangThai='HOAT_DONG'",
            Param("@TenDangNhap", userName.Trim()), Param("@MatKhau", password));
        if (result.Rows.Count == 0) return null;
        Execute("UPDATE dbo.TAIKHOAN SET LanDangNhapCuoiUtc=SYSUTCDATETIME() WHERE MaTK=@MaTK", Param("@MaTK", result.Rows[0]["MaTK"]));
        return result.Rows[0];
    }

    public DataRow? FindOpenParking(string query)
    {
        var result = Query(
            "SELECT TOP(1) MaLuotGui, BienSo, LoaiXe, MaThe, KhuVuc, ThoiGianVao, ThoiGianRa, TienGui, NhanVienVao, NhanVienRa, TrangThai, LoaiVe " +
            "FROM dbo.vw_LichSuGuiXe WHERE TrangThai='DANG_GUI' AND (BienSo LIKE @Query OR MaThe LIKE @Query) ORDER BY ThoiGianVaoUtc DESC",
            Param("@Query", $"%{query.Trim()}%"));
        return result.Rows.Count == 0 ? null : result.Rows[0];
    }

    public string AddParking(string plate, string vehicleType, string card, string areaName, string employeeName)
    {
        using var connection = OpenConnection();
        using var command = new SqlCommand("dbo.sp_XeVao", connection) { CommandType = CommandType.StoredProcedure };
        command.Parameters.AddRange(new[]
        {
            Param("@BienSo", plate), Param("@LoaiXe", vehicleType), Param("@MaThe", card),
            Param("@MaKhuVuc", RequiredId(connection, "SELECT MaKhuVuc FROM dbo.KHUVUC WHERE TenKhuVuc=@Value", areaName)),
            Param("@MaNVVao", RequiredId(connection, "SELECT MaNV FROM dbo.NHANVIEN WHERE HoTen=@Value", employeeName)),
            Param("@MaKH", null)
        });
        var output = new SqlParameter("@MaLuotGuiMoi", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
        command.Parameters.Add(output);
        command.ExecuteNonQuery();
        return Convert.ToString(output.Value) ?? string.Empty;
    }

    public decimal CompleteParking(DataRow row, string employeeName, string paymentMethod)
    {
        using var connection = OpenConnection();
        using var command = new SqlCommand("dbo.sp_XeRa", connection) { CommandType = CommandType.StoredProcedure };
        command.Parameters.Add(Param("@BienSoHoacMaThe", row["BienSo"]));
        command.Parameters.Add(Param("@MaNVRa", RequiredId(connection, "SELECT MaNV FROM dbo.NHANVIEN WHERE HoTen=@Value", employeeName)));
        command.Parameters.Add(Param("@PhuongThuc", paymentMethod == "KHONG_THU_PHI" ? "TIEN_MAT" : paymentMethod));
        command.Parameters.Add(new SqlParameter("@MaLuotGui", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output });
        var fee = new SqlParameter("@TienGui", SqlDbType.Decimal) { Precision = 18, Scale = 2, Direction = ParameterDirection.Output };
        command.Parameters.Add(fee);
        command.ExecuteNonQuery();
        return Convert.ToDecimal(fee.Value);
    }

    public (string RegistrationId, DateTime EndDate, decimal Total) RegisterMonthlyPass(
        string customerName, string plate, string card, DateTime startDate, int monthCount)
    {
        using var connection = OpenConnection();
        using var command = new SqlCommand("dbo.sp_DangKyVeThang", connection) { CommandType = CommandType.StoredProcedure };
        command.Parameters.Add(Param("@MaKH", RequiredId(connection, "SELECT MaKH FROM dbo.KHACHHANG WHERE HoTen=@Value", customerName)));
        command.Parameters.Add(Param("@MaPT", RequiredId(connection, "SELECT MaPT FROM dbo.PHUONGTIEN WHERE BienSo=@Value", plate)));
        command.Parameters.Add(Param("@MaThe", card));
        command.Parameters.Add(Param("@NgayBatDau", startDate.Date));
        command.Parameters.Add(Param("@SoThang", monthCount));
        var id = new SqlParameter("@MaDangKyMoi", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
        var endDate = new SqlParameter("@NgayKetThuc", SqlDbType.Date) { Direction = ParameterDirection.Output };
        var total = new SqlParameter("@TongTien", SqlDbType.Decimal) { Precision = 18, Scale = 2, Direction = ParameterDirection.Output };
        command.Parameters.AddRange(new[] { id, endDate, total });
        command.ExecuteNonQuery();
        return (Convert.ToString(id.Value) ?? string.Empty, Convert.ToDateTime(endDate.Value), Convert.ToDecimal(total.Value));
    }

    public string PayMonthlyPass(string registrationId, string employeeId, string paymentMethod)
    {
        using var connection = OpenConnection();
        using var command = new SqlCommand("dbo.sp_ThanhToanVeThang", connection) { CommandType = CommandType.StoredProcedure };
        command.Parameters.AddRange(new[]
        {
            Param("@MaDangKy", registrationId), Param("@MaNV", employeeId),
            Param("@PhuongThuc", paymentMethod), Param("@MaThamChieu", null)
        });
        var output = new SqlParameter("@MaThanhToanMoi", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
        command.Parameters.Add(output);
        command.ExecuteNonQuery();
        return Convert.ToString(output.Value) ?? string.Empty;
    }

    private static string RequiredId(SqlConnection connection, string sql, string displayValue)
    {
        using var command = new SqlCommand(sql, connection);
        command.Parameters.Add(Param("@Value", displayValue));
        return Convert.ToString(command.ExecuteScalar())
            ?? throw new InvalidOperationException($"Không tìm thấy dữ liệu: {displayValue}.");
    }
}

public static class PhienDangNhap
{
    public static string EmployeeId { get; private set; } = "NV001";
    public static string EmployeeName { get; private set; } = "Nguyễn Minh Anh";
    public static string Role { get; private set; } = "ADMIN";
    public static string UserName { get; private set; } = "admin";

    public static void SignIn(string employeeId, string employeeName, string role, string userName)
    {
        EmployeeId = employeeId;
        EmployeeName = employeeName;
        Role = role;
        UserName = userName;
    }
}

public static class DinhDang
{
    public static readonly Color Primary = Color.FromArgb(37, 99, 235);
    public static readonly Color PrimaryDark = Color.FromArgb(29, 78, 216);
    public static readonly Color Sidebar = Color.FromArgb(15, 23, 42);
    public static readonly Color Background = Color.FromArgb(248, 250, 252);
    public static readonly Color Card = Color.White;
    public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);
    public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139);
    public static readonly Color Border = Color.FromArgb(226, 232, 240);
    public static readonly Color Success = Color.FromArgb(22, 163, 74);
    public static readonly Color Warning = Color.FromArgb(245, 158, 11);
    public static readonly Color Danger = Color.FromArgb(220, 38, 38);

    public static Font Font(float size = 10F, FontStyle style = FontStyle.Regular) =>
        new("Segoe UI", size, style, GraphicsUnit.Point);

    public static string Money(decimal value) =>
        string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0} ₫", value);

    public static void StyleButton(Button button, Color? color = null)
    {
        button.BackColor = color ?? Primary;
        button.ForeColor = Color.White;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Cursor = Cursors.Hand;
        button.Font = Font(10F, FontStyle.Bold);
        button.Height = Math.Max(button.Height, 38);
    }

    public static void StyleSecondaryButton(Button button)
    {
        button.BackColor = Color.White;
        button.ForeColor = TextPrimary;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderColor = Border;
        button.FlatAppearance.BorderSize = 1;
        button.Cursor = Cursors.Hand;
        button.Font = Font(10F, FontStyle.Bold);
        button.Height = Math.Max(button.Height, 38);
    }

    public static void ConfigureGrid(DataGridView grid)
    {
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AllowUserToResizeRows = false;
        grid.ReadOnly = true;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.BackgroundColor = Card;
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.GridColor = Border;
        grid.RowHeadersVisible = false;
        grid.RowTemplate.Height = 38;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersHeight = 42;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
        grid.ColumnHeadersDefaultCellStyle.Font = Font(10F, FontStyle.Bold);
        grid.DefaultCellStyle.BackColor = Card;
        grid.DefaultCellStyle.ForeColor = TextPrimary;
        grid.DefaultCellStyle.Font = Font(9.5F);
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
        grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
    }

    public static void ConfigurePage(Form form)
    {
        form.BackColor = Background;
        form.Font = Font();
        form.ForeColor = TextPrimary;
        form.FormBorderStyle = FormBorderStyle.None;
        form.TopLevel = false;
        form.Dock = DockStyle.Fill;
    }
}

public static class DuLieuForm
{
    public static void RenameColumns(DataGridView grid, params (string Name, string Header)[] columns)
    {
        foreach (var column in columns)
            if (grid.Columns.Contains(column.Name)) grid.Columns[column.Name]!.HeaderText = column.Header;
    }

    public static void HideColumns(DataGridView grid, params string[] names)
    {
        foreach (var name in names)
            if (grid.Columns.Contains(name)) grid.Columns[name]!.Visible = false;
    }

    public static DataRow? RequireSelection(QuanLyDanhSach page)
    {
        var row = page.SelectedRow;
        if (row is null) MessageBox.Show("Vui lòng chọn một bản ghi trong danh sách.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return row;
    }

    public static bool Confirm(string message) =>
        MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    public static string NextId(DataTable table, string prefix, int width = 3) => $"{prefix}{(table.Rows.Count + 1).ToString().PadLeft(width, '0')}";

    public static bool IsPhone(string value) => value.All(char.IsDigit) && value.Length is >= 9 and <= 11;

    public static void ShowDetails(DataRow row, string title)
    {
        var lines = row.Table.Columns.Cast<DataColumn>().Where(c => c.ColumnName.IndexOf("MatKhau", StringComparison.OrdinalIgnoreCase) < 0)
            .Select(c => $"{c.ColumnName}: {(row.IsNull(c) ? "—" : row[c])}");
        MessageBox.Show(string.Join(Environment.NewLine, lines), title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

public sealed class QuanLyDanhSach
{
    private readonly Label _title;
    private readonly Label _description;
    private readonly Label _filterLabel;
    private readonly Label _secondFilterLabel;
    private readonly Label _fromDateLabel;
    private readonly Label _toDateLabel;
    private DataView? _view;
    private string[] _searchColumns = Array.Empty<string>();

    public Button AddButton { get; }
    public Button EditButton { get; }
    public Button DeleteButton { get; }
    public Button ViewButton { get; }
    public Button RefreshButton { get; }
    public TextBox SearchBox { get; }
    public ComboBox FilterCombo { get; }
    public ComboBox SecondFilterCombo { get; }
    public DateTimePicker FromDatePicker { get; }
    public DateTimePicker ToDatePicker { get; }
    public DataGridView Grid { get; }
    public Label RecordCountLabel { get; }
    public string FilterColumn { get; set; } = string.Empty;
    public string SecondFilterColumn { get; set; } = string.Empty;
    public event EventHandler? FilterChanged;

    public QuanLyDanhSach(
        Label title, Label description, Button addButton, TextBox searchBox,
        Label filterLabel, ComboBox filterCombo, Label secondFilterLabel, ComboBox secondFilterCombo,
        Label fromDateLabel, DateTimePicker fromDatePicker, Label toDateLabel, DateTimePicker toDatePicker,
        Button refreshButton, DataGridView grid, Label recordCountLabel,
        Button viewButton, Button editButton, Button deleteButton)
    {
        _title = title;
        _description = description;
        _filterLabel = filterLabel;
        _secondFilterLabel = secondFilterLabel;
        _fromDateLabel = fromDateLabel;
        _toDateLabel = toDateLabel;
        AddButton = addButton;
        SearchBox = searchBox;
        FilterCombo = filterCombo;
        SecondFilterCombo = secondFilterCombo;
        FromDatePicker = fromDatePicker;
        ToDatePicker = toDatePicker;
        RefreshButton = refreshButton;
        Grid = grid;
        RecordCountLabel = recordCountLabel;
        ViewButton = viewButton;
        EditButton = editButton;
        DeleteButton = deleteButton;

        Grid.AllowUserToAddRows = false;
        Grid.AllowUserToDeleteRows = false;
        Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        Grid.MultiSelect = false;
        Grid.ReadOnly = true;
        Grid.RowHeadersVisible = false;
        Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        SearchBox.TextChanged += FilterControlChanged;
        FilterCombo.SelectedIndexChanged += FilterControlChanged;
        SecondFilterCombo.SelectedIndexChanged += FilterControlChanged;
        FromDatePicker.ValueChanged += FilterControlChanged;
        ToDatePicker.ValueChanged += FilterControlChanged;
        RefreshButton.Click += RefreshButtonClick;
    }

    public void Configure(string title, string description, string addText = "Thêm mới", string searchPlaceholder = "Tìm kiếm...")
    {
        _title.Text = title;
        _description.Text = description;
        AddButton.Text = addText;
        SearchBox.AccessibleDescription = searchPlaceholder;
    }

    public void ConfigureFilter(string label, IEnumerable<string> options, string column)
    {
        _filterLabel.Text = label;
        FilterColumn = column;
        FilterCombo.Items.Clear();
        FilterCombo.Items.Add("Tất cả");
        FilterCombo.Items.AddRange(options.Cast<object>().ToArray());
        FilterCombo.SelectedIndex = 0;
        _filterLabel.Visible = FilterCombo.Visible = true;
    }

    public void ConfigureSecondFilter(string label, IEnumerable<string> options, string column)
    {
        _secondFilterLabel.Text = label;
        SecondFilterColumn = column;
        SecondFilterCombo.Items.Clear();
        SecondFilterCombo.Items.Add("Tất cả");
        SecondFilterCombo.Items.AddRange(options.Cast<object>().ToArray());
        SecondFilterCombo.SelectedIndex = 0;
        _secondFilterLabel.Visible = SecondFilterCombo.Visible = true;
    }

    public void ShowDateRange(bool visible = true)
    {
        _fromDateLabel.Visible = FromDatePicker.Visible = _toDateLabel.Visible = ToDatePicker.Visible = visible;
    }

    public void Bind(DataTable table, params string[] searchColumns)
    {
        _searchColumns = searchColumns;
        _view = new DataView(table);
        Grid.DataSource = _view;
        UpdateCount();
    }

    public void ApplyFilter(string? additionalExpression = null)
    {
        if (_view is null) return;
        var parts = new List<string>();
        var search = EscapeLike(SearchBox.Text.Trim());
        if (!string.IsNullOrWhiteSpace(search) && _searchColumns.Length > 0)
            parts.Add("(" + string.Join(" OR ", _searchColumns.Select(c => $"CONVERT([{c}], 'System.String') LIKE '%{search}%'")) + ")");
        if (!string.IsNullOrWhiteSpace(FilterColumn) && FilterCombo.SelectedIndex > 0)
            parts.Add($"CONVERT([{FilterColumn}], 'System.String') = '{EscapeValue(FilterCombo.Text)}'");
        if (!string.IsNullOrWhiteSpace(SecondFilterColumn) && SecondFilterCombo.SelectedIndex > 0)
            parts.Add($"CONVERT([{SecondFilterColumn}], 'System.String') = '{EscapeValue(SecondFilterCombo.Text)}'");
        if (!string.IsNullOrWhiteSpace(additionalExpression)) parts.Add(additionalExpression!);
        _view.RowFilter = string.Join(" AND ", parts);
        UpdateCount();
    }

    public DataRow? SelectedRow => Grid.CurrentRow?.DataBoundItem is DataRowView view ? view.Row : null;
    public void UpdateCount() => RecordCountLabel.Text = $"Tổng số: {Grid.Rows.Count:N0} bản ghi";

    private void FilterControlChanged(object? sender, EventArgs e)
    {
        ApplyFilter();
        FilterChanged?.Invoke(this, EventArgs.Empty);
    }

    private void RefreshButtonClick(object? sender, EventArgs e)
    {
        SearchBox.Clear();
        if (FilterCombo.Items.Count > 0) FilterCombo.SelectedIndex = 0;
        if (SecondFilterCombo.Items.Count > 0) SecondFilterCombo.SelectedIndex = 0;
        ApplyFilter();
        FilterChanged?.Invoke(this, EventArgs.Empty);
    }

    private static string EscapeLike(string value) => value.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
    private static string EscapeValue(string value) => value.Replace("'", "''");
}

