using employesControl_V2.Models;
using employesControl_V2.Repository.interfaces;
using employesControl_V2.Services.interfaces;

namespace employesControl_V2.Services
{
    public class FuncionarioService : IFuncionarioService
    {

        private readonly IFuncionarioRepository _repositoryFunc;
        public FuncionarioService(IFuncionarioRepository repositoryFunc)
        {
            _repositoryFunc = repositoryFunc;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _repositoryFunc.FindById(id);
            if (entity == null) return false;

            _repositoryFunc.Delete(entity);

            _repositoryFunc.Delete(entity);
            return await _repositoryFunc.SaveChangesAsync();
        }

        public Task<IEnumerable<Funcionario>> FindAll()
        {
            return _repositoryFunc.FindAll();
        }

        public Task<Funcionario> FindById(int id)
        {
            return _repositoryFunc.FindById(id);
        }

        public async Task<bool> Create(Funcionario entity)
        {
            entity.Senha = Helper.DataProtection.EncriptiStringValue(entity.Senha);

            var resultFuncionarios = await _repositoryFunc.FindAll();
            var maxId = resultFuncionarios.Count() > 0
                        ? resultFuncionarios?.OrderByDescending(x => x.Id)?.First().Id
                        : 0;
            maxId++;
            entity.NumeroChapa = Convert.ToDecimal(maxId?.ToString("D10"));

            _repositoryFunc.Create(entity);
            return await _repositoryFunc.SaveChangesAsync();
        }

        public async Task<bool> Update(int id, Funcionario entity)
        {
            var funcionario = await _repositoryFunc.FindById(id);
            if (entity == null) return false;

            entity.DDD = funcionario.DDD ?? entity.DDD;
            entity.Email = funcionario.Email ?? entity.Email;
            entity.Nome = funcionario.Nome ?? entity.Nome;
            entity.Sobrenome = funcionario.Sobrenome ?? entity.Sobrenome;
            entity.Telefones = funcionario.Telefones ?? entity.Telefones;
            entity.LiderId = funcionario.LiderId ?? entity.LiderId;


            _repositoryFunc.Updade(entity);
            return await _repositoryFunc.SaveChangesAsync();
        }
    }
}