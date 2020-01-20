using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyIsland.Classes
{
    class Schiff : Location
    {
        private Meer meer;

        public Meer Meer
        {
            get { return meer; }
            set { meer = value; }
        }

        public Schiff(Pirat p, Meer m)
        {
            Random r = new Random();
            
            int schiffRandomMain = r.Next(Enums.Schiff.SchiffMain.Count() - 1);
            int schiffRandomSuffix = r.Next(Enums.Schiff.SchiffSuffix.Count() - 1);

            this.Name = String.Format("{0} {1}",
                                            Enums.Schiff.SchiffMain.First(x => x.Key == (schiffRandomMain < 0 ? 0 : schiffRandomMain)).Value,
                                            Enums.Schiff.SchiffSuffix.First(x => x.Key == (schiffRandomSuffix < 0 ? 0 : schiffRandomSuffix)).Value);

            this.LocationType = Enums.LocationType.Schiff;
            this.NamePrefix = "auf dem Schiff";
            this.Pirat = p;
            this.Meer = m;

            if (this.NPCPiraten == null)
            {
                this.NPCPiraten = new List<Pirat>();
            }
            else
            {
                this.NPCPiraten.Clear();
            }
            for (int c = 0; c < r.Next(1,3); c++)
            {
                this.NPCPiraten.Add(new Pirat(String.Empty, String.Empty, String.Empty, 30, 100));
                //r.Next(this.Pirat.Staerke + 20)
            }
        }

        public override void ShowActions()
        {
            while (this.NPCPiraten.Count > 0 && this.Pirat.IsAlive)
            {
                Console.WriteLine(String.Format("Eine Horde wilder ({0}) Piraten erscheint. Was wollt ihr tun?\n\r" +
                                    "(1) Kaempfen\n\r" +
                                    "(2) Fluechten", this.NPCPiraten.Count));
                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        this.Pirat.Kaempfen(this.NPCPiraten.First());
                        break;
                    case 2:
                        this.Pirat.ChangeLocation(this.Meer);
                        this.Pirat.LocationChanged();
                        break;
                }
            }
            if (this.Pirat.IsAlive)
            {
                Console.WriteLine("(1) Zur Insel übersetzen");
                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        this.Pirat.ChangeLocation(new Insel(this.Pirat, this.Meer));
                        this.Pirat.LocationChanged();
                        break;
                }
            }
        }
    }
}
