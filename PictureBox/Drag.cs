using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
        private Shape draggedShape;
        private void PictureBox_Drag_MouseDown(object sender, MouseEventArgs e) {
            if(this.cursorState == CursorStates.Select) {
                Shape shape = Shape.GetCollidedShape(new Point(e.Location.X, e.Location.Y), this.ratio);
                if(shape != null) {
                    this.draggedShape = shape;
                }
            }
        }
        private void PictureBox_Drag_MouseMove(object sender, MouseEventArgs e) {
            if(this.draggedShape != null) {
                this.draggedShape.Anchor.X = this.DivideRatio(e.Location.X - this.MultiplyRatio(this.draggedShape.OffsetX));
                this.draggedShape.Anchor.Y = this.DivideRatio(e.Location.Y - this.MultiplyRatio(this.draggedShape.OffsetY));
                this.pictureBox.Refresh();
            }
        }
        private void PictureBox_Drag_MouseUp(object sender, MouseEventArgs e) {
            if(this.draggedShape != null) {
                this.draggedShape = null;
                this.pictureBox.Refresh();
            }
        }
    }
}