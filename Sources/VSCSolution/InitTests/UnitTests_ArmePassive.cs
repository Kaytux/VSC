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
        [InlineData("Empty Tome","A huge empty tome")]
        [InlineData("Empty Tome", "A huge empty tome", "./images/Empty_Tome.png")]
        [InlineData("Empty Tome", "A huge empty tome", "./images/Empty_Tome.png",42)]
        public void TestConstructeurSansAmelioration(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, Amelioration amelioration = null)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            ArmePassive arme = new ArmePassive(nom,stats, desc, image, niveau, amelioration);

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(niveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }

        [Theory]
        [InlineData("Empty Tome")]
        [InlineData("Empty Tome", "A huge empty tome")]
        [InlineData("Empty Tome", "A huge empty tome", "./images/Empty_Tome.png")]
        [InlineData("Empty Tome", "A huge empty tome", "./images/Empty_Tome.png", 42)]
        public void TestConstructeurAvecAmelioration(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            Amelioration amelioration = new Amelioration("Holy Wand", stats);
            ArmePassive arme = new ArmePassive(nom, stats, desc, image, niveau, amelioration);

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(niveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }
        [Fact]
        public void TestStatsAemePasive()
        {
            string nom = "passive";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 20));
            stats.Add(new Stat(Stat.NomStat.Knockback, 20));
            stats.Add(new Stat(Stat.NomStat.Rarity, 10));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 15));

            ArmePassive passive = new ArmePassive(nom, stats);

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
