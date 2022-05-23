using BibliothequeClassesVSC;
using System;
using Xunit;

namespace InitTests
{
    public class UnitTests_ArmeActive
    {
        [Theory]
        [InlineData("Magic Wand")]
        public void TestConstructeu(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, Amelioration amelioration = null)
        {
            Arme arme = new ArmeActive(nom, desc, image, niveau, amelioration);

            Assert.Equal(nom, arme.Nom);
            Assert.Equal(desc, arme.Description);
            Assert.Equal(image, arme.Image);
            Assert.Equal(niveau, arme.Niveau);
            Assert.Equal(amelioration, arme.Amelioration);
        }


    }
}
