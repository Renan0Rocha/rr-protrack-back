using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;

namespace rr_protrack_back.Services
{
    public class ProgramaService
    {
        private readonly AppDbContext _context;

        public ProgramaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Programa>> GetAll()
        {
            var list = await _context.Programa.ToListAsync();

            return list;
        }

        public async Task<Programa?> GetOneById(int id)
        {
            try
            {
                return await _context.Programa
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Programa?> Create(ProgramaDto progama)
        {
            try
            {
                var data = progama.DataInicio;

                var newPrograma = new Programa
                {
                    Nome = progama.Nome,
                    Sigla = progama.Sigla,
                    Descricao = progama.Descricao,
                    Tipo = progama.Tipo,  
                    Status = progama.Status, 
                    DataInicio = new DateOnly(data.Year, data.Month, data.Day)

                };

                await _context.Programa.AddAsync(newPrograma);
                await _context.SaveChangesAsync();

                return newPrograma;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Programa?> Update(int id, ProgramaDto programa)
        {
            try
            {
                var _programa = await GetOneById(id);

                if (_programa is null)
                {
                    return _programa;
                }

                _programa.Nome = programa.Nome;
              

                _context.Programa.Update(_programa);
                await _context.SaveChangesAsync();

                return _programa;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Programa?> Delete(int id)
        {
            return null;
        }

        private async Task<bool> Exist(int id)
        {
            return await _context.Programa.AnyAsync(c => c.Id == id);
        }
    }
}
