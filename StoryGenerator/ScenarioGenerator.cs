using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator
{
    public static class ScenarioGenerator
    {
        public static AreaType NowArea { get; set; } = AreaType.Common;
        public static int DifficultLuckyModifier { get; set; } = 0; //max value is 5, not implemented, can be removed
        public static Random r = new Random();
        public static AreaType GenerateNextArea()
        {
            int n = r.Next(1, 11);
            switch (n)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    return AreaType.Enemy;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    return AreaType.ChoiceWay;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    return AreaType.Relax;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    return AreaType.Treasure;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    return AreaType.Common;
            }
        }
        public static Treasure GetTreasure()
        {
            int n = r.Next(1, 11);
            switch (n)
            {
                case int num when num <= 2:
                    return Treasure.Medecines;
                case int num when num <= 4:
                    return Treasure.Mind;
                default:
                    return Treasure.Food;
            }
        }
        public static Food GetFood()
        {
            int n = r.Next(1, 11);
            switch (n)
            {
                case 1:
                    return Food.FreshRat;
                case int num when num <= 5:
                    return Food.Chocolate;
                default:
                    return Food.Potato;
            }
        }
        public static Mind GetMind()
        {
            int n = r.Next(1, 11);
            switch (n)
            {
                case int num when num <= 7:
                    return Mind.Match;
                default:
                    return Mind.FlashLight;
            }
        }
        public static Enemy GetEnemy()
        {
            int n = r.Next(1, 11);
            switch (n)
            {
                case 1:
                    return Enemy.Deadline;
                case int num when num <= 6:
                    return Enemy.Delay;
                default:
                    return Enemy.Laziness;
            }
        }

    }
}
