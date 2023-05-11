using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Essentials;
using System.Net;

namespace App_BancoDigital.Service
{
    public abstract class DataService
    {
        private static readonly string servidor = "http://10.0.2.2:8000";

        protected static async Task<string> GetDataFromService(string rota)
        {
            string resposta_json;

            string uri = servidor + rota;

            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {

                throw new Exception("ERR_INTERNET_DISCONNECTED - Sem Internet");

            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage resposta = await client.GetAsync(uri);

                    if (resposta.IsSuccessStatusCode)
                    {
                        resposta_json = resposta.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        throw new Exception(DecodeServerError(resposta.StatusCode));
                    }
                }
            }
          return resposta_json;
        }

        private static string DecodeServerError(HttpStatusCode status_code) 
        {

            string mensagem_erro;

            switch (status_code)
            {
                case HttpStatusCode.BadRequest:
                    mensagem_erro = "ERR_BAD_REQUEST - A requisição não atendida.";
                    break;

                case HttpStatusCode.NotFound:
                    mensagem_erro = "ERR_NOT_FOUND - Recurso não encontrado.";
                    break;

                case HttpStatusCode.InternalServerError:
                    mensagem_erro = "ERR_INTERNAL_SERVER - Banco de Dados Indisponível!";
                    break;

                case HttpStatusCode.RequestTimeout:
                    mensagem_erro = "ERR_TIMED_OUT - O servidor demorou muito para responder.";
                    break;

                case HttpStatusCode.Forbidden:
                    mensagem_erro = "ERR_FORBIDDEN - Recurso indisponível.";
                    break;

                default:
                    mensagem_erro = "ERR_UNKNOWN - Erro desconhecido. Tente novamente!";
                    break;
            }
            return mensagem_erro;
        }
        protected static async Task<string> PostDataToService(string objeto_json, string rota)
        {
            string resposta_json;

            string uri = servidor + rota;
        }
    }

}