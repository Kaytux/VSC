using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class ArmeActive : Arme
    {
        /// <summary>
        /// constructeur de la classe ArmeActive
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        /// <param name="niveau"></param>
        /// <param name="amelioration"></param>
        public ArmeActive(string nom, string desc, string image,HashSet<Stat> particularite, List<HashSet<Stat>> statsNiveau)
            : base(nom, desc, image, particularite, statsNiveau)
        {
            stats.Add(new Stat(Stat.NomStat.Area, 0));
            stats.Add(new Stat(Stat.NomStat.Speed, 0));
            stats.Add(new Stat(Stat.NomStat.Duration , 0));
            stats.Add(new Stat(Stat.NomStat.Amount, 0));
            stats.Add(new Stat(Stat.NomStat.Cooldown, 0));

            AjoutStats(particularite);
        }

        /// <summary>
        /// declaration de l'attribut Amelioration avec son getter et setter
        /// </summary>
        public Amelioration Amelioration { get; set; }

        public ArmePassive ArmePass { get; set; }

        public void ajouterAmelioration(Amelioration amelio)
        {
            Amelioration = amelio;
        }

        public void ajouterArmePasssive(ArmePassive arme)
        {
            ArmePass = arme;
        }
    } 
}
