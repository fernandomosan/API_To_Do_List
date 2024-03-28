using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Infra.Interfaces
{
    public interface IRepositorio<T>
    {
        IQueryable<T> Get();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Deletar(T entity);
    }
}
