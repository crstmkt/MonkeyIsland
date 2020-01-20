using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyIsland.Enums
{
    static class KneipenName
    {
        public static Dictionary<int, string> KneipePrefix = new Dictionary<int, string>
        {
            {0, "Zum" },
            {1, "Am" }
        };

        public static Dictionary<int, string> KneipeMain = new Dictionary<int, string>
        {
            {0, "lachenden" },
            {1, "tänzelden" }
        };

        public static Dictionary<int, string> KneipeSuffix = new Dictionary<int, string>
        {
            {0, "Wildschwein" },
            {1, "Pony"}
        };
    }
}
