using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Element
    {
        /// <summary>
        /// constructeur de la classe abstraite Element
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        public Element(string nom, string desc="N/A", string image="N/A")
        {
            Nom = nom;
            Description = desc;
            Image = image;
        }

        /// <summary>
        /// declaration de l'attribut Nom avec son getter et setter
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// declaration de l'attribut Description avec son getter et setter
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// declaration de l'attribut Image (chemin d'acces vers l'image) avec getter et setter
        /// </summary>
        public string Image { get; set; }
    }
}
