using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rr_protrack_back.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        public int Id { get; set; }
        public required string Logradouro { get; set; }
        public required string Numero { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        public required string Cep { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
    } 
}
