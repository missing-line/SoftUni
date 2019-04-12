namespace InfernoInfinity.Weapons
{
    using InfernoInfinity.Rarety;
    public class Knife : Weapon
    {
        public Knife(Rare rare, string name)
           : base(rare, name, 3, 4, 2)
        {
        }
    }
}
