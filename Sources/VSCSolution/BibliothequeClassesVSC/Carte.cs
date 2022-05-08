using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Carte
    {
        public List<Ennemie> LesEnnemies;
        public List<ArmePassive> LesObjetsCaches;

        public Carte(List<Ennemie> lesEnnemies, List<ArmePassive> lesObjetsCaches)
        {
            LesEnnemies = lesEnnemies;
            LesObjetsCaches = lesObjetsCaches;
        }
    }
}
