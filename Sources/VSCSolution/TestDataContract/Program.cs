using Stub;
using System;
using BibliothequeClassesVSC;

namespace TestDataContract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new Stub.Stub());
            manager.ChargeDonnées();
            manager.Persistance = new DataContractPersistance.DataContractPers();
            manager.SauvegardeDonnées();
        }
    }
}
