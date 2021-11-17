namespace graphical {
    class Circle : Shape {
        protected int radius;
        public Circle(Point point, int radius, System.Drawing.Color color) : base(point, color) {
            this.radius = radius;
        }
        override public void Draw(System.Drawing.Graphics graphic) {
            if(this.ghost) {
                graphic.FillEllipse(System.Drawing.Brushes.Black, (int)(this.anchor.X * Shape.ratio), (int)(this.anchor.Y * Shape.ratio), (int)(this.radius * Shape.ratio), (int)(this.radius * Shape.ratio));
            } else {
                graphic.DrawEllipse(new System.Drawing.Pen(this.color, (float)(2 * Shape.ratio)), (int)(this.anchor.X * Shape.ratio), (int)(this.anchor.Y * Shape.ratio), (int)(this.radius * Shape.ratio), (int)(this.radius * Shape.ratio));
            }
        }
        public override bool IsPointCollided(Point point) {
            double ratioRadius = (double)(this.radius * Shape.ratio);
            double ratioX = (double)(this.anchor.X * Shape.ratio);
            double ratioY = (double)(this.anchor.Y * Shape.ratio);
            return (System.Math.Sqrt(System.Math.Pow(ratioX + ratioRadius / 2 - point.X, 2) + System.Math.Pow(ratioY + ratioRadius / 2 - point.Y, 2))) <= ratioRadius / 2;
        }
    }
}