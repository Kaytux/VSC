using BibliothequeClassesVSC;
using System;
using Xunit;

namespace InitTests
{
    public class UnitTests_Utilisateur
    {
        [Fact]
        public void testConstructeurUtilisateur()
        {
            string nom = "test";
            ulong id = 100;
            Utilisateur utilisateur = new Utilisateur(nom, id);

            Assert.Equal(nom, utilisateur.Nom);
            Assert.Equal(id, utilisateur.Id);
        }

        [Fact]
        public void testConstructeurAchievement()
        {
            Utilisateur utilisateur = new Utilisateur("test", 100);

            Utilisateur.Achievements achievements = new Utilisateur.Achievements("test", "test1", "test2");
            
            utilisateur.achievements.Add(achievements);

            Assert.Equal(achievements, utilisateur.achievements[0]);
        }
    }
}

