using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rr_protrack_back.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public required string Nome { get; set; }
        public required string Telefone { get; set; }
        public required string Cpf { get; set; }

        [Column("data_nasc")]
        public required DateOnly DataNascimento { get; set; }

        [JsonIgnore]
        [Column("id_end_fk")]
        public int EnderecoId { get; set; }

        public required Endereco Endereco { get; set; }

        [JsonIgnore]
        [Column("id_ven_fk")]
        public int VendedorId { get; set; }

        public required Vendedor Vendedor { get; set; }


    }
}
