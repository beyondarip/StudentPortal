using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mahasiswas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NIM = table.Column<string>(type: "TEXT", nullable: false),
                    Nama = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Jurusan = table.Column<string>(type: "TEXT", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahasiswas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mahasiswas");
        }
    }
}
