using BibliothequeClassesVSC;
using System;
using Xunit;

namespace InitTests
{
    public class UnitTests_Jeu
    {
        [Theory]
        [InlineData(1.01, "ceci est une description")]
        // [InlineData(-1.01, "ceci est une autre dscription")]
        public void testConstructeurPatchNote(byte Num, string Description)
        {
            var date1 = new DateTime(2021, 3, 1, 7, 0, 0);

            Jeu.PatchNote patch = new Jeu.PatchNote(Num, Description, date1);

            Assert.Equal(Num, patch.Num);
            Assert.Equal(Description, patch.Description);
            Assert.Equal(date1, patch.Date);
        }
    }
}

