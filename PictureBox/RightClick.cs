using System.Drawing;
using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private void PictureBox_RightClick_MouseClick(object sender, MouseEventArgs e) {
			if(e.Button != MouseButtons.Right || this.cursorState != CursorStates.Add) {
				return;
			}
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y, this.ratio);
			if(shape != null) {
                Shape.Remove(shape);
                this.pictureBox.Refresh();
			}
		}
    }
}