using System;
using System.Collections.Generic;
using System.Linq;
using ThingsInEnglish.ApplicationContextDB;

namespace ThingsInEnglish.Helpers
{
    public static class RandomThing
    {
        public static int QuantityOnTable()
        {
            var _dbContext = new ApplicationContext_DB();
            var quantityOnTable = _dbContext.Thing.ToList();
            return quantityOnTable.Count;
        }

        public static int GetRandomThing()
        {
            Random random = new Random();
            return random.Next(1, QuantityOnTable());
        }

        public static List<int> ThingAletory(int count)
        {
            var list = new List<int>();

            var random = new Random();

            while (list.Count < count)
            {
                var num = random.Next(1, QuantityOnTable());
                if (!list.Contains(num))
                {
                    list.Add(num);
                }
            }
            return list;
        }
    }
}