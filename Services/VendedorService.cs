using AutoMapper;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.Services
{
    public class VendedorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VendedorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VendedorDto> Create(VendedorDto dto)
        {
            var vendedor = _mapper.Map<Vendedor>(dto);
            _context.Vendedor.Add(vendedor);
            await _context.SaveChangesAsync();
            return _mapper.Map<VendedorDto>(vendedor);
        }

        public async Task<VendedorDto?> GetById(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            return vendedor == null ? null : _mapper.Map<VendedorDto>(vendedor);
        }

        public async Task<List<VendedorDto>> GetAll()
        {
            var vendedores = await _context.Vendedor.ToListAsync();
            return _mapper.Map<List<VendedorDto>>(vendedores);
        }

        public async Task<bool> Update(int id, VendedorDto dto)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null) return false;

            _mapper.Map(dto, vendedor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null) return false;

            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
