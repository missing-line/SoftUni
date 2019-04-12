namespace Mordor_sCruelPlan
{
    public class Food
    {
        private string name;
        private int points;

        public Food(string name)
        {
            this.Name = name;
            this.Points = points;
        }

        public int Points
        {
            get { return this.points; }
            private set
            {
                switch (this.name.ToLower())
                {
                    case "apple":
                        value = 1;
                        break;
                    case "cram":
                        value = 2;
                        break;
                    case "lembas":
                        value = 3;
                        break;
                    case "melon":
                        value = 1;
                        break;
                    case "honeycake":
                        value = 5;
                        break;
                    case "mushrooms":
                        value = -10;
                        break;
                    default:
                        value = -1;
                        break;
                }
                this.points = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }
    }
}
