using System.Windows.Forms;

namespace graphical {
    public partial class Form1 : Form {
        public int MultiplyRatio(int number) {
            return (int)(number * this.ratio);
        }
        public int DivideRatio(int number) {
            return (int)(number / this.ratio);
        }
    }
}
