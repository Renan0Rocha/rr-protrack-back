using System.ComponentModel.DataAnnotations.Schema;

namespace rr_protrack_back.Dtos.ContratosDtos
{
    public class ContratoCreateDto
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

        [Column("id_cli_fk")]
        public required int ClienteId { get; set; }
        [Column("id_ven_fk")]
        public required int VendedorId { get; set; }
        [Column("id_ins_fk")]
        public required int InsercaoId { get; set; }
    }
}
