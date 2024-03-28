using API_To_Do_List.Domain.Model.Entidades;
using API_To_Do_List.Infra.Interfaces;
using API_To_Do_List.Infra.PersistirDados.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Infra.Repositorio
{
    public class TarefaRepositorio : Repositorio<Tarefa>, ITarefaRepositorio
    {
        public TarefaRepositorio(ApiContext contexto) : base(contexto)
        {
        }

        public async Task<IEnumerable<Tarefa>> ListaTarefas()
        {
            return await Get().ToListAsync(); 
        }

        public async Task<Tarefa> PegarTarefaPorId(int tarefaId)
        {
            return await GetById(x => x.Id == tarefaId);
        }
    }
}
