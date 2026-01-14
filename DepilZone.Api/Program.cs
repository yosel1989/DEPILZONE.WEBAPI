using DepilZone.Api.Hubs;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace DepilZone.Api
{
    public class Program
    {
        public static IDictionary<string, IdentificacionUsuarioChatDTO> usuarios = new Dictionary<string, IdentificacionUsuarioChatDTO>();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
