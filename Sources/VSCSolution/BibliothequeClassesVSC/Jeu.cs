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
            public byte Num { get; private set; }
            public string Description { get; private set; }
            public DateTime Date { get; private set; }
            public PatchNote(byte num, string description, DateTime date)
            {
                Num = num;
                Description = description;
                Date = date;
            }
            
            

            public override string ToString()
            {
                return "Patch notes " + Num + Date.ToLongDateString() + " : " + Description;
            }
        }

        public override string ToString()
        {
            return "Description :\n\n" + Description + Patch;
        }
    }
}
