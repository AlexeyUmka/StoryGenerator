using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Treasures.Mind
{
    public class Flashlight : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public Flashlight(int choice)
        {
            if (choice == 1)
                MindSpending = 20;
            else
                throw new NotImplementedException();
        }
    }
}
