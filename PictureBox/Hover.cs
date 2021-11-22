using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		object hoveringObject;
		private void Hover(object obj) {
			if(obj == null) {
				CancelHover();
				return;
			}
			if(obj != null) {
				if(this.cursorState == CursorStates.Add) {
					this.Cursor = Cursors.Hand;
				}
				if(hoveringObject != null) {
					if(hoveringObject is Shape) {
						((Shape)hoveringObject).Hovering = false;
					} else if(hoveringObject is Line) {
						((Line)hoveringObject).Highlighted = false;
					}
				}
				if(obj is Shape) {
					((Shape)obj).Hovering = true;
				} else if(obj is Line) {
					((Line)obj).Highlighted = true;
				}
				hoveringObject = obj;
				this.pictureBox.Refresh();
				return;
			}
		}
		private void CancelHover() {
			if(hoveringObject is Shape) {
				((Shape)hoveringObject).Hovering = false;
			} else if(hoveringObject is Line) {
				((Line)hoveringObject).Highlighted = false;
			}
			hoveringObject = null;
			this.pictureBox.Refresh();
			if(this.cursorState == CursorStates.Add) {
				this.Cursor = Cursors.Cross;
			}
		}
		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y, this.ratio);
			if(shape != null) {
				Hover(shape);
			} else {
				Hover(Line.GetCollidedLine(e.Location.X, e.Location.Y, this.ratio));
			}
		}
    }
}