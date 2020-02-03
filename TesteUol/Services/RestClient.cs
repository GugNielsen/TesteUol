////using System;
////using System.Diagnostics;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using TesteUol.ModelsDtos;

//namespace TesteUol.Services
//{

//    public class RestClient
//    {
//        HttpClient client = new HttpClient();

//        /// <summary>
//        /// Obtém os itens de produtos
//        /// </summary>
//        public async Task<Tempo>GetAsync()
//        {
//            try
//            {
//                Tempo response = await client.GetStringAsync("https://api.darksky.net/forecast/8cdfe5016e2c5632b2f1e060380b873a/37.8267,-122.4233");
//               var Tempo =  JsonConvert.DeserializeObject<Tempo>(response);
//                return Tempo;

//            }
//            catch (System.Exception ex)
//            {
//                var a = ex.Message;
//                return null;
//            }

           
         

//        }
//    }
//}