﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroChavePix : ContentPage
    {
        public CadastroChavePix()
        {
            InitializeComponent();

            Inicializar();
        }

        private async void Inicializar()
        {
            try
            {



            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro!", ex.Message, "OK");

            }
        }

        private void Trocar_Valor_CheckBox()
        {

            string valor_chave;

            if(rdbtn_cpf.IsChecked)
            {

                valor_chave = rdbtn_cpf.Value.ToString();

            }
            else
            {

                if (rdbtn_cnpj.IsChecked)
                {
                    valor_chave = rdbtn_cnpj.Value.ToString();
                }
                else
                {
                    if (rdbtn_telefone.IsChecked)
                    {
                        valor_chave = rdbtn_telefone.Value.ToString();
                    }
                    else
                    {
                        if (rdbtn_email.IsChecked)
                        {
                            valor_chave = rdbtn_email.Value.ToString();
                        }
                        else
                        {
                                valor_chave = rdbtn_aleatoria.Value.ToString();
                        }
                    }
                }
            }

            this.tipo_chave_pix = int.Parse(valor_chave);
        }


        private async void rdbtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {

                Trocar_Valor_CheckBox();

            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", ex.Message, "OK");                

            }
        }

        private async void btn_cadastrar_chave_pix_Clicked(object sender, EventArgs e)
        {
            try
            {

                bool[] opcoes_chave = { rdbtn_cpf.IsChecked, rdbtn_cnpj.IsChecked, 
                                        rdbtn_telefone.IsChecked, rdbtn_email.IsChecked,
                                        rdbtn_aleatoria.IsChecked };

                int condicao = 0;

                for(int i = 0; i < 5; i++)
                {

                    if (opcoes_chave[i])
                    {

                        condicao++;

                    }
                }
                if (condicao == 5)
                {

                    await DisplayAlert("Pergunta", "Selecione uma opção:", "OK");

                }

                else
                {

                    string[] valores_chave_pix = { "CPF", "CNPJ", "Email", "Telefone", "Aleatoria" };

                    string chave_pix = await DisplayPromptAsync("Salvando", "Insira abaixo:", "Salvar",
                                                                "Cancelar", "Insira a chave pix", 20,
                                                                Keyboard.Text);

                    if(!String.IsNullOrEmpty(chave_pix))
                    {
                        
                        Model.Chave_Pix model = new Model.Chave_Pix()
                        {

                            chave = chave_pix,
                                
                            tipo = valores_chave_pix[this.tipo_chave_pix]

                        };

                        Model.Chave_Pix retorno = await Service.Data_Service_Chave_Pix.SaveAsyncChavePix(model);

                        if(!String.IsNullOrEmpty(retorno.id_chave_pix.ToString()))
                        {

                            await DisplayAlert("Aviso", "Chave Pix cadastrada com sucesso.", "OK");

                        }
                        else
                        {
                            
                            throw new Exception("Não foi possível efetuar o cadastro! Tente novamente.")

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro!", ex.Message, "OK");                
            }
        }
    }
}