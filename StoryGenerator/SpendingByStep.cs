﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator
{
    public static class SpendingByStep
    {
        public static Hero setHero;
        public static int healthSpending = 0;
        public static int foodSpending = 0;
        public static int energySpending = 0;
        public static int mindSpending = 0;

        public static void InvokeSpending(int healthSp, int foodSp, int energySp, int mindSp)
        {
            setHero.Health += healthSp;
            setHero.Food += foodSp;
            setHero.Energy += energySp;
            setHero.Mind += mindSp;
        }
        public static void InvokeSpending(IEntity entity)
        {
            InvokeSpending(entity.HealthSpending, entity.FoodSpending, entity.EnergySpending, entity.MindSpending);
        }
    }
}
