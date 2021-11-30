using System.Drawing;
using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
        private Shape firstClickShape;
		private int increment = 0;
		private void PictureBox_LeftClick_MouseClick(object sender, MouseEventArgs e) {
			if(e.Button != MouseButtons.Left || this.cursorState != CursorStates.Add || this.draggedObject != null) {
				return;
			}
			if(hoveringObject != null) {
				if(hoveringObject is Shape) {
					Shape shape = (Shape)hoveringObject;
					if(this.firstClickShape == null) {
						this.firstClickShape = shape;
					} else if(shape != this.firstClickShape) {
						this.firstClickShape.AddAdjacency(shape);
						this.firstClickShape = null;
						this.pictureBox.Refresh();
					} else if(shape == this.firstClickShape) {
						if(shape.IsPointCollidedWithText(new Point(e.Location.X, e.Location.Y), this.ratio)) {
							TextBoxForm prompt = TextBoxForm.Prompt(this, this.Location.X + (int)((shape.CenterX + shape.OffsetX) * this.ratio), this.Location.Y + (int)(shape.CenterY * this.ratio), shape.Text);
							switch(prompt.Result) {
								case System.Windows.Forms.DialogResult.OK: {
									shape.Text = prompt.InputText;
									this.pictureBox.Refresh();
									break;
								}
							}
						} else {
							if(shape.Loop == null) {
								shape.Loop = new Loop(shape);
							}
						}
						this.firstClickShape = null;
					} else {
						this.firstClickShape = null;
					}
				} else if(hoveringObject is Line) {
					Line line = (Line)hoveringObject;
					int side = Line.GetSideOfPoint(line, e.Location.X, e.Location.Y, this.ratio);
					switch(side) {
						case -1: {
							line.StartArrow = !line.StartArrow;
							break;
						}
						case 0: {
							using(TextBoxForm prompt = TextBoxForm.Prompt(this, this.Location.X + e.Location.X, this.Location.Y + e.Location.Y, line.Text)) {
								switch(prompt.Result) {
									case DialogResult.OK: {
										line.Text = prompt.InputText;
										break;
									}
								}
							}
							break;
						}
						case 1: {
							line.EndArrow = !line.EndArrow;
							break;
						}
					}
					this.pictureBox.Refresh();
				} else if(hoveringObject is Loop) {
					Loop loop = (Loop)hoveringObject;
					using(TextBoxForm prompt = TextBoxForm.Prompt(this, this.Location.X + e.Location.X, this.Location.Y + e.Location.Y, loop.Text)) {
						switch(prompt.Result) {
							case DialogResult.OK: {
								loop.Text = prompt.InputText;
								this.pictureBox.Refresh();
								break;
							}
						}
					}
				}
				return;
			}
			const int size = 35;
			int offsetedX = (int)((e.Location.X - (int)(size * (double)(this.ratio) / 2.0)) / this.ratio);
			int offsetedY = (int)((e.Location.Y - (int)(size * (double)(this.ratio) / 2.0)) / this.ratio);
			new Circle(new Point(offsetedX, offsetedY), size, Color.Black).Text = (++this.increment).ToString();
			this.pictureBox.Refresh();
		}
    }
}