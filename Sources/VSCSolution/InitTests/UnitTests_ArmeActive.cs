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
        [InlineData("Magic Wand","This a magic wand !")]
        [InlineData("Magic Wand", "This a magic wand !","./images/Magic_Wand.png")]
        [InlineData("Magic Wand", "This a magic wand !","./images/Magic_Wand.png",11)]
        public void TestConstructeurSansAmelioration(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, Amelioration amelioration = null)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            ArmeActive arme = new ArmeActive(nom, stats, desc, image, niveau, amelioration);

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(niveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }

        [Theory]
        [InlineData("Magic Wand")]
        [InlineData("Magic Wand", "This a magic wand !")]
        [InlineData("Magic Wand", "This a magic wand !", "./images/Magic_Wand.png")]
        [InlineData("Magic Wand", "This a magic wand !", "./images/Magic_Wand.png", 11)]
        public void TestConstructeurAvecAmelioration(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1)
        {
            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 40));
            stats.Add(new Stat(Stat.NomStat.Knockback, 10));
            stats.Add(new Stat(Stat.NomStat.Rarity, 20));
            stats.Add(new Stat(Stat.NomStat.CritRate, 5));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 60));

            Amelioration amelioration = new Amelioration("Holy Wand", stats);
            ArmeActive arme = new ArmeActive(nom, stats,desc, image, niveau, amelioration);

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(niveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }
    }
}
