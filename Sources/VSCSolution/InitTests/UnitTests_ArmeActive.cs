using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_ArmeActive
    {
        [Fact]
        public void TestConstructeurArmeActive()
        {
            string nom = "Magic Wand";
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
            ArmeActive arme = new ArmeActive(nom, desc, image, stats, statsNiveau);

            arme.Amelioration = amelioration;

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(ExpectedNiveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }

        [Fact]
        public void TestStatsArmeActive()
        {
            string nom = "active";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 50));
            stats.Add(new Stat(Stat.NomStat.Knockback, 20));
            stats.Add(new Stat(Stat.NomStat.Rarity, 15));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 15));

            List<HashSet<Stat>> statsNiveau = new List<HashSet<Stat>>();
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 2) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 4), new Stat(Stat.NomStat.Area, 3) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Growth, 8), new Stat(Stat.NomStat.MaxLevel, 4) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Luck, 12) });

            ArmeActive active = new ArmeActive(nom, "N/A","N/A", stats, statsNiveau);

            Assert.Equal(nom, active.Nom);

            foreach (Stat particularite in stats)
            {
                foreach (Stat stat in active.stats)
                {
                    if (particularite.Nom == stat.Nom)
                    {
                        Assert.Equal(particularite, stat);
                    }
                }
            }

            Assert.Equal("N/A", active.Description);
            Assert.Equal("N/A", active.Image);
        }
    }
}
