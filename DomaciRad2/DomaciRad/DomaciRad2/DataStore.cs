using System;
using System.Collections.Generic;
using System.Text;

namespace DomaciRad
{
    public static class DataStore
    {
        public static Dictionary<int, string> PlayList { get; } = new Dictionary<int, string>
            {
                {1, "Iron Maiden - The Wicker Man"},
                {2, "Iron Maiden - Dance of the Dead"},
                {3, "AC/DC - TNT"},
                {4, "Billy Idol - Rebel Yell"},
                {5, "Billy Idol - White Wedding"},
                {6, "AC/DC - Thunderstruck"},
                {7, "Iron Maiden - The Trooper" },
                {8, "Iron Maiden - Aces High" },
                {9, "Whitesnake - Here I go again" },
                {10, "Aerosmith - Dream On" },
                {11, "Aerosmith - Janie's got a gun" }
            };
    }
}
