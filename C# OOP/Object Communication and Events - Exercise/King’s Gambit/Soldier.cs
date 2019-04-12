namespace King_s_Gambit
{
    public abstract class Soldier
    {
        
        public Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract bool IsDead { get; }

        public abstract void KingUnderAttack();

        public abstract void GetHit();
        
    }
}
