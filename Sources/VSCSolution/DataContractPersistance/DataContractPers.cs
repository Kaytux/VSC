using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace DataContractPersistance
{
    public class DataContractPers : IPersistanceManager
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
        public string FileName { get; set; } = "vsc.xml";
        public string File => Path.Combine(FilePath, FileName);

        public (IEnumerable<ArmePassive> lesArmesPassives, 
                IEnumerable<ArmeActive> lesArmesActives, 
                IEnumerable<Amelioration> lesAmeliorations, 
                IEnumerable<Personnage> lesPersonnages, 
                IEnumerable<Ennemie> lesEnnemies, 
                IEnumerable<Carte> lesCartes) ChargeDonnées()
        {
            throw new NotImplementedException();
        }

        public void SauvegardeDonnées(IEnumerable<ArmePassive> lesArmesPassives, 
                                      IEnumerable<ArmeActive> lesArmesActives, 
                                      IEnumerable<Amelioration> lesAmeliorations, 
                                      IEnumerable<Personnage> lesPersonnages,
                                      IEnumerable<Ennemie> lesEnnemies,
                                      IEnumerable<Carte> lesCartes)
        {
            //var serializer = new DataContractSerializer(typeof(IEnumerable<ArmePassive>),
            //                                            typeof(IEnumerable<ArmeActive>),
            //                                            typeof(IEnumerable<Amelioration>),
            //                                            typeof(IEnumerable<Personnage>),
            //                                            typeof(IEnumerable<Ennemie>),
            //                                            typeof(IEnumerable<Carte>));
            //var serializer = new DataContractSerializer(typeof(IEnumerable<Element>));
            //if(!Directory.Exists(FilePath))
            //{
            //    Directory.CreateDirectory(FilePath);
            //}
            //using (Stream s = File.Create(Path.Combine(FilePath, FileName)))
            //{
            //    serializer.WriteObject(s, lesArmesPassives);
            //    serializer.WriteObject(s, lesArmesActives);
            //}
        }
    }
}
