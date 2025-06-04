using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Cliente>> GetAll()
        {
            var list = await _context.Cliente.ToListAsync();

            return list;
        }

        public async Task<Cliente?> GetOneById(int id)
        {
            try
            {
                return await _context.Cliente
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente?> Create(ClienteDto cliente)
        {
            try
            {
                

                var newCliente = new Cliente
                {
                    Nome = cliente.Nome,
                   

                };

                await _context.Cliente.AddAsync(newCliente);
                await _context.SaveChangesAsync();

                return newCliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente?> Update(int id, ClienteDto cliente)
        {
            try
            {
                var _cliente = await GetOneById(id);

                if (_cliente is null)
                {
                    return _cliente;
                }

                _cliente.Nome = cliente.Nome;


                _context.Cliente.Update(_cliente);
                await _context.SaveChangesAsync();

                return _cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Cliente?> Delete(int id)
        {
            return null;
        }

        private async Task<bool> Exist(int id)
        {
            return await _context.Cliente.AnyAsync(c => c.Id == id);
        }
    }
}
