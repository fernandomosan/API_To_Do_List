using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_To_Do_List.Infra.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "Varchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    DataFinalizacao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    StatusTarefa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Tarefa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Tarefa");
        }
    }
}
