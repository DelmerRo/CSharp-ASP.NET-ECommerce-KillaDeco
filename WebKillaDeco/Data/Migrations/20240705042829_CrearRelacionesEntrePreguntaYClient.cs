using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebKillaDeco.Data.Migrations
{
    /// <inheritdoc />
    public partial class CrearRelacionesEntrePreguntaYClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "publicationDate",
                table: "Questions",
                newName: "PublicationDate");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Questions",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicationDate",
                table: "Questions",
                newName: "publicationDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Questions",
                newName: "description");
        }
    }
}
