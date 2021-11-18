namespace graphical {
    class Circle : Shape {
        protected int radius;
        public int Radius {
            get => this.radius;
            set { this.radius = value; }
        }
        public Circle(Point point, int radius, System.Drawing.Color color) : base(point, color) {
            this.radius = radius;
        }
        override public void Draw(System.Drawing.Graphics graphic, decimal ratio) {
            if(this.hovering) {
                graphic.FillEllipse(System.Drawing.Brushes.Black, (int)(this.anchor.X * ratio), (int)(this.anchor.Y * ratio), (int)(this.radius * ratio), (int)(this.radius * ratio));
            } else {
                graphic.DrawEllipse(new System.Drawing.Pen(this.color, (float)(2 * ratio)), (int)(this.anchor.X * ratio), (int)(this.anchor.Y * ratio), (int)(this.radius * ratio), (int)(this.radius * ratio));
                graphic.FillEllipse(System.Drawing.Brushes.White, (int)(this.anchor.X * ratio), (int)(this.anchor.Y * ratio), (int)(this.radius * ratio), (int)(this.radius * ratio));
            }
        }
        override public void DrawAdjacentLines(System.Drawing.Graphics graphic, decimal ratio) {
            Point point = new Point(this.anchor.X + (int)(this.radius / 2), this.anchor.Y + (int)(this.radius / 2));
            foreach(Circle shape in this.adjacency) {
                new Line(System.Drawing.Color.Black, 2.0f, point, new Point(shape.Anchor.X + (int)(shape.radius / 2), shape.Anchor.Y + (int)(shape.radius / 2))).Draw(graphic, ratio);
            }
        }
        public override bool IsPointCollided(Point point, decimal ratio) {
            double ratioRadius = (double)(this.radius * ratio);
            double ratioX = (double)(this.anchor.X * ratio);
            double ratioY = (double)(this.anchor.Y * ratio);
            return (System.Math.Sqrt(System.Math.Pow(ratioX + ratioRadius / 2 - point.X, 2) + System.Math.Pow(ratioY + ratioRadius / 2 - point.Y, 2))) <= ratioRadius / 2;
        }
        public override int OffsetX {
            get => this.radius / 2;
        }
        public override int OffsetY {
            get => this.radius / 2;
        }
    }
}