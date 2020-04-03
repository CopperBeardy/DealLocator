using Domain;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DealLocator.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FiltersPage : ContentPage
    {
           public FiltersPage()
        {
            InitializeComponent();
          
            categories.ItemsSource = Enum.GetValues(typeof(Category));
        }

        private void RangeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Ok_Clicked(object sender, EventArgs e)
        {          
            Preferences.Set("Range", rangeSlider.Value);
            
            int catergoryIndex;
            if(categories.SelectedItem == null)
            {
                catergoryIndex = 0;

            } else
            {
                var catergory = categories.SelectedItem;
                
                catergoryIndex = (int)catergory;
            }
            Preferences.Set("Category", $"{catergoryIndex}");
            Navigation.PopModalAsync();
        }
    }
}