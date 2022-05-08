using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Ennemie : Entite
    {
        public Ennemie(string nom,List<Stat> particularite, string desc = "N/A", string image = "N/A") : base(nom, desc, image)
        {
            foreach (Stat stat in particularite)
            {

            }
        }
    }
}
