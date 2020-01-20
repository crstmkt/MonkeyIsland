using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyIsland.Enums
{
    static class IslandNames
    {
        public static Dictionary<int, string> IslandPrefix = new Dictionary<int, string>
        {
            {0, "Les" },
            {1, "Port" },
            {2, "Isla" },
            {3, "La" }
        };

        public static Dictionary<int, string> IslandMain = new Dictionary<int, string>
        {
            {0, "Manta" },
            {1, "Royal" },
            {2, "Siesta"},
            {3, "Maryland" },
            {4, "cinco" }
        };

        public static Dictionary<int, string> IslandSuffix = new Dictionary<int, string>
        {
            {0, "de la Cruz" },
            {1, "Royal" },
            {2, "without suffix" },
            {3, "Harbour" },
            {4, "muertes" }
        };
    }

}
