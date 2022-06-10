using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public partial class Stat
    {
        private class StatEqualityComparer : EqualityComparer<Stat>
        {
            /// <summary>
            /// surcharge du protocole d'égalité entre deux Stat
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override bool Equals(Stat x, Stat y)
            {
                return ((byte)x.Nom).Equals((byte)y.Nom);
            }
            /// <summary>
            /// surcharge du GetHashCode d'une Stat
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override int GetHashCode([DisallowNull] Stat obj)
            {
                return obj.Nom.GetHashCode();
            }
        }
        /// <summary>
        /// déclaration de l'attribut FullEqComparer d'une Stat
        /// </summary>
        public static IEqualityComparer<Stat> FullEqComparer
        {
            get
            {
                if (statEqualityComparer == null)
                {
                    statEqualityComparer = new StatEqualityComparer();
                }
                return statEqualityComparer;
            }
        }
        /// <summary>
        /// déclaration de l'attribut statEqualityComparer d'une Stat
        /// </summary>
        private static StatEqualityComparer statEqualityComparer = null;
    }
}
