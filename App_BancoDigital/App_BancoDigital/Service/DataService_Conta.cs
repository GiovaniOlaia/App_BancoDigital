using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

using App_BancoDigital.Model;
using Newtonsoft.Json;

namespace App_BancoDigital.Service
{
    public class DataService_Conta : DataService
    {
        public static async Task<Conta> SaveAsyncConta(Conta model)
        {
            var post_json = JsonConvert.SerializeObject(model);

            string json = await DataService.SetDataApi(post_json, "/conta/salvar");

            Conta model_retornada = JsonConvert.DeserializeObject<Conta>(json);

            return model_retornada;
        }

        public static async Task<List<Conta>> GetListAsyncConta()
        {
            string get_json = await DataService.GetDataApi("/conta/lista");

            List<Conta> lista_contas = JsonConvert.DeserializeObject<List<Conta>>(get_json);

            return lista_contas;
        }
    }
}
