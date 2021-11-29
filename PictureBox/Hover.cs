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
				if(hoveringObject != null && hoveringObject != obj) {
					if(hoveringObject is Shape) {
						((Shape)hoveringObject).Hovering = false;
					} else if(hoveringObject is Line) {
						((Line)hoveringObject).Highlighted = false;
					} else if(hoveringObject is Loop) {
						((Loop)hoveringObject).Highlight = System.Drawing.Color.Transparent;
					}
				}
				if(obj is Shape) {
					((Shape)obj).Hovering = true;
				} else if(obj is Line) {
					((Line)obj).Highlighted = true;
				} else if(hoveringObject is Loop) {
					((Loop)hoveringObject).Highlight = System.Drawing.Color.Red;
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
			} else if(hoveringObject is Loop) {
				((Loop)hoveringObject).Highlight = System.Drawing.Color.Transparent;
			}
			hoveringObject = null;
			this.pictureBox.Refresh();
			if(this.cursorState == CursorStates.Add) {
				this.Cursor = Cursors.Cross;
			}
		}
		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			object obj = Shape.GetCollidedShape(e.Location.X, e.Location.Y, this.ratio);
			if(obj == null) {
				obj = Line.GetCollidedLine(e.Location.X, e.Location.Y, this.ratio);
				if(obj == null) {
					obj = Loop.GetCollidedLoop(e.Location.X, e.Location.Y, this.ratio);
				}
			}
			Hover(obj);
		}
    }
}