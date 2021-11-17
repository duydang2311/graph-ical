namespace graphical {
    abstract class Line {
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
            lines.Add(this);
        }
        public virtual void Draw(System.Drawing.Graphics graphics) {
            graphics.DrawLine(new System.Drawing.Pen(this.color, this.thickness), this.start.X, this.start.Y, this.end.X, this.end.Y);
        }
        public static void __Draw(System.Drawing.Graphics graphics) {
            foreach(Line line in lines) {
                line.Draw(graphics);
            }
        }
    }
}