using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y);
			if(shape != null) {
				if(ghostShape != null) {
					ghostShape.Hovering = false;
				}
				shape.Hovering = true;
				ghostShape = shape;
				this.pictureBox.Refresh();
			} else if(ghostShape != null) {
				ghostShape.Hovering = false;
				ghostShape = null;
				this.pictureBox.Refresh();
			}
		}
    }
}