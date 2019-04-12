using System;
using System.Collections.Generic;
using System.Text;

namespace King_s_Gambit
{
    public delegate void KingIsAttacked();
    public class King
    {
        private string name;    
        public event KingIsAttacked kingAttacked;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => name;
            private  set => name = value;
        }

        public void OnAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            kingAttacked?.Invoke();
        }
    }
}
