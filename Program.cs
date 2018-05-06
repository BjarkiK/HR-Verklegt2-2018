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
            Console.WriteLine("Hello From Main");
        }

          public static void SeedData() {
            var db = new DataContext();


            if(!db.Subscriptions.Any()){
                var initialPublishers = new List<Subscription> {
                  //  new Book { Name = "pub1", Picture = "w",DetailsEN= "asd",DetailsIS="qwe", GenreId=1, AuthorId=1, PublisherId=1, Price=100,Discount=5,Pages=20, Quantity=1,Grade=5 },
                    new Subscription { DescriptionEn = "wqe", DescriptionIn ="qweq", TypeEn = "sw", TypeIn = "sqwe"},
                    new Subscription { DescriptionEn = "wqe", DescriptionIn ="qweq", TypeEn = "sw", TypeIn = "sqwe"},
                    new Subscription { DescriptionEn = "wqe", DescriptionIn ="qweq", TypeEn = "sw", TypeIn = "sqwe"}
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

