using System.Drawing;
using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
        private Shape firstClickShape;
		private void PictureBox_LeftClick_MouseClick(object sender, MouseEventArgs e) {
			if(e.Button != MouseButtons.Left || this.cursorState != CursorStates.Add || draggedShape != null) {
				return;
			}
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y, this.ratio);
			if(shape != null) {
                if(this.firstClickShape == null) {
                    this.firstClickShape = shape;
                } else if(shape != this.firstClickShape) {
                    this.firstClickShape.addAdjacency(shape);
					this.firstClickShape = null;
                    this.pictureBox.Refresh();
                } else {
					this.firstClickShape = null;
				}
				return;
			}
			const int size = 70;
			int offsetedX = (int)((e.Location.X - (int)(size * (double)(this.ratio) / 2.0)) / this.ratio);
			int offsetedY = (int)((e.Location.Y - (int)(size * (double)(this.ratio) / 2.0)) / this.ratio);
			new Circle(new Point(offsetedX, offsetedY), size, Color.Black);
			this.pictureBox.Refresh();
		}
    }
}