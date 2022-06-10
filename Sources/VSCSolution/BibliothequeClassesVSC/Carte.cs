using System.Collections.Generic;

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
        public Carte(string nom, string desc, string image, List<string> lesEnnemies, List<string> lesObjetsCaches)
            : base(nom, desc, image)
        {
            NomEnn = lesEnnemies;
            NomArmPass = lesObjetsCaches;
        }

        /// <summary>
        /// declaration de la list de string NomEnn qui contient le nom de tout les ennemies present sur la carte
        /// </summary>
        public List<string> NomEnn;

        /// <summary>
        /// declaration de la list de string NomArmPass qui contient le nom de tout les objets cachés présent sur la carte
        /// </summary>
        public List<string> NomArmPass;
    }
}
