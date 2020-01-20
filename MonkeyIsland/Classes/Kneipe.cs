using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyIsland.Classes
{
    class Kneipe : Location
    {
		private Insel insel;

		public Insel Insel
		{
			get { return insel; }
			set { insel = value; }
		}

		public Kneipe(Pirat p, Insel i)
        {
			Random r = new Random();

			int kneipeRandomPrefix = r.Next(Enums.KneipenName.KneipePrefix.Count() - 1);
			int kneipeRandomMain = r.Next(Enums.KneipenName.KneipeMain.Count() - 1);
			int kneipeRandomSuffix = r.Next(Enums.KneipenName.KneipeSuffix.Count() - 1);

			this.Name = String.Format("{0} {1} {2}",
											Enums.KneipenName.KneipePrefix.First(x => x.Key == (kneipeRandomPrefix < 0 ? 0 : kneipeRandomPrefix)).Value,
											Enums.KneipenName.KneipeMain.First(x => x.Key == (kneipeRandomMain < 0 ? 0 : kneipeRandomMain)).Value,
											Enums.KneipenName.KneipeSuffix.First(x => x.Key == (kneipeRandomSuffix < 0 ? 0 : kneipeRandomSuffix)).Value);
			this.Pirat = p;
			this.Insel = i;
			this.LocationType = Enums.LocationType.Kneipe;
            this.NamePrefix = "in der Kneipe";

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
						this.Pirat.ChangeLocation(this.Insel);
						this.Pirat.LocationChanged();
						break;
				}
			}
			if (this.Pirat.IsAlive)
			{
				Console.WriteLine("(1) Etwas essen oder trinken\n\r" +
									"(2) An den Strand gehen\n\r" +
									"(3) Mit einem Schiff auf eine neue Insel fahren");
				switch (Int32.Parse(Console.ReadLine()))
				{
					case 1:
						this.Pirat.EssenTrinken();
						break;
					case 2:
						this.Pirat.ChangeLocation(this.Insel.Strand);
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
