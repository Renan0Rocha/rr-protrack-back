using rr_protrack_back.Dtos.ContratosDtos;

namespace rr_protrack_back.Dtos
{
    public class OrdemBlocoContratoDto
    {
        public int Id { get; set; }
        public int NumeroOrdem { get; set; }

        public int OrdemBlocoId { get; set; }
        public int ContratoId { get; set; }

        public OrdemBlocoDto? OrdemBloco { get; set; }
        public ContratoDto? Contrato { get; set; }
    }
}
