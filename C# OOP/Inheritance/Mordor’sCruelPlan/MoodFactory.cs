namespace Mordor_sCruelPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class MoodFactory
    {
        private List<Food> food;
        private string happines;

        public MoodFactory(List<Food> allFood)
        {
            this.food = allFood;
            this.Happines = happines;
        }

        public string Happines
        {
            get { return this.happines; }
            private set
            {
                if (GetHappined() >= 1 && GetHappined() <= 15)
                {
                    value = "Happy";
                }
                else if (GetHappined() >= -5 && GetHappined() <= 0)
                {
                    value = "Sad";
                }
                else if (GetHappined() > 15)
                {
                    value = "JavaScript";
                }
                else if (GetHappined() < -5)
                {
                    value = "Angry";
                }
                this.happines = value;
            }
        }
        public int GetHappined()
        {
            return this.food.Select(x => x.Points).Sum();
        }

        public override string ToString()
        {
            return $"{GetHappined()}" + Environment.NewLine +
                      $"{this.happines}";
        }
    }
}
