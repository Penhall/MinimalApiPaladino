using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApiPaladino.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Dominio = table.Column<string>(type: "TEXT", nullable: false),
                    NumUnico = table.Column<string>(type: "TEXT", nullable: false),
                    Classificação = table.Column<string>(type: "TEXT", nullable: false),
                    Responsavel = table.Column<string>(type: "TEXT", nullable: true),
                    Oficio = table.Column<string>(type: "TEXT", nullable: false),
                    Registro = table.Column<string>(type: "TEXT", nullable: true),
                    Inicio = table.Column<string>(type: "TEXT", nullable: true),
                    Fim = table.Column<string>(type: "TEXT", nullable: true),
                    Protecao = table.Column<string>(type: "TEXT", nullable: true),
                    Curatelado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masters");
        }
    }
}
