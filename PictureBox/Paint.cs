using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private void pictureBox_Paint(object sender, PaintEventArgs e) {
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			e.Graphics.Clear(System.Drawing.Color.White);
			Shape.__Draw(e.Graphics, this.ratio);
			if(hoveringObject != null) {
				if(hoveringObject is Shape) {
					((Shape)hoveringObject).Draw(e.Graphics, this.ratio);
				} else {
					((Line)hoveringObject).Draw(e.Graphics, this.ratio);
				}
			}
		}
    }
}