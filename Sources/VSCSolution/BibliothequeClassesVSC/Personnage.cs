using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class Personnage : Entite
    {
        public Personnage(string nom, List<Stat> particularite, string desc = "N/A", string image = "N/A") : base(nom,particularite, desc, image)
        {
            stats.Add(new Stat(Stat.NomStat.Luck, 0));
            stats.Add(new Stat(Stat.NomStat.Growth, 0));
            stats.Add(new Stat(Stat.NomStat.Greed, 0));
            stats.Add(new Stat(Stat.NomStat.Magnet, 0));

            AjoutParticularite(particularite);
        }        
    }
}