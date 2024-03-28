using API_To_Do_List.Domain.Model.Entidades;
using API_To_Do_List.Infra.Interfaces;
using API_To_Do_List.Service.Servico.Interfaca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Service.Servico.Repositorio
{
    public class TarefaServico : ITarefaServico
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaServico(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public async Task AdicionarAsync(Tarefa entity)
        {
            if(entity.DataCriacao == null) throw new Exception("Para criar uma tarefa é necessario informar a data de criação.");
            if(entity.StatusTarefa == Domain.Enums.StatusTarefa.Iniciada ||
                entity.StatusTarefa == Domain.Enums.StatusTarefa.Concluida) throw new Exception("Tarefas só podem ser criadas com o status de aguardando inicio.");

            await _tarefaRepositorio.Adicionar(entity);
        }

        public async Task AtualizarAsync(Tarefa entity)
        {
            var tarefaEntidade = await _tarefaRepositorio.GetById(x => x.Id == entity.Id);
            if (tarefaEntidade == null) throw new Exception("Não foi enconrado uma tarefa");
            if(entity.StatusTarefa == Domain.Enums.StatusTarefa.AguardandoInicio) throw new Exception("Tarefas já criadas devem alterar seu status para iniciada ou concluida.");

            tarefaEntidade.Titulo = entity.Titulo ?? tarefaEntidade.Titulo;
            tarefaEntidade.Descricao = entity.Descricao ?? tarefaEntidade.Descricao;
            tarefaEntidade.DataCriacao = entity.DataCriacao ?? tarefaEntidade.DataCriacao;
            tarefaEntidade.DataFinalizacao = entity.DataFinalizacao ?? tarefaEntidade.DataFinalizacao;

            if(tarefaEntidade.DataFinalizacao <= tarefaEntidade.DataCriacao) throw new Exception("Data de finalização deve ser maior que a data de criação");

            await _tarefaRepositorio.Atualizar(tarefaEntidade);
        }

        public async Task DelearAsync(int tarefaId)
        {
            if (tarefaId <= 0) throw new Exception("Informe um Id valido");

            var tarefaEntidade = await _tarefaRepositorio.GetById(x => x.Id == tarefaId);

            if (tarefaEntidade == null) throw new Exception("Erro ao encontrar tarefa");

            await _tarefaRepositorio.Deletar(tarefaEntidade);
        }

        public async Task<IEnumerable<Tarefa>> listaTarefaAsync()
        {
            return await _tarefaRepositorio.ListaTarefas();
        }

        public async Task<Tarefa> PegarTarefaPorIdAsync(int tarefaId)
        {
            return await _tarefaRepositorio.PegarTarefaPorId(tarefaId);
        }
    }
}
