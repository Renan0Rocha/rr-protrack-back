using AutoMapper;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.DataContexts
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
             CreateMap<FilmeDto, Filme>().ForMember(dest => dest.AnoLancamento, opt => opt.MapFrom(src => new 
             DateOnly(src.AnoLancamento.Year, src.AnoLancamento.Month, src.AnoLancamento.Day))).ReverseMap();
        }
    }
}
