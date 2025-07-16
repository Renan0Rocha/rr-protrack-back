using AutoMapper;
using rr_protrack_back.DataContext;
using rr_protrack_back.Models;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.Dtos.ContratosDtos;

namespace rr_protrack_back.Services
{
    public class ContratoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ContratoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ContratoDto>> GetAllAsync()
        {
            var contratos = await _context.Contrato
                .Include(c => c.Cliente)
                .Include(c => c.Vendedor)
                .Include(c => c.Insercao)
                .ToListAsync();

            return _mapper.Map<List<ContratoDto>>(contratos);
        }

        public async Task<ContratoDto?> GetByIdAsync(int id)
        {
            var contrato = await _context.Contrato
                .Include(c => c.Cliente)
                .Include(c => c.Vendedor)
                .Include(c => c.Insercao)
                .FirstOrDefaultAsync(c => c.Id == id);

            return contrato == null ? null : _mapper.Map<ContratoDto>(contrato);
        }

        public async Task<ContratoDto> CreateAsync(ContratoCreateDto dto)
        {
            var contrato = _mapper.Map<Contrato>(dto);
            _context.Contrato.Add(contrato);
            await _context.SaveChangesAsync();

            foreach (var horario in dto.Horarios)
            {
                var ordemBloco = await _context.OrdemBloco
                    .FirstOrDefaultAsync(o => o.Hora == horario); // sem filtrar por programa

                if (ordemBloco != null)
                {
                    var ordemBlocoContrato = new OrdemBlocoContrato
                    {
                        ContratoId = contrato.Id,
                        OrdemBlocoId = ordemBloco.Id,
                        NumeroOrdem = GerarNumeroOrdem(ordemBloco.Id)
                    };

                    _context.OrdemBlocoContrato.Add(ordemBlocoContrato);
                }
            }

            await _context.SaveChangesAsync();

            var contratoCompleto = await _context.Contrato
                .Include(c => c.OrdemBlocoContrato)
                .ThenInclude(o => o.OrdemBloco)
                .FirstOrDefaultAsync(c => c.Id == contrato.Id);

            return _mapper.Map<ContratoDto>(contratoCompleto);
        }

        public async Task<bool> UpdateAsync(int id, ContratoDto dto)
        {
            var contrato = await _context.Contrato.FindAsync(id);

            if (contrato == null)
                return false;

            _mapper.Map(dto, contrato);
            _context.Contrato.Update(contrato);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contrato = await _context.Contrato.FindAsync(id);

            if (contrato == null)
                return false;

            _context.Contrato.Remove(contrato);
            await _context.SaveChangesAsync();

            return true;
        }

        private int GerarNumeroOrdem(int ordemBlocoId)
        {
            // Conta quantos contratos já estão vinculados a esse bloco
            return _context.OrdemBlocoContrato
                .Count(x => x.OrdemBlocoId == ordemBlocoId) + 1;
        }
    }
}
