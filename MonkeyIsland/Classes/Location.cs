using MonkeyIsland.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyIsland.Classes
{
    abstract class Location
    {
        private Pirat pirat;

        public Pirat Pirat
        {
            get { return pirat; }
            set { pirat = value; }
        }

        private LocationType locationType;

        public LocationType LocationType
        {
            get { return locationType; }
            set { locationType = value; }
        }

        private List<Pirat> nPCPiraten;
        public List<Pirat> NPCPiraten
        {
            get { return nPCPiraten; }
            set { nPCPiraten = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string namePrefix;

        public string NamePrefix
        {
            get { return namePrefix; }
            set { namePrefix = value; }
        }

        public abstract void ShowActions();



    }
}
