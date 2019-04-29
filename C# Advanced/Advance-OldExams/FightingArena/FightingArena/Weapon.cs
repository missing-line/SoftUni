namespace FightingArena
{
    public class Weapon
    {
        //•Size: int
        //•	Solidity: int
        //•	Sharpness: int

        private int size;
        private int solidity;
        private int sharpness;

        public Weapon(int size, int solidity, int sharpness)
        {
            this.Size = size;
            this.Solidity = solidity;
            this.Sharpness = sharpness;
        }

        public int Sharpness
        {
            get { return sharpness; }
            private set { sharpness = value; }
        }

        public int Solidity
        {
            get { return solidity; }
            private set { solidity = value; }
        }

        public int Size
        {
            get { return size; }
            private set { size = value; }
        }

    }
}
