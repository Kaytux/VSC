using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Arme: Element
    {
        public Arme(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1)
            : base(nom, desc, image)
        {
            Niveau = niveau;
        }

        public byte Niveau { get; set; }

        public void AugmenterNiveau()
        {
            ++this.Niveau;
        }

        public void BaisserNiveau()
        {
            --this.Niveau;
        }
    }
}
