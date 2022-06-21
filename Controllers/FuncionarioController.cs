using employesControl_V2.Models;
using employesControl_V2.Repository.interfaces;
using employesControl_V2.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace employesControl_V2.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _repositoryFunc;
        private readonly ILiderRepository _repositoryLid;


        public FuncionarioController(IFuncionarioRepository epositoryFunc, ILiderRepository repositoryLid)
        {
            _repositoryFunc = epositoryFunc;
            _repositoryLid = repositoryLid;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var funcionarios = await _repositoryFunc.Get();
            return funcionarios.Any()
                        ? Ok(funcionarios)
                        : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                BadRequest("Id não informado");

            var funcionario = await _repositoryFunc.GetById(id);
            return funcionario != null
                        ? Ok(funcionario)
                        : NotFound("Funcionario não encontrado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Funcionario funcionario)
        {
            if (funcionario == null)
                return BadRequest("Dados invalidos");

            var entity = await _repositoryFunc.GetById(id);
            if (entity == null) return NotFound("Funcionario não encontrado");

            entity.DDD = funcionario.DDD ?? entity.DDD;
            entity.Email = funcionario.Email ?? entity.Email;
            entity.Nome = funcionario.Nome ?? entity.Nome;
            entity.Sobrenome = funcionario.Sobrenome ?? entity.Sobrenome;
            entity.Telefones = funcionario.Telefones ?? entity.Telefones;
            entity.IdLider = funcionario.IdLider ?? entity.IdLider;
            entity.NumeroChapa = funcionario.NumeroChapa == 0 ? entity.NumeroChapa : funcionario.NumeroChapa;

            _repositoryFunc.Put(entity);

            return await _repositoryFunc.SaveChangesAsync()
                    ? Ok("Funcionario alterado com sucesso")
                    : BadRequest("Erro ao alterar Funcionario");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Funcionario funcionario)
        {
            _repositoryFunc.Post(funcionario);
            var result = await _repositoryFunc.SaveChangesAsync();

            if (result)
            {
                if (funcionario.isLider)
                    _repositoryLid.Post(new Lider() { IdFuncionario = funcionario.id, Ativo = true });
            }
            else return BadRequest("Erro ao criar Funcionario");

            return await _repositoryLid.SaveChangesAsync()
                    ? Ok("Funcionario salvo com sucesso")
                    : BadRequest("Erro ao salvar Funcionario");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repositoryFunc.GetById(id);
            if (entity == null) return NotFound("Funcionario não encontrado");

            _repositoryFunc.Delete(entity);

            if (entity.isLider)
            {
                var lider = await _repositoryLid.GetById(id);
                _repositoryLid.Delete(lider);
                await _repositoryLid.SaveChangesAsync();
            }

            return await _repositoryFunc.SaveChangesAsync()
                     ? Ok("Funcionario Deletado com sucesso")
                     : BadRequest("Erro ao Deletar Funcionario");

        }
    }
}