using API_To_Do_List.Domain.Model.Entidades;
using API_To_Do_List.Service.Servico.Interfaca;
using Microsoft.AspNetCore.Mvc;

namespace API_To_Do_List.Cliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : Controller
    {
        private readonly ITarefaServico _tarefaServico;
        public TarefaController(ITarefaServico tarefaServico)
        {
            _tarefaServico = tarefaServico;
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> Adicionar(Tarefa entity)
        {
            await _tarefaServico.AdicionarAsync(entity);
            return Ok("Tarefa Criada");
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar(Tarefa entity)
        {
            await _tarefaServico.AtualizarAsync(entity);
            return NoContent();
        }

        [HttpDelete("Deletar/{tarefaId}")]
        public async Task<IActionResult> Deletar(int tarefaId)
        {
            await _tarefaServico.DelearAsync(tarefaId);
            return NoContent();
        }

        [HttpGet("PegarPorId/{tarefaId}")]
        public async Task<Tarefa> PegarTarefaPorId(int tarefaId)
        {
            return await _tarefaServico.PegarTarefaPorIdAsync(tarefaId);
        }

        [HttpGet("Lista")]
        public async Task<IEnumerable<Tarefa>> ListaTarefas()
        {
            return await _tarefaServico.listaTarefaAsync();
        }
    }
}
