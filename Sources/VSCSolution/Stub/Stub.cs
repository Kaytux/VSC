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

            AjoutCollection(lesEnnemies,
                           new Ennemie("Bat", "Bat is an enemy that appears in Mad Forest.", "./Images/Sprite-Bat.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 1), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 5), new Stat(Stat.NomStat.MoveSpeed, 140), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Red-Eyed Bat", "Red-Eyed Bat is an enemy that appears in Mad Forest and Gallo Tower. It only appears as a normal enemy.", "./Images/Sprite-Red_Eyed_Bat.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 5), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 5), new Stat(Stat.NomStat.MoveSpeed, 140), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Crimson Bat", "Crimson Bat is an enemy that appears in Gallo Tower. It only appears as a normal enemy.", "./Images/Sprite-Crimson_Bat.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 11), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 5), new Stat(Stat.NomStat.MoveSpeed, 200), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Skullino", "Skullino is an enemy that appears in Gallo Tower and The Bone Zone. It only appears as a normal enemy.", "./Images/Sprite-Skullino.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 6), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 5), new Stat(Stat.NomStat.MoveSpeed, 200), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Skulorosso", "Skulorosso is an enemy that appears in Gallo Tower and The Bone Zone. It only appears as a normal enemy.", "./Images/Sprite-Skulorosso.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 10), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 5), new Stat(Stat.NomStat.MoveSpeed, 200), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Glowing Bat", "Glowing Bat is a boss enemy that appears in Mad Forest, Inlaid Library, Dairy Plant and Gallo Tower. It mostly appears as a boss, but in later waves of Mad Forest it also appears as a normal enemy. When it appears as a boss it has a chance to drop a Treasure Chest.", "./Images/Sprite-Glowing_Bat.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 50), new Stat(Stat.NomStat.XpGiven, 30), new Stat(Stat.NomStat.Might, 10), new Stat(Stat.NomStat.MoveSpeed, 140), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Silver Bat", "Silver Bat is a boss enemy that appears in Mad Forest and Inlaid Library. It first appears as a boss, but in later stages of Mad Forest it also appears as a normal enemy. When it appears as a boss it has a chance to drop a Treasure Chest.", "./Images/Sprite-Silver_Bat.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 50), new Stat(Stat.NomStat.XpGiven, 30), new Stat(Stat.NomStat.Might, 10), new Stat(Stat.NomStat.MoveSpeed, 140), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Skelangue", "Skelangue is an enemy that appears in Gallo Tower and The Bone Zone. In Gallo Tower it first appears as a boss and later also as a normal enemy and in The Bone Zone only as a normal enemy. It cannot drop a Treasure Chest.", "./Images/Sprite-Skelangue.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 15), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 5), new Stat(Stat.NomStat.MoveSpeed, 100), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Skeleton", "Skeleton is an enemy that appears in Mad Forest, Dairy Plant, Gallo Tower and The Bone Zone. In Mad Forest, Gallo Tower and The Bone Zone it only appears as a normal enemy. In Dairy Plant it appears as a normal enemy and as a part of a Swarm map event.", "./Images/Sprite-Skeleton.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 15), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 10), new Stat(Stat.NomStat.MoveSpeed, 100), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Flower", "Flower is an enemy that appears in Mad Forest. It initially appears as part of Flower Wall event, and later also as a normal enemy.", "./Images/Sprite-Flower.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 30), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 1), new Stat(Stat.NomStat.MoveSpeed, 20), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Zombie", "Zombie is an enemy that appears in Mad Forest. It only appears as a normal enemy.", "./Images/Sprite-Zombie.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 10), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 10), new Stat(Stat.NomStat.MoveSpeed, 100), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Gray Mudman", "Gray Mudman is an enemy that appears in Mad Forest. It only appears as a normal enemy.", "./Images/Sprite-Gray_Mudman.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 70), new Stat(Stat.NomStat.XpGiven, 3), new Stat(Stat.NomStat.Might, 10), new Stat(Stat.NomStat.MoveSpeed, 100), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Green Mudman", "Green Mudman is an enemy that appears in Mad Forest. It only appears as a normal enemy.", "./Images/Sprite-Green_Mudman.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 15), new Stat(Stat.NomStat.XpGiven, 3), new Stat(Stat.NomStat.Might, 10), new Stat(Stat.NomStat.MoveSpeed, 100), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Werewolf", "Werewolf is an enemy that appears in Mad Forest. It only appears as a normal enemy.", "./Images/Sprite-Werewolf.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 180), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 14), new Stat(Stat.NomStat.MoveSpeed, 130), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Ghost", "Ghost is an enemy that appears in Mad Forest, Inlaid Library, Gallo Tower and Moongolow. It only appears as a normal enemy.", "./Images/Sprite-Ghost.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 10), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 5), new Stat(Stat.NomStat.MoveSpeed, 200), new Stat(Stat.NomStat.KnockbackReceive, 0))),
                           new Ennemie("Mud", "Mud is an enemy that appears in Inlaid Library. It only appears as a normal enemy.", "./Images/Sprite-Mud.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 5), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 5), new Stat(Stat.NomStat.MoveSpeed, 140), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Lion Head", "Lion Head is an enemy that appears in Inlaid Library. It only appears as a normal enemy. Killing 3,000 Lion Heads is the requirement for unlocking Yatta Cavallo.", "./Images/Sprite-Lion_Head.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 3), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 3), new Stat(Stat.NomStat.MoveSpeed, 200), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Dragon Shrimp", "Dragon Shrimp is an enemy that appears in Gallo Tower. It only appears as a normal enemy. Killing a total of 3,000 Dragon Shrimps, including Flame Dragon Shrimps, Serpentine Dragon Shrimps and Serpentine Flame Dragon Shrimps, is the requirement for unlocking O'Sole Meeo.", "./Images/Sprite-Dragon_Shrimp.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 4), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 3), new Stat(Stat.NomStat.MoveSpeed, 200), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Flame Dragon Shrimp", "Flame Dragon Shrimp is an enemy that appears in Gallo Tower. It only appears as a normal enemy. Killing a total of 3,000 Dragon Shrimps, including Flame Dragon Shrimps, Serpentine Dragon Shrimps and Serpentine Flame Dragon Shrimps, is the requirement for unlocking O'Sole Meeo.", "./Images/Sprite-Flame_Dragon_Shrimp.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 20), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 8), new Stat(Stat.NomStat.MoveSpeed, 200), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Red Shade", "Red Shade is an enemy that appears in Inlaid Library. It only appears as a part of the map event, Shade Bomb. It chases the player and upon getting close enough it triggers its self-destruct, exploding 2 seconds later for 50 damage. It does not collide with other enemies.", "./Images/Sprite-Red_Shade.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 11), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 3), new Stat(Stat.NomStat.MoveSpeed, 330), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Poltergeist", "Poltergeist is an enemy that appears in Gallo Tower. It only appears in the map event, Poltergeist Roulette, which can be triggered by stepping on a trap. Poltergeist's health is based on the player's level. If the player gets close enough, it triggers its self-destruct, exploding 2 seconds later for 50 damage. It has no collision and does not take knockback.", "./Images/Sprite-Poltergeist.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 1), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 3), new Stat(Stat.NomStat.MoveSpeed, 0), new Stat(Stat.NomStat.KnockbackReceive, 0))),
                           new Ennemie("Nesuferit", "Nesuferit is an enemy that appears in Inlaid Library. It only appears as a boss and has a chance to drop a Treasure Chest. Killing Nesuferit is the requirement for unlocking hyper mode for Inlaid Library. It is resistant to freeze, instant kill effects and debuffs.", "./Images/Sprite-Nesuferit.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 250), new Stat(Stat.NomStat.XpGiven, 50), new Stat(Stat.NomStat.Might, 30), new Stat(Stat.NomStat.MoveSpeed, 210), new Stat(Stat.NomStat.KnockbackReceive, 0))),
                           new Ennemie("Count", "Count is an enemy that appears in Inlaid Library. It only appears as a boss and has a chance to drop a Treasure Chest. It is resistant to freeze.", "./Images/Sprite-Count.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 200), new Stat(Stat.NomStat.XpGiven, 50), new Stat(Stat.NomStat.Might, 30), new Stat(Stat.NomStat.MoveSpeed, 160), new Stat(Stat.NomStat.KnockbackReceive, 0))),
                           new Ennemie("Giant Skull", "Giant Skull is an enemy that appears in Gallo Tower and The Bone Zone. It only appears as a boss and has a chance to drop a Treasure Chest.", "./Images/Sprite-Giant_Skull.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 50), new Stat(Stat.NomStat.XpGiven, 30), new Stat(Stat.NomStat.Might, 10), new Stat(Stat.NomStat.MoveSpeed, 140), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Mummy", "Mummy is an enemy that appears in Inlaid Library. It only appears as a normal enemy.", "./Images/Sprite-Mummy.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 15), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 3), new Stat(Stat.NomStat.MoveSpeed, 140), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Medusa Head", "Medusa Head is an enemy that appears in Inlaid Library. It appears as a normal enemy as well as a part of Medusa Swarm and Medusa Wall map events. Medusa Head's moves horizontally accross the screen in a wavy pattern, instead of homing to the player. The unit has a fast variant, which has higher movespeed, and and aggro variant, which has normal movespeed, but does not have the fixed movement restriction, and chases the player like most other enemies.", "./Images/Sprite-Medusa_Head.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 25), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 1), new Stat(Stat.NomStat.MoveSpeed, 240), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Harpy", "Harpy is an enemy that appears in Gallo Tower. It only appears as a normal enemy.", "./Images/Sprite-Harpy.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 25), new Stat(Stat.NomStat.XpGiven, 2), new Stat(Stat.NomStat.Might, 1), new Stat(Stat.NomStat.MoveSpeed, 240), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Small Ectoplasm", "Small Ectoplasm is an enemy that appears in Inlaid Library. It only appears as a normal enemy.", "./Images/Sprite-Small_Ectoplasm", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 1), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 2), new Stat(Stat.NomStat.MoveSpeed, 160), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Ectoplasm", "Ectoplasm is an enemy that appears in Inlaid Library and Dairy Plant. In Inlaid Library it only appears as a normal enemy, and in Dairy Plant it appears as an event enemy from a trap.", "./Images/Sprite-Ectoplasm.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 15), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 4), new Stat(Stat.NomStat.MoveSpeed, 160), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Imp", "Imp is an enemy that appears in Gallo Tower. It appears as a normal enemy and in the map event, Imp Swarm, triggered by stepping on a trap.", "./Images/Sprite-Imp.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 13), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 4), new Stat(Stat.NomStat.MoveSpeed, 160), new Stat(Stat.NomStat.KnockbackReceive, 1))),
                           new Ennemie("Lesser Dullahan", "Lesser Dullahan is an enemy that appears in Gallo Tower. It only appears as a normal enemy.", "./Images/Sprite-Lesser_Dullahan.png", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 35), new Stat(Stat.NomStat.XpGiven, 1), new Stat(Stat.NomStat.Might, 8), new Stat(Stat.NomStat.MoveSpeed, 100), new Stat(Stat.NomStat.KnockbackReceive, 1)))
                           );

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
                                                                        new Stat(Stat.NomStat.Might, 1)),
                                            "Whip"),
                            new Personnage("Imelda Belpaese",
                                            "Imelda Belpaese is one of the playable characters in Vampire Survivors. Her starting weapon is Magic Wand. Imelda gains +10% Growth every 5 levels until level 15. The maximum Growth gained this way is +30%. ",
                                            "imelda.png",
                                            ConstructionParticularite(),
                                            "Magic Wand"),
                            new Personnage("Pasqualina Belpaese",
                                            "Pasqualina Belpaese is one of the playable characters in Vampire Survivors. Her starting weapon is Runetracer. Pasqualina she gains +10% Speed every 5 levels until level 15. The maximum Speed gained this way is +30%, or +40% with the starting bonus included. ",
                                            "pasqualina.png",
                                            ConstructionParticularite(new Stat(Stat.NomStat.Speed, 10)),
                                            "Runetracer"),
                            new Personnage("Gennaro Belpaese",
                                            "Gennaro Belpaese is one of the playable characters in Vampire Survivors. His starting weapon is Knife.",
                                            "gennaro.png",
                                            ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 20),
                                                                        new Stat(Stat.NomStat.Amount, 1)),
                                            "Knife"),
                            new Personnage("Arca Ladonna",
                                            "Arca Ladonna is one of the playable characters in Vampire Survivors. His starting weapon is Fire Wand. Arca gains -5% Cooldown every 10 levels until level 30. The maximum Cooldown reduction gained this way is -15%.",
                                            "arca.png",
                                            ConstructionParticularite(),
                                            "Fire Wand"),
                            new Personnage("Porta Ladonna",
                                            "Porta Ladonna is one of the playable characters in Vampire Survivors. Her starting weapon is Lightning Ring. Porta starts with -90% Cooldown bonus, which increases by 30% on every level up until negated upon reaching level 4, allowing the Lightning Ring to quickly kill enemies for experience. ",
                                            "antonio.png",
                                            ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 20),
                                                                      new Stat(Stat.NomStat.Armor, 1),
                                                                      new Stat(Stat.NomStat.Might, 1)),
                                            "Lightning Ring"));
            AjoutCollection(lesEnnemies,e1,e2);
            AjoutCollection(lesCartes,
                new Carte("Carte 1","","", new List<string>() { "Ennemie 1" }, new List<string>() { "Arme Passive 1" }),
                new Carte("Carte 2", "", "", new List<string>() { "Ennemie 2" }, new List<string>() { "Arme Passive 2" }));

            LiensDesClasses(lesArmesPassives, lesArmesActives, lesAmeliorations, lesCartes, lesEnnemies,lesPersonnages);

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
        public void LiensDesClasses(HashSet<ArmePassive> armesPassives, HashSet<ArmeActive> armesActives, HashSet<Amelioration> ameliortions, HashSet<Carte> cartes, HashSet<Ennemie> ennemies,HashSet<Personnage> persos)
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
            foreach (Personnage p in persos)
            {
                p.Arme = armesActives.Where(a => a.Nom == p.NomArme).DefaultIfEmpty().First();
            }
        }

    }
}
