using employesControl_V2.Data;
using employesControl_V2.Models;
using employesControl_V2.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace employesControl_V2.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private readonly DataContext _context;
        public FuncionarioRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Funcionario>> FindAll()
        {
            return await _context.Funcionarios.ToListAsync();
        }
        public async Task<Funcionario> FindById(int id)
        {
            return await _context.Funcionarios.
                Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public void Updade(Funcionario entity)
        {
            _context.Update(entity);
        }
        public void Create(Funcionario entity)
        {
            _context.Add(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Delete(Funcionario entity)
        {
            _context.Remove(entity);
        }
    }
}