using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator
{
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
        public int Mind
        {
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
}
