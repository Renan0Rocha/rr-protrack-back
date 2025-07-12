using AutoMapper;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.DataContexts
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VendedorDto, Vendedor>().ReverseMap();

        }
    }
}
