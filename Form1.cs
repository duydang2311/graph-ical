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
	public partial class Form1 : Form
	{
		private CursorStates cursorState;
		public Form1()
		{
			InitializeComponent();
			this.Resize += new EventHandler(Form1_Resize);
			this.KeyDown += new KeyEventHandler(Form1_KeyDown);
			this.KeyUp += new KeyEventHandler(Form1_KeyUp);
			this.pictureBox.MouseClick += new MouseEventHandler(PictureBox_LeftClick_MouseClick);
			this.pictureBox.MouseClick += new MouseEventHandler(PictureBox_RightClick_MouseClick);
			this.pictureBox.MouseWheel += new MouseEventHandler(pictureBox_MouseWheel);
			this.pictureBox.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
			this.pictureBox.MouseDown += new MouseEventHandler(PictureBox_Drag_MouseDown);
			this.pictureBox.MouseMove += new MouseEventHandler(PictureBox_Drag_MouseMove);
			this.pictureBox.MouseUp += new MouseEventHandler(PictureBox_Drag_MouseUp);
			this.pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
		}
		private void Form1_Load(object sender, EventArgs e) {
			this.ratio = 1.0m;
			this.cursorState = CursorStates.Add;
			this.Cursor = Cursors.Cross;
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

			Form_About form = new Form_About();
			form.StartPosition = FormStartPosition.CenterParent;
			form.ShowDialog(this);
		}
		private void Form1_Resize(object sender, EventArgs e) {
			this.pictureBox.Width = this.Width - 16;
			this.pictureBox.Height = this.Height - 39;
			this.pictureBox.Refresh();
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if(e.Control) {
				this.Cursor = Cursors.Default;
				this.cursorState = CursorStates.Select;
				this.UpdateHelpText();
			} else {
				if(this.hoveringObject != null) {
					this.Cursor = Cursors.Hand;
				} else {
					this.Cursor = Cursors.Cross;
				}
				this.cursorState = CursorStates.Add;
				this.UpdateHelpText();
			}
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.F1) {
				Form_About form = new Form_About();
				form.StartPosition = FormStartPosition.CenterParent;
				form.ShowDialog(this);
				return;
			}
			if(!e.Control) {
				if(this.hoveringObject != null) {
					this.Cursor = Cursors.Hand;
				} else {
					this.Cursor = Cursors.Cross;
				}
				this.cursorState = CursorStates.Add;
				this.UpdateHelpText();
			}
		}
	}
}
