using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StoryGenerator
{
    #region enums
    public enum AreaType
    {
        Common,
        Enemy,
        Relax,
        ChoiceWay,
        Treasure
    }
    public enum Food
    {
        Potato,
        Chocolate,
        FreshRat
    }
    public enum Mind
    {
        FlashLight,
        Match
    }
    public enum Treasures
    {
        Medecines,
        Food,
        Mind
    }
    public enum Enemy
    {
        Laziness,
        Delay,
        Deadline
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            SpendingByStep.setHero = hero;
            int steps = 0;
            string story = "История приключений Василия:\n";
            Console.WriteLine("После удачного прохождения собеседования на должность программиста в компанию ЛГУГ\n" +
                "Василия отправили в серверную, где живёт главный админ, чтобы он его добавил в базу... ");
            story += "После удачного прохождения собеседования на должность программиста в компанию ЛГУГ\n" +
                "Василия отправили в серверную, где живёт главный админ, чтобы он его добавил в базу...\n";
            Thread.Sleep(5000);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Помоги Василию пройти(пробел - пройти 1 метр) Смертельный лабиринт из кабелей и крыс и получи сгенерированную историю Василия,\nследи за его показателями, если они опустятся ниже нуля, он навсегда останется жителем серверной\n" +
                "для взаимодействия с локацией нажимай E(нажмите любую клавишу, чтобы начать):");
            Console.ReadKey();
            int end = new Random().Next(30, 70);
            story += "Ему предстояло пройти " + end + " метров через джунгли из проводов и удлинителей.\nСитуацию усложнял диплом Василия, который нужно было сдать уже завтра.\nПоэтому наш герой очень волновался и хотел всё сделать как можно быстрее.";
            while (steps <= end)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(hero.GetStatus());
                Console.WriteLine("Пройдено "+steps+" из "+end);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                AreaType area = ScenarioGenerator.GenerateNextArea();
                Console.WriteLine(area);
                string mes = "";
                switch (area)
                {
                    case AreaType.Common:
                        Console.WriteLine("Ничего интересного можно идти дальше"); 
                        break;
                    case AreaType.Relax:
                        Console.WriteLine("Вы находите отличное место для отдыха! E-(+20 к энергии + 10 к здоровью - 10 еды)");
                        if (ConsoleKey.E == Console.ReadKey().Key)
                        {
                            hero.Energy += 20;
                            hero.Health += 10;
                            hero.Food -= 10;
                            hero.RestAmount++;
                        }
                        break;
                    case AreaType.Enemy:
                        Enemy e = ScenarioGenerator.GetEnemy();
                        switch (e) 
                        {
                            case Enemy.Laziness:
                                mes = "Лень(-5 к здоровью)E-убежать(-10 к енергии)";
                                Console.WriteLine("На вас нападает: " + mes);
                                if (ConsoleKey.E == Console.ReadKey().Key)
                                    hero.Energy -= 10;
                                else
                                {
                                    hero.Health -= 5;
                                    hero.LazKilled++;
                                }
                                break;
                            case Enemy.Delay:
                                mes = "Прокрастинация(-10 к здоровью)E-убежать(-20 к енергии)";
                                Console.WriteLine("На вас нападает: " + mes);
                                if (ConsoleKey.E == Console.ReadKey().Key)
                                    hero.Energy -= 20;
                                else
                                {
                                    hero.Health -= 10;
                                    hero.DelKilled++;
                                }
                                break;
                            case Enemy.Deadline:
                                mes = "ДЭДЛАЙН!(-20 к здоровью)E-убежать(-40 к енергии)";
                                Console.WriteLine("На вас нападает: " + mes);
                                if (ConsoleKey.E == Console.ReadKey().Key)
                                    hero.Energy -= 40;
                                else
                                {
                                    hero.Health -= 20;
                                    hero.DeadlineKilled++;
                                }
                                break;
                        }
                        break;
                    case AreaType.ChoiceWay:
                        Console.WriteLine("Перед вами 3 пути(1num - Спрыгнуть вниз(-6 здоровья), 2num - залезть наверх(-6 енергии),3num - обойти(-6 рассудок))");
                        hero.DifficultChoice++;
                        ConsoleKey k = Console.ReadKey().Key;
                        if (ConsoleKey.NumPad1 == k)
                            hero.Health -= 6;
                        else if (ConsoleKey.NumPad2 == k)
                            hero.Energy -= 6;
                        else
                            hero.Mind -= 6;
                            break;
                    case AreaType.Treasure:
                        Treasures t = ScenarioGenerator.GetTreasure();
                        switch (t)
                        {
                            case Treasures.Food:
                                Food f = ScenarioGenerator.GetFood();
                                switch (f)
                                {
                                    case Food.Chocolate:
                                        mes = "Шоколад(+15 к еде + 10 к рассудку)";
                                        hero.Food += 15;
                                        hero.Mind += 10;
                                        hero.ChocolateAte++;
                                        break;
                                    case Food.Potato:
                                        mes = "Картошку(+5 к еде)";
                                        hero.Food += 5;
                                        hero.PotatoAte++;
                                        break;
                                    case Food.FreshRat:
                                        mes = "Мертвую крысу(ещё теплая), вкуснятина! E-(+30 к еде -20 к рассудку + 30 к енергии)";
                                        if (ConsoleKey.E == Console.ReadKey().Key)
                                        {
                                            hero.Food += 30;
                                            hero.Mind -= 20;
                                            hero.Energy += 30;
                                            hero.FreshRatAte++;
                                        }
                                        break;
                                }
                                break;
                            case Treasures.Medecines:
                                mes = "Медикаменты(+20 к здоровью)";
                                hero.Health += 20;
                                hero.MedicineUsed++;
                                break;
                            case Treasures.Mind:
                                Mind m = ScenarioGenerator.GetMind();
                                switch (m)
                                {
                                    case Mind.Match:
                                        mes = "Спички(+10 к рассудку)";
                                        hero.Mind += 10;
                                        break;
                                    case Mind.FlashLight:
                                        mes = "Фонарик(+20 к рассудку)";
                                        hero.Mind += 20;
                                        break;
                                }
                                break;
                        }
                        Console.WriteLine("В темноте вы натыкаетесь на: " + mes);
                        break;
                        
                }
                SpendingByStep.InvokeSpending(SpendingByStep.healthSpending, SpendingByStep.foodSpending, SpendingByStep.energySpending, SpendingByStep.mindSpending);
                if (hero.Health < 0 || hero.Mind < 0 || hero.Energy < 0 || hero.Food < 0)
                { 
                    hero.IsAlive = false;
                    break;
                }
                   
                Console.WriteLine("Нажмите пробел, чтобы идти дальше");
                ConsoleKeyInfo key = Console.ReadKey();
                while (key.Key != ConsoleKey.Spacebar)
                    key = Console.ReadKey();
                steps++;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(story);
            if (hero.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Благодаря своей смекалке и проворности Василий сумел добраться до логова админа целым и невредимым.");
                Console.WriteLine(@"О нём написали легенду 'Выживший или жизнь после серверной'. Никто не знает, куда он подевался, но он стал первопроходцем, который ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("К сожалению, удача не была на стороне Василия и его поглотила серверная, он стал её частью.");
                Console.WriteLine("Пускай он не стал победителем, но его достижения заслуживают уважения, он");
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (hero.LazKilled > 0)
                Console.WriteLine("Одолел {0} ед. Лени.", hero.LazKilled);
            if (hero.DelKilled > 0)
                Console.WriteLine("Раздавил {0} ед. Прокрастинации.", hero.DelKilled);
            if (hero.DeadlineKilled > 0)
                Console.WriteLine("Опередил {0} ед. Дедлайна.", hero.DeadlineKilled);
            Console.WriteLine("Питался: ");
            if (hero.PotatoAte > 0)
                Console.WriteLine("{0} ед. Картошки.", hero.PotatoAte);
            if (hero.ChocolateAte > 0)
                Console.WriteLine("{0} ед. Шок.Батончиков.", hero.ChocolateAte);
            if (hero.FreshRatAte > 0)
                Console.WriteLine("{0} ед. Свежих крыс", hero.FreshRatAte);
            Console.WriteLine("На протяжении своего пути отдыхал всего лишь {0} раз.", hero.RestAmount);
            Console.WriteLine("Использовал аптечки {0} раз.", hero.MedicineUsed);
            Console.WriteLine("А делал сложный выбор {0} раз.", hero.DifficultChoice);
            Console.WriteLine("Завершил свой путь с такими показателями: ");
            Console.WriteLine(hero.GetStatus());
            Console.ReadKey();
        }
    }
    public static class ScenarioGenerator
    {
        public static AreaType NowArea { get; set; } = AreaType.Common;
        public static int DifficultLuckyModifier { get; set; } = 0; //max value is 5, not implemented, can be removed
        public static AreaType GenerateNextArea()
        {
            Random r = new Random();
            int n = r.Next(1, 11 - DifficultLuckyModifier);
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
                case int num when num <=6 :
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    return AreaType.Treasure;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    return AreaType.Common;
            }
        }
        public static Treasures GetTreasure()
        {
            Random r = new Random();
            int n = r.Next(1, 6);
            switch (n)
            {
                case 1:
                    return Treasures.Medecines;
                case 2:
                    return Treasures.Mind;
                default:
                    return Treasures.Food;
            }
        }
        public static Food GetFood()
        {
            Random r = new Random();
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
            Random r = new Random();
            int n = r.Next(1, 11);
            switch (n)
            {
                case int num when num <= 4:
                    return Mind.Match;
                default:
                    return Mind.FlashLight;
            }
        }
        public static Enemy GetEnemy()
        {
            Random r = new Random();
            int n = r.Next(1, 11);
            switch (n)
            {
                case 1:
                    return Enemy.Deadline;
                case int num when num <= 4:
                    return Enemy.Delay;
                default:
                    return Enemy.Laziness;
            }
        }

    }
    public class Hero
    {
        private int health;
        private int food;
        private int energy;
        private int mind;
        #region Proporties
        public bool IsAlive { get; set; } = true;
        public byte PotatoAte { get; set; } = 0;
        public byte ChocolateAte { get; set; } = 0;
        public byte FreshRatAte { get; set; } = 0;
        public byte LazKilled { get; set; } = 0;
        public byte DelKilled { get; set; } = 0;
        public byte DeadlineKilled { get; set; } = 0;
        public byte RestAmount { get; set; } = 0;
        public byte DifficultChoice { get; set; } = 0;
        public byte MedicineUsed { get; set; } = 0;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public int Food
        {
            get
            {
                return food;
            }
            set
            {
                food = value;
            }
        }
        public int Energy
        {
            get
            {
                return energy;
            }
            set
            {
                energy = value;
            }
        }
        public int Mind {
            get
            {
                return mind;
            }
            set
            {
                mind = value;
            }
        }
        #endregion
        public Hero(int health = 70, int food = 70, int energy = 70, int mind = 70)
        {
            Health = health;
            Food = food;
            Energy = energy;
            Mind = mind;
        }

        public string GetStatus()
        {
            return string.Format($"Здоровье:{Health} Еда:{Food} Енергия:{Energy} Рассудок:{Mind}");
        }
    }
    public static class SpendingByStep
    {
        public static Hero setHero;
        public static int healthSpending = 0;
        public static int foodSpending = -2;
        public static int energySpending = -1;
        public static int mindSpending = -1;

        public static void InvokeSpending(int healthSp, int foodSp, int energySp, int mindSp)
        {
            setHero.Health += healthSp;
            setHero.Food += foodSp;
            setHero.Energy += energySp;
            setHero.Mind += mindSp;
        }
    }
}
