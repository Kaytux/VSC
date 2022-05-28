﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    [DataContract, KnownType(typeof(ArmePassive)), KnownType(typeof(ArmeActive)), KnownType(typeof(Amelioration))]
    public abstract class Arme: PossedeStats
    {
        /// <summary>
        /// constructeur de la classe abstraite  Arme
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        /// <param name="niveau"></param>
        public Arme(string nom, HashSet<Stat> particularite, string desc = "N/A", string image = "N/A", byte niveau = 1)
            : base(nom, particularite, desc, image)
        {
            Niveau = niveau;
            stats.Add(new Stat(Stat.NomStat.MaxLevel, 0));
            stats.Add(new Stat(Stat.NomStat.Knockback, 0));
            stats.Add(new Stat(Stat.NomStat.Rarity, 0));
            stats.Add(new Stat(Stat.NomStat.CritRate, 0));
            stats.Add(new Stat(Stat.NomStat.CritMultiplier, 0));
        }
        /// <summary>
        /// declaration de l'attribut Niveau avec son getter et setter
        /// </summary>
        public byte Niveau { get; set; }
        [DataMember]
        public IEnumerable<object> Amelioration { get; set; }

        /// <summary>
        /// méthode qui permet d'augmenter de 1 le Niveau d'une arme 
        /// </summary>
        public void AugmenterNiveau()
        {
            ++this.Niveau;
        }

        /// <summary>
        /// méthode qui permet de baisser de 1 le Niveau d'une arme 
        /// </summary>
        public void BaisserNiveau()
        {
            --this.Niveau;
        }
    }
}
