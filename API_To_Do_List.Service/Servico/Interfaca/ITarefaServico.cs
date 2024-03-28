using API_To_Do_List.Domain.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Service.Servico.Interfaca
{
    public interface ITarefaServico
    {
        Task AdicionarAsync(Tarefa entity);
        Task AtualizarAsync(Tarefa entity);
        Task DelearAsync(int tarefaId);
        Task<Tarefa> PegarTarefaPorIdAsync(int tarefaId);
        Task<IEnumerable<Tarefa>> listaTarefaAsync();
    }
}
