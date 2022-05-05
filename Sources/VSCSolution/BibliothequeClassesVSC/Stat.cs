using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public enum NomStat
    {
        /// <summary>
        /// stats globales posséder par plusieurs types (ex : MoveSpeed commun aux monstre et aux personnages)
        /// </summary>
        MaxHealth,
        Recovery,
        Armor,
        MoveSpeed,
        Might,
        Area,
        Speed,
        Duration,
        Amount,
        Cooldown,
        
        /// <summary>
        /// stats propres aux personnages 
        /// </summary>
        Luck,
        Growth,
        Greed,
        Magnet,

        /// <summary>
        /// stats propres aux monstres 
        /// </summary>
        XpGiven,
        KnockbackReceive,

        /// <summary>
        /// stats propres aux armes
        /// </summary>
        MaxLevel,
        Knockback,
        Rarity,
        CritRate,
        CritMultiplier,

    }
    public class Stat
    {
        /// <summary>
        /// Une stat possède sa valeur
        /// </summary>
        public int Valeur { get; set; }

        /// <summary>
        /// Une stat possède son nom
        /// </summary>
        public NomStat Nom { get; private set; }

        /// <summary>
        /// Constructeur de stat
        /// </summary>
        /// <param name="nom">Nom de la stat</param>
        /// <param name="valeur">Valeur de la stat</param>
        public Stat (NomStat nom, int valeur=0)
        {
            Nom = nom;
            Valeur = valeur;
        }
    }
}
