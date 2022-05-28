using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_Amelioration
    {
        [Theory]
        [InlineData("Holy Wand")]
        [InlineData("Holy Wand","Now your wand is more powerful")]
        [InlineData("Holy Wand", "Now your wand is more powerful","./images/Holy_Wand.png")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png",7)]
        public void TestConstructeurSansArmeActPas(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, ArmeActive active = null, ArmePassive passive = null)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            Amelioration amelioration = new Amelioration(nom, stats, desc, image, niveau, active, passive);

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(niveau, amelioration.Niveau);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }

        [Theory]
        [InlineData("Holy Wand")]
        [InlineData("Holy Wand", "Now your wand is more powerful")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png", 7)]
        public void TestConstructeurAvecArmeAct(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, ArmePassive passive = null)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            ArmeActive active = new ArmeActive("Magic Wand", stats);
            Amelioration amelioration = new Amelioration(nom, stats ,desc, image, niveau, active, passive);

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(niveau, amelioration.Niveau);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }

        [Theory]
        [InlineData("Holy Wand")]
        [InlineData("Holy Wand", "Now your wand is more powerful")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png", 7)]
        public void TestConstructeurAvecArmePas(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, ArmeActive active = null)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            ArmePassive passive = new ArmePassive("Empty Tome", stats);
            Amelioration amelioration = new Amelioration(nom, stats, desc, image, niveau, active, passive); ;

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(niveau, amelioration.Niveau);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }

        [Theory]
        [InlineData("Holy Wand")]
        [InlineData("Holy Wand", "Now your wand is more powerful")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png", 7)]
        public void TestConstructeurAvecArmeActEtPas(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            ArmeActive active = new ArmeActive("Magic Wand", stats);
            ArmePassive passive = new ArmePassive("Empty Tome", stats);
            Amelioration amelioration = new Amelioration(nom, stats, desc, image, niveau, active, passive);

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(niveau, amelioration.Niveau);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }

        [Fact]
        public void TestStatsAmelioration()
        {
            string nom = "amelioration";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 10));
            stats.Add(new Stat(Stat.NomStat.Knockback, 20));
            stats.Add(new Stat(Stat.NomStat.Rarity, 30));
            stats.Add(new Stat(Stat.NomStat.CritRate, 10));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 15));

            Amelioration amelioration = new Amelioration(nom, stats);

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
