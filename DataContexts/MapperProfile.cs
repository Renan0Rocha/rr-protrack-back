using AutoMapper;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.Dtos;
using rr_protrack_back.Dtos.ClientesDtos;
using rr_protrack_back.Dtos.ContratosDtos;
using rr_protrack_back.Dtos.VendedoresDtos;
using rr_protrack_back.Dtos.ProgramasDtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.DataContexts
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VendedorDto, Vendedor>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<EnderecoDto, Endereco>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<ClienteCreateDto, Cliente>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
            .ReverseMap();

            CreateMap<Cliente, ClienteResponseDto>();

            CreateMap<Vendedor, VendedorResponseDto>();

            CreateMap<VendedorClienteDto, Vendedor>().ReverseMap();

            CreateMap<Cliente, ClienteDto>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
            .ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.Vendedor))
            .ReverseMap();

            CreateMap<ProgramaDto, Programa>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<InsercaoDto, Insercao>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<OrdemBlocoDto, OrdemBloco>().ReverseMap();

            CreateMap<Programa, ProgramaResponseDto>().ReverseMap();

            CreateMap<OrdemBlocoContrato, OrdemBlocoContratoDto>().ReverseMap();

            CreateMap<ContratoCreateDto, Contrato>()
    .       ForMember(dest => dest.Horarios, opt => opt.MapFrom(src => string.Join(",", src.Horarios)));

            CreateMap<Contrato, ContratoDto>()
            .ForMember(dest => dest.Horarios, opt => opt.MapFrom(src => src.Horarios.Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(h => h.Trim()).ToList()));

        }
    }
}
