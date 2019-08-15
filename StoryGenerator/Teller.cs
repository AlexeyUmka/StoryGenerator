using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator
{
    public static class Teller
    {
        public static string Story { get; set; }
        public static int Steps { get; set; }
        public static int End { get; set; }
        public static void WriteTopInformation(Hero hero, string locationMessage, ConsoleColor locationColor, ConsoleColor statusColor = ConsoleColor.DarkBlue)
        {
            Console.Clear();
            Console.ForegroundColor = statusColor;
            Console.WriteLine(hero.GetStatus());
            Console.WriteLine("Пройдено " + Steps + " из " + End);
            Console.ForegroundColor = locationColor;
            Console.WriteLine(locationMessage);
        }
    }
}
