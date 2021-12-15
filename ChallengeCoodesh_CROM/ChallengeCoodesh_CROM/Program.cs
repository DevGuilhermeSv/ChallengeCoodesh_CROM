
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ChallengeCoodesh_CROM.Interface;
using ChallengeCoodesh_CROM.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ChallengeCoodesh_CROM.Models.Entitie;
using System.Collections.Generic;
using System.Configuration;
using MongoDB.Driver;
using System.Linq;

namespace ChallengeCoodesh_CROM
{

    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {

                    services.AddHttpClient();
                    services.AddTransient<IMyService, MyService>();
                }).UseConsoleLifetime();

            var host = builder.Build();

            try
            {
                Console.WriteLine("Init Service");
                var myService = host.Services.GetRequiredService<IMyService>();
                Console.WriteLine("Geting Number of Articles");
                var count = await myService.GetCount();
                Console.WriteLine("Geting Articles");
                IEnumerable<Data> artigos = await myService.GetArticles(count);
                DbConfig db = new DbConfig();
                var database = db.database;
                database.DropCollection("Data");
                Console.WriteLine("Inserting data in to database");
                var collection = database.GetCollection<Data>("Data");
                collection.InsertMany(artigos);

            }
            catch (Exception ex)
            {
                var logger = host.Services.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occurred.");
                Console.WriteLine("\n An error occurred. Consult the Log");
            }

            return 0;
        }




    }
}
