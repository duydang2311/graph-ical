namespace graphical {
	class Loop {
		protected static System.Collections.Generic.List<Loop> loops = new System.Collections.Generic.List<Loop>();
		protected static float thickness = 2.0f;
		protected Shape shape;
		protected System.Drawing.Color highlight;
		public Loop(Shape shape) {
			this.shape = shape;
			this.highlight = System.Drawing.Color.Transparent;
			Loop.loops.Add(this);
		}
		public static float Thickness {
			get => Loop.thickness;
			set { Loop.thickness = value; }
		}
		public System.Drawing.Color Highlight {
			get => this.highlight ;
			set { this.highlight  = value; }
		}
		public void Draw(System.Drawing.Graphics graphics, decimal ratio) {
			System.Drawing.Color color = System.Drawing.Color.Black;
			if(this.highlight != System.Drawing.Color.Transparent) {
				color = this.highlight;
			}
			using(System.Drawing.Pen pen = new System.Drawing.Pen(color, Loop.thickness * (float)ratio)) {
				graphics.DrawEllipse(pen, (shape.CenterX - shape.OffsetX) * (float)ratio, shape.CenterY * (float)ratio, 70 * (float)ratio, 70 * (float)ratio);
			}
		}
		public static void __Draw(System.Drawing.Graphics graphics, decimal ratio) {
			foreach(Loop loop in Loop.loops) {
				loop.Draw(graphics, ratio);
			}
		}
        public static Loop GetCollidedLoop(int x, int y, decimal ratio) {
        	float dx;
        	float dy;
        	float dist;
        	foreach(Loop loop in Loop.loops) {
        		dx = loop.shape.CenterX * (float)ratio - x;
        		dy = (loop.shape.CenterY + loop.shape.OffsetY) * (float)ratio - y;
        		dist = (float)System.Math.Sqrt(dx * dx + dy * dy);
        		if(dist >= (loop.shape.OffsetX - Loop.thickness) * (float)ratio && dist <= (loop.shape.OffsetX + Loop.thickness) * (float)ratio) {
        			return loop;
        		}
        	}
        	return null;
        }
	}
}