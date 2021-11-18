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
        public virtual void Draw(System.Drawing.Graphics graphics) {
            graphics.DrawLine(new System.Drawing.Pen(this.color, this.thickness), (int)(this.start.X * Shape.Ratio), (int)(this.start.Y * Shape.Ratio), (int)(this.end.X * Shape.Ratio), (int)(this.end.Y * Shape.Ratio));
        }
        public static void __Draw(System.Drawing.Graphics graphics) {
            foreach(Line line in lines) {
                line.Draw(graphics);
            }
        }
    }
}