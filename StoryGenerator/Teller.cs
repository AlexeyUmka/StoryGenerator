using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryGenerator.Enemies;
using StoryGenerator.Treasures.Food;
using StoryGenerator.Treasures.Medecine;
using StoryGenerator.Treasures.Mind;
using StoryGenerator.Commons;
using StoryGenerator.Choices;
using StoryGenerator.RestPlaces;

namespace StoryGenerator
{
    public static class Teller
    {
        public static string Story { get; set; }
        private static List<IEntity> Way { get; set; } = new List<IEntity>();
        public static int Steps { get; set; }
        public static int End { get; set; }
        public static void WriteTopInformation(Hero hero, string locationMessage, ConsoleColor locationColor, ConsoleColor statusColor = ConsoleColor.DarkBlue)
        {
            Console.Clear();
            Console.ForegroundColor = statusColor;
            Console.WriteLine(hero.GetStatus());
            Console.WriteLine("Пройдено " + Steps + " из " + End);
            Console.ForegroundColor = locationColor;
            Console.WriteLine(locationMessage+"\n\n");
            DisplayWay();
            Console.WriteLine();
        }
        public static void AddSectionToWay(IEntity section)
        {
            //TripleChoice _|| ^^, Common _______, Deadline _{Q-Q}_, Delay _[Zzz]_, Laziness _[~0~]_, FirstTypeRest __|=|__, Chocolate __]]]__, FreshRat _<-.->_, Potato __(`)__, Medecine __|+|__, Flashlight __==(:_, Matches __|/|__
            Way.Add(section);
        }
        public static void DisplayWay()
        {
            for(int i = 0; i < Way.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if (i == Way.Count - 1)
                    Console.Write("0");
                if(Way[i] is TripleChoice)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("_|| ^^");
                }
                else if(Way[i] is Common)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("_______");
                }
                else if (Way[i] is Deadline)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("_{Q-Q}_");
                }
                else if (Way[i] is Delay)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("_[Zzz]_");
                }
                else if (Way[i] is Laziness)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("_[~0~]_");
                }
                else if(Way[i] is FirstTypeRest)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("__|=|__");
                }
                else if(Way[i] is Chocolate)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("__]]]__");
                }
                else if(Way[i] is FreshRat)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("_<-.->_");
                }
                else if(Way[i] is Potato)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("__(`)__");
                }
                else if(Way[i] is Medecine)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("__|+|__");
                }
                else if(Way[i] is Flashlight)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("__==(:_");
                }
                else if(Way[i] is Matches)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(@"__|\|__");
                }
            }
        }
    }
}
