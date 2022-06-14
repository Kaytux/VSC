using BibliothequeClassesVSC;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{
    public class UnitTests_Stub
    {
        [Fact]
        public void TestStub()
        {
            Manager Manager = new Manager(new Stub.Stub());
            Manager.ChargeDonnées();

            // Ennemie :
            Assert.Equal("Bat",Manager.LesEnnemies[0].Nom);
            Assert.Equal("Bat is an enemy that appears in Mad Forest.", Manager.LesEnnemies[0].Description);
            Assert.Equal("Sprite-Bat.png", Manager.LesEnnemies[0].Image);

            // Arme active :
            Assert.Equal("Hollow Heart", Manager.LesArmesPassives[0].Nom);
            Assert.Equal("Hollow Heart is a passive item in Vampire Survivors. It is unlocked by surviving 1 minute as any character. Hollow Heart multiplies Max Health by 1.2 per level. Hollow Heart is required for the Evolution of Whip, Bloody Tear. Hollow Heart can be found as a stage item in Mad Forest and Moongolow.", Manager.LesArmesPassives[0].Description);
            Assert.Equal("Sprite-Hollow_Heart.png", Manager.LesArmesPassives[0].Image);

            // Arme Passive
            Assert.Equal("Whip", Manager.LesArmesActives[0].Nom);
            Assert.Equal("Whip is a weapon in Vampire Survivors. It is the starting weapon of Antonio Belpaese. It is unlocked by default, and can be offered to the player from the start. Whip can be evolved into Bloody Tear with Hollow Heart.", Manager.LesArmesActives[0].Description);
            Assert.Equal("Sprite-Whip.png", Manager.LesArmesActives[0].Image);

            // Amelioration
            Assert.Equal("Bloody Tear", Manager.LesAmeliorations[0].Nom);
            Assert.Equal("Bloody Tear is a weapon in Vampire Survivors. It is the evolution of Whip, requiring Hollow Heart.", Manager.LesAmeliorations[0].Description);
            Assert.Equal("Sprite-Bloody_Tear.png", Manager.LesAmeliorations[0].Image);

            // Personnage :
            Assert.Equal("Antonio Belpaese", Manager.LesPersonnages[0].Nom);
            Assert.Equal("Antonio Belpaese is one of the playable characters in Vampire Survivors. He is the character that every player begins with and he is the only free character in the game. His starting weapon is the Whip. He gains +10% Might every 10 levels until level 50. The maximum Might gained this way is +50%.", Manager.LesPersonnages[0].Description);
            Assert.Equal("Sprite-Antonio.png", Manager.LesPersonnages[0].Image);

            // Carte :
            Assert.Equal("Mad Forest", Manager.LesCartes[0].Nom);
            Assert.Equal("Mad Forest is the first stage in Vampire Survivors. This stage is free and is the only stage that is unlocked from the start. It is also the only stage that is available in the demo version of the game on itch.io, the others being completely unavailable, rather than being locked like in the full version of the game.", Manager.LesCartes[0].Description);
            Assert.Equal("Sprite-Mad_Forest.png", Manager.LesCartes[0].Image);
        }
    }
}
