using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using StoryGenerator.Enemies;
using StoryGenerator.Treasures.Food;
using StoryGenerator.Treasures.Medecine;
using StoryGenerator.Treasures.Mind;
using StoryGenerator.Commons;
using StoryGenerator.Choices;
using StoryGenerator.CustomExceptions;
using StoryGenerator.RestPlaces;

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
    public enum Treasure
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
    public static class ScenarioGenerator
    {
        private static Random r = new Random();
        private delegate void GameStatus(Hero hero, string story);
        private delegate void FindedItem(Hero hero);
        private static event GameStatus GameIsEnded = GameIsEndedHandler;
        private static event GameStatus GameIsStarted = GameIsStartedHandler;
        private static event FindedItem FindedTreasure = FindedTreasureHandler;
        private static event FindedItem FindedEnemy = FindedEnemyHandler;
        private static event FindedItem FindedRestPlace = FindedRestPlaceHandler;
        private static event FindedItem FindedCommon = FindedCommonHandler;
        private static event FindedItem FindedChoice = FindedChoiceHandler;
        private static AreaType NowArea { get; set; } = AreaType.Common;
        private static AreaType GenerateNextArea()
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
        private static Treasure GetTreasure()
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
        private static Food GetFood()
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
        private static Mind GetMind()
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
        private static Enemy GetEnemy()
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
        private static void InvokeEndGameEvent(Hero hero, string story) => GameIsEnded(hero, story);
        public static void InvokeStartGameEvent(Hero hero, string story) => GameIsStarted(hero, story);
        private static void GameIsStartedHandler(Hero hero, string story)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Teller.Story = "История приключений Василия:\n";
            Console.WriteLine("После удачного прохождения собеседования на должность программиста в компанию ЛГУГ\n" +
                "Василия отправили в серверную, где живёт главный админ, чтобы он его добавил в базу... ");
            Teller.Story += "После удачного прохождения собеседования на должность программиста в компанию ЛГУГ\n" +
                "Василия отправили в серверную, где живёт главный админ, чтобы он его добавил в базу...\n";
            Console.WriteLine("Помоги Василию пройти(пробел - пройти 1 метр) Смертельный лабиринт из кабелей и крыс и получи сгенерированную историю Василия,\nследи за его показателями, если они опустятся ниже нуля, он навсегда останется жителем серверной\n" +
                "для взаимодействия с локацией нажимай E(нажмите любую клавишу, чтобы начать):");
            Console.ReadKey();
            SpendingByStep.setHero = hero;
            Teller.Steps = 0;
            Teller.End = new Random().Next(30, 70);
            Teller.Story += "Ему предстояло пройти " + Teller.End + " метров через джунгли из проводов и удлинителей.\nСитуацию усложнял диплом Василия, который нужно было сдать уже завтра.\nПоэтому наш герой очень волновался и хотел всё сделать как можно быстрее.";
            while (Teller.Steps <= Teller.End)
            {
                AreaType area = ScenarioGenerator.GenerateNextArea();
                switch (area)
                {
                    case AreaType.Common:
                        ScenarioGenerator.FindedCommon(hero);
                        break;
                    case AreaType.Relax:
                        ScenarioGenerator.FindedRestPlace(hero);
                        break;
                    case AreaType.Enemy:
                        ScenarioGenerator.FindedEnemy(hero);
                        break;
                    case AreaType.ChoiceWay:
                        ScenarioGenerator.FindedChoice(hero);
                        break;
                    case AreaType.Treasure:
                        ScenarioGenerator.FindedTreasure(hero);
                        break;
                }
                if (hero.Health < 0 || hero.Mind < 0 || hero.Energy < 0 || hero.Food < 0)
                {
                    hero.IsAlive = false;
                    break;
                }
                Console.WriteLine("Нажмите пробел, чтобы идти дальше");
                ConsoleKeyInfo key = Console.ReadKey();
                while (key.Key != ConsoleKey.Spacebar)
                    key = Console.ReadKey();
                Teller.Steps++;
            }
            ScenarioGenerator.InvokeEndGameEvent(hero, Teller.Story);
        }
        private static void GameIsEndedHandler(Hero hero, string story)
        {
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
            if (hero.RestAmount > 0)
                Console.WriteLine("На протяжении своего пути отдыхал всего лишь {0} раз.", hero.RestAmount);
            if (hero.MedicineUsed > 0)
                Console.WriteLine("Использовал аптечки {0} раз.", hero.MedicineUsed);
            if (hero.DifficultChoice > 0)
                Console.WriteLine("А делал сложный выбор {0} раз.", hero.DifficultChoice);
            Console.WriteLine("Завершил свой путь с такими показателями: ");
            Console.WriteLine(hero.GetStatus());
        }
        private static void FindedTreasureHandler(Hero hero)
        {
            string mes;
            ConsoleKey k;
            Treasure t = ScenarioGenerator.GetTreasure();
            string pre = "В темноте вы натыкаетесь на: ";
            switch (t)
            {
                case Treasure.Food:
                    Food f = ScenarioGenerator.GetFood();
                    switch (f)
                    {
                        case Food.Chocolate:
                            mes = "Шоколад(+15 к еде + 10 к рассудку)";
                            Teller.WriteTopInformation(hero, string.Format(pre + mes), ConsoleColor.Black);
                            SpendingByStep.InvokeSpending(new Chocolate(1));
                            hero.ChocolateAte++;
                            break;
                        case Food.Potato:
                            mes = "Картошку(+5 к еде)";
                            Teller.WriteTopInformation(hero, string.Format(pre + mes), ConsoleColor.Black);
                            SpendingByStep.InvokeSpending(new Potato(1));
                            hero.PotatoAte++;
                            break;
                        case Food.FreshRat:
                            mes = "Мертвую крысу(ещё теплая), вкуснятина!(пробел)(не употреблять) E-(+30 к еде -30 к рассудку + 15 к енергии)";
                            while (true)
                            {
                                try
                                {
                                    Teller.WriteTopInformation(hero, string.Format(pre + mes), ConsoleColor.Black);
                                    k = Console.ReadKey().Key;
                                    if (k != ConsoleKey.E && k != ConsoleKey.Spacebar)
                                        throw new WrongKeyException(k);
                                    else if (k == ConsoleKey.E)
                                    {
                                        SpendingByStep.InvokeSpending(new FreshRat(2));
                                        hero.FreshRatAte++;
                                        break;
                                    }
                                    else
                                    {
                                        SpendingByStep.InvokeSpending(new Common(1));
                                        break;
                                    }
                                }
                                catch (WrongKeyException wke)
                                {
                                    Console.WriteLine("({0}) {1}", wke.PressedKey, wke.Message);
                                    Console.WriteLine("Попробуйте снова");
                                    Thread.Sleep(1000);
                                }
                            }
                            break;
                    }
                    break;
                case Treasure.Medecines:
                    mes = "Медикаменты(+20 к здоровью)";
                    Teller.WriteTopInformation(hero, string.Format(pre + mes), ConsoleColor.Black);
                    SpendingByStep.InvokeSpending(new Medecine(1));
                    hero.MedicineUsed++;
                    break;
                case Treasure.Mind:
                    Mind m = ScenarioGenerator.GetMind();
                    switch (m)
                    {
                        case Mind.Match:
                            mes = "Спички(+10 к рассудку)";
                            Teller.WriteTopInformation(hero, string.Format(pre + mes), ConsoleColor.Black);
                            SpendingByStep.InvokeSpending(new Matches(1));
                            break;
                        case Mind.FlashLight:
                            mes = "Фонарик(+20 к рассудку)";
                            Teller.WriteTopInformation(hero, string.Format(pre + mes), ConsoleColor.Black);
                            SpendingByStep.InvokeSpending(new Flashlight(1));
                            hero.Mind += 20;
                            break;
                    }
                    break;
            }
        }
        private static void FindedEnemyHandler(Hero hero) {
            Enemy e = ScenarioGenerator.GetEnemy();
            string mes;
            ConsoleKey k;
            switch (e)
            {
                case Enemy.Laziness:
                    mes = "Лень Сражаться(пробел)(-10 к здоровью)E-убежать(-10 к енергии)";
                    while (true)
                    {
                        try
                        {
                            Teller.WriteTopInformation(hero, string.Format("На вас нападает: " + mes), ConsoleColor.DarkRed);
                            k = Console.ReadKey().Key;
                            if (k != ConsoleKey.E && k != ConsoleKey.Spacebar)
                                throw new WrongKeyException(k);
                            else if (k == ConsoleKey.E)
                            {
                                SpendingByStep.InvokeSpending(new Laziness(2));
                                hero.LazKilled++;
                                break;
                            }
                            else
                            {
                                SpendingByStep.InvokeSpending(new Laziness(1));
                                break;
                            }
                        }
                        catch (WrongKeyException wke)
                        {
                            Console.WriteLine("({0}) {1}", wke.PressedKey, wke.Message);
                            Console.WriteLine("Попробуйте снова");
                            Thread.Sleep(1000);
                        }
                    }
                    break;
                case Enemy.Delay:
                    mes = "Прокрастинация Сражаться(пробел)(-20 к здоровью)E-убежать(-10 к енергии)";
                    while (true)
                    {
                        try
                        {
                            Teller.WriteTopInformation(hero, string.Format("На вас нападает: " + mes), ConsoleColor.DarkRed);
                            k = Console.ReadKey().Key;
                            if (k != ConsoleKey.E && k != ConsoleKey.Spacebar)
                                throw new WrongKeyException(k);
                            else if (k == ConsoleKey.E)
                            {
                                SpendingByStep.InvokeSpending(new Delay(2));
                                hero.DelKilled++;
                                break;
                            }
                            else
                            {
                                SpendingByStep.InvokeSpending(new Delay(1));
                                break;
                            }
                        }
                        catch (WrongKeyException wke)
                        {
                            Console.WriteLine("({0}) {1}", wke.PressedKey, wke.Message);
                            Console.WriteLine("Попробуйте снова");
                            Thread.Sleep(1000);
                        }
                    }
                    break;
                case Enemy.Deadline:
                    mes = "ДЭДЛАЙН! Сражаться(пробел)(-40 к здоровью)E-убежать(-20 к енергии)";
                    while (true)
                    {
                        try
                        {
                            Teller.WriteTopInformation(hero, string.Format("На вас нападает: " + mes), ConsoleColor.DarkRed);
                            k = Console.ReadKey().Key;
                            if (k != ConsoleKey.E && k != ConsoleKey.Spacebar)
                                throw new WrongKeyException(k);
                            else if (k == ConsoleKey.E)
                            {
                                SpendingByStep.InvokeSpending(new Deadline(2));
                                hero.DeadlineKilled++;
                                break;
                            }
                            else
                            {
                                SpendingByStep.InvokeSpending(new Deadline(1));
                                break;
                            }
                        }
                        catch (WrongKeyException wke)
                        {
                            Console.WriteLine("({0}) {1}", wke.PressedKey, wke.Message);
                            Console.WriteLine("Попробуйте снова");
                            Thread.Sleep(1000);
                        }
                    }
                    break;
            }
        }
        private static void FindedRestPlaceHandler(Hero hero) {
            ConsoleKey k;
            while (true)
            {
                try
                {
                    Teller.WriteTopInformation(hero, "Вы находите отличное место для отдыха!(пробел)(пропустить) E-(+20 к энергии + 10 к здоровью - 10 еды)", ConsoleColor.Black);
                    k = Console.ReadKey().Key;
                    if (k != ConsoleKey.E && k != ConsoleKey.Spacebar)
                        throw new WrongKeyException(k);
                    else if (k == ConsoleKey.E)
                    {
                        SpendingByStep.InvokeSpending(new FirstTypeRest(1));
                        hero.RestAmount++;
                        break;
                    }
                    else
                    {
                        SpendingByStep.InvokeSpending(new Common(1));
                        break;
                    }
                }
                catch (WrongKeyException wke)
                {
                    Console.WriteLine("({0}) {1}", wke.PressedKey, wke.Message);
                    Console.WriteLine("Попробуйте снова");
                    Thread.Sleep(1000);
                }
            }
        }
        private static void FindedCommonHandler(Hero hero) {
            Teller.WriteTopInformation(hero, "Ничего интересного можно идти дальше", ConsoleColor.DarkGreen);
            SpendingByStep.InvokeSpending(new Common(1));
        }
        private static void FindedChoiceHandler(Hero hero) {
            hero.DifficultChoice++;
            ConsoleKey k;
            while (true)
            {
                try
                {
                    Teller.WriteTopInformation(hero, "Перед вами 3 пути(1num - Спрыгнуть вниз(-6 здоровья), 2num - залезть наверх(-6 енергии),3num - обойти(-6 рассудок))", ConsoleColor.Black);
                    k = Console.ReadKey().Key;
                    if (k != ConsoleKey.NumPad1 && k != ConsoleKey.NumPad2 && k != ConsoleKey.NumPad3)
                        throw new WrongKeyException(k);
                    else if (k == ConsoleKey.NumPad1)
                    {
                        SpendingByStep.InvokeSpending(new TripleChoice(1));
                        break;
                    }
                    else if (k == ConsoleKey.NumPad2)
                    {
                        SpendingByStep.InvokeSpending(new TripleChoice(2));
                        break;
                    }
                    else if (k == ConsoleKey.NumPad3)
                    {
                        SpendingByStep.InvokeSpending(new TripleChoice(3));
                        break;
                    }
                }
                catch (WrongKeyException wke)
                {
                    Console.WriteLine("({0}) {1}", wke.PressedKey, wke.Message);
                    Console.WriteLine("Попробуйте снова");
                    Thread.Sleep(1000);
                }
            }
        }
    }

}
