namespace BibliothequeClassesVSC
{

    public partial class Stat
    {
        // le byte correspond à l'ordre d'affichage des statistiques (plus il est bas, plus il est affiché en premier)
        public enum NomStat : byte
        {
            /// <summary>
            /// stats globales posséder par plusieurs types (ex : MoveSpeed commun aux monstre et aux personnages)
            /// </summary>
            MaxHealth=1,
            Recovery=2,
            Armor=3,
            MoveSpeed=4,
            Might=5,
            Area=6,
            Speed=7,
            Duration=8,
            Amount=9,
            Cooldown=10,

            /// <summary>
            /// stats propres aux personnages 
            /// </summary>
            Luck=11,
            Growth=12,
            Greed=13,
            Magnet=14,

            /// <summary>
            /// stats propres aux monstres 
            /// </summary>
            XpGiven=15,
            KnockbackReceive=16,

            /// <summary>
            /// stats propres aux armes
            /// </summary>
            MaxLevel=17,
            Knockback=18,
            Rarity=19,
            CritRate=20,
            CritMultiplier=21,
        }
    }
}
