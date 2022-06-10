using BibliothequeClassesVSC;
using System.Collections.Generic;
using Xunit;

namespace InitTests
{

    public class UnitTests_Carte
    {
        [Fact]
        public void testConstructeurCarte()
        {
            string nom = "carte";
            string desc = "testDesc";
            string image = "/Sources/VSCSolution/VuesVSC/Images/Sprite-Empty_Tome.png";

            HashSet<Stat> stats = new HashSet<Stat>(); ;
            stats.Add(new Stat(Stat.NomStat.Growth, 40));
            stats.Add(new Stat(Stat.NomStat.Luck));
            stats.Add(new Stat(Stat.NomStat.Magnet, 10));

            List<HashSet<Stat>> statsNiveau = new List<HashSet<Stat>>();
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.MaxLevel, 2) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Knockback, 4), new Stat(Stat.NomStat.Area, 3) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Growth, 8), new Stat(Stat.NomStat.MaxLevel, 4) });
            statsNiveau.Add(new HashSet<Stat>() { new Stat(Stat.NomStat.Luck, 12) });

            Ennemie e1 = new Ennemie("ennemie1", "desc", "img", stats);
            Ennemie e2 = new Ennemie("ennemie2", "desc", "img", stats);

            ArmePassive a1 = new ArmePassive("passive1", "desc", "img", stats, statsNiveau);
            ArmePassive a2 = new ArmePassive("passive2", "desc", "img", stats, statsNiveau);

            List<string> nomEnn = new List<string> { "ennemie1", "ennemie2" };
            List<string> nomPass = new List<string> { "passive1", "passive2" };

            List<Ennemie> lesEnnemies = new List<Ennemie> { e1, e2 };
            List<ArmePassive> lesObjetsCacher = new List<ArmePassive> { a1, a2 };

            Carte carte = new Carte(nom, desc, image, nomEnn, nomPass);

            carte.LesEnnemies = lesEnnemies;
            carte.LesObjetsCaches = lesObjetsCacher;

            Assert.Equal(nom, carte.Nom);

            foreach (string enn in nomEnn)
            {
                foreach (string carteEnn in carte.NomEnn)
                {
                    if (enn == carteEnn)
                    {
                        Assert.Equal(enn, carteEnn);
                    }
                }
            }

            foreach (string pass in nomPass)
            {
                foreach (string cartePass in carte.NomArmPass)
                {
                    if (pass == cartePass)
                    {
                        Assert.Equal(pass, cartePass);
                    }
                }
            }

            foreach (Ennemie ennemie in lesEnnemies)
            {
                foreach (Ennemie ennemie1 in carte.LesEnnemies)
                {
                    if (ennemie.Nom == ennemie1.Nom)
                    {
                        Assert.Equal(ennemie, ennemie1);
                    }
                }
            }

            foreach (ArmePassive armePassive in lesObjetsCacher)
            {
                foreach (ArmePassive objetCacher in carte.LesObjetsCaches)
                {
                    if (armePassive.Nom == objetCacher.Nom)
                    {
                        Assert.Equal(armePassive, objetCacher);
                    }
                }
            }

            Assert.Equal(desc, carte.Description);
            Assert.Equal(image, carte.Image);
        }

        //[Fact]
        //public void testAffichEnnemie()
        //{
        //    string nom = "carte";

        //    HashSet<Stat> stats = new HashSet<Stat>(); ;
        //    stats.Add(new Stat(Stat.NomStat.Growth, 40));
        //    stats.Add(new Stat(Stat.NomStat.Luck));
        //    stats.Add(new Stat(Stat.NomStat.Magnet, 10));

        //    Ennemie e1 = new Ennemie("ennemie1", stats);
        //    Ennemie e2 = new Ennemie("ennemie2", stats);

        //    ArmePassive a1 = new ArmePassive("objet1",stats);
        //    ArmePassive a2 = new ArmePassive("objet2",stats);

        //    List<Ennemie> lesEnnemies = new List<Ennemie> { e1, e2 };
        //    List<ArmePassive> lesObjetsCacher = new List<ArmePassive> { a1, a2 };

        //    string image = "/Sources/VSCSolution/VuesVSC/Images/Sprite-Empty_Tome.png";

        //    string desc = "ceci est une carte";

        //    Carte carte = new Carte(nom, lesEnnemies, lesObjetsCacher, desc, image);

        //    string attente = "";
        //    int i = 1;

        //    foreach (Ennemie ennemie in lesEnnemies)
        //    {
        //        attente = attente + "Ennemie n°" + i.ToString() + " présent dans la zone : " + ennemie.Nom;
        //        i++;

        //    }

        //    Assert.Equal(attente, carte.affichEnnemie());
        //}

        //[Fact]
        //public void testAffichArmePassive()
        //{
        //    string nom = "carte";

        //    HashSet<Stat> stats = new HashSet<Stat>(); ;
        //    stats.Add(new Stat(Stat.NomStat.Growth, 40));
        //    stats.Add(new Stat(Stat.NomStat.Luck));
        //    stats.Add(new Stat(Stat.NomStat.Magnet, 10));

        //    Ennemie e1 = new Ennemie("ennemie1", stats);
        //    Ennemie e2 = new Ennemie("ennemie2", stats);

        //    ArmePassive a1 = new ArmePassive("objet1",stats);
        //    ArmePassive a2 = new ArmePassive("objet2",stats);

        //    List<Ennemie> lesEnnemies = new List<Ennemie> { e1, e2 };
        //    List<ArmePassive> lesObjetsCacher = new List<ArmePassive> { a1, a2 };

        //    string image = "/Sources/VSCSolution/VuesVSC/Images/Sprite-Empty_Tome.png";

        //    string desc = "ceci est une carte";

        //    Carte carte = new Carte(nom, lesEnnemies, lesObjetsCacher, desc, image);

        //    string attente = "";
        //    int i = 1;

        //    foreach (ArmePassive objetCacher in lesObjetsCacher)
        //    {
        //        attente = attente + "Arme passive caché n°" + i.ToString() + " : " + objetCacher.Nom;
        //        i++;
        //    }

        //    Assert.Equal(attente, carte.affichArmePassive());
        //}

    }
}
