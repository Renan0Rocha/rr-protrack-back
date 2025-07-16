using rr_protrack_back.Dtos.VendedoresDtos;
using rr_protrack_back.Models;
using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos.ClientesDtos
{
    public class ClienteDto
    {

        public int Id { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Telefone { get; set; }

        [Required]
        public required DateOnly DataNascimento { get; set; }
        
        [Required]
        public required string Cpf { get; set; }

        [Required]
        public required EnderecoDto Endereco { get; set; }
        
        [Required]
        public required VendedorResponseDto Vendedor { get; set; }
    }
}
