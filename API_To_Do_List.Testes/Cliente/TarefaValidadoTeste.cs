using API_To_Do_List.Cliente.Validadores;
using API_To_Do_List.Domain.Model.Entidades;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Testes.Cliente
{
    public class TarefaValidadoTeste
    {
        [Test]
        public void CriarTarefasComTituloVazioDeveRetronarErro()
        {
            var tarefaEntidade = new Tarefa
            {
                Descricao = "Todos os materiais devem ser colocados em seus devidos lugares",
                DataCriacao = DateTime.Now,
                DataFinalizacao = DateTime.Now.AddDays(4),
                StatusTarefa = Domain.Enums.StatusTarefa.AguardandoInicio
            };

            var tarefaValidador = new TarefaValidador();
            var resultado = tarefaValidador.TestValidate(tarefaEntidade);
            resultado.ShouldHaveValidationErrorFor(x => x.Titulo);
        }

        [Test]
        public void CriarTarefaComDataFinalizacaoMenorQueDataCriacaoDeveRetornarErro()
        {
            var tarefaEntidade = new Tarefa
            {
                Titulo = "Organizar os materiais de construcao",
                Descricao = "Todos os materiais devem ser colocados em seus devidos lugares",
                DataCriacao = DateTime.Now,
                DataFinalizacao = DateTime.Now.AddDays(-4),
                StatusTarefa = Domain.Enums.StatusTarefa.AguardandoInicio
            };

            var tarefaValidador = new TarefaValidador();
            var resultado = tarefaValidador.TestValidate(tarefaEntidade);
            resultado.ShouldHaveValidationErrorFor(x => x.DataFinalizacao);
        }

        [Test]
        public void CriarTarfeValidaDeveRetornarSucesso()
        {
            var tarefaEntidade = new Tarefa
            {
                Titulo = "Organizar os materiais de construcao",
                Descricao = "Todos os materiais devem ser colocados em seus devidos lugares",
                DataCriacao = DateTime.Now,
                DataFinalizacao = DateTime.Now.AddDays(4),
                StatusTarefa = Domain.Enums.StatusTarefa.AguardandoInicio
            };

            var tarefaValidador = new TarefaValidador();
            var resultado = tarefaValidador.TestValidate(tarefaEntidade);
            resultado.ShouldNotHaveAnyValidationErrors();
        }
    }
}
