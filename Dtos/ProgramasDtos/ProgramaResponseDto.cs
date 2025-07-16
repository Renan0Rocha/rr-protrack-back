using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos.ProgramasDtos
{
    public class ProgramaResponseDto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
