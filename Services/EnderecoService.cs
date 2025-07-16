using AutoMapper;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.Services
{
    public class EnderecoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EnderecoDto> CreateAsync(EnderecoDto dto)
        {
            var endereco = _mapper.Map<Endereco>(dto);
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();
            return _mapper.Map<EnderecoDto>(endereco);
        }

        public async Task<EnderecoDto?> GetByIdAsync(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            return endereco == null ? null : _mapper.Map<EnderecoDto>(endereco);
        }

        public async Task<List<EnderecoDto>> GetAllAsync()
        {
            var enderecos = await _context.Endereco.ToListAsync();
            return _mapper.Map<List<EnderecoDto>>(enderecos);
        }

        public async Task<bool> UpdateAsync(int id, EnderecoDto dto)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null) return false;

            _mapper.Map(dto, endereco);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null) return false;

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
