namespace graphical {
    abstract class Shape {
        protected Point anchor;
        protected bool hovering;
        protected static System.Collections.Generic.List<Shape> shapes = new System.Collections.Generic.List<Shape>();
        protected static decimal ratio = 1.0m;
        protected System.Drawing.Color color;
        public Point Anchor {
            get => this.anchor;
            set { this.anchor = value; }
        }
        public bool Hovering {
            get => this.hovering;
            set { this.hovering = value; }
        }
        public System.Drawing.Color Color {
            get => this.color;
            set { this.color = value; }
        }
        public Shape(Point anchor, System.Drawing.Color color) {
            this.anchor = anchor;
            this.color = color;
            this.hovering = true;
            Shape.shapes.Add(this);
        }
        public abstract void Draw(System.Drawing.Graphics graphics);
        public abstract bool IsPointCollided(Point point);
        public static Shape GetCollidedShape(Point point) {
            foreach(Shape shape in Shape.shapes) {
                if(shape.IsPointCollided(point)) {
                    return shape;
                }
            }
            return null;
        }
        public static Shape GetCollidedShape(int x, int y) {
            Point point = new Point(x, y);
            foreach(Shape shape in Shape.shapes) {
                if(shape.IsPointCollided(point)) {
                    return shape;
                }
            }
            return null;
        }
        public static void Remove(Shape shape) {
            int index = Shape.shapes.IndexOf(shape);
            if(index == -1) return;
            Shape.shapes.RemoveAt(index);
        }
        public static decimal Ratio {
            get => Shape.ratio;
            set { Shape.ratio = value; }
        }
        public static void __Draw(System.Drawing.Graphics graphics) {
            foreach(Shape shape in Shape.shapes) {
                shape.Draw(graphics);
            }
        }
    }
}