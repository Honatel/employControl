using employesControl_V2.Models;
using employesControl_V2.Repository.interfaces;
using employesControl_V2.Repository.Interfaces;
using employesControl_V2.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace employesControl_V2.Controllers
{

    [Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var funcionarios = await _funcionarioService.FindAll();
            return funcionarios.Any()
                        ? Ok(funcionarios)
                        : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id não informado");

            var funcionario = await _funcionarioService.FindById(id);
            return funcionario != null
                        ? Ok(funcionario)
                        : NotFound("Funcionario não encontrado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Funcionario funcionario)
        {
            if (funcionario == null)
                return BadRequest("Dados invalidos");

            return await _funcionarioService.Update(id, funcionario)
                    ? Ok(new { message = "Funcionario alterado com sucesso", success = true })
                    : BadRequest("Erro ao alterar Funcionario");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Funcionario funcionario)
        {
            return await _funcionarioService.Create(funcionario)
                   ? Ok(new { message = "Funcionario creado com sucesso", success = true })
                   : BadRequest("Erro ao criar Funcionario");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _funcionarioService.Delete(id)
                     ? Ok(new { message = "Funcionario deletado com sucesso", success = true })
                     : BadRequest("Erro ao Deletar Funcionario");

        }
    }
}