using API_To_Do_List.Domain.Model.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Infra.PersistirDados.Contexto
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> context) : base(context)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
