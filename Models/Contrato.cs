
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rr_protrack_back.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public required string NumeroDocumento { get; set; }
        public required string Situacao { get; set; }
        public required string Plano { get; set; }
        public required string Descricao { get; set; }
        public required DateOnly DataEmissao { get; set; }
        public required DateOnly DataInicio { get; set; }
        public required DateOnly DataFim { get; set; }
        public required string Horarios { get; set; }
        public required int TotalInsercoes { get; set; }
        public required double ValorBruto { get; set; }
        public required double ValorDesconto { get; set; }
        public required double ValorTotal { get; set; }
        public required double ValorComissao { get; set; }

        //ForeignKeys
        [Column("id_cli_fk")]
        public int ClienteId { get; set; }
        [Column("id_ven_fk")]
        public int VendedorId { get; set; }
        [Column("id_ins_fk")]
        public int InsercaoId { get; set; }

        public required Cliente Cliente { get; set; }
        public required Vendedor Vendedor { get; set; }
        public required Insercao Insercao { get; set; }

        public ICollection<OrdemBlocoContrato> OrdemBlocoContrato { get; set; }
    }
}
