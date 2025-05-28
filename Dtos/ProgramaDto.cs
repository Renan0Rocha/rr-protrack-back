using System.ComponentModel.DataAnnotations;

public class ProgramaDto
{
    public Guid? Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Sigla { get; set; }

    public string Descricao { get; set; }
    public string Tipo { get; set; }
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFim { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Status { get; set; }
}
