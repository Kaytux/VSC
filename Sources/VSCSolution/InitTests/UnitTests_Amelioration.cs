using BibliothequeClassesVSC;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_Amelioration
    {
        [Fact]
        public void TestConstructeurAvecArmeActEtPas()
        {
            string nom = "Holy Wand";
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

            ArmeActive active = new ArmeActive("Magic Wand", "N/A", "N/A", particularites, statsNiveau);
            ArmePassive passive = new ArmePassive("Empty Tome", "N/A", "N/A", particularites, statsNiveau);
            Amelioration amelioration = new Amelioration(nom, desc, image, particularites, "Magic Wand", "Empty Tome", statsNiveau);

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


            Amelioration amelioration = new Amelioration(nom, desc, image, particularites, "Magic Wand", "Empty Tome", statsNiveau);

            Assert.Equal(nom, amelioration.Nom);

            foreach (Stat particularite in particularites)
            {
                foreach (Stat stat in amelioration.stats)
                {
                    if (particularite.Nom == stat.Nom)
                    {
                        Assert.Equal(particularite, stat);
                    }
                }
            }

            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
        }
    }
}
