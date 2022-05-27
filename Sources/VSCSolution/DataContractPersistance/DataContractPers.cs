using BibliothequeClassesVSC;
using DataContractPersistanceVSC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContractPersistance
{
    public class DataContractPers : IPersistanceManager
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
        public string FileName { get; set; } = "vsc.xml";
        public string PersFile => Path.Combine(FilePath, FileName);
        private DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(DataToPersist),
                                                                                             new DataContractSerializerSettings()
                                                                                             {
                                                                                                 PreserveObjectReferences = true
                                                                                             });

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
            var serializer=new DataContractSerializer(typeof(IEnumerable<Personnage>));
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, lesPersonnages);
                }
            }
        }
    }
}
