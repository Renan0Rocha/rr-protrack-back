using Microsoft.AspNetCore.Mvc;
using rr_protrack_back.Dtos;
using rr_protrack_back.Services;

namespace rr_protrack_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdemBlocoContratoController : ControllerBase
    {
        private readonly OrdemBlocoContratoService _service;

        public OrdemBlocoContratoController(OrdemBlocoContratoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemBlocoContratoDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemBlocoContratoDto>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrdemBlocoContratoDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
