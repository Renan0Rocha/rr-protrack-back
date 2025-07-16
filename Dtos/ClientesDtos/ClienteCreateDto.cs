using rr_protrack_back.Dtos.VendedoresDtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rr_protrack_back.Dtos.ClientesDtos
{
    public class ClienteCreateDto
    {
        [Required]
        public required string Nome { get; set; }
        [Required]
        public required string Cpf { get; set; }
        [Required]
        public required DateOnly DataNasc { get; set; }
        [Required]
        public required string Telefone { get; set; }

        [Required]
        [Column("id_ven_fk")]
        public required int VendedorId { get; set; }

        [Required]
        public required EnderecoDto Endereco { get; set; }
    }
}
