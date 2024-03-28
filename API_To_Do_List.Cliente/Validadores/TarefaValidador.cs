using API_To_Do_List.Domain.Model.Entidades;
using FluentValidation;

namespace API_To_Do_List.Cliente.Validadores
{
    public class TarefaValidador : AbstractValidator<Tarefa>
    {
        public TarefaValidador()
        {
            RuleFor(x => x.Titulo).NotNull().NotEmpty().WithMessage("Para criar uma tarefa o título é obrigatório.");
            RuleFor(x => x.DataFinalizacao).GreaterThan(x => x.DataCriacao).WithMessage("A data de finalização deve ser maior que a data de criação.");
        }
        
    }
}
