using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using ThingsInEnglish.Models;
using Xamarin.Forms;

namespace ThingsInEnglish.ApplicationContextDB
{
    public class ApplicationContext_DB : DbContext
    {
        public ApplicationContext_DB()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        private const string DatabaseName = "ThingsInEnglish.db3";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseName);
                    break;

                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseName);
                    break;

                default:
                    throw new NotImplementedException("Platform not supported");
            }
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        public DbSet<Things> Thing { get; set; }
    }
}