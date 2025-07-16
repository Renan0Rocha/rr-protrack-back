using AutoMapper;
using global::rr_protrack_back.DataContext;
using global::rr_protrack_back.Dtos;
using global::rr_protrack_back.Models;
using Microsoft.EntityFrameworkCore;
using rr_protrack_back.Dtos.ClientesDtos;


namespace rr_protrack_back.Services
    {
        public class ClienteService
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public ClienteService(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ClienteDto>> GetAllAsync()
            {
                var clientes = await _context.Cliente
                .Include(c => c.Endereco)
                .Include(c => c.Vendedor)
                .ToListAsync();

                return _mapper.Map<List<ClienteDto>>(clientes);
            }

            public async Task<ClienteDto?> GetByIdAsync(int id)
            {
                var cliente = await _context.Cliente
                    .Include(c => c.Endereco)
                    .Include(c => c.Vendedor)
                    .FirstOrDefaultAsync(c => c.Id == id);

                return cliente == null ? null : _mapper.Map<ClienteDto>(cliente);
            }

            public async Task<ClienteDto> CreateAsync(ClienteCreateDto dto)
            {
                var cliente = _mapper.Map<Cliente>(dto);

                _context.Entry(cliente).Reference(c => c.Endereco).IsModified = false;
                _context.Entry(cliente).Reference(c => c.Vendedor).IsModified = false;

                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();

                var clienteCompleto = await _context.Cliente
                    .Include(c => c.Endereco)
                    .Include(c => c.Vendedor)
                    .FirstOrDefaultAsync(c => c.Id == cliente.Id);

                return _mapper.Map<ClienteDto>(clienteCompleto);
            }

            public async Task<bool> UpdateAsync(int id, ClienteCreateDto dto)
            {
                var cliente = await _context.Cliente.FindAsync(id);
                if (cliente == null) return false;

                _mapper.Map(dto, cliente);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var cliente = await _context.Cliente.FindAsync(id);
                if (cliente == null) return false;

                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }


