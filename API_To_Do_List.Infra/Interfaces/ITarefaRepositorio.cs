using API_To_Do_List.Domain.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Infra.Interfaces
{
    public interface ITarefaRepositorio : IRepositorio<Tarefa>
    {
        Task<Tarefa> PegarTarefaPorId(int tarefaId);
        Task<IEnumerable<Tarefa>> ListaTarefas();
    }
}
