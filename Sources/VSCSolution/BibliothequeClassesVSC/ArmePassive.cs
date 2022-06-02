using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class ArmePassive:Arme
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

        public void ajouterAmelioration(Amelioration amelio)
        {
            Amelioration = amelio;
        }
    }
}
