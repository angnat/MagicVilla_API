using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<VillaDto, VillaCreateDto>();
            CreateMap<VillaDto, VillaUpdateDto>();
       
            CreateMap<VillaNumberDto, VillaNumberCreateDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();
        }
    }
}
