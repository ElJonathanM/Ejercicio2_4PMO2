using Ejercicio2_4PMO2.Models;
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
    public partial class ListVideos : ContentPage
    {
        public ListVideos()
        {
            InitializeComponent();
        }
        
        private void listadoVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            Video aa = (Video)e.Item;
            String[] nom = aa.path.Split('/');
            String nom1 = nom[nom.Length - 1];
            Reproductor rep = new Reproductor();
            rep.BindingContext = aa;

            rep.Title = "Reproduciendo: " + nom1;


        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listadoVideos.ItemsSource = await App.BaseDatos.GetListVid();//LLENAR LA LISTAA
        }
    }
}