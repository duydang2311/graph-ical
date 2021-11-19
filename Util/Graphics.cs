namespace graphical {
    public partial class Util {
        public static void DrawArrowHead(System.Drawing.Graphics gr, System.Drawing.Pen pen, Point p, float nx, float ny, float length, decimal ratio) {
            float ax = length * (-ny - nx);
            float ay = length * (nx - ny);
            System.Drawing.PointF[] points = {
                new System.Drawing.PointF((p.X + ax) * (float)ratio, (p.Y + ay) * (float)ratio),
                new System.Drawing.PointF(p.X * (float)ratio, p.Y * (float)ratio),
                new System.Drawing.PointF((p.X - ay) * (float)ratio, (p.Y + ax) * (float)ratio)
            };
            gr.DrawLines(pen, points);
        }
    }
}