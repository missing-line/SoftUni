namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Contracts.Pilots;
    using MortalEngines.Entities.Machines;

    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.All(x => x.Name != name))
            {
                this.pilots.Add(new Pilot(name));
                return string.Format(OutputMessages.PilotHired, name);
            }

            return string.Format(OutputMessages.PilotExists, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.All(x => x.Name != name))
            {
                var tank = new Tank(name, attackPoints, defensePoints);
                //((ITank)tank).ToggleDefenseMode();
                this.machines.Add(tank);
                return string.Format(OutputMessages
                    .TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }

            return string.Format(OutputMessages.MachineExists, name);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.All(x => x.Name != name))
            {
                IMachine machine = new Fighter(name, attackPoints, defensePoints);
                //((IFighter)machine).ToggleAggressiveMode();
                this.machines.Add((IFighter)machine);
                return string.Format(OutputMessages
                    .FighterManufactured, name, machine.AttackPoints, machine.DefensePoints, "ON");
            }

            return string.Format(OutputMessages.MachineExists, name);
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            IMachine machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);

            var sb = new StringBuilder();

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;
            return string.Format(OutputMessages.MachineEngaged, pilot.Name, machine.Name);           
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine machineAttacker = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            IMachine machineDefender = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (machineAttacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (machineDefender == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);

            }

            if (machineDefender.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, machineDefender.Name);
            }

            if (machineAttacker.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, machineAttacker.Name);
            }

            machineAttacker.Attack(machineDefender);

            return string.Format(OutputMessages
                .AttackSuccessful, machineDefender.Name, machineAttacker.Name, machineDefender.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(x => x.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {           
            var fighter = this.machines.FirstOrDefault(x => x.Name == fighterName);

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            if (fighter is IFighter)
            {
                if (((IFighter)fighter).AggressiveMode == false)
                {
                    ((IFighter)fighter).ToggleAggressiveMode();
                }
            }

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var defencer = this.machines.FirstOrDefault(x => x.Name == tankName);

            if (defencer == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            if (defencer is ITank)
            {
                if (((ITank)defencer).DefenseMode == false)
                {
                    ((ITank)defencer).ToggleDefenseMode();
                }
            }

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}