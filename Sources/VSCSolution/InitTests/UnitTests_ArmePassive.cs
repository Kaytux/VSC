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
            ArmePassive arme = new ArmePassive(nom, desc, image, particularites, statsNiveau);

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

            ArmePassive passive = new ArmePassive(nom, "N/A", "N/A", particularites, statsNiveau);

            Assert.Equal(nom, passive.Nom);

            foreach (Stat particularite in particularites)
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
        [Fact]
        public void TestAjouterAmelioration()
        {
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

            ArmePassive armePassive = new ArmePassive("Test", "Test", "Test", particularites, statsNiveau);

            Amelioration amelioration = new Amelioration("Holy Wand", "N/A", "N/A", particularites, "Test", "N/A", statsNiveau);

            armePassive.ajouterAmelioration(amelioration);

            Assert.Equal("Test", armePassive.Nom);
            Assert.Equal("Test", armePassive.Description);
            Assert.Equal("Test", armePassive.Image);
            Assert.Equal(amelioration, armePassive.Amelioration);
        }
        
        [Fact]
        public void TestAjouterArmeActive()
        {
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

            ArmePassive armePassive = new ArmePassive("Test", "Test", "Test", particularites, statsNiveau);

            ArmeActive armeActive = new ArmeActive("Magic Wand", "N/A", "N/A", particularites, statsNiveau);

            armePassive.ajouterArmeActive(armeActive);

            Assert.Equal("Test", armePassive.Nom);
            Assert.Equal("Test", armePassive.Description);
            Assert.Equal("Test", armePassive.Image);
            Assert.Equal(armeActive, armePassive.ArmeAct);
        }
    }
}
