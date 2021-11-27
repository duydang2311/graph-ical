namespace graphical {
    public partial class Util {
        public static string ClampStringWidth(string source, float width) {
            string res = "";
            float w = 0.0f;
            System.Drawing.Font arial = new System.Drawing.Font("Arial", 20, System.Drawing.GraphicsUnit.Pixel);
            for(int i = 0, size = source.Length; i != size; ++i) {
                if(w >= width) {
                    res += "\n";
                    w = 0.0f;
                }
                res += source[i];
                w += System.Windows.Forms.TextRenderer.MeasureText(source[i].ToString(), arial).Width;
            }
            return res;
        }
    }
}