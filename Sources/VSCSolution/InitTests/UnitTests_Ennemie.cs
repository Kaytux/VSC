using BibliothequeClassesVSC;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_Ennemie
    {
        [Fact]
        public void testConstructeurSansImageEtDesc()
        {
            string nom = "ennemie";

            HashSet<Stat> stats = new HashSet<Stat>();
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

        [Fact]
        public void testConstructeurAvecImage()
        {
            string nom = "ennemie";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxHealth, 40));
            stats.Add(new Stat(Stat.NomStat.Luck));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 10));

            string image = "/main/Sources/VSCSolution/VuesVSC/Images/Sprite-Whip.png";

            Ennemie ennemie = new Ennemie(nom, stats, image:image);

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
            Assert.Equal(image, ennemie.Image);

        }

        [Fact]
        public void testConstructeurAvecImageEtDesc()
        {
            string nom = "ennemie";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.MaxHealth, 40));
            stats.Add(new Stat(Stat.NomStat.Luck));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 10));

            string image = "/main/Sources/VSCSolution/VuesVSC/Images/Sprite-Whip.png";

            string desc = "ceci est un ennemie";

            Ennemie ennemie = new Ennemie(nom, stats, desc, image);

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
            
            Assert.Equal(desc, ennemie.Description);
            Assert.Equal(image, ennemie.Image);

        }
    }
}
