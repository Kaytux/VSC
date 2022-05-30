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

            Ennemie e1 = new Ennemie("Ennemie 1", "", "", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)));
            Ennemie e2 = new Ennemie("Ennemie 2", "", "", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)));

            AjoutCollection(lesArmesPassives,
                            new ArmePassive("Arme Passive 1","","", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40))),
                            new ArmePassive("Arme Passive 2", "", "", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40))));
            AjoutCollection(lesArmesActives,
                            new ArmeActive("Arme Active 1","","", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40))),
                            new ArmeActive("Arme Active 2", "", "", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40))));
            AjoutCollection(lesAmeliorations,
                            new Amelioration("Amelioration 1", "", "", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)),"Arme Active 1", "Arme Passive 1"),
                            new Amelioration("Amelioration 2", "", "", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)), "Arme Active 2", "Arme Passive 2"));
            AjoutCollection(lesPersonnages,
                            new Personnage("Antonio Belpaese",
                                            "Antonio Belpaese is one of the playable characters in Vampire Survivors. He is the character that every player begins with and he is the only free character in the game. His starting weapon is the Whip. He gains +10% Might every 10 levels until level 50. The maximum Might gained this way is +50%.",
                                            "antonio.png",
                                            ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 20),
                                                                        new Stat(Stat.NomStat.Armor, 1),
                                                                        new Stat(Stat.NomStat.Might, 1))),
                            new Personnage("Imelda Belpaese",
                                            "Imelda Belpaese is one of the playable characters in Vampire Survivors. Her starting weapon is Magic Wand. Imelda gains +10% Growth every 5 levels until level 15. The maximum Growth gained this way is +30%. ",
                                            "imelda.png",
                                            ConstructionParticularite()),
                            new Personnage("Pasqualina Belpaese",
                                            "Pasqualina Belpaese is one of the playable characters in Vampire Survivors. Her starting weapon is Runetracer. Pasqualina she gains +10% Speed every 5 levels until level 15. The maximum Speed gained this way is +30%, or +40% with the starting bonus included. ",
                                            "pasqualina.png",
                                            ConstructionParticularite(new Stat(Stat.NomStat.Speed, 10))),
                            new Personnage("Gennaro Belpaese",
                                            "Gennaro Belpaese is one of the playable characters in Vampire Survivors. His starting weapon is Knife.",
                                            "gennaro.png",
                                            ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 20),
                                                                        new Stat(Stat.NomStat.Amount, 1))),
                            new Personnage("Arca Ladonna",
                                            "Arca Ladonna is one of the playable characters in Vampire Survivors. His starting weapon is Fire Wand. Arca gains -5% Cooldown every 10 levels until level 30. The maximum Cooldown reduction gained this way is -15%.",
                                            "arca.png",
                                            ConstructionParticularite()),
                            new Personnage("Porta Ladonna",
                                            "Porta Ladonna is one of the playable characters in Vampire Survivors. Her starting weapon is Lightning Ring. Porta starts with -90% Cooldown bonus, which increases by 30% on every level up until negated upon reaching level 4, allowing the Lightning Ring to quickly kill enemies for experience. ",
                                            "antonio.png",
                                            ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 20),
                                                                      new Stat(Stat.NomStat.Armor, 1),
                                                                      new Stat(Stat.NomStat.Might, 1))));
            AjoutCollection(lesEnnemies,e1,e2);
            AjoutCollection(lesCartes,
                new Carte("Carte 1","","", new List<string>() { "Ennemie 1" }, new List<string>() { "Arme Passive 1" }),
                new Carte("Carte 2", "", "", new List<string>() { "Ennemie 2" }, new List<string>() { "Arme Passive 2" }));

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
