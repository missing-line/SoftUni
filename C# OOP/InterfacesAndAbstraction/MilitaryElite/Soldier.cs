namespace MilitaryElite
{
    public class Soldier : ISoldier
    {
        public Soldier(string id, string firstName, string secondName)
        {
           this.Id = id;
           this.FirstName = firstName;
           this.SecondName = secondName;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.SecondName} Id: {this.Id}";
        }
    }
}
