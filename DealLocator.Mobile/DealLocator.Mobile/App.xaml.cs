using DealLocator.Mobile.Models;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using Xamarin.Forms;


namespace DealLocator.Mobile
{
    public partial class App : Application
    {
        public static IPublicClientApplication AuthenticationClient { get; private set; }
        public static double ScreenHeight;
        public static double ScreenWidth;
        //public static string APIBackendUrl = "http://deallocator.azurewebsites.net";

        public static object UIParent { get; set; } = null;

     
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTU1MTU5QDMxMzcyZTMzMmUzMFhrVHl0cmtZcWl0RjRnQk9EVW9aQkdDc3k4RWRJSXZhN1JOeGdqVzcvMk09");
            InitializeComponent();

            AuthenticationClient = PublicClientApplicationBuilder.Create(Constants.ClientId)
                   .WithB2CAuthority(Constants.AuthoritySignin)
                   .Build();
          
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
