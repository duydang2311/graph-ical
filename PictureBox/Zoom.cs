
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
		private void pictureBox_MouseWheel(object sender, MouseEventArgs e) {
			if(e.Delta < 0) {
				Shape.Ratio -= 0.075m;
				this.pictureBox.Refresh();
			} else if(e.Delta > 0) {
				Shape.Ratio += 0.075m;
				this.pictureBox.Refresh();
			}
		}
    }
}