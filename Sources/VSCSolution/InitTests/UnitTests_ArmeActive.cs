using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_ArmeActive
    {
        [Theory]
        [InlineData("Magic Wand")]
        [InlineData("Magic Wand", "This a magic wand !")]
        [InlineData("Magic Wand", "This a magic wand !", "./images/Magic_Wand.png")]
        public void TestConstructeurArmeActive(string nom, string desc = "N/A", string image = "N/A", byte ExpectedNiveau = 1)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            Amelioration amelioration = new Amelioration("Holy Wand", stats, "N/A", "N/A", null, null);
            ArmeActive arme = new ArmeActive(nom, stats,desc, image);

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

            ArmeActive active = new ArmeActive(nom, stats,"N/A","N/A");


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
