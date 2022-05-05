using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Personnage : Entite
    {
        public Personnage(string nom, Stat maxHealth, Stat moveSpeed, List<Stat> particularite, string desc = "N/A", string image = "N/A") : base(nom, maxHealth, moveSpeed, particularite, desc, image)
        {
        }

        public Stat Recovery;
        public Stat Armor;
        public Stat Might;
        public Stat Area;
        public Stat Speed;
        public Stat Duration;
        public Stat Amount;
        public Stat Cooldown;
        public Stat Luck;
        public Stat Growth;
        public Stat Greed;
        public Stat Curse;
        public Stat Magnet;
        public Stat Bonus;

        
    }
}
