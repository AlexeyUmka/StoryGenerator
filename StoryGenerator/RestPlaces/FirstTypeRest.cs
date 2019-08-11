using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.RestPlaces
{
    public class FirstTypeRest : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public FirstTypeRest(int choice)
        {
            if (choice == 1)
            {
                HealthSpending = 10;
                EnergySpending = 20;
                FoodSpending = -10;
            }
            else
                throw new NotImplementedException();
        }
    }
}
