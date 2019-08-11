using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Treasures.Food
{
    public class FreshRat : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public FreshRat(int choice)
        {
            if (choice == 2)
            {
                FoodSpending = 30;
                MindSpending = -30;
                EnergySpending = 15;
            }
            else
                throw new NotImplementedException();
        }
    }
}
