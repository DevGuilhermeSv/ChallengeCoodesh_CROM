using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace challengeCoodesh.DbConfig
{
    public class DbConfig
    {
        public IMongoDatabase database {get; set;}
        public DbConfig()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://DevGuilherme:bAARtddYbyJeltYb@cluster0.xgzsh.mongodb.net/Coodesh?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            database = client.GetDatabase("DataCoodesh");
            

        }
    }
}
