namespace graphical {
    class Line {
        protected Shape start;
        protected Shape end;
        static protected float thickness = 2.0f;
        protected System.Drawing.Color color;
        protected static System.Collections.Generic.List<Line> lines = new System.Collections.Generic.List<Line>();
        protected bool highlighted;
        protected bool startArrow;
        protected bool endArrow;
        protected string text;
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
        public static float Thickness {
            get => Line.thickness;
            set { Line.thickness = value; }
        }
        public string Text {
            get => this.text;
            set { this.text = value; }
        }
        public Line(System.Drawing.Color color, Shape start, Shape end) {
            this.color = color;
            this.start = start;
            this.end = end; 
            this.highlighted = false;
            this.startArrow = false;
            this.endArrow = false;
            this.text = "";
            lines.Add(this);
        }
        public virtual void Draw(System.Drawing.Graphics graphics, decimal ratio) {
            Util.Normalize(this.start.Anchor.X, this.start.Anchor.Y, this.end.Anchor.X, this.end.Anchor.Y, out float vx, out float vy);
            Point start = new Point((int)(this.start.CenterX + vx * this.start.OffsetX), (int)(this.start.CenterY + vy * this.start.OffsetY));
            Point end = new Point((int)(this.end.CenterX - vx * this.end.OffsetX), (int)(this.end.CenterY - vy * this.end.OffsetY));
            using(System.Drawing.Pen p = new System.Drawing.Pen(this.color, Line.thickness * (float)ratio)) {
                if(highlighted) {
                    p.Color = System.Drawing.Color.Red;
                }
                graphics.DrawLine(p, (int)(start.X * ratio), (int)(start.Y * ratio), (int)(end.X * ratio), (int)(end.Y * ratio));
                using(System.Drawing.Font arial = new System.Drawing.Font("Arial", 20 * (float)ratio, System.Drawing.GraphicsUnit.Pixel)) {
                    using(System.Drawing.StringFormat sf = new System.Drawing.StringFormat()) {
                        System.Drawing.Size measure = System.Windows.Forms.TextRenderer.MeasureText(this.text, arial);
                        float centerX = ((start.X + end.X) / 2 + vy * measure.Width / 2 / (float)ratio) * (float)ratio;
                        float centerY = ((start.Y + end.Y) / 2 - vx * measure.Height / (float)ratio) * (float)ratio;
                        sf.Alignment = System.Drawing.StringAlignment.Center;
                        sf.LineAlignment = System.Drawing.StringAlignment.Center;
                        graphics.DrawString(this.text, arial, System.Drawing.Brushes.Black, centerX, centerY, sf);
                    }
                }
                if(this.endArrow) {
                    Util.DrawArrowHead(graphics, p, end, vx, vy, 7, ratio);
                }
                if(this.startArrow) {
                    Util.DrawArrowHead(graphics, p, start, -vx, -vy, 7, ratio);
                }
            }
        }
        public static void __Draw(System.Drawing.Graphics graphics, decimal ratio, float width = 0.0f, float height = 0.0f) {
            if(width == 0.0f || height == 0.0f) {
                foreach(Line line in lines) {
                    line.Draw(graphics, ratio);
                }
            } else {
                foreach(Line line in lines) {
                    if((line.start.Anchor.X * (float)ratio > width && line.end.Anchor.X * (float)ratio > width)
                    || (line.start.Anchor.Y * (float)ratio > height && line.end.Anchor.Y * (float)ratio > height)) {
                        continue;
                    }
                    line.Draw(graphics, ratio);
                }
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
        public static void RemoveByShape(Shape shape) {
            System.Collections.Generic.List<Line> temp = new System.Collections.Generic.List<Line>();
            foreach(Line line in Line.lines) {
                if(line.start == shape || line.end == shape) {
                    temp.Add(line);
                }
            }
            foreach(Line line in temp) {
                Line.Remove(line);
            }
        }
        public static Line GetCollidedLine(int x, int y, decimal ratio) {
            float startDist;
            float endDist;
            float tempX;
            float tempY;
            foreach(Line line in Line.lines) {
                tempX = x - line.start.CenterX * (float)ratio;
                tempY = y - line.start.CenterY * (float)ratio;
                startDist = (float)System.Math.Sqrt(tempX * tempX + tempY * tempY);
                tempX = x - line.end.CenterX * (float)ratio;
                tempY = y - line.end.CenterY * (float)ratio;
                endDist = (float)System.Math.Sqrt(tempX * tempX + tempY * tempY);
                tempX = (line.start.Anchor.X - line.end.Anchor.X) * (float)ratio;
                tempY = (line.start.Anchor.Y - line.end.Anchor.Y) * (float)ratio;
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
            tempX = x - line.start.CenterX * (float)ratio;
            tempY = y - line.start.CenterY * (float)ratio;
            startDist = (float)System.Math.Sqrt(tempX * tempX + tempY * tempY) - line.start.OffsetX * (float)ratio;
            tempX = (line.start.Anchor.X - line.end.Anchor.X) * (float)ratio;
            tempY = (line.start.Anchor.Y - line.end.Anchor.Y) * (float)ratio;
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