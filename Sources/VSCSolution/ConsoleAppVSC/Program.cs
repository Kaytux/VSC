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
            e.Nom = "Bastien";
            Console.WriteLine(e.Nom);
        }
    }
}
