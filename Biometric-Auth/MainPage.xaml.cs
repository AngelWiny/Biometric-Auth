using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biometric_Auth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
            if (!isFingerprintAvailable)
            {
                await DisplayAlert("Error",
                    "Autenticación biométrica no esta disponible o no a sido configurada.", "OK");
                return;
            }

            AuthenticationRequestConfiguration conf =
                new AuthenticationRequestConfiguration("Verificación",
                "Es necesario verificar su identidad");

            var authResult = await CrossFingerprint.Current.AuthenticateAsync(conf);
            if (authResult.Authenticated)
            {
                //Success  
                await DisplayAlert("Éxito", "Autorizado", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No autorizado", "OK");
            }
        }
    }
}
