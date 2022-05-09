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
        public ArmeActive(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, Amelioration amelioration=null)
            : base(nom, desc, image, niveau)
        {
            Amelioration = amelioration;
        }

        /// <summary>
        /// declaration de l'attribut Amelioration avec son getter et setter
        /// </summary>
        Amelioration Amelioration { get; set; }

        /// <summary>
        /// déclaration de la méthode AffichAmelioration qui permet l'affichage le nom de l'arme améliorée possible avec l'arme actuelle
        /// </summary>
        public void AffichAmelioration()
        {
            Console.WriteLine("Amelioration : " + this.Amelioration.Nom);
        }
    }
}
