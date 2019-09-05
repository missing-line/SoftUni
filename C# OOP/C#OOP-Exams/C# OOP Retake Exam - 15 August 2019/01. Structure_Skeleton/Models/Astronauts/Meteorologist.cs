namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        public Meteorologist(string name)
            : base(name, 90)
        {
        }

        public override void Breath()
        {
            base.Breath();
        }
    }
}
