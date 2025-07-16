using Microsoft.AspNetCore.Mvc;
using rr_protrack_back.Dtos;
using rr_protrack_back.Services;

namespace rr_protrack_back.Controllers
{
    [ApiController]
    [Route("endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enderecos = await _service.GetAllAsync();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var endereco = await _service.GetByIdAsync(id);
            return endereco == null ? NotFound() : Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnderecoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnderecoDto dto)
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
