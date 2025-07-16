using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rr_protrack_back.Models
{
    public class Programa
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Sigla { get; set; }
        public required List<string> DiasSemana { get; set; }
        public required string HorarioInicio { get; set; }
        public required string HorarioFim { get; set; }
        public required string Duracao { get; set; }
        public required DateOnly DataInicio { get; set; }
        public required DateOnly DataFim { get; set; }

        [JsonIgnore]
        public ICollection<OrdemBloco>? OrdemBlocos { get; set; }
    }
}
