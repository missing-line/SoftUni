namespace InfernoInfinity.Weapons
{
    using InfernoInfinity.Rarety;
    public class Sword : Weapon
    {
        public Sword(Rare rare, string name)
           : base(rare, name, 4, 6, 3)
        {
        }
    }
}
