using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
        private Shape draggedShape;
        private Shape ghostShape;
        private void PictureBox_Drag_MouseDown(object sender, MouseEventArgs e) {
            if(this.cursorState == CursorStates.Select) {
                Shape shape = Shape.GetCollidedShape(new Point(e.Location.X, e.Location.Y), this.ratio);
                if(shape != null) {
                    draggedShape = shape;
                }
            }
        }
        private void PictureBox_Drag_MouseMove(object sender, MouseEventArgs e) {
            if(draggedShape != null) {
                if(this.cursorState != CursorStates.Select) {
                    ghostShape = null;
                    return;
                }
                if(ghostShape == null) {
                    int offsetedX = this.DivideRatio(e.Location.X - this.MultiplyRatio(draggedShape.OffsetX));
                    int offsetedY = this.DivideRatio(e.Location.Y - this.MultiplyRatio(draggedShape.OffsetY));
                    ghostShape = new Circle(new Point(offsetedX, offsetedY), ((Circle)draggedShape).Radius, System.Drawing.Color.Black);
                }
                ghostShape.Anchor.X = this.DivideRatio(e.Location.X - this.MultiplyRatio(ghostShape.OffsetX));
                ghostShape.Anchor.Y = this.DivideRatio(e.Location.Y - this.MultiplyRatio(ghostShape.OffsetY));
                this.pictureBox.Refresh();
            }
        }
        private void PictureBox_Drag_MouseUp(object sender, MouseEventArgs e) {
            if(draggedShape != null) {
                Shape.Remove(ghostShape);
                Shape shape = Shape.GetCollidedShape(new Point(e.Location.X, e.Location.Y), this.ratio);
                if(shape != null && shape != draggedShape) {
                    draggedShape.addAdjacency(shape);
                } else {
                    draggedShape.Anchor.X = this.DivideRatio(e.Location.X - this.MultiplyRatio(draggedShape.OffsetX));
                    draggedShape.Anchor.Y = this.DivideRatio(e.Location.Y - this.MultiplyRatio(draggedShape.OffsetY));
                }
                draggedShape = null;
                ghostShape = null;
                this.pictureBox.Refresh();
            }
        }
    }
}