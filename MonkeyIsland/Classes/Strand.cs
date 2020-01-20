using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyIsland.Classes
{
    class Strand : Location
    {
        private Insel insel;

        public Insel Insel
        {
            get { return insel; }
            set { insel = value; }
        }
        public Strand(Pirat p, Insel i)
        {
            this.Pirat = p;
            this.Insel = i;
            this.LocationType = Enums.LocationType.Strand;
            this.NamePrefix = "am Strand";
            if (this.NPCPiraten == null)
            {
                this.NPCPiraten = new List<Pirat>();
            }
            else
            {
                this.NPCPiraten.Clear();
            }
            Random r = new Random();
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
                        this.Pirat.ChangeLocation(this.Insel);
                        this.Pirat.LocationChanged();
                        break;
                }
            } 
            if (this.Pirat.IsAlive)
            {
                Console.WriteLine("(1) In die Kneipe gehen\n\r" +
                                     "(2) In den Dschungel gehen\n\r" +
                                     "(3) Mit einem Schiff auf eine neue Insel fahren");
                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        this.Pirat.ChangeLocation(this.Insel.Kneipe);
                        this.Pirat.LocationChanged();
                        break;
                    case 2:
                        this.Pirat.ChangeLocation(this.Insel);
                        this.Pirat.LocationChanged();
                        break;
                    case 3:
                        this.Pirat.ChangeLocation(new Schiff(this.Pirat, this.Insel.Meer));
                        this.Pirat.LocationChanged();
                        break;
                }
            }
        }
    }
}
