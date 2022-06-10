using System.Collections.Generic;

namespace BibliothequeClassesVSC
{
    /// <summary>
    /// Interface du Manager
    /// </summary>
    public interface IPersistanceManager
    {
        (IEnumerable<ArmePassive> lesArmesPassives,
            IEnumerable<ArmeActive> lesArmesActives,
            IEnumerable<Amelioration> lesAmeliorations,
            IEnumerable<Personnage> lesPersonnages,
            IEnumerable<Ennemie> lesEnnemies,
            IEnumerable<Carte> lesCartes,
            Dictionary<ulong, Dictionary<string, string>> lesNotes) ChargeDonnées();
        void SauvegardeDonnées(
            IEnumerable<ArmePassive> lesArmesPassives,
            IEnumerable<ArmeActive> lesArmesActives,
            IEnumerable<Amelioration> lesAmeliorations,
            IEnumerable<Personnage> lesPersonnages,
            IEnumerable<Ennemie> lesEnnemies,
            IEnumerable<Carte> lesCartes,
            Dictionary<ulong, Dictionary<string, string>> lesNotes);
    }
}