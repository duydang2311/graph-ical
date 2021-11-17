using System.Drawing;
using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private void pictureBox_MouseClick(object sender, MouseEventArgs e) {
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y);
			if(shape != null) {
				Shape.Remove(shape);
				this.pictureBox.Refresh();
				return;
			}
			const int size = 70;
			int offsetedX = (int)((e.Location.X - (int)(size * (double)(Shape.Ratio) / 2.0)) / Shape.Ratio);
			int offsetedY = (int)((e.Location.Y - (int)(size * (double)(Shape.Ratio) / 2.0)) / Shape.Ratio);
			new Circle(new Point(offsetedX, offsetedY), size, Color.Black);
			this.pictureBox.Refresh();
		}
    }
}