using BibliothequeClassesVSC;
using System;

namespace ConsoleAppVSC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Element e=new Element ("Billel");
            Console.WriteLine(e.Nom);
            Console.WriteLine(e.Description);
            e.Nom = "Bastien";
            Console.WriteLine(e.Nom);
            Element e2 = new Element("Bones", "Rebounce on enemies", "./Images/Bones.png");
            Console.WriteLine("------");
            Console.WriteLine("Nom : " + e2.Nom);
            Console.WriteLine("Description : " + e2.Description);
            Console.WriteLine("Chemin pour l'image : " + e2.Image);
        }
    }
}
