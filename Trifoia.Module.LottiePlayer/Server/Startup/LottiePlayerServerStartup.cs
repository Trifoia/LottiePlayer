using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using Trifoia.Module.LottiePlayer.Repository;

namespace Trifoia.Module.LottiePlayer.Startup
{
    public class LottiePlayerServerStartup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // not implemented
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            // not implemented
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<LottiePlayerContext>(opt => { }, ServiceLifetime.Transient);
        }
    }
}
