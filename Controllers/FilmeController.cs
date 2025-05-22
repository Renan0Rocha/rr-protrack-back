using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace ApiLocadora.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
       private readonly AppDbContext _context;

        public FilmeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var listaFilmes = await _context.Filmes.ToListAsync();
            return Ok(listaFilmes);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] FilmeDto item)
        {
           var filme = new Filme
           {
               Nome = item.Nome,
               Genero = item.Genero
           };

           await _context.Filmes.AddAsync(filme);
           await _context.SaveChangesAsync();

           return Created("", filme);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] FilmeDto item)
        {

            if (null == null)
            {
                return NotFound("Filme não encontrado.");
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {


            return Ok();
        }


    }
}
