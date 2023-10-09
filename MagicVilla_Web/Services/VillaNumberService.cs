using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaURL;
        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
            villaURL = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public Task<T> CreateAsync<T>(VillaNumberCreateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaURL + "/api/villaNumberAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaURL + "/api/villaNumberAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaURL + "/api/villaNumberAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaURL + "/api/villaNumberAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaURL + "/api/villaNumberAPI/" + dto.VillaNo
            });
        }
    }
}
