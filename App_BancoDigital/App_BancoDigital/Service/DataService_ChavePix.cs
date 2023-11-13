using App_BancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App_BancoDigital.Service
{
    public class DataService_ChavePix : DataService
    {

        public static async Task<ChavePix> SaveAsyncChavePix(ChavePix model)
        {
            var post_json = JsonConvert.SerializeObject(model);

            string json = await DataService.SetDataApi(post_json, "/chavepix/save");

            ChavePix model_retornada = JsonConvert.DeserializeObject<ChavePix>(json);

            return model_retornada;
        }

        public static async Task<bool> RemoveAsyncChavePix(int id)
        {
            var post_json = JsonConvert.SerializeObject(id);

            string json = await DataService.SetDataApi(post_json, "/chavepix/remove");

            bool exito = JsonConvert.DeserializeObject<bool>(json);

            return exito;
        }

        public static async Task<List<ChavePix>> GetListAsyncChavePix()
        {
            string json = await DataService.GetDataApi("/chavepix/list");

            List<ChavePix> lista_chaves_pix = JsonConvert.DeserializeObject<List<ChavePix>>(json);

            return lista_chaves_pix;
        }

        public static async Task<List<ChavePix>> SearchAsyncChavePix(string parametro)
        {
            var post_json = JsonConvert.SerializeObject(parametro);

            string json = await DataService.SetDataApi(post_json, "/chavepix/search");

            List<ChavePix> lista_chaves_pix_encontradas = JsonConvert.DeserializeObject<List<ChavePix>>(json);

            return lista_chaves_pix_encontradas;
        }
    }
}
