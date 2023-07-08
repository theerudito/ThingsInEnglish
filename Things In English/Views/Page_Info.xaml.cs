﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThingsInEnglish.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Info : ContentPage
    {
        public Page_Info()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void OpenUrl(string url)
        {
            await Browser.OpenAsync(url);
        }

        private void instagram_Clicked(object sender, System.EventArgs e)
        {
            OpenUrl("https://www.instagram.com/theerudito/");
        }

        private void github_Clicked(object sender, System.EventArgs e)
        {
            OpenUrl("https://github.com/theerudito?tab=repositories");
        }

        private void theads_Clicked(object sender, EventArgs e)
        {
            OpenUrl("https://www.threads.net/@theerudito");
        }

        private void linkedin_Clicked(object sender, System.EventArgs e)
        {
            OpenUrl("https://www.linkedin.com/in/theerudito/");
        }
    }
}