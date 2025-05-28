using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.DataContext;

namespace rr_protrack_back.Controllers
{
    [Route("estudios")]
    [ApiController]
    public class EstudioController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var estudios = await _context.Estudios.Include(e => e.Filmes).ToListAsync();

                return Ok(estudios);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}/filmes")]
        public async Task<IActionResult> GetFilmes(int id)
        {
            try
            {

                var filmes = await _context.Filmes.Where(e => e.EstudioId == id).ToListAsync();

                return Ok(filmes);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
