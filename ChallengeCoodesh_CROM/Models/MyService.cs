using ChallengeCoodesh_CROM.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCoodesh_CROM.Models
{
    public class MyService : IMyService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration configuration;
        
        public MyService(IHttpClientFactory clientFactory  )
        {
            _clientFactory = clientFactory;
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://DevGuilherme:bAARtddYbyJeltYb@cluster0.xgzsh.mongodb.net/Coodesh?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DataCoodesh");
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
