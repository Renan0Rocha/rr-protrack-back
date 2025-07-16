using System.ComponentModel.DataAnnotations;

namespace rr_protrack_back.Dtos
{
    public class InsercaoDto
    {
        public int Id { get; set; }

        [Required]
        public required string Tempo { get; set; }

        [Required]
        public required double Valor { get; set; }
    }

}
