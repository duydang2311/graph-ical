
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			Shape shape = Shape.GetCollidedShape(e.Location.X, e.Location.Y);
			if(shape != null) {
				if(ghostShape != null) {
					ghostShape.Ghost = false;
				}
				shape.Ghost = true;
				ghostShape = shape;
				this.pictureBox.Refresh();
			} else if(ghostShape != null) {
				ghostShape.Ghost = false;
				ghostShape = null;
				this.pictureBox.Refresh();
			}
		}
    }
}