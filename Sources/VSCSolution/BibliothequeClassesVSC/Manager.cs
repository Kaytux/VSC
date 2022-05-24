using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Manager
    {
        public IPersistanceManager Persistance { get; /*private*/ set; }
        public ReadOnlyCollection<ArmePassive> LesArmesPassives
        {
            get;
            private set;
        }
        private HashSet<ArmePassive> lesArmesPassives = new HashSet<ArmePassive>();

        public ReadOnlyCollection<ArmeActive> LesArmesActives
        {
            get;
            private set;
        }
        private HashSet<ArmeActive> lesArmesActives = new HashSet<ArmeActive>();

        public ReadOnlyCollection<Amelioration> LesAmeliorations
        {
            get;
            private set;
        }
        private HashSet<Amelioration> lesAmeliorations = new HashSet<Amelioration>();

        public ReadOnlyCollection<Personnage> LesPersonnages
        {
            get;
            private set;
        }
        private HashSet<Personnage> lesPersonnages = new HashSet<Personnage>();

        public ReadOnlyCollection<Ennemie> LesEnnemies
        {
            get;
            private set;
        }
        private HashSet<Ennemie> lesEnnemies = new HashSet<Ennemie>();

        public ReadOnlyCollection<Carte> LesCartes
        {
            get;
            private set;
        }
        private HashSet<Carte> lesCartes = new HashSet<Carte>();

        public void ChargeDonnées()
        {
            var données = Persistance.ChargeDonnées();
            foreach (var donn in données.lesArmesPassives)
            {
                lesArmesPassives.Add(donn);
            }
            foreach (var donn in données.lesArmesActives)
            {
                lesArmesActives.Add(donn);
            }
            foreach (var donn in données.lesAmeliorations)
            {
                lesAmeliorations.Add(donn);
            }
            foreach (var donn in données.lesPersonnages)
            {
                lesPersonnages.Add(donn);
            }
            foreach (var donn in données.lesEnnemies)
            {
                lesEnnemies.Add(donn);
            }
            foreach (var donn in données.lesCartes)
            {
                lesCartes.Add(donn);
            }
        }

        public void SauvegardeDonnées()
        {
            Persistance.SauvegardeDonnées(lesArmesPassives,
                                          lesArmesActives,
                                          lesAmeliorations,
                                          lesPersonnages,
                                          lesEnnemies,
                                          lesCartes);
        }

        public Manager(IPersistanceManager persistance)
        {
            Persistance = persistance;
            ChargeDonnées();
            LesArmesPassives = new ReadOnlyCollection<ArmePassive>(new List<ArmePassive>(lesArmesPassives));
            LesArmesActives = new ReadOnlyCollection<ArmeActive>(new List<ArmeActive>(lesArmesActives));
            LesAmeliorations = new ReadOnlyCollection<Amelioration>(new List<Amelioration>(lesAmeliorations));
            LesPersonnages = new ReadOnlyCollection<Personnage>(new List<Personnage>(lesPersonnages));
            LesEnnemies = new ReadOnlyCollection<Ennemie>(new List<Ennemie>(lesEnnemies));
            LesCartes = new ReadOnlyCollection<Carte>(new List<Carte>(lesCartes));
        }

        public void AffichList(IEnumerable<Element> liste)
        {
            foreach (Element ele in liste)
            {
                Console.WriteLine(ele.Nom);
            }
        }

        public HashSet<T> TriNom<T>(IEnumerable<T> liste) where T : Element
        {
            if(!liste.Any()) return null;
            var res = liste.OrderBy(a => a.Nom);

            switch(liste.GetType())
            {
                case IEnumerable<ArmePassive>:
                    LesArmesPassives = new ReadOnlyCollection<ArmePassive>(new List<ArmePassive>(lesArmesPassives));
                    break;
                case IEnumerable<ArmeActive>:
                    LesArmesActives = new ReadOnlyCollection<ArmeActive>(new List<ArmeActive>(lesArmesActives));
                    break;
                case IEnumerable<Amelioration>:
                    LesAmeliorations = new ReadOnlyCollection<Amelioration>(new List<Amelioration>(lesAmeliorations));
                    break;
                case IEnumerable<Personnage>:
                    LesPersonnages = new ReadOnlyCollection<Personnage>(new List<Personnage>(lesPersonnages));
                    break;
                case IEnumerable<Ennemie>:
                    LesEnnemies = new ReadOnlyCollection<Ennemie>(new List<Ennemie>(lesEnnemies));
                    break;
                case IEnumerable<Carte>:
                    LesCartes = new ReadOnlyCollection<Carte>(new List<Carte>(lesCartes));
                    break;
            }
            return res.ToHashSet();
        }
    }
}
