using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace notelohell.Utils
{
    public static class HeroesStandard
    {
        public static IList<string> Categories = 
            new List<string>()
            {
                "Offensive",
                "Defensive",
                "Tank",
                "Support"
            };

        public static IDictionary<string, string> Heroes = new Dictionary<string, string>()
        {
            { "ana","Support" },
            { "bastion","Defensive" },
            { "doomfist","Offensive" },
            { "dva", "Tank" },
            { "genji","Offensive" },
            { "hanzo","Defensive" },
            { "junkrat","Defensive" },
            { "lucio","Support" },
            { "mccree","Offensive" },
            { "mei","Defensive" },
            { "mercy","Support" },
            { "orisa","Tank" },
            { "pharah", "Offensive" },
            { "reaper", "Offensive" },
            { "reinhardt", "Tank" },
            { "roadhog", "Tank" },
            { "soldier76", "Offensive" },
            { "sombra", "Offensive" },
            { "symmetra", "Support" },
            { "torbjorn", "Defensive" },
            { "tracer", "Offensive" },
            { "widowmaker", "Defensive" },
            { "winston", "Tank" },
            { "zarya", "Tank" },
            { "zenyatta", "Support" }
        };
    }

    public class OffensiveHero
    {
        public long GamesWon { get; set; }
        public long GamesLost { get; set; }
        public long GamesPlayed { get; set; }
        public long Kills { get; set; }
        public long Damage { get; set; }
        public long ObjectiveKills { get; set; }
        public long ObjectiveTime { get; set; }
        public long WeaponAcc { get; set; }
    }

    public class DefensiveHero
    {
        public long GamesWon { get; set; }
        public long GamesLost { get; set; }
        public long GamesPlayed { get; set; }
        public long Kills { get; set; }
        public long Damage { get; set; }
        public long ObjectiveKills { get; set; }
        public long ObjectiveTime { get; set; }
        public long DamageBlock { get; set; }
        public long DamageBlockAvg { get; set; }
    }

    public class TankHero
    {
        public long GamesWon { get; set; }
        public long GamesLost { get; set; }
        public long GamesPlayed { get; set; }
        public long DamageBlock { get; set; }
        public long DamageBlockAvg { get; set; }
        public long ObjectiveTime { get; set; }
    }

    public class SupportHero
    {
        public long GamesWon { get; set; }
        public long GamesLost { get; set; }
        public long GamesPlayed { get; set; }
        public long DamageAmp { get; set; }
        public long DamageAmpAvg { get; set; }
        public long Ressurect { get; set; }
        public long RessurectAvg { get; set; }
        public long Healing { get; set; }
        public long HealingAvg { get; set; }
    }
}