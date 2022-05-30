using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Carte : Element
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
        public Carte(string nom, string desc, string image,  List<string> lesEnnemies, List<string> lesObjetsCaches)
            :base(nom,desc,image)
        {
            NomEnn = lesEnnemies;
            NomArmPass = lesObjetsCaches;
        }
        
        public List<string> NomEnn;
        public List<string> NomArmPass;
    }
}
