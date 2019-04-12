namespace InfernoInfinity.Weapons
{
    using InfernoInfinity.Rarety;
    public class Axe : Weapon
    {
        public Axe(Rare rare, string name)
            : base(rare,name, 5, 10, 4)
        {         
        }
    }
}
