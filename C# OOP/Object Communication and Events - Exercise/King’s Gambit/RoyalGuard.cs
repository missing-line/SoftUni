namespace King_s_Gambit
{
    using System;
    public class RoyalGuard : Soldier
    {
        private int getHits;
        public RoyalGuard(string name) 
            : base(name)
        {
        }

        public override bool IsDead => this.getHits == 3;

        public override void GetHit()
        {
            this.getHits++;
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
