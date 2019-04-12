using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.CommandPattern
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unit;

        protected Command(string[] data, IRepository repository, IUnitFactory unit)
        {
            this.Data = data;
            this.Repository = repository;
            this.Unit = unit;
        }

        protected IUnitFactory Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        protected IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        protected string[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public abstract string Execute();
                              
    }
}
