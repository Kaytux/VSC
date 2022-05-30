using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Personnage : Entite
    {
        /// <summary>
        /// Constructeur de personnage
        /// </summary>
        /// <param name="nom">Nom du personnage que l'on souhaite créer</param>
        /// <param name="particularite">liste de Stat qui correspond au différentes particularité du personnage que l'on souhaite créer. Ces particularités sont des amélioration des stats de bases communes à tout les personnages qui lui sont propres</param>
        /// <param name="desc">description du personnage que l'on souhaite créer</param>
        /// <param name="image">chemin permettant d'accéder à l'image qui correspond au personnage que l'on souhaite créer</param>
        public Personnage(string nom,
                          string desc,
                          string image,
                          HashSet<Stat> particularite
                          ) : base(nom, desc, image, particularite)
        {
            stats.Add(new Stat(Stat.NomStat.Luck, 0));
            stats.Add(new Stat(Stat.NomStat.Growth, 0));
            stats.Add(new Stat(Stat.NomStat.Greed, 0));
            stats.Add(new Stat(Stat.NomStat.Magnet, 0));

            AjoutParticularite(particularite);
        }        
    }
}