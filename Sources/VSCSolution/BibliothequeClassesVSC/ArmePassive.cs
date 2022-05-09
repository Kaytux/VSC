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
    public ArmePassive(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, Amelioration amelioration=null)
            : base(nom, desc, image, niveau) 
        {
            Amelioration = amelioration;
        }

        /// <summary>
        /// declaration de l'attribut Amelioration avec son getter et setter
        /// </summary>
        public Amelioration Amelioration { get; set; }

        /// <summary>
        /// déclaration de la méthode AffichAmelioration qui permet l'affichage le nom de l'arme améliorée possible avec l'arme actuelle
        /// </summary>
        public void AfficheArme()
        {
            if (Amelioration != null)
            {
                Console.WriteLine("\n---\nNom : " + this.Nom + "\nDescription : " + this.Description + "\nImage : " + this.Image + "\nNiveau : " + this.Niveau + "\nAmélioration possible : " + this.Amelioration.Nom + "\n---\n");
            }
            else
            {
                Console.WriteLine("\n---\nNom : " + this.Nom + "\nDescription : " + this.Description + "\nImage : " + this.Image + "\nNiveau : " + this.Niveau + "\nAmélioration possible : N/A\n---\n");
            }
        }
    }
}
