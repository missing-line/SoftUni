namespace ViceCity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Core.Contracts;
    using ViceCity.Factories.GunFactory;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;

    public class Controller : IController
    {
        private IGunFactory gunFactory;
        private INeighbourhood neighbourhood;
        private Queue<IGun> guns;
        private List<IPlayer> players;
        private IPlayer main;
        public Controller()
        {
            this.gunFactory = new GunFactory();
            this.neighbourhood = new GangNeighbourhood();
            this.guns = new Queue<IGun>();
            this.players = new List<IPlayer>();
            this.main = new MainPlayer();
        }
        public string AddGun(string type, string name)
        {
            var gun = this.gunFactory.CreateGun(type, name);

            this.guns.Enqueue(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = this.guns.Peek();

            if (name == "Vercetti")
            {
                this.main.GunRepository.Add(this.guns.Dequeue());
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti"; ;
            }

            if (this.players.All(x => x.Name != name))
            {
                return "Civil player with that name doesn't exists!";
            }

            var findPlayer = this.players.FirstOrDefault(x => x.Name == name);
            findPlayer.GunRepository.Add(this.guns.Dequeue());

            return $"Successfully added {gun.Name} to the Civil Player: {findPlayer.Name}";
        }

        public string AddPlayer(string name)
        {
            this.players.Add(new CivilPlayer(name));

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            this.neighbourhood.Action(this.main, this.players);

            var areAllCivilsOk = this.players
                .All(x => x.LifePoints == 50);

            var deadCivilPlayers = this.players
                .Where(x => !x.IsAlive)
                .Count();

            this.players
                .RemoveAll(x => !x.IsAlive);

            if (this.main.LifePoints == 100 && areAllCivilsOk)
            {
                return "Everything is okay!";
            }
           

               return   "A fight happened:" + Environment.NewLine +
                        $"Tommy live points: {this.main.LifePoints}!" + Environment.NewLine +
                        $"Tommy has killed: {deadCivilPlayers} players!" + Environment.NewLine +
                        $"Left Civil Players: {this.players.Count}!";                     
        }
    }
}
