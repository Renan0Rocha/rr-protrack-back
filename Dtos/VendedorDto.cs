using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos
{
    public class VendedorDto
    {
        [Required]
        [MinLength(5)]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateOnly DataNascimento { get; set; }

        public string Vinculo { get; set; }

    }
}
