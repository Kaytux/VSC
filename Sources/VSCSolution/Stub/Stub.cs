using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
                            new ArmePassive("Hollow Heart", "", "./Images/Sprite-Hollow_Heart.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)), new List<HashSet<Stat>>()),
                            new ArmePassive("Empty Tome", "", "./Images/Sprite-Empty_Tome.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)), new List<HashSet<Stat>>()),
                            new ArmePassive("Bracer","","./Images/Sprite-Bracer.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)), new List<HashSet<Stat>>())
                            );
            AjoutCollection(lesArmesActives,
                            new ArmeActive("Whip", "", "./Images/Sprite-Whip.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)), new List<HashSet<Stat>>()),
                            new ArmeActive("Magic Wand", "", "./Images/Sprite-Magic_Wand.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)), new List<HashSet<Stat>>()),
                            new ArmeActive("Knife", "Le couteau est une arme", "./Images/Sprite-Knife.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxLevel, 40)), new List<HashSet<Stat>>())                        
                            );
            AjoutCollection(lesAmeliorations,
                            new Amelioration("Bloody Tear", "", "./Images/Sprite-Bloody_Tear.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)),"Whip", "Hollow Heart",new List<HashSet<Stat>>()),
                            new Amelioration("Holy Wand","","./Images/Sprite-Holy_Wand.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)), "Magic Wand", "Empty Tome", new List<HashSet<Stat>>()),
                            new Amelioration("Thousand Edge","", "./Images/Sprite-Thousand_Edge.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40)), "Knife", "Bracer", new List<HashSet<Stat>>())
                            );
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

            LiensDesClasses(lesArmesPassives, lesArmesActives, lesAmeliorations, lesCartes, lesEnnemies);

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
        public void LiensDesClasses(HashSet<ArmePassive> armesPassives, HashSet<ArmeActive> armesActives, HashSet<Amelioration> ameliortions, HashSet<Carte> cartes, HashSet<Ennemie> ennemies)
        {
            foreach (Amelioration amelio in ameliortions)
            {
                foreach (ArmeActive active in armesActives)
                {
                    if (amelio.NomArmeAct == active.Nom)
                    {
                        amelio.ArmeAct = active;
                        active.ajouterAmelioration(amelio);
                    }
                }
                foreach (ArmePassive passive in armesPassives)
                {
                    if (amelio.NomArmePass == passive.Nom)
                    {
                        amelio.ArmePass = passive;
                        passive.ajouterAmelioration(amelio);
                        passive.ajouterArmeActive(amelio.ArmeAct);
                    }
                }
                foreach (ArmeActive active in armesActives)
                {
                    if (amelio.NomArmeAct == active.Nom)
                    {
                        active.ajouterArmePasssive(amelio.ArmePass);
                    }
                }
            }
            foreach (Carte carte in cartes)
            {
                carte.LesEnnemies = (from en in ennemies
                                     join nomen in carte.NomEnn on en.Nom equals nomen
                                     select en).ToList();

                carte.LesObjetsCaches = (from ap in armesPassives
                                         join objcach in carte.NomArmPass on ap.Nom equals objcach
                                         select ap).ToList();
            }
        }

    }
}
