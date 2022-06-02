using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;


namespace InitTests
{
    public class UnitTests_Armes
    {
        [Fact]
        public void TestChangementNiveau()
        {
            string nom = "BATONNNNN";
            string desc = "Test desccccc";
            string image = "test/img/img/img";
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
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 10) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 10) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 10) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 10) });

            List<HashSet<Stat>> ExpectedStatsUP = new List<HashSet<Stat>>();
            ExpectedStatsUP.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 22) });
            ExpectedStatsUP.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 24), new Stat(Stat.NomStat.Rarity, 13) });
            ExpectedStatsUP.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritMultiplier, 23), new Stat(Stat.NomStat.MaxLevel, 26) });
            ExpectedStatsUP.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 15) });
            ExpectedStatsUP.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 25) });
            ExpectedStatsUP.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 35) });
            ExpectedStatsUP.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 45) });

            ArmeActive active = new ArmeActive(nom, desc, image, particularites, statsNiveau);
            Assert.Equal(nom, active.Nom);
            Assert.Equal(desc, active.Description);
            Assert.Equal(image, active.Image);
            Assert.Equal(ExpectedNiveau, active.Niveau);

            foreach (HashSet<Stat> newStats in ExpectedStatsUP)
            {
                active.AugmenterNiveau();
                ExpectedNiveau++;
                Assert.Equal(ExpectedNiveau, active.Niveau);
                foreach (Stat newStat in newStats)
                {
                    foreach (Stat activeStat in active.stats)
                    {
                        if (newStat.Nom == activeStat.Nom)
                        {
                            Assert.Equal(newStat, activeStat);
                        }
                    }
                }
            }

            List<HashSet<Stat>> ExpectedStatsDOWN = new List<HashSet<Stat>>();
            ExpectedStatsDOWN.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 35) });
            ExpectedStatsDOWN.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 25) });
            ExpectedStatsDOWN.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritRate, 15) });
            ExpectedStatsDOWN.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.CritMultiplier, 23), new Stat(Stat.NomStat.MaxLevel, 26) });
            ExpectedStatsDOWN.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 24), new Stat(Stat.NomStat.Rarity, 13) });
            ExpectedStatsDOWN.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 22) });
            ExpectedStatsDOWN.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 20), new Stat(Stat.NomStat.Knockback, 20), new Stat(Stat.NomStat.Rarity, 10), new Stat(Stat.NomStat.CritRate, 5), new Stat(Stat.NomStat.CritMultiplier, 15) }); ;

            foreach (HashSet<Stat> newStats in ExpectedStatsDOWN)
            {
                active.BaisserNiveau();
                ExpectedNiveau--;
                Assert.Equal(ExpectedNiveau, active.Niveau);
                foreach (Stat newStat in newStats)
                {
                    foreach (Stat activeStat in active.stats)
                    {
                        if (newStat.Nom == activeStat.Nom)
                        {
                            Assert.Equal(newStat, activeStat);
                        }
                    }
                }
            }
        }
    }
}
