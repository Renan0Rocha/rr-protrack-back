namespace rr_protrack_back.Models

{
    [Tags("Filmes")]
    public class Filme
    {
       
        
            public int Id { get; set; }
            public required string Nome { get; set; }
            public required string Genero { get; set; }
            public DateOnly? AnoLancamento { get; set; }

            public int EstudioId { get; set; }

            public virtual Estudio? Estudio { get; set; }
           
        
    }
}
