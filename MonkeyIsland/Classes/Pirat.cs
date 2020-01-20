using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyIsland.Classes
{
    class Pirat
    {

		private Location location;

		public Location Location
		{
			get { return location; }
			set { location = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string vorname;

		public string Vorname
		{
			get { return vorname; }
			set { vorname = value; }
		}

		private string spitzname;

		public string Spitzname
		{
			get { return spitzname; }
			set { spitzname = value; }
		}

		private int staerke;

		public int Staerke
		{
			get { return staerke; }
			set { staerke = value; }
		}

		private int health;

		public int Health
		{
			get { return health; }
			set { health = value; }
		}

		private int money;

		public int Money
		{
			get { return money; }
			set { money = value; }
		}

		public bool IsAlive
		{
			get { return this.Health <= 0 ? false : true; }
		}

		private bool isNPC;

		public bool IsNPC
		{
			get { return isNPC; }
			set { isNPC = value; }
		}






		public Pirat(string vorname, 
						string nachname,
						string spitzname,
						int staerke,
						int health,
						bool isNPC = true)
		{
			this.vorname = vorname;
			this.name = nachname;
			this.spitzname = spitzname;
			this.staerke = staerke;
			this.health = health;
			this.Money = 20;
			this.IsNPC = isNPC;
		}

		public void ChangeLocation(Location newLocation)
		{
			this.Location = newLocation;
			switch (Location.LocationType)
			{
				case Enums.LocationType.Kneipe:
					this.Location = (Kneipe)this.Location;
					break;
				case Enums.LocationType.Strand:
					this.Location = (Strand)this.Location;
					break;
				case Enums.LocationType.Schiff:
					this.Location = (Schiff)this.Location;
					break;
				case Enums.LocationType.Insel:
					this.Location = (Insel)this.Location;
					break;
				case Enums.LocationType.Meer:
					this.Location = (Meer)this.Location;
					break;
			}
			Console.Clear();
		}

		public void WhereAmI()
		{
			Console.WriteLine(String.Format("Sie befinden sich nun {0} {1}", this.Location.NamePrefix, this.Location.Name));
		}

		public void ShowStatus()
		{
			Console.WriteLine(String.Format("Eure Werte: \n\r" +
								"Staerke: {0} \n\r" +
								"Gesundheit: {1} \n\r" + 
								"Muenzen: {2}", 
								this.Staerke, this.Health, this.Money));
		}

		public void LocationChanged()
		{
				WhereAmI();
				Console.WriteLine("Was möchten sie tun?");
				Location.ShowActions();
		}

		public void Kaempfen(Pirat gegner)
		{
			Random r = new Random();
			bool crit = false;
			
			if (!this.IsNPC)
			{
				crit = (r.Next(30) % 6 == 0 ? true : false);
			}

			double multiplikator = r.NextDouble();

			int schaden = (int)((this.Staerke * multiplikator) / 2);

			Console.WriteLine(String.Format("Sie {0} {1} {2}kritischen Schaden.",	(!this.IsNPC ? "machen" : "erhalten"),
																					schaden, 
																					(crit ? String.Empty : "nicht ")));

			gegner.Health = crit ? gegner.Health - (schaden*2) : gegner.Health - schaden;

			if (gegner.Health <= 0)
			{
				if(this.Location != null 
					&& this.Location.NPCPiraten.Contains(gegner))
				{
					var win = r.Next(5, 25);
					Console.WriteLine("Ihr Gegner wurde besiegt.");
					Console.WriteLine(String.Format("Ihr erhaltet {0} Münzen", win));
					this.Money = this.Money + win;
					this.Staerke = this.Staerke + 5;
					this.Location.NPCPiraten.Remove(gegner);
					this.ShowStatus();
					return;
				}
				else
				{
					Console.WriteLine("Ihr wurdet besiegt.");
					gegner.ShowStatus();
					return;
				}
			}
			
			gegner.Kaempfen(this);

		}

		public void EssenTrinken()
		{
			do
			{
				Console.WriteLine("Was wollt Ihr essen oder trinken?\n\r" +
									"(1) Einen Grog trinken\n\r" + 
									"(2) Einen Seemannstopf essen\n\r" +
									"(99) Verlassen");
				switch (Int32.Parse(Console.ReadLine()))
				{
					case 1:
						NahrungAufnehmen(Enums.EssenTrinken.Grog);
						break;
					case 2:
						NahrungAufnehmen(Enums.EssenTrinken.Seemannstopf);
						break;
					case 99:
						return;
				}

			} while (true);

		}

		public void NahrungAufnehmen(Enums.EssenTrinken type)
		{
			var kosten = 0;
			var health = 0;
			bool essen = true;

			switch (type)
			{
				case Enums.EssenTrinken.Grog:
					kosten = 3;
					health = 3;
					essen = false;
					break;
				case Enums.EssenTrinken.Seemannstopf:
					kosten = 10;
					health = 15;
				break;
			}

			if (this.Money < kosten)
			{
				Console.WriteLine(String.Format("Ihr habt nicht genug Muenzen um etwas zu {0}", (essen ? "essen" : "trinken")));
				Console.ReadLine();
				return;
			}
			Console.WriteLine(String.Format("Ihr habt etwas {0}...", (essen ? "gegessen" : "getrunken")));
			this.Money = this.Money - kosten;
			this.Health = (this.Health + health >= 100 ? 100 : this.Health + health);
			this.ShowStatus();
			Console.ReadLine();
		}


	}
}
