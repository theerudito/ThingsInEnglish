using ThingsInEnglish.ViewModes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThingsInEnglish.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Home : ContentPage
    {
        public Page_Home()
        {
            InitializeComponent();
            BindingContext = new VM_PageHome(Navigation);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}