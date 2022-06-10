using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class PossedeStats : Element
    {
        /// <summary>
        /// construcuteur de PossedeStats
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        /// <param name="particularites"></param>
        protected PossedeStats(string nom, string desc, string image, HashSet<Stat> particularites) 
            : base(nom, desc, image) 
        {
            this.particularites = particularites;
        }
        /// <summary>
        /// declaration de l'attribut stats, qui contient les statistiques de l'élément
        /// </summary>
        public SortedSet<Stat> stats = new SortedSet<Stat>();
        /// <summary>
        /// declaration de l'attribut particularite, qui contient les statistiques spécifiques à un élément
        /// </summary>
        public HashSet<Stat> particularites = new HashSet<Stat>();
        /// <summary>
        /// méthode permettant d'ajouter des stats supplémentaire à l'élement
        /// </summary>
        /// <param name="lesStats"></param>
        protected void AjoutStats(HashSet<Stat> lesStats)
        {
            foreach (Stat stat in lesStats)
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
        /// <summary>
        /// méthode permettant d'enlever des stats à l'élement
        /// </summary>
        /// <param name="lesStats"></param>
        protected void EnleverStats(HashSet<Stat> lesStats)
        {
            foreach (Stat stat in lesStats)
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
    }
}
