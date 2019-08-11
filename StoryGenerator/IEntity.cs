using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator
{
    public interface IEntity
    {
        int HealthSpending { get; }
        int MindSpending { get; }
        int EnergySpending { get; }
        int FoodSpending { get; }
    }
}
