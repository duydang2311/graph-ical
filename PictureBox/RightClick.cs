using System.Drawing;
using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private void PictureBox_RightClick_MouseClick(object sender, MouseEventArgs e) {
			if(e.Button != MouseButtons.Right || this.cursorState != CursorStates.Add || hoveringObject == null) {
				return;
			}
			if(hoveringObject != null) {
				if(hoveringObject is Shape) {
					Shape.Remove((Shape)hoveringObject);
					this.pictureBox.Refresh();
				} else if(hoveringObject is Line) {
					Line line = (Line)hoveringObject;
					line.Start.RemoveAdjacency(line.End);
					line.End.RemoveAdjacency(line.Start);
					Line.Remove(line);
					this.pictureBox.Refresh();
				} else if(hoveringObject is Loop) {
					Loop loop = (Loop)hoveringObject;
					loop.Shape.Loop = null;
					Loop.Remove(loop);
					this.pictureBox.Refresh();
				}
			}
		}
    }
}