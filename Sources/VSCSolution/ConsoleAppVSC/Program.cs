using BibliothequeClassesVSC;
using System;

namespace ConsoleAppVSC
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Test fonctionnel de la bibliothèque de classes : ");
            Console.WriteLine("===============================");

            Manager Manager = new Manager(new Stub.Stub());

            Console.WriteLine("\n\nCreation du manager");
            Console.WriteLine("--------------------------------");

            Manager.ChargeDonnées();

            Console.WriteLine("\n\nChargement du Stub dans le Manager");
            Console.WriteLine("--------------------------------");



            Console.WriteLine("\n\nTest Amelioration :");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Nom : " + Manager.LesAmeliorations[0]);
            Console.WriteLine("Desc : " + Manager.LesAmeliorations[0].Description);
            Console.WriteLine("Image path : " + Manager.LesAmeliorations[0].Image);
            Console.WriteLine("Arme Active : " + Manager.LesAmeliorations[0].ArmeAct);
            Console.WriteLine("Arme Passive : " + Manager.LesAmeliorations[0].ArmePass);
            foreach (Stat stat in Manager.LesAmeliorations[0].stats)
            {
                Console.WriteLine("Stats : " + stat);
            }

            Console.WriteLine("\n\nTest Arme Active :");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Nom : " + Manager.LesArmesActives[0]);
            Console.WriteLine("Desc : " + Manager.LesArmesActives[0].Description);
            Console.WriteLine("Image path : " + Manager.LesArmesActives[0].Image);
            Console.WriteLine("Amelioration : " + Manager.LesArmesActives[0].Amelioration);
            Console.WriteLine("Arme Passive : " + Manager.LesArmesActives[0].ArmePass);
            foreach (Stat stat in Manager.LesArmesActives[0].stats)
            {
                Console.WriteLine("Stats : " + stat);
            }

            Console.WriteLine("\n\nTest Arme Passive :");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Nom : " + Manager.LesArmesPassives[0]);
            Console.WriteLine("Desc : " + Manager.LesArmesPassives[0].Description);
            Console.WriteLine("Image path : " + Manager.LesArmesPassives[0].Image);
            Console.WriteLine("Amelioration : " + Manager.LesArmesPassives[0].Amelioration);
            Console.WriteLine("Arme Axtive : " + Manager.LesArmesPassives[0].ArmeAct);
            foreach (Stat stat in Manager.LesArmesPassives[0].stats)
            {
                Console.WriteLine("Stats : " + stat);
            }

            Console.WriteLine("\n\nTest Carte :");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Nom : " + Manager.LesCartes[0]);
            Console.WriteLine("Desc : " + Manager.LesCartes[0].Description);
            Console.WriteLine("Image path : " + Manager.LesCartes[0].Image);
            foreach (Ennemie ennemie in Manager.LesCartes[0].LesEnnemies)
            {
                Console.WriteLine("Ennemie : " + ennemie);
            }
            foreach (ArmePassive armePassive in Manager.LesCartes[0].LesObjetsCaches)
            {
                Console.WriteLine("Ennemie : " + armePassive);
            }

            Console.WriteLine("\n\nTest Ennemie :");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Nom : " + Manager.LesEnnemies[0]);
            Console.WriteLine("Desc : " + Manager.LesEnnemies[0].Description);
            Console.WriteLine("Image path : " + Manager.LesEnnemies[0].Image);
            foreach (Stat stat in Manager.LesEnnemies[0].stats)
            {
                Console.WriteLine("Stats : " + stat);
            }

            Console.WriteLine("\n\nTest Personnage :");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Nom : " + Manager.LesPersonnages[0]);
            Console.WriteLine("Desc : " + Manager.LesPersonnages[0].Description);
            Console.WriteLine("Image path : " + Manager.LesPersonnages[0].Image);
            Console.WriteLine("Arme active : " + Manager.LesPersonnages[0].Arme);
            foreach (Stat stat in Manager.LesPersonnages[0].stats)
            {
                Console.WriteLine("Stats : " + stat);
            }

        }
    }
}
