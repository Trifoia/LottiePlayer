using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using System.Net;

namespace Trifoia.Module.LottiePlayer.Services
{
    public class LottiePlayerService : ResponseServiceBase, IService
    {
        public LottiePlayerService(IHttpClientFactory http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("LottiePlayer");

        public async Task<(List<Models.LottiePlayer>,HttpStatusCode)> GetLottiePlayersAsync()
        {
            var url = $"{Apiurl}";
            (var data, var response) = await GetJsonWithResponseAsync<List<Models.LottiePlayer>>(url);
            return (data, response.StatusCode);      
        }

        public async Task<(Models.LottiePlayer,HttpStatusCode)> GetLottiePlayerAsync(int id)
        {
            var url = $"{Apiurl}/{id}";
            (var data, var response) = await GetJsonWithResponseAsync<Models.LottiePlayer>(url);
            return (data, response.StatusCode);        
        }

        public async Task<(Models.LottiePlayer,HttpStatusCode)> AddLottiePlayerAsync(Models.LottiePlayer item)
        {
            var url = $"{Apiurl}";
            (var data, var response) = await PostJsonWithResponseAsync<Models.LottiePlayer>(url,item);
            return (data, response.StatusCode);        
        }

        public async Task<(Models.LottiePlayer,HttpStatusCode)> UpdateLottiePlayerAsync(Models.LottiePlayer item)
        {
            var url = $"{Apiurl}/{item.LottiePlayerId}";
            (var data, var response) = await PutJsonWithResponseAsync<Models.LottiePlayer>(url,item);
            return (data, response.StatusCode);        
        }

        public async Task<HttpStatusCode> DeleteLottiePlayerAsync(int id)
        {
            var url = $"{Apiurl}/{id}";
            var response  = await DeleteWithResponseAsync(url);
            return response.StatusCode;
        }
    }
}
