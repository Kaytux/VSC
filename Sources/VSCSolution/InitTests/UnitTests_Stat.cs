using BibliothequeClassesVSC;
using System;
using Xunit;

namespace InitTests
{
    public class UnitTests_Stat
    {
        [Fact]
        public void TestConstructeur()
        {
            Stat stat = new Stat(Stat.NomStat.MaxHealth, 40);

            Assert.Equal(Stat.NomStat.MaxHealth, stat.Nom);
            Assert.Equal(40, stat.Valeur);
        }
        
        [Fact]
        public void TestToString()
        {
            Stat stat = new Stat(Stat.NomStat.MaxHealth, 40);

            string test = stat.ToString();

            Assert.Equal("MaxHealth : +40", test);
        }

        [Fact]
        public void TestEquals()
        {
            Stat stat = new Stat(Stat.NomStat.MaxHealth, 40);
            Stat stat1 = new Stat(Stat.NomStat.MaxHealth, 40);
        }
    }
}
