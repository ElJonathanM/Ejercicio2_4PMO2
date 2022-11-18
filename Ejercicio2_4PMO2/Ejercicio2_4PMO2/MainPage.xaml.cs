using Ejercicio2_4PMO2.Models;
using Ejercicio2_4PMO2.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2_4PMO2
{
    public partial class MainPage : ContentPage
    {
        String pathVideo = "";
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No hay Camara", "No hay camara Disponible.", "OK"); return;
            }
            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Name = "Vid01.mp4",
                Directory = "MysVideos"
            });
            if (file == null)
                return;
            await DisplayAlert("Información", "Video Guardado en: " + file.Path, "OK");
            videoV.Source = file.Path;
            pathVideo = file.Path;
        }

        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathVideo))
            {
                var respuesta = await App.BaseDatos.guardaVideos(new Video { path = pathVideo });
                if (respuesta == 1)
                {
                    await DisplayAlert("Información", "Se guardo el video en SQLite!", "OK");
                    videoV.Source = null;
                    pathVideo = "";
                }
                else
                {
                    await DisplayAlert("Error", "Algo fallo al guardar en SQLite", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "No se Encontro la ruta de tu video Grabado!", "OK");
            }
        }

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            var listado = await App.BaseDatos.GetListVid();//LLENAR LA LISTAA
            if (listado != null)
            {
                if (listado.Count() > 0)
                {
                    await Navigation.PushAsync(new ListVideos());
                }
                else
                {
                    await DisplayAlert("Error", "Aun no tienes videos guardados", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Aun no tienes videos guardado", "OK");
            }
        }
    }
}
