using employesControl_V2.Models;

namespace employesControl_V2.Repository.interfaces
{
    public interface IFuncionarioRepository
    {
        public Task<IEnumerable<Funcionario>> FindAll();

        public Task<Funcionario> FindById(int id);

        public void Create(Funcionario entity);

        public void Updade(Funcionario entity);

        public void Delete(Funcionario entity);

        public Task<bool> SaveChangesAsync();
    }
}