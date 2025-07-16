using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos.VendedoresDtos
{
    public class VendedorDto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateOnly DataNascimento { get; set; }

        public string Vinculo { get; set; }
    }
}
