using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using App_BancoDigital.Model;

namespace App_BancoDigital.Service
{
    public class DataService_Correntista : DataService
    {
        public static async Task<Correntista> LoginAsync(Correntista c)
        {
            var get_json = JsonConvert.SerializeObject(c);

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("DADOS JÁ DIGITADOS E AGORA CONVERTIDOS EM JSON: ");
            Console.WriteLine(get_json);
            Console.WriteLine("__________________________________________________________________");

            string json = await DataService.PostDataToService(get_json, "/correntista/entrar");

            return JsonConvert.DeserializeObject<Correntista>(json);
        }

        public static async Task<Correntista> SaveAsync(Correntista c)
        {
            var post_json = JsonConvert.SerializeObject(c);

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("DADOS JÁ DIGITADOS E AGORA CONVERTIDOS EM JSON: ");
            Console.WriteLine(post_json);
            Console.WriteLine("__________________________________________________________________");

            string json = await DataService.PostDataToService(post_json, "/correntista/salvar");

            return JsonConvert.DeserializeObject<Correntista>(json); ;
        }

        public static async Task<Correntista> RemoveAsync(Correntista c)
        {
            var post_json = JsonConvert.SerializeObject(c);

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("DADOS JÁ DIGITADOS E AGORA CONVERTIDOS EM JSON: ");
            Console.WriteLine(post_json);
            Console.WriteLine("__________________________________________________________________");

            string json = await DataService.PostDataToService(post_json, "/correntista/apagar");

            return JsonConvert.DeserializeObject<Correntista>(json); ;
        }

        public static async Task<Correntista> ListAsync(Correntista c)
        {
            var post_json = JsonConvert.SerializeObject(c);

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("DADOS JÁ DIGITADOS E AGORA CONVERTIDOS EM JSON: ");
            Console.WriteLine(post_json);
            Console.WriteLine("__________________________________________________________________");

            string json = await DataService.PostDataToService(post_json, "/correntista/listar");

            return JsonConvert.DeserializeObject<Correntista>(json);
        }

        public static async Task<Correntista> SearchAsync(Correntista c)
        {
            var post_json = JsonConvert.SerializeObject(c);

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("DADOS JÁ DIGITADOS E AGORA CONVERTIDOS EM JSON: ");
            Console.WriteLine(post_json);
            Console.WriteLine("__________________________________________________________________");

            string json = await DataService.PostDataToService(post_json, "/correntista/pesquisar");
        }
    }
}
