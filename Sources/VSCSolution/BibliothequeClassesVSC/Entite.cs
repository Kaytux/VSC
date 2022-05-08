using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Entite : Element , IStatAffichable
    {
        public Entite(string nom, string desc = "N/A", string image = "N/A") : base(nom, desc, image)
        {
            stats.Add(new Stat(Stat.NomStat.MaxHealth, 0));
            stats.Add(new Stat(Stat.NomStat.MoveSpeed, 0));
        }

        public List<Stat> stats=new List<Stat>();

        public void AffichStats() 
        {
            foreach (Stat stat in stats)
            {
                Console.WriteLine(stat);
            }
        }
    }
}
