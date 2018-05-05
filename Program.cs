using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;

namespace TheBookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = BuildWebHost(args);
            SeedData();
            host.Run();
        }

          public static void SeedData() {
            var db = new DataContext();

            if(!db.Publishers.Any()){
                var initialPublishers = new List<Publisher> {
                    new Publisher { Name = "pub1" },
                    new Publisher { Name = "pub2" },
                    new Publisher { Name = "pub3" },
                    new Publisher { Name = "pub4" },
                };

                db.AddRange(initialPublishers);
                db.SaveChanges();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

                
    }
}
