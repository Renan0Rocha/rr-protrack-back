using Microsoft.AspNetCore.Mvc;
using rr_protrack_back.Dtos.ContratosDtos;
using rr_protrack_back.Services;

namespace rr_protrack_back.Controllers
{
    [ApiController]
    [Route("contrato")]
    public class ContratoController : ControllerBase
    {
        private readonly ContratoService _service;

        public ContratoController(ContratoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contratos = await _service.GetAllAsync();
            return Ok(contratos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contrato = await _service.GetByIdAsync(id);
            return contrato == null ? NotFound() : Ok(contrato);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContratoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContratoDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
