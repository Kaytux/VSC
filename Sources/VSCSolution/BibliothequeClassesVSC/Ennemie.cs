using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Ennemie : Entite
    {
        /// <summary>
        /// Constructeur de la classe Ennemie
        /// </summary>
        /// <param name="nom">Nom de l'ennemie que l'on souhaite créer</param>
        /// <param name="particularite">Liste de Stat correspondant aux particularités de l'ennemie que l'on souhaite créer. Ces stats sont des améliorations des stats de bases posséder par tout les ennemies qui lui sont prores</param>
        /// <param name="desc">Description de l'ennemie que l'on souhaite creér.</param>
        /// <param name="image">Chemin qui permet d'accéder à l'image correspondante à l'ennemie que l'on douhaite créer.</param>
        public Ennemie(string nom, HashSet<Stat> particularite, string desc = "N/A", string image = "N/A") : base(nom,particularite, desc, image)
        {
            AjoutParticularite(particularite);
        }
    }
}
