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
        public Amelioration(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1,ArmeActive active=null,ArmePassive passive=null)
            : base(nom, desc, image, niveau) 
        {
            ArmeAct = active;
            ArmePass = passive;
        }

        /// <summary>
        /// declaration de l'attribut ArmeAct (arme active necessaire à l'amélioration) avec son getter et setter
        /// </summary>
        public ArmeActive ArmeAct{get;set;}

        /// <summary>
        /// declaration de l'attribut ArmePass (arme passive necessaire à l'amélioration) avec son getter et setter
        /// </summary>
        public ArmePassive ArmePass { get; set; }

        /// <summary>
        /// méthode d'affichage qui permet d'afficher les noms de l'arme active et de l'arme passive nécessaire pour l'amélioration
        /// </summary>
        public void affichAmelioration()
        {
            Console.WriteLine("Arme Active : "+this.ArmeAct.Nom);
            Console.WriteLine("Arme Passive : " + this.ArmePass.Nom);
        }
    }
}
