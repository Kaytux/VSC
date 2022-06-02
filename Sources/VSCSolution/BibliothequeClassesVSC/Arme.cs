using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Arme: PossedeStats
    {
        /// <summary>
        /// constructeur de la classe abstraite  Arme
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        /// <param name="niveau"></param>
        public Arme(string nom, string desc, string image, HashSet<Stat> lesStats, List<HashSet<Stat>> statsNiveau)
            : base(nom, desc, image , lesStats)
        {
            Niveau = 1;
            this.statsNiveau = statsNiveau;

            stats.Add(new Stat(Stat.NomStat.MaxLevel, 0));
            stats.Add(new Stat(Stat.NomStat.Knockback, 0));
            stats.Add(new Stat(Stat.NomStat.Rarity, 0));
            stats.Add(new Stat(Stat.NomStat.CritRate, 0));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 0));
        }
        /// <summary>
        /// declaration de l'attribut Niveau avec son getter et setter
        /// </summary>
        public int Niveau { get; set; }

        public List<HashSet<Stat>> statsNiveau;

        /// <summary>
        /// méthode qui permet d'augmenter de 1 le Niveau d'une arme 
        /// </summary>
        public void AugmenterNiveau()
        {
            if (Niveau > 8)
            {
                return;
            }
            else
            {
                Niveau = Niveau + 1;
                this.AjoutStats(statsNiveau[Niveau - 2]);
            }
        }

        /// <summary>
        /// méthode qui permet de baisser de 1 le Niveau d'une arme 
        /// </summary>
        public void BaisserNiveau()
        {
            if (Niveau <= 1)
            {
                return;
            }
            else
            {
                Niveau = Niveau - 1;
                this.EnleverStats(statsNiveau[Niveau - 1]);
            } 
        }
    }
}
