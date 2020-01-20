using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyIsland.Classes
{
    class Meer : Location
    {
		
		private List<Insel> inseln = new List<Insel>();

		public List<Insel> Inseln
		{
			get { return inseln; }
			set { inseln = value; }
		}

		public Meer(Pirat p)
		{
			this.Pirat = p;
			this.Inseln.Add(new Insel(p, this));
			this.NamePrefix = "im Meer";
		}

		public override void ShowActions()
		{
			Console.WriteLine("(1) An Land schwimmen");
			switch (Int32.Parse(Console.ReadLine()))
			{
				case 1:
					this.Pirat.ChangeLocation(new Insel(this.Pirat, this));
					this.Pirat.LocationChanged();
					break;
			}
		}

	}
}
