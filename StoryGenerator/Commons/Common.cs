using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Commons
{
    public class Common : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public Common(int choice)
        {
            if (choice == 1)
            {
                MindSpending = -1;
                EnergySpending = -1;
                FoodSpending = -1;
            }
            else
                throw new NotImplementedException();
        }
    }
}
