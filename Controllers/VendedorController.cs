using Microsoft.AspNetCore.Mvc;
using rr_protrack_back.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using rr_protrack_back.Models;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.Dtos.VendedoresDtos;


namespace rr_protrack_back.Controllers
{
        [ApiController]
        [Route("vendedor")]
        public class VendedorController : ControllerBase
        {
            private readonly VendedorService _service;

            public VendedorController(VendedorService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _service.GetAll();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _service.GetById(id);
                return result == null ? NotFound() : Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] VendedorDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = await _service.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Cpf }, created);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] VendedorDto dto)
            {
                var updated = await _service.Update(id, dto);
                return updated ? NoContent() : NotFound();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var deleted = await _service.Delete(id);
                return deleted ? NoContent() : NotFound();
            }
        }
}

