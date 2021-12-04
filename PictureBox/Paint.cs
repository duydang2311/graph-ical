using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private void pictureBox_Paint(object sender, PaintEventArgs e) {
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			e.Graphics.Clear(System.Drawing.Color.White);
            Loop.__Draw(e.Graphics, this.ratio, this.pictureBox.Width, this.pictureBox.Height);
			Shape.__Draw(e.Graphics, this.ratio, this.pictureBox.Width, this.pictureBox.Height);
            Line.__Draw(e.Graphics, this.ratio, this.pictureBox.Width, this.pictureBox.Height);
			if(this.draggedObject != null) {
				this.DrawHelpBackground(e.Graphics);
				this.DrawHelpMouse(e.Graphics);
			}
		}
    }
}