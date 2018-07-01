using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.ProgressBar;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CR.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBar : ContentPage
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        private void ProgressBarBase_OnValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress < 50)
            {
                this.LinearProgressBar.ProgressColor = Color.Red;
            }
            else if (e.Progress >= 50)
            {
                this.LinearProgressBar.ProgressColor = Color.Green;
            }
        }


        private void ProgressBarBase_OnProgressCompleted(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(this.CircularProgressBar0.Maximum))
            {
                // Changed the label text when progress reaches maximum value.
                this.Label222.Text = "Completed";
            }
        }
    }
}