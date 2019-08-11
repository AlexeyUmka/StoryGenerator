using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Enemies
{
    public class Deadline : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public Deadline(int choice)
        {
            if (choice == 1)
            {
                HealthSpending = -40;
            }
            else if (choice == 2)
            {
                EnergySpending = -20;
            }
            else
                throw new NotImplementedException();
        }
    }
}
