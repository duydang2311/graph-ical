namespace graphical {
    class Circle : Shape {
        protected int radius;
        public Circle(int x, int y, int radius, System.Drawing.Color color) : base(x, y, color) {
            this.radius = radius;
        }
        override public void Draw(System.Drawing.Graphics graphic) {
            if(this.ghost) {
                graphic.FillEllipse(System.Drawing.Brushes.Black, (int)(this.x * Shape.ratio), (int)(this.y * Shape.ratio), (int)(this.radius * Shape.ratio), (int)(this.radius * Shape.ratio));
            } else {
                graphic.DrawEllipse(new System.Drawing.Pen(this.color, (float)(2 * Shape.ratio)), (int)(this.x * Shape.ratio), (int)(this.y * Shape.ratio), (int)(this.radius * Shape.ratio), (int)(this.radius * Shape.ratio));
            }
        }
        public override bool IsPointCollided(int x, int y) {
            double ratioRadius = (double)(this.radius * Shape.ratio);
            double ratioX = (double)(this.x * Shape.ratio);
            double ratioY = (double)(this.y * Shape.ratio);
            return (System.Math.Sqrt(System.Math.Pow(ratioX + ratioRadius / 2 - x, 2) + System.Math.Pow(ratioY + ratioRadius / 2 - y, 2))) <= ratioRadius / 2;
        }
    }
}