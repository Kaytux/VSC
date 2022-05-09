using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Arme: Element,IStatAffichable
    {
        /// <summary>
        /// constructeur de la classe abstraite  Arme
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        /// <param name="niveau"></param>
        public Arme(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1)
            : base(nom, desc, image)
        {
            Niveau = niveau;
        }

        /// <summary>
        /// declaration de l'attribut Niveau avec son getter et setter
        /// </summary>
        public byte Niveau { get; set; }

        /// <summary>
        /// méthode qui permet d'augmenter de 1 le Niveau d'une arme 
        /// </summary>
        public void AugmenterNiveau()
        {
            ++this.Niveau;
        }

        /// <summary>
        /// méthode qui permet de baisser de 1 le Niveau d'une arme 
        /// </summary>
        public void BaisserNiveau()
        {
            --this.Niveau;
        }

        public void AffichStats() { }
    }
}
