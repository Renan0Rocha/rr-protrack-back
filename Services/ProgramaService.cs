using AutoMapper;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.Services
{
    public class ProgramaService
    {
        private readonly AppDbContext _context;
        private readonly OrdemBlocoService _ordemBlocoService;
        private readonly IMapper _mapper;

        public ProgramaService(AppDbContext context, OrdemBlocoService ordemBlocoService, IMapper mapper)
        {
            _context = context;
            _ordemBlocoService = ordemBlocoService;
            _mapper = mapper;
        }

        public async Task<ProgramaDto> CreateAsync(ProgramaDto dto)
        {
            var entity = _mapper.Map<Programa>(dto);
            _context.Programa.Add(entity);
            await _context.SaveChangesAsync();
            await _ordemBlocoService.GerarOrdemBlocoParaProgramaAsync(entity);

            return _mapper.Map<ProgramaDto>(entity);

        }

        public async Task<ProgramaDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Programa.FindAsync(id);
            return entity == null ? null : _mapper.Map<ProgramaDto>(entity);
        }

        public async Task<List<ProgramaDto>> GetAllAsync()
        {
            var list = await _context.Programa.ToListAsync();
            return _mapper.Map<List<ProgramaDto>>(list);
        }

        public async Task<bool> UpdateAsync(int id, ProgramaDto dto)
        {
            var entity = await _context.Programa.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Programa.FindAsync(id);
            if (entity == null) return false;

            _context.Programa.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
