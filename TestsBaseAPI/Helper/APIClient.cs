using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestsBaseAPI.Helper
{
    public class APIClient
    {
        protected static HttpClient _client = new HttpClient();

        internal T? QueryAPI<T,R>(R request, string urlAPI)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var webResponse = _client.PostAsync(urlAPI, content).GetAwaiter().GetResult();
            var jsonResponse = webResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<T>(jsonResponse);
            return result;
        }

        internal T? QueryAPI<T>(string urlApi)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var webResponse = _client.GetAsync(urlApi).GetAwaiter().GetResult();
            var jsonRespose = webResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<T>(jsonRespose);
            return result;
        }
    }
}
