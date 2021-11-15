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
		private bool cursorState;
		public Form1()
		{
			InitializeComponent();
			this.Resize += new EventHandler(Form1_Resize);
			this.KeyDown += new KeyEventHandler(Form1_KeyDown);
			this.KeyUp += new KeyEventHandler(Form1_KeyUp);
			this.pictureBox.MouseClick += new MouseEventHandler(pictureBox_MouseClick);
		}
		private void Form1_Load(object sender, EventArgs e) {
			this.cursorState = true;
			this.Cursor = Cursors.Cross;
		}
		private void Form1_Resize(object sender, EventArgs e) {
			this.pictureBox.Width = this.Width;
			this.pictureBox.Height = this.Height;
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if(e.Control) {
				this.Cursor = Cursors.Default;
				this.cursorState = false;
			} else {
				this.Cursor = Cursors.Cross;
				this.cursorState = true;
			}
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e) {
			if(!e.Control) {
				this.Cursor = Cursors.Cross;
				this.cursorState = true;
			}
		}
		private void pictureBox_MouseClick(object sender, MouseEventArgs e) {
			MessageBox.Show("cursorState: " + cursorState + Environment.NewLine + e.Location.ToString());
		}
	}
}
