using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium
{
    public class Program
    {
        /*Asp.net Core temelinde bir console uygulamasý
         * Sunucuyu ayaða kaldýrdýðý kýsým
         */
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    /*Default startup
                     * Temel konfigürasyon sýnýfý
                     */
                    webBuilder.UseStartup<Startup>();
                });
    }
}
