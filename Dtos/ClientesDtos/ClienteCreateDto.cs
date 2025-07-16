using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos.ClientesDtos
{
    public class ClienteCreateDto
    {
        [Required]
        public required string Nome { get; set; }
        [Required]
        public required string Cpf { get; set; }
        [Required]
        public required DateTime DataNasc { get; set; }
        [Required]
        public required string Telefone { get; set; }
        [Required]
        public required int EnderecoId { get; set; }
        [Required]
        public required int VendedorId { get; set; }
    }
}
