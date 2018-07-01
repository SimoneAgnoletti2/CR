using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CR
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTc0M0AzMTM2MmUzMjJlMzBoZjVSVTJJYk4rMkh3VFFvQ3h5NGpCbFd0NUIwQ05zUCt1SnQ0eEcyTXBVPQ==");

            InitializeComponent();

            MainPage = new CR.MainPage();
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
