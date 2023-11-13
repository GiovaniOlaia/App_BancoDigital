using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App_BancoDigital.View.Acesso;

namespace App_BancoDigital.View.Acesso
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginMenu : FlyoutPage
	{
		public LoginMenu()
		{
			InitializeComponent();

            Inicializar();
		}
        private async void Inicializar()
		{
			try
			{
				NavigationPage.SetHasNavigationBar(this, false);

                img_logo.Source = ImageSource.FromResource
					("App_BancoDigital.View.Acesso.Logo_Deutsche_Bank.png");

				Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(View.Acesso.Login)));

				IsPresented = false;
			}

			catch (Exception ex)
			{
				await DisplayAlert("Erro!", ex.Message, "OK");
			}
		}

		private async void Mudar_Pagina(Type tipo)
		{
			try
			{
				if (await DisplayAlert("Atenção!", "as página atual será fechada." +
					"Tem certeza de que deseja prosseguir?", "Sim", "Não"))
				{
					Detail = new NavigationPage((Page)Activator.CreateInstance(tipo));

					IsPresented = false;
				}
			}
			catch (Exception ex) 
			{
				await DisplayAlert("Erro!", ex.Message, "OK");
			}
		}

        private void btn_tela_inicial_Clicked(object sender, EventArgs e)
        {

			Mudar_Pagina(typeof(View.Acesso.Login));

        }

		private void btn_chaves_pix_Clicked(object sender, EventArgs e)
		{

			Mudar_Pagina(typeof(View.Pix.CadastroChavePix));

		}

		private async void btn_sair_Clicked(object sender, EventArgs e)
		{
			try
			{

				if (await DisplayAlert("Atenção!", "Deseja realmente desconectar-se da sua conta?", "Sim", "Não"))
				{
					App.Current.MainPage = new NavigationPage(new LoginCorrentista());
				}

			}
			catch (Exception ex)
			{
				await DisplayAlert("Erro!", ex.Message, "OK!");
			}
		}
    }
}