namespace RectangleIntersection
{
    public class Rectangle
    {
        //id, width, height and the coordinates of its top left corner 
        private string id;
        private double width;
        private double height;
        private double x;
        private double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }
        public string Id { get { return this.id; } set { this.id = value; } }
        public double Width { get { return this.width; } set { this.width = value; } }
        public double Height { get { return this.height; } set { this.height = value; } }
        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }

        public bool Intersects(Rectangle newRecrangle)
        {
            if ((newRecrangle.y >= this.y && newRecrangle.y - newRecrangle.height <= this.y && newRecrangle.x <= this.x && newRecrangle.x + newRecrangle.width >= this.x) ||
                (newRecrangle.y >= this.y && newRecrangle.y - newRecrangle.height <= this.y && newRecrangle.x >= this.x && newRecrangle.x <= this.x + this.width) ||
                (newRecrangle.y <= this.y && newRecrangle.y >= this.y - this.height && newRecrangle.x <= this.x && newRecrangle.x + newRecrangle.width >= this.x) ||
                (newRecrangle.y <= this.y && newRecrangle.y >= this.y - this.height && newRecrangle.x >= this.x && newRecrangle.x <= this.x + this.width))
            {
                return true;
            }

            return false;
        }
    }
}
