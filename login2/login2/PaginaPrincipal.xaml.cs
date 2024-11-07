using System;
using Xamarin.Forms;
using login2.Models;

namespace login2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string username = entryUsername.Text;
            string password = entryPassword.Text;

            var user = await App.Database.GetUserAsync(username, password);

            if (user != null)
            {
                await DisplayAlert("Inicio Correcto", "Bienvenido " + username, "Salir");
                // Navegar a otra página si es necesario
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrecta", "Intentar de nuevo");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            // Esta es la lógica para el botón de registrarse
            string username = entryUsername.Text;
            string password = entryPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                User newUser = new User
                {
                    Username = username,
                    Password = password
                };

                await App.Database.SaveUserAsync(newUser);
                await DisplayAlert("Registro Completo", "Usuario registrado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos", "OK");
            }
        }
    }
}
