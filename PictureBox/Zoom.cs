using System.Windows.Forms;

namespace graphical {
	public partial class Form1 : Form {
		private decimal ratio;
		public decimal Ratio {
			get => this.ratio;
			set { this.ratio = value; }
		}
		private void pictureBox_MouseWheel(object sender, MouseEventArgs e) {
			if(e.Delta < 0) {
				this.ratio -= 0.075m;
				if(this.ratio <= 0.25m) {
					this.ratio = 0.25m;
				}
				this.pictureBox.Refresh();
			} else if(e.Delta > 0) {
				this.ratio += 0.075m;
				if(this.ratio >= 1.75m) {
					this.ratio = 1.75m;
				}
				this.pictureBox.Refresh();
			}
		}
    }
}