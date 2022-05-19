using BibliothequeClassesVSC;
using System;
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
            ArmeActive arme = new ArmeActive(nom, desc, image, niveau, amelioration);

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
            Amelioration amelioration = new Amelioration("Holy Wand");
            ArmeActive arme = new ArmeActive(nom, desc, image, niveau, amelioration);

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(niveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }
    }
}
