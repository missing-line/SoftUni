namespace _8.PetClinic
{
    using System;
    using System.Linq;
    public class Clinic
    {
        private readonly int firstIndex;

        private string name;
        private Pet[] rooms;

        public Clinic(string name, int rooms)
        {
            this.Name = name;
            this.Rooms = new Pet[rooms];
            this.firstIndex = this.rooms.Length / 2;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Pet[] Rooms
        {
            get { return this.rooms; }
            set { this.rooms = value; }
        }
        public bool AddPet(Pet pet)
        {
            for (int i = 0; i <= firstIndex; i++)
            {
                if (this.rooms[this.firstIndex - i] == null)
                {
                    this.rooms[this.firstIndex - i] = pet;
                    return true;
                }

                if (this.rooms[this.firstIndex + i] == null)
                {
                    this.rooms[this.firstIndex + i] = pet;
                    return true;
                }
            }
            return false;
        }

        public void PrintCurrentRoom(int index)
        {
            if (index >= 0 && index < this.rooms.Length)
            {
                if (this.rooms[index] == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(this.rooms[index].ToString());
                }
            }
        }

        public bool Release()
        {
            for (int i = this.firstIndex; i < this.rooms.Length; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < this.firstIndex; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms = null;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms(Pet[] rooms)
        {
            return this.rooms.All(x => x == default(Pet));
        }
    }
}
