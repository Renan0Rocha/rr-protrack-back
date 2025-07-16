using System.ComponentModel.DataAnnotations;

public class ProgramaDto
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Sigla { get; set; }

    [Required]
    public List<string> DiasSemana { get; set; }

    [Required]
    public string HorarioInicio { get; set; }

    [Required]
    public string HorarioFim { get; set; }

    [Required]
    public string Duracao { get; set; }

    [Required]
    public DateOnly DataInicio { get; set; }

    [Required]
    public DateOnly DataFim { get; set; }
}

