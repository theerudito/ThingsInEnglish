using System.Collections.Generic;
using ThingsInEnglish.ApplicationContextDB;
using ThingsInEnglish.Models;

namespace ThingsInEnglish.Helpers
{
    public static class InformationData
    {
        public static void DataDefault()
        {
            var _dbCcontext = new ApplicationContext_DB();

            var newThing = new List<Things>
            {
               new Things { IdThing = 1, Name = "APPLE", ImageBase64 = DataBase64.stringOne},
               new Things { IdThing = 2, Name = "ORANGE", ImageBase64 = DataBase64.stringTwo},
               new Things { IdThing = 3, Name = "MOUSE", ImageBase64 = DataBase64.stringThree},
               new Things { IdThing = 4, Name = "CD", ImageBase64 = DataBase64.stringFour},
               new Things { IdThing = 5, Name = "PHONE", ImageBase64 = DataBase64.stringFive},
               new Things { IdThing = 6, Name = "COMPUTER", ImageBase64 = DataBase64.stringSix},
            };

            _dbCcontext.AddRange(newThing);
            _dbCcontext.SaveChanges();
        }
    }
}