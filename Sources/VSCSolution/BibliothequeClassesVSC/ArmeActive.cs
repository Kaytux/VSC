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
        public ArmeActive(string nom, HashSet<Stat> particularite, string desc, string image)
            : base(nom, particularite, desc, image)
        {
            AjoutParticularite(particularite);
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
