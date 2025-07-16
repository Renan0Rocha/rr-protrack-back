using AutoMapper;
using rr_protrack_back.DataContext;
using rr_protrack_back.Dtos;
using rr_protrack_back.Models;
using Microsoft.EntityFrameworkCore;

namespace rr_protrack_back.Services
{
    public class OrdemBlocoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrdemBlocoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task GerarOrdemBlocoParaProgramaAsync(Programa programa)
        {
            var diasSemana = programa.DiasSemana.Select(d => d.Trim().ToLowerInvariant());
            var horarios = new[] { programa.HorarioInicio, programa.HorarioFim, programa.Duracao };

            var blocos = new List<OrdemBloco>();

            for (var data = programa.DataInicio; data <= programa.DataFim; data = data.AddDays(1))
            {
                var dia = data.DayOfWeek.ToString().ToLowerInvariant();

                if (diasSemana.Any(d => dia.Contains(d)))
                {
                    foreach (var hora in horarios.Distinct())
                    {
                        blocos.Add(new OrdemBloco
                        {
                            Data_bloco = data,
                            Hora = hora,
                            ProgramaId = programa.Id
                        });
                    }
                }
            }

            await _context.OrdemBloco.AddRangeAsync(blocos);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrdemBlocoDto>> GetAllAsync()
        {
            var blocos = await _context.OrdemBloco.ToListAsync();
            return _mapper.Map<List<OrdemBlocoDto>>(blocos);
        }

        public async Task<OrdemBlocoDto?> GetByIdAsync(int id)
        {
            var bloco = await _context.OrdemBloco.FindAsync(id);
            return bloco == null ? null : _mapper.Map<OrdemBlocoDto>(bloco);
        }

        public async Task<bool> UpdateAsync(int id, OrdemBlocoDto dto)
        {
            var bloco = await _context.OrdemBloco.FindAsync(id);
            if (bloco == null) return false;

            bloco.Data_bloco = dto.Data_bloco;
            bloco.Hora = dto.Hora;
            bloco.ProgramaId = dto.ProgramaId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bloco = await _context.OrdemBloco.FindAsync(id);
            if (bloco == null) return false;

            _context.OrdemBloco.Remove(bloco);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
