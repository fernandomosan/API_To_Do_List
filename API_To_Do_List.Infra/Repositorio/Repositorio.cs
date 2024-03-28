using API_To_Do_List.Infra.Interfaces;
using API_To_Do_List.Infra.PersistirDados.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Infra.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected ApiContext _context;

        public Repositorio(ApiContext contexto)
        {
            _context = contexto;
        }

        public Task Adicionar(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public Task Atualizar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }

        public Task Deletar(T entity)
        {
             _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }
    }
}
