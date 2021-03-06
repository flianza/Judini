using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Judini.Client.Infraestructura;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Radzen;

namespace Judini.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<IdentityAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.Scan(scan =>
            {
                scan.FromCallingAssembly()
                    .AddClasses()
                    .AsMatchingInterface();
            });

            builder.Services.AddMudServices();
            builder.Services.AddScoped<DialogService>();

            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("es-AR");
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("es-AR");
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CurrentUICulture;

            await builder.Build().RunAsync();
        }
    }
}
