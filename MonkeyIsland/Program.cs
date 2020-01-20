using MonkeyIsland.Classes;
using System;
using System.Linq;

namespace MonkeyIsland
{
    class Program
    {
        public static Pirat Player;
        public static Meer GameWorld;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Willkommen. Was wollen Sie tun?");

                Console.WriteLine("(1) Neues Spiel\n\r" +
                                   "(99) Verlassen");

                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        InitializeNewGame();
                        break;
                    case 60:
                        DemoIslandNames();
                        break;
                    case 99:
                        return;
                }
            } while (true);

        }

        static void InitializeNewGame()
        {
            Console.Clear();
            Player = new Pirat("Guybrush", "Threepwood", "", 100, 100, false);
            GameWorld = new Meer(Player);
            Player.ChangeLocation(GameWorld.Inseln.First());
            NextStep(GameWorld.Inseln.First());
        }

        static void NextStep(Insel currentIsland)
        {
            do
            {
                Console.Clear();
                Player.WhereAmI();
                Player.Location.ShowActions();
            } while (Player.IsAlive);

            Console.WriteLine("Game Over!");

        }

        static void DemoIslandNames()
        {
            var rand = new Random();
            var prefixnum = rand.Next(Enums.IslandNames.IslandPrefix.Count()-1);
            var mainnum = rand.Next(Enums.IslandNames.IslandMain.Count()-1);
            var suffixnum = rand.Next(Enums.IslandNames.IslandSuffix.Count()-1);

            Console.WriteLine(String.Format("{0} {1} {2}", 
                                            Enums.IslandNames.IslandPrefix.First(x => x.Key == (prefixnum < 0 ? 0 : prefixnum)).Value,
                                            Enums.IslandNames.IslandMain.First(x => x.Key == (mainnum < 0 ? 0 : mainnum)).Value,
                                            Enums.IslandNames.IslandSuffix.First(x => x.Key == (suffixnum < 0 ? 0 : suffixnum)).Value));

            Console.ReadLine();

        }
    }
}
