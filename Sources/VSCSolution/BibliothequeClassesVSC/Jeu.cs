using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public struct Jeu
    {
        /// <summary>
        /// declaration du constructeur de Jeu
        /// </summary>
        /// <param name="description"></param>
        /// <param name="patch"></param>
        public Jeu(string description,PatchNote patch)
        {
            Description=description;
            Patch=patch;
        }
        /// <summary>
        /// declaration de l'attribut description avec son getter et setter
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// declaration de l'attribut Patch avec son getter et setter
        /// </summary>
        public PatchNote Patch { get; private set; }
        /// <summary>
        /// declaration de la structure PatchNote qui est compris dans la classe Jeu
        /// </summary>
        public struct PatchNote
        {
            /// <summary>
            /// declaration de l'attribut Num de PatchNote avec son getter et setter
            /// </summary>
            public byte Num { get; private set; }
            /// <summary>
            /// declaration de l'attribut Description de PatchNote avec son getter et setter
            /// </summary>
            public string Description { get; private set; }
            /// <summary>
            /// declaration de l'attribut Date de PatchNote avec son getter et setter
            /// </summary>
            public DateTime Date { get; private set; }
            /// <summary>
            /// declaration du constructeur de PatchNote
            /// </summary>
            /// <param name="num"></param>
            /// <param name="description"></param>
            /// <param name="date"></param>
            /// <exception cref="ArgumentException"></exception>
            public PatchNote(byte num, string description, DateTime date)
            {
                if (num < 0)
                {
                    throw new ArgumentException();
                }

                Num = num;
                Description = description;
                Date = date;
            }
            /// <summary>
            /// redifinission du ToString de PatchNote
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return "Patch notes " + Num + Date.ToLongDateString() + " : " + Description;
            }
        }

        /// <summary>
        /// redifinission du ToString de Jeu
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Description :\n\n" + Description + Patch;
        }
    }
}
