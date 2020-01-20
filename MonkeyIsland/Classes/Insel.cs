using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyIsland.Classes
{
    class Insel : Location
    {
		private Meer meer;

		public Meer Meer
		{
			get { return meer; }
			set { meer = value; }
		}


		private Strand strand;

		public Strand Strand
		{
			get { return strand; }
			set { strand = value; }
		}

		private Kneipe kneipe;

		public Kneipe Kneipe
		{
			get { return kneipe; }
			set { kneipe = value; }
		}

		public Insel(Pirat p, Meer m)
		{
			Random r = new Random();

			int islandRandomPrefix = r.Next(Enums.IslandNames.IslandPrefix.Count() - 1);
			int islandRandomMain = r.Next(Enums.IslandNames.IslandMain.Count() - 1);
			int islandRandomSuffix = r.Next(Enums.IslandNames.IslandSuffix.Count() - 1);

			this.Name = String.Format("{0} {1} {2}",
											Enums.IslandNames.IslandPrefix.First(x => x.Key == (islandRandomPrefix < 0 ? 0: islandRandomPrefix)).Value,
											Enums.IslandNames.IslandMain.First(x => x.Key == (islandRandomMain < 0 ? 0 : islandRandomMain)).Value,
											Enums.IslandNames.IslandSuffix.First(x => x.Key == (islandRandomSuffix < 0 ? 0 : islandRandomSuffix)).Value);
			this.Kneipe = new Kneipe(p, this);
			this.Strand = new Strand(p, this);
			this.LocationType = Enums.LocationType.Insel;
			this.NamePrefix = "auf der Insel";
			this.Pirat = p;
			this.Meer = m;
		}

		public override void ShowActions()
		{
			Console.WriteLine(	"(1) In die Kneipe gehen\n\r" + 
								"(2) An den Strand gehen\n\r" + 
								"(3) Mit einem Schiff auf eine neue Insel fahren");
			switch (Int32.Parse(Console.ReadLine()))
			{
				case 1:
					this.Pirat.ChangeLocation(this.Kneipe);
					this.Pirat.LocationChanged();
					break;
				case 2:
					this.Pirat.ChangeLocation(this.Strand);
					this.Pirat.LocationChanged();
					break;
				case 3:
					this.Pirat.ChangeLocation(new Schiff(this.Pirat, this.Meer));
					this.Pirat.LocationChanged();
					break;
			}
		}


	}
}
