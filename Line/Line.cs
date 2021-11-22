namespace graphical {
    class Line {
        protected Shape start;
        protected Shape end;
        protected float thickness;
        protected System.Drawing.Color color;
        protected static System.Collections.Generic.List<Line> lines = new System.Collections.Generic.List<Line>();
        protected bool highlighted;
        protected bool startArrow;
        protected bool endArrow;
        public Shape Start {
            get => this.start;
            set { this.start = value; }
        }
        public Shape End {
            get => this.end;
            set { this.end = value; }
        }
        public bool Highlighted {
            get => this.highlighted;
            set { this.highlighted = value; }
        }
        public bool StartArrow {
            get => this.startArrow;
            set { this.startArrow = value; }
        }
        public bool EndArrow {
            get => this.endArrow;
            set { this.endArrow = value; }
        }
        public Line(System.Drawing.Color color, float thickness, Shape start, Shape end) {
            this.color = color;
            this.thickness = thickness;
            this.start = start;
            this.end = end; 
            this.highlighted = false;
            this.startArrow = false;
            this.endArrow = false;
            lines.Add(this);
        }
        public virtual void Draw(System.Drawing.Graphics graphics, decimal ratio) {
            System.Drawing.Pen p = new System.Drawing.Pen(this.color, this.thickness * (float)ratio);
            if(highlighted) {
                p.Color = System.Drawing.Color.Red;
            }
            Util.Normalize(this.start.Anchor.X, this.start.Anchor.Y, this.end.Anchor.X, this.end.Anchor.Y, out float vx, out float vy);
            Point start = new Point((int)((this.start.Anchor.X + this.start.OffsetX) + vx * this.start.OffsetX), (int)((this.start.Anchor.Y + this.start.OffsetY) + vy * this.start.OffsetY));
            Point end = new Point((int)((this.end.Anchor.X + this.end.OffsetX) - vx * this.end.OffsetX), (int)((this.end.Anchor.Y + this.end.OffsetY) - vy * this.end.OffsetY));
            graphics.DrawLine(p, (int)(start.X * ratio), (int)(start.Y * ratio), (int)(end.X * ratio), (int)(end.Y * ratio));
            if(this.endArrow) {
                Util.DrawArrowHead(graphics, p, end, vx, vy, 7, ratio);
            }
            if(this.startArrow) {
                Util.DrawArrowHead(graphics, p, start, -vx, -vy, 7, ratio);
            }
        }
        public static void __Draw(System.Drawing.Graphics graphics, decimal ratio) {
            foreach(Line line in lines) {
                line.Draw(graphics, ratio);
            }
        }
        public static void Clear() {
            Line.lines.Clear();
        }
        public static void Remove(Line line) {
            int index = Line.lines.IndexOf(line);
            if(index == -1) return;
            Line.lines.RemoveAt(index);
        }
        public static Line GetCollidedLine(int x, int y, decimal ratio) {
            float startDist;
            float endDist;
            float tempX;
            float tempY;
            foreach(Line line in Line.lines) {
                tempX = x - line.start.Anchor.X * (float)ratio - line.start.OffsetX * (float)ratio;
                tempY = y - line.start.Anchor.Y * (float)ratio - line.start.OffsetY * (float)ratio;
                startDist = (float)System.Math.Sqrt(tempX * tempX + tempY * tempY);
                tempX = x - line.end.Anchor.X * (float)ratio - line.end.OffsetX * (float)ratio;
                tempY = y - line.end.Anchor.Y * (float)ratio - line.end.OffsetY * (float)ratio;
                endDist = (float)System.Math.Sqrt(tempX * tempX + tempY * tempY);
                tempX = line.start.Anchor.X * (float)ratio - line.end.Anchor.X * (float)ratio;
                tempY = line.start.Anchor.Y * (float)ratio - line.end.Anchor.Y * (float)ratio;
                if((int)(startDist + endDist - (float)System.Math.Sqrt(tempX * tempX + tempY * tempY)) == 0) {
                    return line;
                }
            }
            return null;
        }
        public static int GetSideOfPoint(Line line, int x, int y, decimal ratio) {
            float startDist;
            float percentage;
            float tempX;
            float tempY;
            tempX = x - line.start.Anchor.X * (float)ratio - line.start.OffsetX * (float)ratio;
            tempY = y - line.start.Anchor.Y * (float)ratio - line.start.OffsetY * (float)ratio;
            startDist = (float)System.Math.Sqrt(tempX * tempX + tempY * tempY) - line.start.OffsetX * (float)ratio;
            tempX = line.start.Anchor.X * (float)ratio - line.end.Anchor.X * (float)ratio;
            tempY = line.start.Anchor.Y * (float)ratio - line.end.Anchor.Y * (float)ratio;
            percentage = startDist / ((float)System.Math.Sqrt(tempX * tempX + tempY * tempY) - line.start.OffsetX * (float)ratio - line.end.OffsetX * (float)ratio);
            if(percentage >= 0.80) {
                return 1;
            } else if(percentage <= 0.20) {
                return -1;
            }
            return 0;
        }
    }
}