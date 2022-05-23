using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public interface IPersistanceManager
    {
        (IEnumerable<ArmePassive> ap,IEnumerable<Personnage> pers) ChargeDonnées();
        void SauvegardeDonnées(IEnumerable<ArmePassive> ap, IEnumerable<Personnage> pers);
    }
}
