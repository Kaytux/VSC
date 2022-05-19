using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_Ennemie
    {
        [Theory]
        [InlineData("Ennemie")]
        public void testConstructeurSansImageEtDesc(string nom)
        {
            List<Stat> stats = new List<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxHealth, 40));
            stats.Add(new Stat(Stat.NomStat.Luck));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 10));

            Ennemie ennemie = new Ennemie(nom, stats);

            Assert.Equal(nom, ennemie.Nom);

            foreach (Stat particularite in stats)
            {
                foreach (Stat stat in ennemie.stats)
                {
                    if(particularite.Nom == stat.Nom)
                    {
                        Assert.Equal(particularite, stat);
                    }
                }
            }
            
            Assert.Equal("N/A", ennemie.Description);
            Assert.Equal("N/A", ennemie.Image);
        }
    }
}
