using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Treasures.Mind
{
    public class Matches : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public Matches(int choice)
        {
            if (choice == 1)
                MindSpending = 10;
            else
                throw new NotImplementedException();
        }
    }
}
