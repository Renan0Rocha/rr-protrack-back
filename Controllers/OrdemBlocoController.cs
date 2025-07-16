using Microsoft.AspNetCore.Mvc;
using rr_protrack_back.Dtos;
using rr_protrack_back.Services;

namespace rr_protrack_back.Controllers
{
    [ApiController]
    [Route("ordemBloco")]
    public class OrdemBlocoController : ControllerBase
    {
        private readonly OrdemBlocoService _service;

        public OrdemBlocoController(OrdemBlocoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bloco = await _service.GetByIdAsync(id);
            return bloco == null ? NotFound() : Ok(bloco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrdemBlocoDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }

}
