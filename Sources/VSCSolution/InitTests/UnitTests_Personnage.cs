using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_Personnage
    {
        [Fact]
        public void testConstructeurSansImageEtDesc()
        {
            string nom = "personnage";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.Growth, 40));
            stats.Add(new Stat(Stat.NomStat.Luck));
            stats.Add(new Stat(Stat.NomStat.Magnet, 10));

            Personnage personnage = new Personnage(nom, stats);

            Assert.Equal(nom, personnage.Nom);

            foreach (Stat particularite in stats)
            {
                foreach (Stat stat in personnage.stats)
                {
                    if (particularite.Nom == stat.Nom)
                    {
                        Assert.Equal(particularite, stat);
                    }
                }
            }

            Assert.Equal("N/A", personnage.Description);
            Assert.Equal("N/A", personnage.Image);


        }

        [Fact]
        public void testConstructeurAvecImage()
        {
            string nom = "personnage";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.Growth, 40));
            stats.Add(new Stat(Stat.NomStat.Luck));
            stats.Add(new Stat(Stat.NomStat.Magnet, 10));

            string image = "/Sources/VSCSolution/VuesVSC/Images/Sprite-Hollow_Heart.png";

            Personnage personnage = new Personnage(nom, stats, image:image);

            Assert.Equal(nom, personnage.Nom);

            foreach (Stat particularite in stats)
            {
                foreach (Stat stat in personnage.stats)
                {
                    if (particularite.Nom == stat.Nom)
                    {
                        Assert.Equal(particularite, stat);
                    }
                }
            }

            Assert.Equal("N/A", personnage.Description);
            Assert.Equal(image, personnage.Image);

        }

        [Fact]
        public void testConstructeurAvecImageEtDesc()
        {
            string nom = "personnage";

            HashSet<Stat> stats = new HashSet<Stat>();
            stats.Add(new Stat(Stat.NomStat.Growth, 40));
            stats.Add(new Stat(Stat.NomStat.Luck));
            stats.Add(new Stat(Stat.NomStat.Magnet, 10));

            string desc = "ceci est un personnage";

            string image = "/Sources/VSCSolution/VuesVSC/Images/Sprite-Hollow_Heart.png";


            Personnage personnage = new Personnage(nom, stats, desc, image);

            Assert.Equal(nom, personnage.Nom);

            foreach (Stat particularite in stats)
            {
                foreach (Stat stat in personnage.stats)
                {
                    if (particularite.Nom == stat.Nom)
                    {
                        Assert.Equal(particularite, stat);
                    }
                }
            }

            Assert.Equal(desc, personnage.Description);
            Assert.Equal(image, personnage.Image);

        }
    }
}
