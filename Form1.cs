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
		private Shape ghostShape;
		public Form1()
		{
			InitializeComponent();
			this.Resize += new EventHandler(Form1_Resize);
			this.KeyDown += new KeyEventHandler(Form1_KeyDown);
			this.KeyUp += new KeyEventHandler(Form1_KeyUp);
			this.pictureBox.MouseClick += new MouseEventHandler(pictureBox_MouseClick);
			this.pictureBox.MouseWheel += new MouseEventHandler(pictureBox_MouseWheel);
			this.pictureBox.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
			this.pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
		}
		private void Form1_Load(object sender, EventArgs e) {
			this.ratio = 1.0m;
			this.cursorState = CursorStates.Add;
			this.Cursor = Cursors.Cross;
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}
		private void Form1_Resize(object sender, EventArgs e) {
			this.pictureBox.Width = this.Width;
			this.pictureBox.Height = this.Height;
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if(e.Control) {
				this.Cursor = Cursors.Default;
				this.cursorState = CursorStates.Select;
			} else {
				this.Cursor = Cursors.Cross;
				this.cursorState = CursorStates.Add;
			}
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e) {
			if(!e.Control) {
				this.Cursor = Cursors.Cross;
				this.cursorState = CursorStates.Add;
			}
		}
	}
}
