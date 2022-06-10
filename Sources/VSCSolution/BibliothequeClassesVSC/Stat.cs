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

        /// <summary>
        /// redifinnition du ToString de Stat
        /// </summary>
        /// <returns></returns>
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
                    return res+ val+"%";
            }
            return res+val;
        }
        /// <summary>
        /// surcharge du protocole d'égalité, pour comparer deux Stat
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] Stat other)
        {
            return this.Nom.Equals(other.Nom) && this.Valeur.Equals(other.Valeur);
        }
        /// <summary>
        /// methode permettant de gérer les comparaisons entre des types diférent de Stat
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(obj, null)) return false;
            if(ReferenceEquals(obj, this)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals(obj as Stat);
        }
        /// <summary>
        /// surcharge de la méthode GetHashCode de Stat
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode() * Valeur.GetHashCode();
        }
        /// <summary>
        /// méthode de protocole d'égalité, uniquement sur le nom d'une Stat
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo([AllowNull] Stat other)
        {
            return ((byte)Nom).CompareTo((byte)(other.Nom));
        }
        /// <summary>
        /// methode permettant de gérer les comparaisons entre des types diférent de Stat
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if(!(obj is Stat))
            {
                throw new ArgumentException("Argument is not a Stat", "obj");
            }
            Stat otherstat=obj as Stat;
            return this.CompareTo(otherstat);
        }
        /// <summary>
        /// surcharge de l'opérateur "<" pour une Stat
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Stat left, Stat right)
        {
            return left.CompareTo(right) < 0;
        }
        /// <summary>
        /// surcharge de l'opérateur "<=" pour une Stat
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Stat left, Stat right)
        {
            return left.CompareTo(right) < 0;
        }
        /// <summary>
        /// surcharge de l'opérateur ">" pour une Stat
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Stat left, Stat right)
        {
            return left.CompareTo(right) < 0;
        }
        /// <summary>
        /// surcharge de l'opérateur ">=" pour une Stat
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Stat left, Stat right)
        {
            return left.CompareTo(right) < 0;
        }
    }
}
