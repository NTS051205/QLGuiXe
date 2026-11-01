using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

public partial class RecordEditorDialog : Form
{
    private readonly Dictionary<string, Control> _editors = new(StringComparer.OrdinalIgnoreCase);

    public IReadOnlyDictionary<string, string> Values => _editors.ToDictionary(x => x.Key, x => GetValue(x.Value));

    public RecordEditorDialog(string title, IEnumerable<EditorField> fields)
    {
        InitializeComponent();
        lblTitle.Text = title;
        Text = title;
        foreach (var field in fields) AddField(field);
    }

    private static string GetValue(Control control) => control switch
    {
        ComboBox combo => combo.SelectedItem?.ToString() ?? string.Empty,
        DateTimePicker picker when ((EditorField)picker.Tag!).Kind == EditorKind.Date => picker.Value.ToString("yyyy-MM-dd"),
        DateTimePicker picker => picker.Value.ToString("HH:mm"),
        _ => control.Text.Trim()
    };

    private void btnSave_Click(object? sender, EventArgs e)
    {
        foreach (var pair in _editors)
        {
            var field = (EditorField)pair.Value.Tag!;
            if (field.Required && string.IsNullOrWhiteSpace(GetValue(pair.Value)))
            {
                MessageBox.Show($"Vui lòng nhập {field.Label.ToLowerInvariant()}.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pair.Value.Focus();
                return;
            }
        }
        DialogResult = DialogResult.OK;
        Close();
    }
}

public enum EditorKind { Text, Password, Date, Time }

public sealed class EditorField
{
    public string Key { get; }
    public string Label { get; }
    public string? Value { get; }
    public bool Required { get; }
    public IReadOnlyList<string>? Options { get; }
    public EditorKind Kind { get; }
    public string? Placeholder { get; }

    public EditorField(string Key, string Label, string? Value = null, bool Required = true,
        IReadOnlyList<string>? Options = null, EditorKind Kind = EditorKind.Text, string? Placeholder = null)
    {
        this.Key = Key;
        this.Label = Label;
        this.Value = Value;
        this.Required = Required;
        this.Options = Options;
        this.Kind = Kind;
        this.Placeholder = Placeholder;
    }
}
