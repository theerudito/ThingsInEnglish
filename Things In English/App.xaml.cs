using MarcTron.Plugin;
using Microsoft.EntityFrameworkCore;
using Plugin.FirebasePushNotification;
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
            Ads.ShowIntertiscal();

            var _dbCcontext = new ApplicationContext_DB();

            _dbCcontext.Database.Migrate();

            var query = _dbCcontext.Thing.Find(1);

            if (query == null)
            {
                InformationData.DataDefault();
            }

            InitializeComponent();

            CrossMTAdmob.Current.OnInterstitialLoaded += (s, args) =>
            {
                CrossMTAdmob.Current.ShowInterstitial();
            };

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
            };
            // Push message received event
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Received");
            };
            //Push message received event
            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }
            };


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