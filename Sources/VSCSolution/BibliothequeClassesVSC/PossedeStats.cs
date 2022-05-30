using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class PossedeStats : Element
    {
        protected PossedeStats(string nom, string desc, string image, HashSet<Stat> particularites) 
            : base(nom, desc, image) 
        {
            this.particularites = particularites;
        }

        public SortedSet<Stat> stats = new SortedSet<Stat>();
        public HashSet<Stat> particularites = new HashSet<Stat>();

        protected void AjoutStats(HashSet<Stat> particularite)
        {
            foreach (Stat stat in particularite)
            {
                foreach (Stat stat2 in stats)
                {
                    if (Stat.FullEqComparer.Equals(stat, stat2))
                    {
                        stat2.Valeur += stat.Valeur;
                        break;
                    }
                }
            }
        }

        protected void EnleverStats(HashSet<Stat> particularite)
        {
            foreach (Stat stat in particularite)
            {
                foreach (Stat stat2 in stats)
                {
                    if (Stat.FullEqComparer.Equals(stat, stat2))
                    {
                        stat2.Valeur -= stat.Valeur;
                        break;
                    }
                }
            }
        }
        protected void AjoutParticularite(HashSet<Stat> particularite)
        {
            foreach (Stat stat in particularite)
            {
                foreach (Stat stat2 in particularites)
                {
                    if (Stat.FullEqComparer.Equals(stat, stat2))
                    {
                        stat2.Valeur += stat.Valeur;
                        break;
                    }
                }
            }
        }
        protected void EnleverParticularite(HashSet<Stat> particularite)
        {
            foreach (Stat stat in particularite)
            {
                foreach (Stat stat2 in particularites)
                {
                    if (Stat.FullEqComparer.Equals(stat, stat2))
                    {
                        stat2.Valeur -= stat.Valeur;
                        break;
                    }
                }
            }
        }
    }
}
