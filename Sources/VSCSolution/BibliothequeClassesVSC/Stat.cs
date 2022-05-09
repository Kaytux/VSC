using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace BibliothequeClassesVSC
{

    public partial class Stat : IComparable<Stat>
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
                    return res+ val+" %";
            }
            return res+val;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Stat)) { return false; }
            return this.Nom == ((Stat)obj).Nom;
        }

        public static Stat operator +(Stat a,Stat b)
        {
            a.Valeur += b.Valeur;
            return a;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Stat other)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Stat left, Stat right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Stat left, Stat right)
        {
            return !(left == right);
        }

        public static bool operator <(Stat left, Stat right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Stat left, Stat right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Stat left, Stat right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Stat left, Stat right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
