using System.Collections.Generic;

namespace BibliothequeClassesVSC
{
    public class Amelioration : Arme
    {
        /// <summary>
        /// constructeur de la classe Amelioration
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        /// <param name="niveau"></param>
        /// <param name="active"></param>
        /// <param name="passive"></param>
        public Amelioration(string nom, string desc, string image, HashSet<Stat> particularite, string active, string passive, List<HashSet<Stat>> statsNiveau)
            : base(nom, desc, image, particularite, statsNiveau)
        {
            NomArmeAct = active;
            NomArmePass = passive;
            AjoutStats(particularite);
            //active.ajouterAmelioration(this); 
            //passive.ajouterAmelioration(this);
        }

        /// <summary>
        /// Ajout de l'attribut NomArmeAct qui correspond au nom de l'arme active necessaire à la création de l'amélioration
        /// </summary>
        public string NomArmeAct { get; set; }
        /// <summary>
        /// Ajout de l'attribut NomArmePass qui correspond au nom de l'arme passive necessaire à la création de l'amélioration
        /// </summary>
        public string NomArmePass { get; set; }

        /// <summary>
        /// declaration de l'attribut ArmeAct (arme active necessaire à l'amélioration) avec son getter et setter
        /// </summary>
        public ArmeActive ArmeAct { get; set; }


        /// <summary>
        /// declaration de l'attribut ArmePass (arme passive necessaire à l'amélioration) avec son getter et setter
        /// </summary>
        public ArmePassive ArmePass { get; set; }
    }
}
