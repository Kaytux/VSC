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

            Ennemie e1 = new Ennemie("Ennemie 1", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)));
            Ennemie e2 = new Ennemie("Ennemie 2", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)));
            ArmeActive a1 = new ArmeActive("Arme Active 1", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)));
            ArmeActive a2 = new ArmeActive("Arme Active 2", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)));
            ArmePassive p1 = new ArmePassive("Arme Passive 1", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)));
            ArmePassive p2 = new ArmePassive("Arme Passive 2", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)));

            AjoutCollection(lesArmesPassives,p1,p2);
            AjoutCollection(lesArmesActives,a1,a2);
            AjoutCollection(lesAmeliorations,
                new Amelioration("Amelioration 1", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)),"","",1,a1,p1),
                new Amelioration("Amelioration 2", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)), "", "", 1, a2, p2));
            AjoutCollection(lesPersonnages,
                new Personnage("Perso 1", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 2", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))));
            AjoutCollection(lesEnnemies,e1,e2);
            AjoutCollection(lesCartes,
                new Carte("Carte 1", new List<Ennemie>() { e1 }, new List<ArmePassive>() { p1 }),
                new Carte("Carte 2", new List<Ennemie>() { e2 }, new List<ArmePassive>() { p2 }));

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
