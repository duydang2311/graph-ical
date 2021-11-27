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
                using(System.Drawing.Font font = new System.Drawing.Font("Arial", 20 * (float)ratio, System.Drawing.GraphicsUnit.Pixel)) {
                    using(System.Drawing.StringFormat stringFormat = new System.Drawing.StringFormat()) {
                        stringFormat.LineAlignment = System.Drawing.StringAlignment.Center;
                        stringFormat.Alignment = System.Drawing.StringAlignment.Center;
                        graphic.DrawString(Util.ClampStringWidth(this.text, this.Radius * 1.4f), font, System.Drawing.Brushes.White, this.CenterX * (float)ratio, this.CenterY * (float)ratio, stringFormat);
                    }
                }
            } else {
                using (System.Drawing.Pen pen = new System.Drawing.Pen(this.color, (float)(2 * ratio))) {
                    graphic.DrawEllipse(pen, (int)(this.anchor.X * ratio), (int)(this.anchor.Y * ratio), (int)(this.radius * ratio), (int)(this.radius * ratio));
                    graphic.FillEllipse(System.Drawing.Brushes.White, (int)(this.anchor.X * ratio), (int)(this.anchor.Y * ratio), (int)(this.radius * ratio), (int)(this.radius * ratio));
                    using(System.Drawing.Font font = new System.Drawing.Font("Arial", 20 * (float)ratio, System.Drawing.GraphicsUnit.Pixel)) {
                        using(System.Drawing.StringFormat stringFormat = new System.Drawing.StringFormat()) {
                            stringFormat.LineAlignment = System.Drawing.StringAlignment.Center;
                            stringFormat.Alignment = System.Drawing.StringAlignment.Center;
                            graphic.DrawString(Util.ClampStringWidth(this.text, this.Radius * 1.4f), font, System.Drawing.Brushes.Black, this.CenterX * (float)ratio, this.CenterY * (float)ratio, stringFormat);
                        }
                    }
                }
            }
        }
        public override bool IsPointCollided(Point point, decimal ratio) {
            double ratioRadius = (double)(this.radius * ratio);
            double ratioX = (double)(this.anchor.X * ratio);
            double ratioY = (double)(this.anchor.Y * ratio);
            return (System.Math.Sqrt(System.Math.Pow(ratioX + ratioRadius / 2 - point.X, 2) + System.Math.Pow(ratioY + ratioRadius / 2 - point.Y, 2))) <= ratioRadius / 2;
        }
        public override bool IsPointCollidedWithText(Point point, decimal ratio) {
            System.Drawing.Font arial = new System.Drawing.Font("Arial", 20 * (float)ratio, System.Drawing.GraphicsUnit.Pixel);
            System.Drawing.Size textSize = System.Windows.Forms.TextRenderer.MeasureText(Util.ClampStringWidth(this.text, this.Radius * 2), arial);
            float left = this.CenterX * (float)ratio - textSize.Width / 2;
            float right = this.CenterX * (float)ratio + textSize.Width / 2;
            float top = this.CenterY * (float)ratio - textSize.Height / 2;
            float bottom = this.CenterY * (float)ratio + textSize.Height / 2;
            return (point.X >= left && point.X <= right && point.Y >= top && point.Y <= bottom);
        }
        public override int OffsetX {
            get => this.radius / 2;
        }
        public override int OffsetY {
            get => this.radius / 2;
        }
        public override int CenterX {
            get => this.anchor.X + this.radius / 2;
        }
        public override int CenterY {
            get => this.anchor.Y + this.radius / 2;
        }
    }
}