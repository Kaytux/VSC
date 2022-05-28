using Stub;
using System;
using BibliothequeClassesVSC;

namespace TestDataContract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //version premier chargement des données avec le stub
            //Manager managerTmp = new Manager(new Stub.Stub());
            //managerTmp.ChargeDonnées();
            //managerTmp.Persistance = new DataContractPersistance.DataContractPers();
            //managerTmp.SauvegardeDonnées();

            //version finale à utiliser
            Manager manager = new Manager(new DataContractPersistance.DataContractPers());
            manager.ChargeDonnées();
            manager.SauvegardeDonnées();
        }
    }
}
