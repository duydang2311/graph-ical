using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y, this.ratio);
			if(shape != null) {
				if(hoveringShape != null) {
					hoveringShape.Hovering = false;
				}
				shape.Hovering = true;
				hoveringShape = shape;
				this.pictureBox.Refresh();
			} else if(hoveringShape != null) {
				hoveringShape.Hovering = false;
				hoveringShape = null;
				this.pictureBox.Refresh();
			}
		}
    }
}