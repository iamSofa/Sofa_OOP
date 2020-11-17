using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public delegate void Act(Entity obj);
    public class Game
    {
        public event Act attack;
        public event Act heal;

        public void DoAttack(Entity obj) => attack?.Invoke(obj);
        public void DoHeal(Entity obj) => heal?.Invoke(obj);
    }

    public class Entity
    {
        public int heatlh;
        public int wisdom;
        public int strength;

        public Act doAttack;
        public Act doHeal;
        
        public override string ToString()
        {
            return $"{heatlh} | {wisdom} | {strength}";
        }
    }
}
