using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Newtonsoft.Json;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClientFactory { get; set; }

        public BaseService( IHttpClientFactory httpClientFactory)
        {
            this.responseModel = new();
            this.httpClientFactory = httpClientFactory;
        }

        public Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = this.httpClientFactory.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),System.Text.Encoding.UTF8,
                        "application/json");
                }
            }
        }
    }
}
