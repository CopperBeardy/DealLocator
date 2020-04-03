using DealLocator.Mobile;
using DealLocator.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace DealLocator.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        MapPageViewModel vm;
        public MapPage()
        {
            InitializeComponent();          
            vm = new MapPageViewModel();          
            Content = vm.Map;
        }

        private async void FiltersButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new FiltersPage());
        }
    }


}