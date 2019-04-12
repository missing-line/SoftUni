using CosmosX.Core.Contracts;
using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using CosmosX.Utils;
using System.Collections.Generic;
using System.Linq;
using System;
using CosmosX.Entities.Reactors;

namespace CosmosX.Core
{
    public class ReactorManager : IManager
    {
        private int currentId;
        private readonly IDictionary<int, IIdentifiable> identifiableObjects;
        private readonly IDictionary<int, IReactor> reactors;
        private readonly IDictionary<int, IModule> modules;

        private readonly ReactorFactory reactorFactory;
        public ReactorManager()
        {
            this.currentId = Constants.StartingId;
            this.identifiableObjects = new Dictionary<int, IIdentifiable>();
            this.reactors = new Dictionary<int, IReactor>();
            this.modules = new Dictionary<int, IModule>();

            this.reactorFactory = new ReactorFactory();
        }

        public string ReactorCommand(IList<string> arguments)
        {
            string reactorType = arguments[0];
            int additionalParameter = int.Parse(arguments[1]);
            int moduleCapacity = int.Parse(arguments[2]);

            IContainer container = new ModuleContainer(moduleCapacity);

            //Reflection
            IReactor reactor = this.reactorFactory
                .CreateReactor(reactorType, this.currentId, container, additionalParameter);

            this.currentId++;

            this.reactors.Add(reactor.Id, reactor);
            this.identifiableObjects.Add(reactor.Id, reactor);

            string result = string.Format(Constants.ReactorCreateMessage, reactorType, reactor.Id);
            return result;
        }

        public string ModuleCommand(IList<string> arguments)
        {
            int reactorId = int.Parse(arguments[0]);
            string moduleType = arguments[1];
            int additionalParameter = int.Parse(arguments[2]);

            int moduleId = 0;
            switch (moduleType)//TODO
            {
                case "CryogenRod":
                    IEnergyModule cryogenRod = new CryogenRod(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddEnergyModule(cryogenRod);
                    this.identifiableObjects.Add(cryogenRod.Id, cryogenRod);
                    this.modules.Add(cryogenRod.Id, cryogenRod);

                    moduleId = cryogenRod.Id;
                    break;
                case "HeatProcessor":
                    IAbsorbingModule heatprocessor = new HeatProcessor(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(heatprocessor);
                    this.identifiableObjects.Add(heatprocessor.Id, heatprocessor);
                    this.modules.Add(heatprocessor.Id, heatprocessor);

                    moduleId = heatprocessor.Id;
                    break;
                case "CooldownSystem":
                    IAbsorbingModule coolDownSystem = new CooldownSystem(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(coolDownSystem);
                    this.identifiableObjects.Add(coolDownSystem.Id, coolDownSystem);
                    this.modules.Add(coolDownSystem.Id, coolDownSystem);

                    moduleId = coolDownSystem.Id;
                    break;
            }
            this.currentId++;

            string result = string.Format(Constants.ModuleCreateMessage, moduleType, moduleId, reactorId);
            return result;
        }
        //TODO
        public string ReportCommand(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);

            var report = this.identifiableObjects[id];

            if (report is IModule)
            {
                return report.ToString();
            }
            else if (report is IReactor)
            {
                return report.ToString();
            }

            return null;
        }
        //TODO
        public string ExitCommand(IList<string> arguments)
        {
            long cryoReactorCount = this.reactors
                .Values
                .Count(r => r is CryoReactor);

            long heatReactorCount = this.reactors
                .Values
                .Count(r => r is HeatReactor);

            long energyModulesCount = this.modules
                .Values
                .Count(m => m is IEnergyModule);

            long absorbingModulesCount = this.modules
                .Values
                .Count(m => m is IAbsorbingModule);

            long totalEnergyOutput = this.reactors
                .Values
                .Sum(r => r.TotalEnergyOutput);

            long totalHeatAbsorbing = this.reactors
                .Values
                .Sum(r => r.TotalHeatAbsorbing);

            string result = $"Cryo Reactors: {cryoReactorCount}\n" +
                            $"Heat Reactors: {heatReactorCount}\n" +
                            $"Energy Modules: {energyModulesCount}\n" +
                            $"Absorbing Modules: {absorbingModulesCount}\n" +
                            $"Total Energy Output: {totalEnergyOutput}\n" +
                            $"Total Heat Absorbing: {totalHeatAbsorbing}\n";

            return result;
        }
    }
}