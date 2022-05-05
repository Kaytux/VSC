using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract class Element
    {
        public Element(string nom, string desc="N/A", string image="N/A")
        {
            Nom = nom;
            Description = desc;
            Image = image;
        }

        public string Nom { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public override string ToString()
        {
            return $"{Nom} {Description}";
        }
    }
}
