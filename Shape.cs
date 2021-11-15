namespace graphical {
    abstract class Shape {
        protected int x;
        protected int y;
        protected static System.Collections.Generic.List<Shape> shapes = new System.Collections.Generic.List<Shape>();
        protected static decimal ratio = 1.0m;
        protected System.Drawing.Color color;
        public int X {
            get => this.x;
            set { this.x = value; }
        }
        public int Y {
            get => this.y;
            set { this.y = value; }
        }
        public System.Drawing.Color Color {
            get => this.color;
            set { this.color = value; }
        }
        public Shape(int x, int y, System.Drawing.Color color) {
            this.x = x;
            this.y = y;
            this.color = color;
            Shape.shapes.Add(this);
        }
        public abstract void Draw(System.Drawing.Graphics graphics);
        public abstract bool IsPointCollided(int x, int y);
        public static Shape GetCollidedShape(int x, int y) {
            foreach(Shape shape in Shape.shapes) {
                if(shape.IsPointCollided(x, y)) {
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
            graphics.Clear(System.Drawing.Color.White);
            foreach(Shape shape in Shape.shapes) {
                shape.Draw(graphics);
            }
        }
    }
}