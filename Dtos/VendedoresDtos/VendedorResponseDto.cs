using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos.VendedoresDtos
{
    public class VendedorResponseDto
    {
        public int Id { get; set; }

        [Required]
        public required string Nome { get; set; }
    }
}
