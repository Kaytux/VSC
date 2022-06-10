using System.Collections.Generic;

namespace BibliothequeClassesVSC
{
    public class ArmePassive : Arme
    {
        /// <summary>
        /// constructeur de la classe ArmePassive
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        /// <param name="niveau"></param>
        /// <param name="amelioration"></param>
        public ArmePassive(string nom, string desc, string image, HashSet<Stat> particularite, List<HashSet<Stat>> statsNiveau)
            : base(nom, desc, image, particularite, statsNiveau)
        {
            AjoutStats(particularite);
        }

        /// <summary>
        /// declaration de l'attribut Amelioration avec son getter et setter
        /// </summary>
        public Amelioration Amelioration { get; set; }

        /// <summary>
        /// declaration de l'attribut ArmeAct avec son getter et setter
        /// </summary>
        public ArmeActive ArmeAct { get; set; }

        /// <summary>
        /// declaration de la methode ajouterAmelioration, qui permet de definir l'amelioration liée à l'arme passive
        /// </summary>
        /// <param name="amelio"></param>
        public void ajouterAmelioration(Amelioration amelio)
        {
            Amelioration = amelio;
        }

        /// <summary>
        /// declaration de la methode ajouterArmeActive qui permet de definir l'arme active necessaire à la transformation de notre arme passive
        /// </summary>
        /// <param name="arme"></param>
        public void ajouterArmeActive(ArmeActive arme)
        {
            ArmeAct = arme;
        }
    }
}
