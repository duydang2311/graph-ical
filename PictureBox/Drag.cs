using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
        private object draggedObject;
        private void PictureBox_Drag_MouseDown(object sender, MouseEventArgs e) {
            if(this.cursorState == CursorStates.Select) {
                Point point = new Point(e.Location.X, e.Location.Y);
                object obj = Shape.GetCollidedShape(e.Location.X, e.Location.Y, this.ratio);
                if(obj == null) {
                    obj = Loop.GetCollidedLoop(e.Location.X, e.Location.Y, this.ratio);
                }
                if(obj != null) {
                    this.draggedObject = obj;
                }
            }
        }
        private void PictureBox_Drag_MouseMove(object sender, MouseEventArgs e) {
            if(this.draggedObject != null) {
                if(this.draggedObject is Shape) {
                    Shape shape = (Shape)this.draggedObject;
                    shape.Anchor.X = this.DivideRatio(e.Location.X - this.MultiplyRatio(shape.OffsetX));
                    shape.Anchor.Y = this.DivideRatio(e.Location.Y - this.MultiplyRatio(shape.OffsetY));
                    this.pictureBox.Refresh();
                } else if(this.draggedObject is Loop) {
                    Loop loop = (Loop)this.draggedObject;
                    float centerX = this.MultiplyRatio(loop.Shape.CenterX);
                    float centerY = this.MultiplyRatio(loop.Shape.CenterY);
                    float ox = 1f;
                    float vx = e.Location.X - centerX;
                    float vy = e.Location.Y - centerY;
                    float cos_angle = (ox * vx) / (float)System.Math.Sqrt(vx * vx + vy * vy);
                    loop.Angle = (float)System.Math.Acos(cos_angle);
                    if(e.Location.Y < centerY) {
                        loop.Angle *= -1;
                    }
                    this.pictureBox.Refresh();
                }
            }
        }
        private void PictureBox_Drag_MouseUp(object sender, MouseEventArgs e) {
            if(this.draggedObject != null) {
                this.draggedObject = null;
                this.pictureBox.Refresh();
            }
        }
    }
}