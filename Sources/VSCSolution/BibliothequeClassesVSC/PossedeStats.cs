using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    [DataContract, KnownType(typeof(Arme)), KnownType(typeof(Entite))]
    public abstract class PossedeStats : Element
    {
        protected PossedeStats(string nom, HashSet<Stat> particularite, string desc = "N/A", string image = "N/A") 
            : base(nom, desc, image) { }

        [DataMember]
        public SortedSet<Stat> stats = new SortedSet<Stat>();

        protected void AjoutParticularite(HashSet<Stat> particularite)
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
    }
}
