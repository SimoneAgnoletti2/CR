
using CR.ViewModels;
using Xamarin.Forms;

namespace CR
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.BindingContext = new MainPageViewModel();
            InitializeComponent();
        }
    }

}
