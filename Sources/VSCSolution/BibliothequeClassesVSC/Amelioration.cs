using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Amelioration : Arme
    {
        public Amelioration(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1,ArmeActive active=null,ArmePassive passive=null)
            : base(nom, desc, image, niveau) 
        {
            ArmeAct = active;
            ArmePass = passive;
        }

        public ArmeActive ArmeAct{get;set;}

        public ArmePassive ArmePass { get; set; }

        public void affichAmelioration()
        {
            Console.WriteLine("Arme Active : "+this.ArmeAct.Nom);
            Console.WriteLine("Arme Passive : " + this.ArmePass.Nom);
        }
    }
}
