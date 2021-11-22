namespace graphical {
    class Line {
        protected Shape start;
        protected Shape end;
        protected float thickness;
        protected System.Drawing.Color color;
        protected static System.Collections.Generic.List<Line> lines = new System.Collections.Generic.List<Line>();
        public Shape Start {
            get => this.start;
            set { this.start = value; }
        }
        public Shape End {
            get => this.end;
            set { this.end = value; }
        }
        public Line(System.Drawing.Color color, float thickness, Shape start, Shape end) {
            this.color = color;
            this.thickness = thickness;
            this.start = start;
            this.end = end; 
            lines.Add(this);
        }
        public virtual void Draw(System.Drawing.Graphics graphics, decimal ratio) {
            System.Drawing.Pen p = new System.Drawing.Pen(this.color, this.thickness * (float)ratio);
            Util.Normalize(this.start.Anchor.X, this.start.Anchor.Y, this.end.Anchor.X, this.end.Anchor.Y, out float vx, out float vy);
            Point start = new Point((int)((this.start.Anchor.X + this.start.OffsetX) + vx * this.start.OffsetX), (int)((this.start.Anchor.Y + this.start.OffsetY) + vy * this.start.OffsetY));
            Point end = new Point((int)((this.end.Anchor.X + this.end.OffsetX) - vx * this.end.OffsetX), (int)((this.end.Anchor.Y + this.end.OffsetY) - vy * this.end.OffsetY));
            graphics.DrawLine(p, (int)(start.X * ratio), (int)(start.Y * ratio), (int)(end.X * ratio), (int)(end.Y * ratio));
            Util.DrawArrowHead(graphics, p, end, vx, vy, 7, ratio);
        }
        public static void __Draw(System.Drawing.Graphics graphics, decimal ratio) {
            foreach(Line line in lines) {
                line.Draw(graphics, ratio);
            }
        }
        public static void Clear() {
            Line.lines.Clear();
        }
    }
}