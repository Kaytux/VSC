using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppVSC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilisateur u1 = new Utilisateur("Axlr");
            
            Jeu j1 = new Jeu(
                "Vampire Survivors est un Rogue Light.",
                new Jeu.PatchNote(0,5,2,"De nombreux changements sont apparus."));
            
            HashSet<ArmePassive> ap1 = new HashSet<ArmePassive>();
            HashSet<ArmeActive> aa1 = new HashSet<ArmeActive>();
            HashSet<Amelioration> am1 = new HashSet<Amelioration>();
            HashSet<Personnage> p1 = new HashSet<Personnage>();
            HashSet<Ennemie> e1 = new HashSet<Ennemie>();
            HashSet<Carte> c1 = new HashSet<Carte>();

            AjoutCollection(ap1,
                new ArmePassive("Passive 3"),
                new ArmePassive("Passive 1"),
                new ArmePassive("Passive 2")
                );

            AjoutCollection(aa1,
                new ArmeActive("Active 3"),
                new ArmeActive("Active 1"),
                new ArmeActive("Active 2")
                );

            AjoutCollection(am1,
                new Amelioration("Amelioration 3"),
                new Amelioration("Amelioration 1"),
                new Amelioration("Amelioration 2")
                );

            AjoutCollection(p1,
                new Personnage("Personnage 3",ConstructionParticularite(new Stat(Stat.NomStat.Armor,20),new Stat(Stat.NomStat.Duration,-20))),
                new Personnage("Personnage 1", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20))),
                new Personnage("Personnage 2", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20)))
                );

            AjoutCollection(e1,
                new Ennemie("Ennemie 3", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20))),
                new Ennemie("Ennemie 1", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20))),
                new Ennemie("Ennemie 2", ConstructionParticularite(new Stat(Stat.NomStat.Armor, 20), new Stat(Stat.NomStat.Duration, -20)))
                );

            AjoutCollection(c1,
                new Carte("Carte 3", e1.Where(a => a.Nom.Equals("Ennemie 1")).ToList(), ap1.Where(a => a.Nom.Equals("Passive 1")).ToList()),
                new Carte("Carte 1", e1.Where(a => a.Nom.Equals("Ennemie 1")).ToList(), ap1.Where(a => a.Nom.Equals("Passive 1")).ToList()),
                new Carte("Carte 2", e1.Where(a => a.Nom.Equals("Ennemie 1")).ToList(), ap1.Where(a => a.Nom.Equals("Passive 1")).ToList())
                );

            AffichList(ap1);
            AffichList(aa1);
            AffichList(am1);
            AffichList(p1);
            AffichList(e1);
            AffichList(c1);

            ap1 = TriNom(ap1);
            AffichList(ap1);
        }
        static void AffichList(IEnumerable<Element> liste)
        {
            foreach (Element ele in liste)
            {
                Console.WriteLine(ele.Nom);
            }
        }

        static HashSet<T> TriNom<T>(HashSet<T> liste) where T : Element
        {
            var res=liste.OrderBy(a => a.Nom);
            return res.ToHashSet();
        }

        static void AjoutCollection<T>(HashSet<T> list, params T[] liste) where T : Element
        {
            list.UnionWith(liste);
        }
        static List<Stat> ConstructionParticularite(params Stat[] liste)
        {
            List<Stat> res = new List<Stat>();
            res.AddRange(liste);
            return res;
        }
    }
}
