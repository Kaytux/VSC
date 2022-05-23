using BibliothequeClassesVSC;
using System;
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
            ArmePassive arme = new ArmePassive(nom, desc, image, niveau, amelioration);

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
            Amelioration amelioration = new Amelioration("Holy Wand");
            ArmePassive arme = new ArmePassive(nom, desc, image, niveau, amelioration);

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(niveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }
    }
}
