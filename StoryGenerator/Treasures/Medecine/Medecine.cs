using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Treasures.Medecine
{
    public class Medecine : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public Medecine(int choice)
        {
            if (choice == 1)
                HealthSpending = 20;
            else
                throw new NotImplementedException();
        }
    }
}
