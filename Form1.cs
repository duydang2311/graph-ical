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
		private decimal ratio;
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
			this.cursorState = true;
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
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y);
			if(shape != null) {
				Shape.Remove(shape);
				this.pictureBox.Refresh();
				return;
			}
			const int size = 70;
			int offsetedX = (int)((e.Location.X - (int)(size * (double)(Shape.Ratio) / 2.0)) / Shape.Ratio);
			int offsetedY = (int)((e.Location.Y - (int)(size * (double)(Shape.Ratio) / 2.0)) / Shape.Ratio);
			new Circle(offsetedX, offsetedY, size, Color.Black);
			this.pictureBox.Refresh();
		}
		private void pictureBox_MouseWheel(object sender, MouseEventArgs e) {
			if(e.Delta < 0) {
				Shape.Ratio -= 0.075m;
				this.pictureBox.Refresh();
			} else if(e.Delta > 0) {
				Shape.Ratio += 0.075m;
				this.pictureBox.Refresh();
			}
		}
		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y);
			if(shape != null) {
				if(ghostShape != null) {
					ghostShape.Ghost = false;
				}
				shape.Ghost = true;
				ghostShape = shape;
				this.pictureBox.Refresh();
			} else if(ghostShape != null) {
				ghostShape.Ghost = false;
				ghostShape = null;
				this.pictureBox.Refresh();
			}
		}
		private void pictureBox_Paint(object sender, PaintEventArgs e) {
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			Shape.__Draw(e.Graphics);
			if(ghostShape != null) {
				ghostShape.Draw(e.Graphics);
			}
		}
	}
}
