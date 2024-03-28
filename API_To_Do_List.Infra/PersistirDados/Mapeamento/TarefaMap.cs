using API_To_Do_List.Domain.Model.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_To_Do_List.Infra.PersistirDados.Mapeamento
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tb_Tarefa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).HasColumnType("Varchar(max)");
            builder.Property(x => x.Descricao).HasColumnType("Varchar(max)");
            builder.Property(x => x.DataCriacao).HasColumnType("Datetime");
            builder.Property(x => x.DataFinalizacao).HasColumnType("Datetime");
            builder.Property(x => x.StatusTarefa);
        }
    }
}
