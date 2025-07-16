using System.ComponentModel.DataAnnotations.Schema;

namespace rr_protrack_back.Models
{
    public class OrdemBlocoContrato
    {
        public int Id { get; set; }
        public required int NumeroOrdem { get; set; }

        [Column("id_ord_fk")]
        public int OrdemBlocoId { get; set; }
        
        [Column("id_con_fk")]
        public int ContratoId { get; set; }

        public Contrato? Contrato { get; set; }
        public OrdemBloco? OrdemBloco { get; set; }

    }
}
