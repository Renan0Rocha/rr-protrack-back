using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos
{
    public class OrdemBlocoDto
    {
        public int Id { get; set; }
        [Required]
        public DateOnly Data_bloco { get; set; }
        [Required]
        public required string Hora { get; set; }
        [Required]
        public int ProgramaId { get; set; }

        public ProgramaDto? Programa { get; set; }
    }

}
