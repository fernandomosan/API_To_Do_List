﻿// <auto-generated />
using System;
using API_To_Do_List.Infra.PersistirDados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_To_Do_List.Infra.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_To_Do_List.Domain.Model.Entidades.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("Datetime");

                    b.Property<DateTime?>("DataFinalizacao")
                        .HasColumnType("Datetime");

                    b.Property<string>("Descricao")
                        .HasColumnType("Varchar(max)");

                    b.Property<int>("StatusTarefa")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("Varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tb_Tarefa", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}