using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Treasures.Food
{
    public class Potato : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public Potato(int choice)
        {
            if (choice == 1)
                FoodSpending = 5;
            else
                throw new NotImplementedException();
        }
    }
}
