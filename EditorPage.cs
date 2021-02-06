using System;
using System.Windows.Forms;

namespace PBDesk
{
    class EditorPage : TabPage
    {
        private RichTextBox editor_field;

        public EditorPage(in String title, Boolean editable = false, in String tag = "", in String text = "")
        {
            this.editor_field = new RichTextBox();
            this.editor_field.Tag = "EditorPageField";
            this.editor_field.Dock = DockStyle.Fill;
            this.editor_field.ReadOnly = !editable;
            this.Controls.Add(this.editor_field);
            this.Text = title;
            this.Tag = tag;
            this.ContainedText = text;
        }

        public String ContainedText { get => this.editor_field.Text; set => this.editor_field.Text = value; }

        public Boolean Editable { get => !this.editor_field.ReadOnly; set => this.editor_field.ReadOnly = !value;  }
    }
}
