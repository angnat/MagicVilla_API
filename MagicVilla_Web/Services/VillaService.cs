using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaURL;
        public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
            villaURL = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public Task<T> CreateAsync<T>(VillaCreateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaURL + "/api/villaAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaURL + "/api/villaAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaURL + "/api/villaAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaURL + "/api/villaAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaURL + "/api/villaAPI/" + dto.Id
            });
        }
    }
}
