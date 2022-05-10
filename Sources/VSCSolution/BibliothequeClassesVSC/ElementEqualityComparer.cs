using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public abstract partial class Element
    {
        private class ElementEqualityComparer : EqualityComparer<Element>
        {
            public override bool Equals(Element x, Element y)
            {
                return x.GetType().Equals(y.GetType()) && x.Nom.Equals(y.Nom);
            }

            public override int GetHashCode([DisallowNull] Element obj)
            {
                return obj.Nom.GetHashCode();
            }
        }

        public static IEqualityComparer<Element> FullEqComparer
        {
            get
            {
                if (elementEqualityComparer == null)
                {
                    elementEqualityComparer = new ElementEqualityComparer();
                }
                return elementEqualityComparer;
            }
        }

        private static ElementEqualityComparer elementEqualityComparer = null;
    }
}
