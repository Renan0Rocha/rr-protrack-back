using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rr_protrack_back.Models
{
    [Table("filmes")]
    public class Filme
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Genero { get; set; }

        public DateOnly? AnoLancamento { get; set; }

        [JsonIgnore]
        public int? EstudioId { get; set; }

        public virtual Estudio? Estudio { get; set; }
    }
}
