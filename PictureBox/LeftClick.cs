using System.Drawing;
using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
        private Shape firstClickShape;
		private void PictureBox_LeftClick_MouseClick(object sender, MouseEventArgs e) {
			if(e.Button != MouseButtons.Left || this.cursorState != CursorStates.Add || draggedShape != null) {
				return;
			}
			if(hoveringObject != null) {
				if(hoveringObject is Shape) {
					Shape shape = (Shape)hoveringObject;
					if(shape.IsPointCollidedWithText(new Point(e.Location.X, e.Location.Y), this.ratio)) {
						TextBoxForm prompt = TextBoxForm.Prompt(this, this.Location.X + e.Location.X, this.Location.Y + e.Location.Y, shape.Text);
						switch(prompt.Result) {
							case System.Windows.Forms.DialogResult.OK: {
								shape.Text = prompt.InputText;
								this.pictureBox.Refresh();
								break;
							}
						}
						return;
					}
					if(this.firstClickShape == null) {
						this.firstClickShape = shape;
					} else if(shape != this.firstClickShape) {
						this.firstClickShape.AddAdjacency(shape);
						this.firstClickShape = null;
						this.pictureBox.Refresh();
					} else if(shape == this.firstClickShape) {
						new Loop(shape);
					} else {
						this.firstClickShape = null;
					}
				} else if(hoveringObject is Line) {
					Line line = (Line)hoveringObject;
					int side = Line.GetSideOfPoint(line, e.Location.X, e.Location.Y, this.ratio);
					if(side == -1) {
						line.StartArrow = !line.StartArrow;
					} else if(side == 1) {
						line.EndArrow = !line.EndArrow;
					} else {
						return;
					}
					this.pictureBox.Refresh();
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