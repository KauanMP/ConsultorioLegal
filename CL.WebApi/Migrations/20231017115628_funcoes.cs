using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CL.WebApi.Migrations
{
    public partial class funcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FuncaoUsuario",
                columns: table => new
                {
                    FuncoesId = table.Column<int>(type: "int", nullable: false),
                    UsuariosLogin = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncaoUsuario", x => new { x.FuncoesId, x.UsuariosLogin });
                    table.ForeignKey(
                        name: "FK_FuncaoUsuario_Funcoes_FuncoesId",
                        column: x => x.FuncoesId,
                        principalTable: "Funcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncaoUsuario_Usuarios_UsuariosLogin",
                        column: x => x.UsuariosLogin,
                        principalTable: "Usuarios",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FuncaoUsuario_UsuariosLogin",
                table: "FuncaoUsuario",
                column: "UsuariosLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncaoUsuario");

            migrationBuilder.DropTable(
                name: "Funcoes");
        }
    }
}
