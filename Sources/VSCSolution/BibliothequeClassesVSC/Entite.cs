using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Entite : Element , IStatAffichable
    {
        public Entite(string nom, string desc = "N/A", string image = "N/A", Stat maxHealth, Stat moveSpeed, List<Stat> particularite) : base(nom, desc, image)
        {
            MaxHealth = maxHealth;
            MoveSpeed = moveSpeed;
            foreach (Stat stat in particularite)
            {

            }
        }

        public Stat MaxHealth;
        public Stat MoveSpeed;

        public void AffichStats() { }
    }
}
