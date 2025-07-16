using AutoMapper;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.Services
{
    public class OrdemBlocoContratoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrdemBlocoContratoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrdemBlocoContratoDto>> GetAllAsync()
        {
            var entidades = await _context.OrdemBlocoContrato
                .Include(x => x.Contrato)
                .Include(x => x.OrdemBloco)
                .ToListAsync();

            return _mapper.Map<List<OrdemBlocoContratoDto>>(entidades);
        }

        public async Task<OrdemBlocoContratoDto?> GetByIdAsync(int id)
        {
            var entidade = await _context.OrdemBlocoContrato
                .Include(x => x.Contrato)
                .Include(x => x.OrdemBloco)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<OrdemBlocoContratoDto>(entidade);
        }

        public async Task<bool> UpdateAsync(int id, OrdemBlocoContratoDto dto)
        {
            var entidade = await _context.OrdemBlocoContrato.FindAsync(id);
            if (entidade == null) return false;

            entidade.NumeroOrdem = dto.NumeroOrdem;
            entidade.OrdemBlocoId = dto.OrdemBlocoId;
            entidade.ContratoId = dto.ContratoId;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}