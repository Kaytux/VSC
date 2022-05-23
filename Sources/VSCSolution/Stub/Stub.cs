using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Stub
{
    public class Stub : IPersistanceManager
    {
        public (IEnumerable<ArmePassive> ap, IEnumerable<Personnage> pers) ChargeDonnées()
        {
            HashSet<ArmePassive> ap = new HashSet<ArmePassive>();
            HashSet<Personnage> pers = new HashSet<Personnage>();
            AjoutCollection(ap,
                new ArmePassive("Armes Passives 1"),
                new ArmePassive("Armes Passives 2"));
            AjoutCollection(pers,
                new Personnage("Perso 1", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 2", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 3", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 4", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))));
            return (ap,pers);
        }

        public void SauvegardeDonnées(IEnumerable<ArmePassive> ap, IEnumerable<Personnage> pers)
        {
            Debug.WriteLine("Sauvegarde demandée");
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
