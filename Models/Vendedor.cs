namespace rr_protrack_back.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required DateOnly DataNascimento { get; set; }
        public required string Cpf { get; set; }
        public string? Vinculo { get; set; }
    }
}
