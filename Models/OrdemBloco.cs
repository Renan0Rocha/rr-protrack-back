using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rr_protrack_back.Models
{
    public class OrdemBloco
    {
        public int Id { get; set; }
        public required DateOnly Data_bloco { get; set; }
        public required string Hora { get; set; }

        [Column("id_pro_fk")]
        public int ProgramaId { get; set; }

        public Programa? Programa { get; set; }

        public ICollection<OrdemBlocoContrato> OrdemBlocoContrato { get; set; }
    }

}
