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
            MaxHealth = 1,
            Recovery = 2,
            Armor = 3,
            MoveSpeed = 4,
            Might = 5,
            Area = 6,
            Speed = 7,
            Duration = 8,
            Amount = 9,
            Cooldown = 10,
            Curse = 11,

            /// <summary>
            /// stats propres aux personnages 
            /// </summary>
            Luck = 12,
            Growth = 13,
            Greed = 14,
            Magnet = 15,

            /// <summary>
            /// stats propres aux monstres 
            /// </summary>
            XpGiven = 16,
            KnockbackReceive = 17,

            /// <summary>
            /// stats propres aux armes
            /// </summary>
            MaxLevel = 18,
            Knockback = 19,
            Rarity = 20,
            CritRate = 21,
            CritMultiplier = 22,
        }
    }
}
