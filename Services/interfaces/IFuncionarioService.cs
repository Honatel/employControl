using employesControl_V2.Models;

namespace employesControl_V2.Services.interfaces
{
    public interface IFuncionarioService
    {
        public Task<IEnumerable<Funcionario>> FindAll();

        public Task<Funcionario> FindById(int id);

        public Task<bool> Create(Funcionario entity);

        public Task<bool> Update(int id, Funcionario entity);

        public Task<bool> Delete(int id);
    }
}