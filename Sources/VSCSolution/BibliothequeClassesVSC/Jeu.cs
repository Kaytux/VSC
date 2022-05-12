using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public struct Jeu
    {
        public Jeu(string description,PatchNote patch)
        {
            Description=description;
            Patch=patch;
        }
        
        public string Description { get; private set; }
        public PatchNote Patch { get; private set; }

        public struct PatchNote
        {
            public PatchNote(byte num1,byte num2,byte num3,string description)
            {
                Num1 = num1;
                Num2 = num2;
                Num3 = num3;
                Description = description;
            }
            
            public byte Num1 { get; private set; }
            public byte Num2 { get; private set; }
            public byte Num3 { get; private set; }
            public string Description { get; private set; }

            public override string ToString()
            {
                return "\n\nPatch notes " + Num1 + "." + Num2 + Num3 + " :\n\n" + Description;
            }
        }

        public override string ToString()
        {
            return "Description :\n\n" + Description + Patch;
        }
    }
}
