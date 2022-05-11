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
            public override bool Equals(Stat x, Stat y)
            {
                return ((byte)x.Nom).Equals((byte)y.Nom);
            }

            public override int GetHashCode([DisallowNull] Stat obj)
            {
                return obj.Nom.GetHashCode();
            }
        }

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

        private static StatEqualityComparer statEqualityComparer = null;
    }
}
