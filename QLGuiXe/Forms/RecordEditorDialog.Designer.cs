#nullable disable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLGuiXe.Forms;

partial class RecordEditorDialog
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader = null!;
    private Label lblTitle = null!;
    private FlowLayoutPanel pnlFields = null!;
    private Panel pnlFooter = null!;
    private FlowLayoutPanel pnlFooterActions = null!;
    private Button btnSave = null!;
    private Button btnCancel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlHeader = new Panel();
        lblTitle = new Label();
        pnlFields = new FlowLayoutPanel();
        pnlFooter = new Panel();
        pnlFooterActions = new FlowLayoutPanel();
        btnSave = new Button();
        btnCancel = new Button();
        pnlHeader.SuspendLayout();
        pnlFooter.SuspendLayout();
        SuspendLayout();
        // pnlHeader
        pnlHeader.BackColor = Color.FromArgb(37, 99, 235);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Height = 70;
        pnlHeader.Padding = new Padding(24, 0, 24, 0);
        // lblTitle
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Text = "Cập nhật thông tin";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // pnlFields
        pnlFields.AutoScroll = true;
        pnlFields.BackColor = Color.White;
        pnlFields.Dock = DockStyle.Fill;
        pnlFields.FlowDirection = FlowDirection.TopDown;
        pnlFields.Padding = new Padding(28, 20, 28, 20);
        pnlFields.WrapContents = false;
        // pnlFooter
        pnlFooter.BackColor = Color.FromArgb(248, 250, 252);
        pnlFooter.Controls.Add(pnlFooterActions);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Height = 72;
        // pnlFooterActions
        pnlFooterActions.Controls.Add(btnSave);
        pnlFooterActions.Controls.Add(btnCancel);
        pnlFooterActions.Dock = DockStyle.Right;
        pnlFooterActions.FlowDirection = FlowDirection.RightToLeft;
        pnlFooterActions.Padding = new Padding(0, 16, 20, 8);
        pnlFooterActions.Size = new Size(300, 72);
        // btnSave
        btnSave.Margin = new Padding(8, 0, 0, 0);
        btnSave.Size = new Size(118, 40);
        btnSave.Text = "Lưu thay đổi";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // btnCancel
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Margin = new Padding(8, 0, 0, 0);
        btnCancel.Size = new Size(112, 40);
        btnCancel.Text = "Hủy";
        btnCancel.UseVisualStyleBackColor = false;
        // RecordEditorDialog
        AcceptButton = btnSave;
        pnlHeader.Name = "pnlHeader"; lblTitle.Name = "lblTitle"; pnlFields.Name = "pnlFields"; pnlFooter.Name = "pnlFooter"; pnlFooterActions.Name = "pnlFooterActions"; btnSave.Name = "btnSave"; btnCancel.Name = "btnCancel";
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(460, 520);
        Controls.Add(pnlFields);
        Controls.Add(pnlFooter);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "RecordEditorDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Cập nhật thông tin";
        pnlHeader.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    private void AddField(EditorField field)
    {
        var label = new Label
        {
            Name = $"lbl{field.Key}",
            Text = field.Required ? $"{field.Label} *" : field.Label,
            AutoSize = true,
            Font = DinhDang.Font(9.5F, FontStyle.Bold),
            ForeColor = DinhDang.TextPrimary,
            Margin = new Padding(0, 7, 0, 6)
        };

        Control editor;
        if (field.Options is { Count: > 0 })
        {
            var combo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 390,
                Height = 36
            };
            combo.Items.AddRange(field.Options.Cast<object>().ToArray());
            if (!string.IsNullOrWhiteSpace(field.Value) && combo.Items.Contains(field.Value))
                combo.SelectedItem = field.Value;
            else if (combo.Items.Count > 0)
                combo.SelectedIndex = 0;
            editor = combo;
        }
        else if (field.Kind == EditorKind.Date)
        {
            editor = new DateTimePicker
            {
                Width = 390,
                Height = 36,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = DateTime.TryParse(field.Value, out var date) ? date : DateTime.Today
            };
        }
        else if (field.Kind == EditorKind.Time)
        {
            editor = new DateTimePicker
            {
                Width = 390,
                Height = 36,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                ShowUpDown = true,
                Value = DateTime.TryParse(field.Value, out var time) ? time : DateTime.Today
            };
        }
        else
        {
            editor = new TextBox
            {
                Text = field.Value ?? string.Empty,
                Width = 390,
                Height = 36,
                UseSystemPasswordChar = field.Kind == EditorKind.Password
            };
        }

        editor.Name = editor switch
        {
            ComboBox => $"cbo{field.Key}",
            DateTimePicker => $"dtp{field.Key}",
            _ => $"txt{field.Key}"
        };
        editor.Tag = field;
        editor.Margin = new Padding(0, 0, 0, 8);
        pnlFields.Controls.Add(label);
        pnlFields.Controls.Add(editor);
        _editors[field.Key] = editor;
    }
}


