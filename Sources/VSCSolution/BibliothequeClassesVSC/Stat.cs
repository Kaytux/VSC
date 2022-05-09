using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace BibliothequeClassesVSC
{
    public partial class Stat :IEquatable<Stat>, IComparable<Stat>,IComparable
    {
        /// <summary>
        /// Une stat possède sa valeur
        /// </summary>
        public int Valeur { get; set; }

        /// <summary>
        /// Une stat possède son nom
        /// </summary>
        public NomStat Nom { get; private set; }

        /// <summary>
        /// Constructeur de stat
        /// </summary>
        /// <param name="nom">Nom de la stat</param>
        /// <param name="valeur">Valeur de la stat</param>
        public Stat (NomStat nom, int valeur=0)
        {
            Nom = nom;
            Valeur = valeur;
        }

        public override string ToString()
        {
            string res = Nom.ToString() + " : ";
            string val=Valeur.ToString();

            if(Math.Sign(Valeur)==1) { val = "+" + Valeur.ToString(); }
            if (Valeur == 0) { return res + "-"; }
            switch (Nom)
            {
                case Stat.NomStat.MoveSpeed:
                case Stat.NomStat.Luck:
                    return res+ val+" %";
            }
            return res+val;
        }

        public bool Equals([AllowNull] Stat other)
        {
            return this.Nom.Equals(other.Nom);
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(obj, null)) return false;
            if(ReferenceEquals(obj, this)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals(obj as Stat);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }

        public int CompareTo([AllowNull] Stat other)
        {
            return ((byte)Nom).CompareTo((byte)(other.Nom));
        }

        int IComparable.CompareTo(object obj)
        {
            if(!(obj is Stat))
            {
                throw new ArgumentException("Argument is not a Stat", "obj");
            }
            Stat otherstat=obj as Stat;
            return this.CompareTo(otherstat);
        }

        public static bool operator <(Stat left, Stat right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Stat left, Stat right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Stat left, Stat right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >=(Stat left, Stat right)
        {
            return left.CompareTo(right) < 0;
        }
    }
}
