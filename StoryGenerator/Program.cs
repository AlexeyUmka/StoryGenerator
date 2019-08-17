using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StoryGenerator
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetWindowSize(160, 41);
            Hero hero = new Hero();
            ScenarioGenerator.InvokeStartGameEvent(hero, Teller.Story);
            Console.WriteLine("CollectionsGeneric");
            Console.ReadKey();
        }
    }
}
