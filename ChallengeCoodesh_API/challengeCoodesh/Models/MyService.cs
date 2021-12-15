using ChallengeCoodesh.Models.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCoodesh.Models
{
    public class MyService : IMyService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MyService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> GetPage()
        {
            // Content from BBC One: Dr. Who website (©BBC)
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://api.spaceflightnewsapi.net/v3/articles?_limit=20");
            var client = _clientFactory.CreateClient();
            return await client.SendAsync(request);

           
        }
    }
}
