using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Stub
{
    public class Stub : IPersistanceManager
    {
        public void SauvegardeDonnées(IEnumerable<ArmePassive> lesArmesPassives,
                                      IEnumerable<ArmeActive> lesArmesActives, 
                                      IEnumerable<Amelioration> lesAmeliorations,
                                      IEnumerable<Personnage> lesPersonnages,
                                      IEnumerable<Ennemie> lesEnnemies,
                                      IEnumerable<Carte> lesCartes)
        {
            Debug.WriteLine("Sauvegarde demandée");
        }
        public (IEnumerable<ArmePassive> lesArmesPassives, 
            IEnumerable<ArmeActive> lesArmesActives, 
            IEnumerable<Amelioration> lesAmeliorations, 
            IEnumerable<Personnage> lesPersonnages,
            IEnumerable<Ennemie> lesEnnemies,
            IEnumerable<Carte> lesCartes) ChargeDonnées()
        {
            HashSet<ArmePassive> lesArmesPassives = new HashSet<ArmePassive>();
            HashSet<ArmeActive> lesArmesActives = new HashSet<ArmeActive>();
            HashSet<Amelioration> lesAmeliorations = new HashSet<Amelioration>();
            HashSet<Personnage> lesPersonnages = new HashSet<Personnage>();
            HashSet<Ennemie> lesEnnemies = new HashSet<Ennemie>();
            HashSet<Carte> lesCartes = new HashSet<Carte>();
            AjoutCollection(lesArmesPassives,
                new ArmePassive("Armes Passives 1"),
                new ArmePassive("Armes Passives 2"));
            AjoutCollection(lesPersonnages,
                new Personnage("Perso 1", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 2", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 3", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 4", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))));
            return (lesArmesPassives,lesArmesActives,lesAmeliorations, lesPersonnages, lesEnnemies, lesCartes);
        }
        private void AjoutCollection<T>(HashSet<T> list, params T[] liste) where T : Element
        {
            list.UnionWith(liste);
        }

        private HashSet<Stat> ConstructionParticularite(params Stat[] liste)
        {
            HashSet<Stat> res = new HashSet<Stat>();
            res.UnionWith(liste);
            return res;
        }
    }
}
