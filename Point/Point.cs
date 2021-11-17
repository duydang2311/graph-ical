namespace graphical {
    class Point {
        private int x;
        private int y;
        public int X {
            get => this.x;
            set { this.x = value; }
        }
        public int Y {
            get => this.y;
            set { this.y = value; }
        }
        public Point() {
            this.x = 0;
            this.y = 0;
        }
        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}