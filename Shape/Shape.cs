namespace graphical {
    abstract class Shape {
        protected static System.Collections.Generic.List<Shape> shapes = new System.Collections.Generic.List<Shape>();
        protected Point anchor;
        protected bool hovering;
        protected System.Drawing.Color color;
        protected System.Collections.Generic.List<Shape> adjacency; 
        protected string text;
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
        public string Text {
            get => this.text;
            set { this.text = value; }
        }
        public Shape(Point anchor, System.Drawing.Color color) {
            this.anchor = anchor;
            this.color = color;
            this.hovering = true;
            this.adjacency = new System.Collections.Generic.List<Shape>();
            this.text = "Text";
            Shape.shapes.Add(this);
        }
        public abstract void Draw(System.Drawing.Graphics graphics, decimal ratio);
        public abstract bool IsPointCollided(Point point, decimal ratio);
        public void AddAdjacency(Shape shape) {
            if(this.adjacency.IndexOf(shape) != -1) {
                return;
            }
            this.adjacency.Add(shape);
            new Line(System.Drawing.Color.Black, this, shape);
        }
        public void RemoveAdjacency(Shape shape) {
            int index = this.adjacency.IndexOf(shape);
            if(index == -1) {
                return;
            }
            this.adjacency.RemoveAt(index);
        }
        public virtual int OffsetX {
            get => 0;
        }
        public virtual int OffsetY {
            get => 0;
        }
        public virtual int CenterX {
            get => 0;
        }
        public virtual int CenterY {
            get => 0;
        }
        public static Shape GetCollidedShape(Point point, decimal ratio) {
            foreach(Shape shape in Shape.shapes) {
                if(shape.IsPointCollided(point, ratio)) {
                    return shape;
                }
            }
            return null;
        }
        public static Shape GetCollidedShape(int x, int y, decimal ratio) {
            Point point = new Point(x, y);
            foreach(Shape shape in Shape.shapes) {
                if(shape.IsPointCollided(point, ratio)) {
                    return shape;
                }
            }
            return null;
        }
        public static void Remove(Shape shape) {
            int index = Shape.shapes.IndexOf(shape);
            if(index == -1) return;
            Shape.shapes.RemoveAt(index);
            foreach(Shape s in Shape.shapes) {
                s.RemoveAdjacency(shape);
            }
        }
        public static void __Draw(System.Drawing.Graphics graphics, decimal ratio) {
            foreach(Shape shape in Shape.shapes) {
                shape.Draw(graphics, ratio);
            }
        }
    }
}