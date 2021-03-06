namespace graphical {
	class Loop {
		protected static System.Collections.Generic.List<Loop> loops = new System.Collections.Generic.List<Loop>();
		protected static float thickness = 2.0f;
		protected Shape shape;
		protected System.Drawing.Color highlight;
		protected float angle;
		protected string text;
		public Loop(Shape shape) {
			this.shape = shape;
			this.highlight = System.Drawing.Color.Transparent;
			this.angle = 0.0f;
			this.text = "";
			Loop.loops.Add(this);
		}
		public static float Thickness {
			get => Loop.thickness;
			set { Loop.thickness = value; }
		}
		public Shape Shape {
			get => this.shape;
			set { this.shape = value; }
		}
		public System.Drawing.Color Highlight {
			get => this.highlight ;
			set { this.highlight  = value; }
		}
		public float Angle {
			get => this.angle;
			set { this.angle = value; }
		}
		public string Text {
			get => this.text;
			set { this.text = value; }
		}
		public void Draw(System.Drawing.Graphics graphics, decimal ratio) {
			System.Drawing.Color color = System.Drawing.Color.Black;
			if(this.highlight != System.Drawing.Color.Transparent) {
				color = this.highlight;
			}
			using(System.Drawing.Pen pen = new System.Drawing.Pen(color, Loop.thickness * (float)ratio)) {
				graphics.DrawEllipse(
					pen,
					(float)(shape.Anchor.X + shape.OffsetX * System.Math.Cos(this.angle)) * (float)ratio,
					(float)(shape.Anchor.Y + shape.OffsetY * System.Math.Sin(this.angle)) * (float)ratio,
					shape.OffsetX * 2 * (float)ratio,
					shape.OffsetY * 2 * (float)ratio
				);
				using(System.Drawing.Font arial = new System.Drawing.Font("Arial", 20 * (float)ratio, System.Drawing.GraphicsUnit.Pixel)) {
					using(System.Drawing.StringFormat sf = new System.Drawing.StringFormat()) {
						System.Drawing.Size measure = System.Windows.Forms.TextRenderer.MeasureText(this.text, arial);
						float centerX = (float)(this.shape.CenterX + (2 * this.shape.OffsetX + measure.Width / 1.6 / (float)ratio) * System.Math.Cos(this.angle)) * (float)ratio;
						float centerY = (float)(this.shape.CenterY + (2 * this.shape.OffsetY + measure.Height / 1.6 / (float)ratio) * System.Math.Sin(this.angle)) * (float)ratio;
						sf.Alignment = System.Drawing.StringAlignment.Center;
						sf.LineAlignment = System.Drawing.StringAlignment.Center;
						graphics.DrawString(
							this.text,
							arial,
							System.Drawing.Brushes.Black,
							centerX,
							centerY,
							sf
						);
					}
				}
			}
		}
		public static void __Draw(System.Drawing.Graphics graphics, decimal ratio, float width = 0.0f, float height = 0.0f) {
            if(width == 0.0f || height == 0.0f) {
                foreach(Loop loop in Loop.loops) {
                    loop.Draw(graphics, ratio);
                }
            } else {
                foreach(Loop loop in Loop.loops) {
                    if(loop.shape.Anchor.X * (float)ratio > width || loop.shape.Anchor.Y * (float)ratio > height) {
                        continue;
                    }
                    loop.Draw(graphics, ratio);
                }
            }
		}
		public static void Remove(Loop loop) {
			int index = Loop.loops.IndexOf(loop);
			if(index == -1) return;
			Loop.loops.RemoveAt(index);
		}
        public static Loop GetCollidedLoop(int x, int y, decimal ratio) {
        	float dx;
        	float dy;
        	float dist;
			float centerX;
			float centerY;
        	foreach(Loop loop in Loop.loops) {
				centerX = (float)(loop.shape.CenterX + loop.shape.OffsetX * System.Math.Cos(loop.angle)) * (float)ratio;
				centerY = (float)(loop.shape.CenterY + loop.shape.OffsetY * System.Math.Sin(loop.angle)) * (float)ratio;
        		dx = centerX - x;
        		dy = centerY - y;
        		dist = (float)System.Math.Sqrt(dx * dx + dy * dy);
        		if(dist >= (loop.shape.OffsetX - Loop.thickness) * (float)ratio && dist <= (loop.shape.OffsetX + Loop.thickness) * (float)ratio) {
        			return loop;
        		}
        	}
        	return null;
        }
	}
}