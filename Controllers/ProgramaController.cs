// Controllers/ProgramaController.cs
using rr_protrack_back.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

[Route("programas")]
[ApiController]
public class ProgramaController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProgramaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] ProgramaDto dto)
    {
        var programa = new Programa
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            Sigla = dto.Sigla,
            Descricao = dto.Descricao,
            Tipo = dto.Tipo,
            HorarioInicio = dto.HorarioInicio,
            HorarioFim = dto.HorarioFim,
            DataInicio = dto.DataInicio,
            DataFim = dto.DataFim,
            Status = dto.Status,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await _context.Programas.AddAsync(programa);
        await _context.SaveChangesAsync();

        return Created("", programa);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(Guid id)
    {
        var programa = await _context.Programas.FindAsync(id);

        if (programa == null)
            return NotFound();

        return Ok(programa);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var programas = await _context.Programas.ToListAsync();
        return Ok(programas);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] ProgramaDto dto)
    {
        var programa = await _context.Programas.FindAsync(id);

        if (programa == null)
            return NotFound();

        programa.Nome = dto.Nome;
        programa.Sigla = dto.Sigla;
        programa.Descricao = dto.Descricao;
        programa.Tipo = dto.Tipo;
        programa.HorarioInicio = dto.HorarioInicio;
        programa.HorarioFim = dto.HorarioFim;
        programa.DataInicio = dto.DataInicio;
        programa.DataFim = dto.DataFim;
        programa.Status = dto.Status;
        programa.UpdatedAt = DateTime.Now;

        _context.Programas.Update(programa);
        await _context.SaveChangesAsync();

        return Ok(programa);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        var programa = await _context.Programas.FindAsync(id);

        if (programa == null)
            return NotFound();

        _context.Programas.Remove(programa);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
