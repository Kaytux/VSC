using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Carte
    {
        /// <summary>
        /// Une carte possède un attribut lesEnnemies qui correspond à une liste d'ennemie qui contient les ennemies présent dans la zone
        /// </summary>
        public List<Ennemie> LesEnnemies;

        /// <summary>
        /// Une carte possède un attribut lesObjetsCaches qui correspond à une liste d'arme passive qui contient les armes passives qui sont cacher un peu partout sur la carte
        /// </summary>
        public List<ArmePassive> LesObjetsCaches;

        /// <summary>
        /// Constructeur de Carte
        /// </summary>
        /// <param name="lesEnnemies">liste des ennemies présent dans la carte</param>
        /// <param name="lesObjetsCaches">liste des objets chachés dans la carte</param>
        public Carte(List<Ennemie> lesEnnemies, List<ArmePassive> lesObjetsCaches)
        {
            LesEnnemies = lesEnnemies;
            LesObjetsCaches = lesObjetsCaches;
        }

        /// <summary>
        /// affichage des objets présent sur la carte
        /// </summary>
        public void affichArmePassive() {
            int i = 1;
            foreach (ArmePassive arme in LesObjetsCaches)
            {
                Console.WriteLine("Arme passive caché n°"+i+" : "+arme.Nom);
                i++;
            }
        }

        /// <summary>
        /// affichage des ennemies présent sur la carte
        /// </summary>
        public void affichEnnemie()
        {
            int i = 1;
            foreach (Ennemie ennemie in LesEnnemies)
            {
                Console.WriteLine("Ennemie n°" + i + " présent dans la zone : " + ennemie.Nom);
                i++;
            }
        }
    }
}
