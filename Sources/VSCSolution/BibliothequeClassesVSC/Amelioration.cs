using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Amelioration(string nom, HashSet<Stat> particularite, string desc = "N/A", string image = "N/A", byte niveau = 1, ArmeActive active = null, ArmePassive passive = null)
            : base(nom, particularite, desc, image, niveau)
        {
            ArmeAct = active;
            ArmePass = passive;
            AjoutParticularite(particularite);
        }

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
