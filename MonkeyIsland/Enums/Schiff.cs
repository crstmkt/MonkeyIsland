using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyIsland.Enums
{
    public static class Schiff
    {

        public static Dictionary<int, string> SchiffMain = new Dictionary<int, string>
        {
            {0, "Black" },
            {1, "Dead" },
            {2, "Iron" },
            {3, "Queen" },
            {4, "Lady" },
            {5, "Ocean" }
        };

        public static Dictionary<int, string> SchiffSuffix = new Dictionary<int, string>
        {
            {0, "Pearl" },
            {1, "Lady"},
            {2, "Queen" },
            {3, "in Black" },
            {4, "Mary" },
            {5, "Lucy" }
        };
    }
}
