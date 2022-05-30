using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_ArmePassive
    {
        [Theory]
        [InlineData("Empty Tome")]
        [InlineData("Empty Tome", "A huge empty tome")]
        [InlineData("Empty Tome", "A huge empty tome", "./images/Empty_Tome.png")]
        public void TestConstructeurArmePassive(string nom, string desc = "N/A", string image = "N/A", byte ExpectedNiveau = 1)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            Amelioration amelioration = new Amelioration("Holy Wand", stats, "N/A", "N/A", null, null);
            ArmePassive arme = new ArmePassive(nom, stats, desc, image);

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

            ArmePassive passive = new ArmePassive(nom, stats,"N/A","N/A");

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
