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

            Assert.Equal("MaxHealth : +40", stat.ToString());
        }

        [Fact]
        public void TestEquals()
        {
            Stat stat = new Stat(Stat.NomStat.MaxHealth, 40);
            Stat stat1 = new Stat(Stat.NomStat.MaxHealth, 40);
            Stat stat2 = new Stat(Stat.NomStat.Amount, 40);
            Stat stat3 = new Stat(Stat.NomStat.MaxHealth, 10);

            Assert.True(stat.Equals(stat1));
            Assert.False(stat.Equals(stat2));
            Assert.False(stat.Equals(stat3));
        }

        [Fact]
        public void TestCompareTo()
        {
            Stat stat = new Stat(Stat.NomStat.MaxHealth, 40);
            Stat stat1 = new Stat(Stat.NomStat.MaxHealth, 10);
            Stat stat2 = new Stat(Stat.NomStat.Cooldown, 20);

            Assert.Equal(0, stat.CompareTo(stat1));
            Assert.True(stat.CompareTo(stat2) < 0);
            Assert.True(stat2.CompareTo(stat) > 0);
        }
    }
}
