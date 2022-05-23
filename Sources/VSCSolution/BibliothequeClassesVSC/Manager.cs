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
        private HashSet<Personnage> lesPersonnages= new HashSet<Personnage>();

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

        public Manager()
        {
            AjoutCollection(lesArmesPassives,
                new ArmePassive("Armes Passives 1"),
                new ArmePassive("Armes Passives 2"));
            AjoutCollection(lesPersonnages,
                new Personnage("Perso 1", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth,40))),
                new Personnage("Perso 2", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 3", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))),
                new Personnage("Perso 4", ConstructionParticularite(new Stat(Stat.NomStat.MaxHealth, 40))));
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

        private void AjoutCollection<T>(HashSet<T> list, params T[] liste) where T : Element
        {
            list.UnionWith(liste);
        }
        private HashSet<Stat> ConstructionParticularite(params Stat[] liste)
        {
            HashSet<Stat> res = new HashSet<Stat>();
            res.UnionWith(liste);
            return res;
        }
    }
}
