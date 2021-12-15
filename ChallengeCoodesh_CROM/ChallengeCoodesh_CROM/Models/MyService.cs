using ChallengeCoodesh_CROM.Interface;
using ChallengeCoodesh_CROM.Models.Entitie;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChallengeCoodesh_CROM.Models
{
    public class MyService : IMyService
    {
        private string URL = "https://api.spaceflightnewsapi.net/v3/articles";
        private readonly IHttpClientFactory _clientFactory;
        
        public MyService(IHttpClientFactory clientFactory  )
        {
            _clientFactory = clientFactory;
            

        }

        public async Task<IEnumerable<Data>> GetArticles(int limit)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Get,$"{URL}?_limit={limit}");
            var client = _clientFactory.CreateClient();
            var response =  await client.SendAsync(request);
            var result = await response.Content.ReadAsStreamAsync();
            IEnumerable<Data> Datas = await JsonSerializer.DeserializeAsync<IEnumerable<Data>>(result);
            return Datas;

           
        }

        public async Task<int> GetCount()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{URL}/count");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();
            return int.Parse(result);
        }
    }
}
