using BibliothequeClassesVSC;
using System;
using Xunit;

namespace InitTests
{
    public class UnitTests_Amelioration
    {
        [Theory]
        [InlineData("Holy Wand")]
        [InlineData("Holy Wand","Now your wand is more powerful")]
        [InlineData("Holy Wand", "Now your wand is more powerful","./images/Holy_Wand.png")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png",7)]
        public void TestConstructeurSansArmeActPas(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, ArmeActive active = null, ArmePassive passive = null)
        {
            Amelioration amelioration = new Amelioration(nom, desc, image, niveau, active, passive);

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(niveau, amelioration.Niveau);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }

        [Theory]
        [InlineData("Holy Wand")]
        [InlineData("Holy Wand", "Now your wand is more powerful")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png", 7)]
        public void TestConstructeurAvecArmeAct(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, ArmePassive passive = null)
        {
            ArmeActive active = new ArmeActive("Magic Wand");
            Amelioration amelioration = new Amelioration(nom, desc, image, niveau, active, passive);

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(niveau, amelioration.Niveau);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }

        [Theory]
        [InlineData("Holy Wand")]
        [InlineData("Holy Wand", "Now your wand is more powerful")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png", 7)]
        public void TestConstructeurAvecArmePas(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, ArmeActive active = null)
        {
            ArmePassive passive = new ArmePassive("Empty Tome");
            Amelioration amelioration = new Amelioration(nom, desc, image, niveau, active, passive);

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(niveau, amelioration.Niveau);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }

        [Theory]
        [InlineData("Holy Wand")]
        [InlineData("Holy Wand", "Now your wand is more powerful")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png")]
        [InlineData("Holy Wand", "Now your wand is more powerful", "./images/Holy_Wand.png", 7)]
        public void TestConstructeurAvecArmeActEtPas(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1)
        {
            ArmeActive active = new ArmeActive("Magic Wand");
            ArmePassive passive = new ArmePassive("Empty Tome");
            Amelioration amelioration = new Amelioration(nom, desc, image, niveau, active, passive);

            Assert.Equal(nom, amelioration.Nom);
            Assert.Equal(desc, amelioration.Description);
            Assert.Equal(image, amelioration.Image);
            Assert.Equal(niveau, amelioration.Niveau);
            Assert.Equal(active, amelioration.ArmeAct);
            Assert.Equal(passive, amelioration.ArmePass);
        }
    }
}
