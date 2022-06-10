using BibliothequeClassesVSC;
using System;

namespace ConsoleAppVSC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager Manager = new Manager(new Stub.Stub());

            Console.WriteLine("Test Fonctionnel des classes : ");
            Console.WriteLine("===============================");

            Console.WriteLine("Test Amelioration :");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Nom : "+Manager.LesAmeliorations[1]);
            Console.WriteLine("Desc : ");


        } 
    }
}
