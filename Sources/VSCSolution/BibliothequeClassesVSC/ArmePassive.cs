using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    [DataContract]
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
        public ArmePassive(string nom, HashSet<Stat> particularite, string desc = "N/A", string image = "N/A", byte niveau = 1, Amelioration amelioration=null)
            : base(nom, particularite, desc, image, niveau) 
        {
            Amelioration = amelioration;
            AjoutParticularite(particularite);
        }

        /// <summary>
        /// declaration de l'attribut Amelioration avec son getter et setter
        /// </summary>
        [DataMember]
        public new Amelioration Amelioration { get; set; }
    }
}
