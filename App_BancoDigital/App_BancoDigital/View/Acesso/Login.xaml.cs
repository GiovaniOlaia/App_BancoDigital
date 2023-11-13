using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View.Acesso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            Inicializar();
        }

        private async void Inicializar()
        {
            try
            {
                string caminho_fixo = "App_Banco_Digital.View.Acesso";

                btn_menu.IconImageSource = ImageSource.FromResource(caminho_fixo + "Logo_Usuario.png");

                imgbtn_pagar.Source = ImageSource.FromResource(caminho_fixo + "Receber.png");

                imgbtn_pix.Source = ImageSource.FromResource(caminho_fixo + "Logo_Pix.png");

                imgbtn_transferir.Source = ImageSource.FromResource(caminho_fixo + "Transferencia Bancaria.png");

                imgbtn_cobrar.Source = ImageSource.FromResource(caminho_fixo + "Cobrança.png");

                img_banner.Source = ImageSource.FromResource(caminho_fixo + "Logo_Cartão.png");

            }
            catch(Exception ex) 
            {
                await DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private async void btn_menu_Clicked(object sender, EventArgs e)
        {
            try
            {

                await DisplayAlert(Title, "Você está conectado.", "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private async void imgbtn_pagar_Clicked(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro!", ex.Message, "OK");

            }
        }

        private async void imgbtn_transferir_Clicked(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro!", ex.Message, "OK");

            }
        }

        private async void imgbtn_cobrar_Clicked(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro!", ex.Message, "OK");

            }
        }
    }
}