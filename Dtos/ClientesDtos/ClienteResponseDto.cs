using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos.ClientesDtos
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Cpf { get; set; }
    }
}
