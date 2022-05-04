using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Element
    {
        public Element(string nom, string desc="N/A", string image="N/A")
        {
            Nom = nom;
            Description = desc;
            Image = image;
        }

        public string Nom { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public override string ToString()
        {
            return $"{Nom}{Description}";
        }
    }
}
