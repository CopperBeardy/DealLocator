using DealLocator.Mobile.Helpers;
using DealLocator.Mobile;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace DealLocator.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        AuthenticationResult authenticationResult;

          public MainPage(AuthenticationResult result)
        {
            InitializeComponent();
            authenticationResult = result;

        }

    


        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            IEnumerable<IAccount> accounts = await App.AuthenticationClient.GetAccountsAsync();

            while (accounts.Any())
            {
                await App.AuthenticationClient.RemoveAsync(accounts.First());
                accounts = await App.AuthenticationClient.GetAccountsAsync();
            }

            await Navigation.PopAsync();
        }

        private async void DealButton_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new MapPage());
        
        }

        private async void FiltersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FiltersPage());
        }

       
    }
}
