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
            byte ExpectedNiveau = 1;

            HashSet<Stat> particularites = new HashSet<Stat>();
            particularites.Add(new Stat(Stat.NomStat.MaxLevel, 20));
            particularites.Add(new Stat(Stat.NomStat.Knockback, 20));
            particularites.Add(new Stat(Stat.NomStat.Rarity, 10));
            particularites.Add(new Stat(Stat.NomStat.CritRate, 5));
            particularites.Add(new Stat(Stat.NomStat.CritMultiplier, 15));

            List<HashSet<Stat>> statsNiveau = new List<HashSet<Stat>>();
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 2) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 4), new Stat(Stat.NomStat.Rarity, 3) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritMultiplier, 8), new Stat(Stat.NomStat.MaxLevel, 4) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 12) });

            Amelioration amelioration = new Amelioration("Holy Wand", "N/A", "N/A", particularites, nom, "N/A", statsNiveau);
            ArmeActive arme = new ArmeActive(nom, desc, image, particularites, statsNiveau);

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

            HashSet<Stat> particularites = new HashSet<Stat>();
            particularites.Add(new Stat(Stat.NomStat.MaxLevel, 20));
            particularites.Add(new Stat(Stat.NomStat.Knockback, 20));
            particularites.Add(new Stat(Stat.NomStat.Rarity, 10));
            particularites.Add(new Stat(Stat.NomStat.CritRate, 5));
            particularites.Add(new Stat(Stat.NomStat.CritMultiplier, 15));

            List<HashSet<Stat>> statsNiveau = new List<HashSet<Stat>>();
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 2) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 4), new Stat(Stat.NomStat.Rarity, 3) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritMultiplier, 8), new Stat(Stat.NomStat.MaxLevel, 4) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 12) });

            ArmeActive active = new ArmeActive(nom, "N/A","N/A", particularites, statsNiveau);

            Assert.Equal(nom, active.Nom);

            foreach (Stat particularite in particularites)
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
