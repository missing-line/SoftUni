namespace FightingArena
{
    public class Stat
    {
        //Strength: int
        //Flexibility: int
        //Agility: int
        //Skills: int
        //Intelligence: int

        private int intelligence;
        private int skills;
        private int agility;
        private int flexibility;
        private int strength;

        public Stat(int strength, int flexibility, int agility, int skills, int intelligence)
        {
            this.Strength = strength;
            this.Flexibility = flexibility;
            this.Agility = agility;
            this.Skills = skills;
            this.Intelligence = intelligence;
        }

        public int Strength
        {
            get { return strength; }
            private set { strength = value; }
        }

        public int Flexibility
        {
            get { return flexibility; }
            private set { flexibility = value; }
        }

        public int Agility
        {
            get { return agility; }
            private set { agility = value; }
        }

        public int Skills
        {
            get { return skills; }
            private set { skills = value; }
        }

        public int Intelligence
        {
            get { return intelligence; }
            private set { intelligence = value; }
        }


    }
}
