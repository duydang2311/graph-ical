namespace graphical {
    public partial class Form1 : System.Windows.Forms.Form {
        public void DrawHelpBackground(System.Drawing.Graphics graphics) {
            using(System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(137, 0, 0, 0))) {
                graphics.FillRectangle(brush, -2, this.pictureBox.Height - 30, this.pictureBox.Width + 2, this.pictureBox.Height + 1);
            }
        }
        public void DrawHelpText(System.Drawing.Graphics graphics) {
            using(System.Drawing.Font arial = new System.Drawing.Font("Arial", 15, System.Drawing.GraphicsUnit.Pixel)) {
                if(this.cursorState == CursorStates.Add) {
                    graphics.DrawString("F1─About    CTRL─Enter select state    LMB─Create, adjust vertex, edge, loop    RMB─Delete vertex, edge, loop", arial, System.Drawing.Brushes.White, 10, this.pictureBox.Size.Height - 24);
                } else {
                    graphics.DrawString("F1─About     LMB─Drag vertex, loop", arial, System.Drawing.Brushes.White, 10, this.pictureBox.Size.Height - 24);
                }
            }
        }
        public void DrawHelpMouse(System.Drawing.Graphics graphics) {
            using(System.Drawing.Font arial = new System.Drawing.Font("Arial", 15, System.Drawing.GraphicsUnit.Pixel)) {
                graphics.DrawString("X─" + this.draggingMouseX + "    Y─" + this.draggingMouseY, arial, System.Drawing.Brushes.White, 10, this.pictureBox.Size.Height - 24);
            }
        }
    }
}