namespace InfernoInfinity.Data
{
    using InfernoInfinity.Interface;
    using InfernoInfinity.Interfaces;
    using System;
    using System.Collections.Generic;

    class Repository : IRepository
    {
        private IDictionary<string, IWeapon> weaponBase;

        public Repository()
        {
            this.weaponBase = new Dictionary<string, IWeapon>();
        }

        public void AddGem(string name, int index, IGem gem)
        {
            var weapon = this.weaponBase[name];

            if (weapon.Slots.Count > index && index >= 0)
            {
                weapon.Slots[index] = gem;
               // weapon.AddGemValues(gem);
            }
        }

        public void CreateWeapon(IWeapon weapon)
        {
            string name = weapon.Name;
            if (!this.weaponBase.ContainsKey(name))
            {
                this.weaponBase.Add(name, null);

            }
            this.weaponBase[name] = weapon;
        }

        public void RemoveGem(string name, int index)
        {
            var weapon = this.weaponBase[name];
            if (weapon.Slots.Count > index && index >= 0)
            {
                IGem gem = weapon.Slots[index];
                weapon.Slots[index] = null;
                //weapon.RemoveGem(gem);
            }
        }

        public IWeapon GetInstance(string name)
        {
            IWeapon weapon = this.weaponBase[name];

            return weapon;
        }
    }
}
