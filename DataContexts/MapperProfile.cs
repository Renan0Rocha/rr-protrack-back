using AutoMapper;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.Dtos;
using rr_protrack_back.Dtos.ClientesDtos;
using rr_protrack_back.Dtos.ContratosDtos;
using rr_protrack_back.Dtos.VendedoresDtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.DataContexts
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VendedorDto, Vendedor>().ReverseMap();
            
            CreateMap<EnderecoDto, Endereco>().ReverseMap();

            CreateMap<ClienteCreateDto, Cliente>();

            CreateMap<Cliente, ClienteResponseDto>();

            CreateMap<Vendedor, VendedorResponseDto>();

            CreateMap<Cliente, ClienteDto>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
            .ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.Vendedor))
            .ReverseMap();

            CreateMap<ProgramaDto, Programa>().ReverseMap();

            CreateMap<InsercaoDto, Insercao>().ReverseMap();

            CreateMap<OrdemBlocoDto, OrdemBloco>().ReverseMap();

            CreateMap<ContratoCreateDto, Contrato>();

            CreateMap<OrdemBlocoContrato, OrdemBlocoContratoDto>().ReverseMap();

            CreateMap<Contrato, ContratoDto>()
            .ForMember(dest => dest.Horarios, opt => opt.MapFrom(src =>
             src.Horarios.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(h => h.Trim()).ToList()));

            CreateMap<ContratoDto, Contrato>()
            .ForMember(dest => dest.Horarios, opt => opt.MapFrom(src => string.Join(",", src.Horarios)));


        }
    }
}
