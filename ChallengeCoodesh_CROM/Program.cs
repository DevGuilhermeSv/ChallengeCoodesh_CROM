
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

namespace ChallengeCoodesh_CROM
{

    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // requires using Microsoft.Extensions.Options
                    services.Configure<BookstoreDatabaseSettings>(
                        Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

                    services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                        sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);
                    services.AddHttpClient();
                    services.AddTransient<IMyService, MyService>();
                }).UseConsoleLifetime();

            var host = builder.Build();

            try
            {
                var myService = host.Services.GetRequiredService<IMyService>();
                var response = await myService.GetPage();
                if (response.IsSuccessStatusCode)
                {
                    var pageContent =  await response.Content.ReadAsStreamAsync();
                    IEnumerable<Data> Branches = await JsonSerializer.DeserializeAsync<IEnumerable<Data>>(pageContent);
                    //Console.WriteLine(pageContent/*.Substring(0, 500)*/);
                }
                else
                {
                   // return $"StatusCode: {response.StatusCode}";
                }
                //using var responseStream = await response.Content.ReadAsStreamAsync();
               
            }
            catch (Exception ex)
            {
                var logger = host.Services.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occurred.");
            }

            return 0;
        }

        

       
    }
}
