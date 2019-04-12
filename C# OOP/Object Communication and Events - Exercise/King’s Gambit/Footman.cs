namespace King_s_Gambit
{
    using System;
    public class Footman : Soldier
    {
        private int getHits;
        public Footman(string name)
            : base(name)
        {
        }

        public override bool IsDead => this.getHits == 2;

        public override void GetHit()
        {
            this.getHits++;
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
