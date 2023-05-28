using Microsoft.EntityFrameworkCore;
using ThingsInEnglish.ApplicationContextDB;
using ThingsInEnglish.Helpers;
using ThingsInEnglish.Views;
using Xamarin.Forms;

namespace ThingsInEnglish
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var _dbCcontext = new ApplicationContext_DB();

            _dbCcontext.Database.Migrate();

            var query = _dbCcontext.Thing.Find(1);

            if (query == null)
            {
                InformationData.DataDefault();
            }
            MainPage = new NavigationPage(new Page_Home());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}