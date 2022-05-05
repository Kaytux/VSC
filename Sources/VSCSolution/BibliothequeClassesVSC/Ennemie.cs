using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Ennemie : Entite
    {
        public Ennemie(string nom, Stat maxHealth, Stat moveSpeed, List<Stat> particularite, string desc = "N/A", string image = "N/A") : base(nom, maxHealth, moveSpeed, particularite, desc, image)
        {
        }
    }
}
