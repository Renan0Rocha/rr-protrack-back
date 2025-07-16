using rr_protrack_back.Dtos.ClientesDtos;
using rr_protrack_back.Dtos.VendedoresDtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rr_protrack_back.Dtos.ContratosDtos
{
    public class ContratoDto
    {
        public int Id { get; set; }
        public required string NumeroDocumento { get; set; }
        public required string Situacao { get; set; }
        public required string Plano { get; set; }
        public required string Descricao { get; set; }
        public required DateOnly DataEmissao { get; set; }
        public required DateOnly DataInicio { get; set; }
        public required DateOnly DataFim { get; set; }
        public required List<string> Horarios { get; set; }
        public required int TotalInsercoes { get; set; }
        public required double ValorBruto { get; set; }
        public required double ValorDesconto { get; set; }
        public required double ValorTotal { get; set; }
        public required double ValorComissao { get; set; }

        
        public required ClienteDto Cliente { get; set; }
        
        public required VendedorResponseDto Vendedor { get; set; }
        
        public required InsercaoDto Insercao { get; set; }
    }
}
