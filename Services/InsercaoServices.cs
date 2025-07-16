using AutoMapper;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;
using Microsoft.EntityFrameworkCore;

namespace rr_protrack_back.Services
{
    public class InsercaoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InsercaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InsercaoDto> CreateAsync(InsercaoDto dto)
        {
            var entity = _mapper.Map<Insercao>(dto);
            _context.Insercao.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<InsercaoDto>(entity);
        }

        public async Task<InsercaoDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Insercao.FindAsync(id);
            return entity == null ? null : _mapper.Map<InsercaoDto>(entity);
        }

        public async Task<List<InsercaoDto>> GetAllAsync()
        {
            var list = await _context.Insercao.ToListAsync();
            return _mapper.Map<List<InsercaoDto>>(list);
        }

        public async Task<bool> UpdateAsync(int id, InsercaoDto dto)
        {
            var entity = await _context.Insercao.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Insercao.FindAsync(id);
            if (entity == null) return false;

            _context.Insercao.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
