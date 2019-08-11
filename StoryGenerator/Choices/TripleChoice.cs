using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.Choices
{
    public class TripleChoice : IEntity
    {
        public int HealthSpending { get; set; }

        public int MindSpending { get; set; }

        public int EnergySpending { get; set; }

        public int FoodSpending { get; set; }

        public TripleChoice(int choice)
        {
            if (choice == 1)
                HealthSpending = -6;
            else if (choice == 2)
                EnergySpending = -6;
            else if (choice == 3)
                MindSpending = -6;
            else
                throw new NotImplementedException();
        }
    }
}
