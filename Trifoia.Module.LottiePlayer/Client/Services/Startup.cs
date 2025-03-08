using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Oqtane.Services;
using Trifoia.Module.LottiePlayer.Services;

namespace Trifoia.Module.LottiePlayer.Client.Services
{
    public class Startup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<LottiePlayerService, LottiePlayerService>();
            services.AddMudServices();
        }
    }
}
