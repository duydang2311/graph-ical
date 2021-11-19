namespace graphical {
    public partial class Util {
        public static void Normalize(Point a, Point b, out float x, out float y) {
            x = b.X - a.X;
            y = b.Y - a.Y;
            float dist = (float)System.Math.Sqrt(x * x + y * y);
            x /= dist;
            y /= dist;
        }
    }
}