using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphical
{
	public partial class TextBoxForm : Form
	{
		private DialogResult result;
		public static TextBoxForm Prompt(Form owner, int startX, int startY, string inputText = "") {
			TextBoxForm form = new TextBoxForm();
			form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			form.Location = new System.Drawing.Point(startX, startY);
			form.InputText = inputText;
			form.result = form.ShowDialog(owner);
			return form;
		}
		public TextBoxForm() {
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler(TextBoxForm_Closing);
			this.buttonOK.Click += new EventHandler(buttonOK_Click);
		}
		private void TextBoxForm_Closing(object sender, FormClosingEventArgs e) {
		}
		private void buttonOK_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}
		public DialogResult Result {
			get => this.result;
			set { this.result = value; }
		}
		public string InputText {
			get => this.textBoxInput.Text;
			set { this.textBoxInput.Text = value; }
		}
	}
}
