using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_ArmePassive
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
        public void TestStatsArmePasive()
        {
            string nom = "passive";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 20));
            stats.Add(new Stat(Stat.NomStat.Knockback, 20));
            stats.Add(new Stat(Stat.NomStat.Rarity, 10));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 15));

            List<HashSet<Stat>> statsNiveau = new List<HashSet<Stat>>();
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 2) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 4), new Stat(Stat.NomStat.Area, 3) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Growth, 8), new Stat(Stat.NomStat.MaxLevel, 4) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Luck, 12) });

            ArmePassive passive = new ArmePassive(nom, "N/A", "N/A", stats, statsNiveau);

            Assert.Equal(nom, passive.Nom);

            foreach (Stat particularite in stats)
            {
                foreach (Stat stat in passive.stats)
                {
                    if (particularite.Nom == stat.Nom)
                    {
                        Assert.Equal(particularite, stat);
                    }
                }
            }

            Assert.Equal("N/A", passive.Description);
            Assert.Equal("N/A", passive.Image);
        }
    }
}
