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

        protected static async Task<string> GetDataApi(string rota)
        {

            string json;

            string uri = servidor + rota;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {

                throw new Exception("ERR_INTERNET_DISCONNECTED - Sem Internet");

            }

            else
            {

                using (HttpClient cliente = new HttpClient())
                {

                    HttpResponseMessage requisicao_api = await cliente.GetAsync(uri);

                    Console.WriteLine("_______________________________");
                    Console.WriteLine(requisicao_api.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("_______________________________");

                    if (requisicao_api.IsSuccessStatusCode)
                    {

                        json = requisicao_api.Content.ReadAsStringAsync().Result;

                    }

                    else
                    {

                        throw new Exception(DecodeServerError(requisicao_api.StatusCode));

                    }

                }

            }

            return json;

        }

        protected static async Task<string> SetDataApi(string objeto_json, string rota)
        {

            string json;

            string uri = servidor + rota;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {

                throw new Exception("ERR_INTERNET_DISCONNECTED - Sem Internet");

            }

            else
            {

                using (HttpClient cliente = new HttpClient())
                {

                    HttpResponseMessage requisicao_api = await cliente.PostAsync(uri,
                                                   new StringContent(objeto_json, Encoding.UTF8,
                                                   "application/json"));

                    Console.WriteLine("_______________________________");
                    Console.WriteLine(requisicao_api.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("_______________________________");

                    if (requisicao_api.IsSuccessStatusCode)
                    {

                        json = requisicao_api.Content.ReadAsStringAsync().Result;

                    }

                    else
                    {

                        throw new Exception(DecodeServerError(requisicao_api.StatusCode));

                    }

                }

            }

            return json;

        }

        protected static async Task<string> GetDataFromService(string rota)
        {
            string json_response;

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

                    Console.WriteLine("_______________________________");
                    Console.WriteLine(resposta.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("_______________________________");

                    if (resposta.IsSuccessStatusCode)
                    {
                        json_response = resposta.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        throw new Exception(DecodeServerError(resposta.StatusCode));
                    }
                }
            }
          return json_response;
        }

        protected static async Task<string> PostDataToService(string json_object, string rota)
        {
            string json_response;

            string uri = servidor + rota;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                throw new Exception("ERR_INTERNET_DISCONNECTED - Sem Internet");
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resposta = await client.PostAsync(uri,
                    new StringContent(json_object, Encoding.UTF8, "application/json"));

                Console.WriteLine("______________________________");
                Console.WriteLine(resposta.Content.ReadAsStringAsync().Result);
                Console.WriteLine("______________________________");

                if (resposta.IsSuccessStatusCode)
                {
                    json_response = resposta.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new Exception(DecodeServerError(resposta.StatusCode));
                }
            }

            return json_response;
        }

        protected static Task<string> SendDataApi(string post_json, string v)
        {
            throw new NotImplementedException();
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
                    mensagem_erro = "ERR_INTERNAL_SERVER - Banco de Dados Indisponível.";
                    break;

                case HttpStatusCode.RequestTimeout:
                    mensagem_erro = "ERR_TIMED_OUT - O servidor demorou muito para responder.";
                    break;

                case HttpStatusCode.Forbidden:
                    mensagem_erro = "ERR_FORBIDDEN - Recurso indisponível.";
                    break;

                default:
                    mensagem_erro = "ERR_SERVER - Erro no servidor. Tente novamente mais tarde.";
                    break;
            }

            return mensagem_erro;
        }
    }

}