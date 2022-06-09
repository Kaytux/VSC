using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public interface IPersistanceManager
    {
        (IEnumerable<ArmePassive> lesArmesPassives,
            IEnumerable<ArmeActive> lesArmesActives,
            IEnumerable<Amelioration> lesAmeliorations,
            IEnumerable<Personnage> lesPersonnages,
            IEnumerable<Ennemie> lesEnnemies,
            IEnumerable<Carte> lesCartes) ChargeDonnées();
        void SauvegardeDonnées(
            IEnumerable<ArmePassive> lesArmesPassives,
            IEnumerable<ArmeActive> lesArmesActives,
            IEnumerable<Amelioration> lesAmeliorations,
            IEnumerable<Personnage> lesPersonnages,
            IEnumerable<Ennemie> lesEnnemies,
            IEnumerable<Carte> lesCartes);
    }
}