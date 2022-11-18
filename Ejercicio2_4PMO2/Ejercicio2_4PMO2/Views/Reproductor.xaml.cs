using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4PMO2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reproductor : ContentPage
    {
        public Reproductor()
        {
            InitializeComponent();
        }
        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            await CrossMediaManager.Current.Stop();
        }
    }
}