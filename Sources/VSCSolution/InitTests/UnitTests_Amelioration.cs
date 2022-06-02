using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_Amelioration
    {

        [Fact]
        public void TestConstructeurArmePassive()
        {
            string nom = "Empy Tome";
            string desc = "Test desc";
            string image = "test/img";
            byte ExpectedNiveau = 0;

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            List<HashSet<Stat>> statsNiveau = new List<HashSet<Stat>>();
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 2) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 4), new Stat(Stat.NomStat.Area, 3) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Growth, 8), new Stat(Stat.NomStat.MaxLevel, 4) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Luck, 12) });

            Amelioration amelioration = new Amelioration("Holy Wand", "N/A", "N/A", stats, nom, "N/A", statsNiveau);
            ArmePassive arme = new ArmePassive(nom, desc, image, stats, statsNiveau);

            arme.Amelioration = amelioration;

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(ExpectedNiveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }

        [Fact]
        public void TestConstructeurAvecArmeActEtPas()
        {
            string nom = "Holy Wand";
            string desc = "Test desc";
            string image = "test/img";
            byte ExpectedNiveau = 1;

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            List<HashSet<Stat>> statsNiveau = new List<HashSet<Stat>>();
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 2) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 4), new Stat(Stat.NomStat.Area, 3) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Growth, 8), new Stat(Stat.NomStat.MaxLevel, 4) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Luck, 12) });

            ArmeActive active = new ArmeActive("Magic Wand","N/A","N/A",stats, statsNiveau);
            ArmePassive passive = new ArmePassive("Empty Tome", "N/A","N/A", stats, statsNiveau);
            Amelioration amelioration = new Amelioration(nom, desc, image, stats, "Magic Wand", "Empty Tome", statsNiveau);

            amelioration.ArmeAct = active;
            amelioration.ArmePass = passive;

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(ExpectedNiveau, amelioration.Niveau);
            Assert.Equal("Magic Wand", amelioration.NomArmeAct);
            Assert.Equal("Empty Tome", amelioration.NomArmePass);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }

        [Fact]
        public void TestStatsAmelioration()
        {
            string nom = "Holy Wand";
            string desc = "Test desc";
            string image = "test/img";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 10));
            stats.Add(new Stat(Stat.NomStat.Knockback, 20));
            stats.Add(new Stat(Stat.NomStat.Rarity, 30));
            stats.Add(new Stat(Stat.NomStat.CritRate, 10));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 15));

            List<HashSet<Stat>> statsNiveau = new List<HashSet<Stat>>();
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 2) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 4), new Stat(Stat.NomStat.Area, 3) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Growth, 8), new Stat(Stat.NomStat.MaxLevel, 4) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Luck, 12) });


            Amelioration amelioration = new Amelioration(nom, desc, image, stats, "Magic Wand", "Empty Tome", statsNiveau);

            Assert.Equal(nom, amelioration.Nom);

            foreach (Stat particularite in stats)
            {
                foreach (Stat stat in amelioration.stats)
                {
                    if (particularite.Nom == stat.Nom)
                    {
                        Assert.Equal(particularite, stat);
                    }
                }
            }

            Assert.Equal("N/A", amelioration.Description);
            Assert.Equal("N/A", amelioration.Image);
        }
    }
}
