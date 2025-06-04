using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rr_protrack_back.Models
{
    [Table("programa")]
    public class Programa
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Sigla { get; set; }

        public string? Descricao { get; set; }

        public required string Tipo { get; set; }

        public TimeOnly? HorarioInicio { get; set; }

        public TimeOnly? HorarioFim { get; set; }

        public DateOnly? DataInicio { get; set; }

        public DateOnly? DataFim { get; set; }

        public required string Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
