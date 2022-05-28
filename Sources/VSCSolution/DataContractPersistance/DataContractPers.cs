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
            if(!File.Exists(PersFile))
            {
                throw new FileNotFoundException("the persistance file is missing");
            }

            DataToPersist data;

            using (Stream s = File.OpenRead(PersFile))
            {
                data = Serializer.ReadObject(s) as DataToPersist;
            }
            return (data.Ap,
                    data.Aa,
                    data.Am,
                    data.Pe,
                    data.En,
                    data.Ca);
        }

        public void SauvegardeDonnées(IEnumerable<ArmePassive> lesArmesPassives,
                                      IEnumerable<ArmeActive> lesArmesActives,
                                      IEnumerable<Amelioration> lesAmeliorations,
                                      IEnumerable<Personnage> lesPersonnages,
                                      IEnumerable<Ennemie> lesEnnemies,
                                      IEnumerable<Carte> lesCartes)
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            DataToPersist data = new DataToPersist();
            data.Ap.AddRange(lesArmesPassives);
            data.Aa.AddRange(lesArmesActives);
            data.Am.AddRange(lesAmeliorations);
            data.Pe.AddRange(lesPersonnages);
            data.En.AddRange(lesEnnemies);
            data.Ca.AddRange(lesCartes);

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    Serializer.WriteObject(writer, data);
                }
            }
        }
    }
}
