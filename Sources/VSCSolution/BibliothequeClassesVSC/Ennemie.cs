using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Ennemie : Entite
    {
        public Ennemie(string nom, string desc = "N/A", string image = "N/A", Stat maxHealth = null, Stat moveSpeed = null) : base(nom, desc, image, maxHealth, moveSpeed)
        {
        }
    }
}
