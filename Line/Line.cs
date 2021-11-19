namespace graphical {
    class Line {
        protected Point start;
        protected Point end;
        protected float thickness;
        protected System.Drawing.Color color;
        protected static System.Collections.Generic.List<Line> lines = new System.Collections.Generic.List<Line>();
        public Point Start {
            get => this.start;
            set { this.start = value; }
        }
        public Point End {
            get => this.end;
            set { this.end = value; }
        }
        public Line(System.Drawing.Color color, float thickness, Point start, Point end) {
            this.color = color;
            this.thickness = thickness;
            this.start = start;
            this.end = end; 
            // lines.Add(this);
        }
        public virtual void Draw(System.Drawing.Graphics graphics, decimal ratio) {
            System.Drawing.Pen p = new System.Drawing.Pen(this.color, this.thickness * (float)ratio);
            Util.Normalize(this.start, this.end, out float vx, out float vy);
            graphics.DrawLine(p, (int)(this.start.X * ratio), (int)(this.start.Y * ratio), (int)(this.end.X * ratio), (int)(this.end.Y * ratio));
            Util.DrawArrowHead(graphics, p, this.end, vx, vy, 7, ratio);
        }
        public static void __Draw(System.Drawing.Graphics graphics, decimal ratio) {
            foreach(Line line in lines) {
                line.Draw(graphics, ratio);
            }
        }
    }
}