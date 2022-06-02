using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_Personnage
    {
        [Fact]
        public void testConstructeurPersonnage()
        {
            string nom = "personnage";

            HashSet<Stat> particularites = new HashSet<Stat>();
            particularites.Add(new Stat(Stat.NomStat.Growth, 40));
            particularites.Add(new Stat(Stat.NomStat.Luck));
            particularites.Add(new Stat(Stat.NomStat.Magnet, 10));

            string desc = "ceci est un personnage";

            string image = "/Sources/VSCSolution/VuesVSC/Images/Sprite-Hollow_Heart.png";


            Personnage personnage = new Personnage(nom, desc, image, particularites);

            Assert.Equal(nom, personnage.Nom);

            foreach (Stat particularite in particularites)
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
