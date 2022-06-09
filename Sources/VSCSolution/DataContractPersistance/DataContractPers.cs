using BibliothequeClassesVSC;
using DataContractPersistanceVSC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContractPersistance
{
    public class DataContractPers : IPersistanceManager
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
        public string FileName { get; set; } = "vsc.xml";
        public string PersFile => Path.Combine(FilePath, FileName);

        internal List<ArmePassive> LesArmesPassives { get; set; } = new List<ArmePassive>();
        internal List<ArmeActive> LesArmesActives { get; set; } = new List<ArmeActive>();
        internal List<Amelioration> LesAmeliorations { get; set; } = new List<Amelioration>();
        internal List<Personnage> LesPersonnages { get; set; } = new List<Personnage>();
        internal List<Ennemie> LesEnnemies { get; set; } = new List<Ennemie>();
        internal List<Carte> LesCartes { get; set; } = new List<Carte>();

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

            LesPersonnages = data.Pe.ToPOCOs().ToList();
            LesEnnemies = data.En.ToPOCOs().ToList();
            LesAmeliorations = data.Am.ToPOCOs().ToList();
            LesArmesPassives = data.Ap.ToPOCOs().ToList();
            LesArmesActives = data.Aa.ToPOCOs().ToList();
            LesCartes = data.Ca.ToPOCOs().ToList();

            LiensDesClasses(LesArmesPassives, LesArmesActives, LesAmeliorations, LesCartes, LesEnnemies,LesPersonnages);

            return (LesArmesPassives,
                    LesArmesActives,
                    LesAmeliorations,
                    LesPersonnages,
                    LesEnnemies,
                    LesCartes);
        }

        public void LiensDesClasses(List<ArmePassive> armesPassives, List<ArmeActive> armesActives, List<Amelioration> ameliortions, List<Carte> cartes, List<Ennemie> ennemies,List<Personnage> persos)
        {
            foreach(Amelioration amelio in ameliortions)
            {
                foreach(ArmeActive active in armesActives)
                {
                    if (amelio.NomArmeAct == active.Nom)
                    {
                        amelio.ArmeAct = active;
                        active.ajouterAmelioration(amelio);
                    }
                }
                foreach(ArmePassive passive in armesPassives)
                {
                    if(amelio.NomArmePass == passive.Nom)
                    {
                        amelio.ArmePass = passive;
                        passive.ajouterAmelioration(amelio);
                        passive.ajouterArmeActive(amelio.ArmeAct);
                    }
                }
                foreach (ArmeActive active in armesActives)
                {
                    if (amelio.NomArmeAct == active.Nom)
                    {
                        active.ajouterArmePasssive(amelio.ArmePass);
                    }
                }
            }
            foreach(Carte carte in cartes)
            {
                carte.LesEnnemies = (from en in ennemies
                                    join nomen in carte.NomEnn on en.Nom equals nomen
                                    select en).ToList();

                carte.LesObjetsCaches = (from ap in armesPassives
                                         join objcach in carte.NomArmPass on ap.Nom equals objcach
                                         select ap).ToList();
            }
            foreach(Personnage p in persos)
            {
                p.Arme = armesActives.Where(ap => ap.Nom == p.NomArme) as ArmeActive;
            }
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
            data.Ap.AddRange(lesArmesPassives.ToDTOs());
            data.Aa.AddRange(lesArmesActives.ToDTOs());
            data.Am.AddRange(lesAmeliorations.ToDTOs());
            data.Pe.AddRange(lesPersonnages.ToDTOs());
            data.En.AddRange(lesEnnemies.ToDTOs());
            data.Ca.AddRange(lesCartes.ToDTOs());

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
