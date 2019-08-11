using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Treasures.Food
{
    public class Chocolate : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }
        
        public Chocolate(int choice)
        {
            if (choice == 1)
            {
                FoodSpending = 15;
                MindSpending = 10;
            }
            else
                throw new NotImplementedException();
        }
    }
}
