using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;
using rr_protrack_back.Services;


namespace rr_protrack_back.Controllers
{
    [Route("programa")]
    [ApiController]
    public class ProgramaController(AppDbContext context) : ControllerBase
    {

        private readonly ProgramaService _service;
        private readonly AppDbContext _context = context;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProgramaDto item)
        {
            try
            {
                var programa = await _service.Create(item);

                if (programa is null)
                {
                    return Problem("Ocorreram erros ao salvar!");
                }

                return Created("", programa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            try
            {
                var programa = await _context.Programa.FindAsync(id);

                if (programa == null)
                    return NotFound();

                return Ok(programa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var Programa = await _context.Programa.ToListAsync();
                return Ok(Programa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] ProgramaDto dto)
        {
            try
            {
                var programa = await _context.Programa.FindAsync(id); // singular

                if (programa == null)
                    return NotFound();

                programa.Nome = dto.Nome;
                programa.Sigla = dto.Sigla;
                programa.Descricao = dto.Descricao;
                programa.Tipo = dto.Tipo;
                programa.HorarioInicio = TimeOnly.FromDateTime(dto.HorarioInicio);
                programa.HorarioFim = TimeOnly.FromDateTime(dto.HorarioFim);
                programa.DataInicio = DateOnly.FromDateTime(dto.DataInicio);
                programa.DataFim = DateOnly.FromDateTime(dto.DataFim);
                programa.Status = dto.Status;
                programa.UpdatedAt = DateTime.Now;

                _context.Programa.Update(programa); // singular
                await _context.SaveChangesAsync();

                return Ok(programa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            try
            {
                var programa = await _context.Programa.FindAsync(id);

                if (programa == null)
                    return NotFound();

                _context.Programa.Remove(programa);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
