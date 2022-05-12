using BibliothequeClassesVSC;
using System;
using Xunit;

namespace InitTests
{
    public class UnitTests_Stat
    {
        [Theory]
        [InlineData(Stat.NomStat.MaxHealth, 40)]
        [InlineData(Stat.NomStat.Rarity, 0)]
        [InlineData(Stat.NomStat.XpGiven, -12)]
        public void TestConstructeur(Stat.NomStat nomStat, int valeur)
        {
            Stat stat = new Stat(nomStat, valeur);

            Assert.Equal(nomStat, stat.Nom);
            Assert.Equal(valeur, stat.Valeur);
        }

        [Theory]
        [InlineData(Stat.NomStat.MaxHealth, 40, "MaxHealth : +40")]
        [InlineData(Stat.NomStat.Rarity, 0, "Rarity : -")]
        [InlineData(Stat.NomStat.XpGiven, -12, "XpGiven : -12")]
        [InlineData(Stat.NomStat.MoveSpeed, 20, "MoveSpeed : +20%")]
        public void TestToString(Stat.NomStat nomStat, int valeur,
                                 string ExpectedToString)
        {
            Stat stat = new Stat(nomStat, valeur);

            Assert.Equal(ExpectedToString, stat.ToString());
        }

        [Theory]
        [InlineData(Stat.NomStat.MaxHealth, 40, Stat.NomStat.Amount, 40, false)]
        [InlineData(Stat.NomStat.MaxHealth, 40, Stat.NomStat.MaxHealth, 10, false)]
        [InlineData(Stat.NomStat.Might, 40, Stat.NomStat.Might, 40, true)]
        [InlineData(Stat.NomStat.Armor, 10, null, null, false)]
        public void TestEquals(Stat.NomStat nomStat, int valeur, Stat.NomStat nomStat1, int valeur1,
                                bool expectedEquals)
        {
            Stat stat = new Stat(nomStat, valeur);
            Stat stat1 = new Stat(nomStat1, valeur1);

            Assert.Equal(expectedEquals, stat.Equals(stat1));
        }

        [Theory]
        [InlineData(Stat.NomStat.MaxHealth, 40, true)]
        public void testEquals_memeStat(Stat.NomStat nomStat, int valeur,
                                        bool expectedEquals)
        {
            Stat stat = new Stat(nomStat, valeur);

            Assert.Equal(expectedEquals, stat.Equals(stat));
        }

        [Theory]
        [InlineData(Stat.NomStat.MaxHealth, 40, Stat.NomStat.MaxHealth, 10, true)]
        [InlineData(Stat.NomStat.MaxHealth, 40, Stat.NomStat.Luck, 20, true)]
        [InlineData(Stat.NomStat.Luck, 10, Stat.NomStat.MaxHealth, 10, false)]
        public void TestCompareTo(Stat.NomStat nomStat, int valeur, Stat.NomStat nomStat1, int valeur1,
                                  bool expectedResults)
        {
            Stat stat = new Stat(nomStat, valeur);
            Stat stat1 = new Stat(nomStat1, valeur1);

            if (stat.Nom == stat1.Nom)
            {
                Assert.Equal(expectedResults, stat.CompareTo(stat1) == 0);
                return;
            }

            Assert.Equal(expectedResults, stat.CompareTo(stat1) < 0);
        }
    }
}
