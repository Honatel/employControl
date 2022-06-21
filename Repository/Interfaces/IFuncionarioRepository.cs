using employesControl_V2.Models;

namespace employesControl_V2.Repository.interfaces
{
    public interface IFuncionarioRepository
    {
        public Task<IEnumerable<Funcionario>> Get();

        public Task<Funcionario> GetById(int id);

        public void Post(Funcionario entity);

        public void Put(Funcionario entity);

        public void Delete(Funcionario entity);

        public Task<bool> SaveChangesAsync();
    }
}