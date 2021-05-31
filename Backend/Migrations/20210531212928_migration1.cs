using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalwareTest.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    edad = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INVENTARIO_PRODUCTO",
                        column: x => x.productoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MOVIMIENTO_CLIENTE",
                        column: x => x.clienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MOVIMIENTO_PRODUCTO",
                        column: x => x.productoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "Id", "apellido", "edad", "nombre" },
                values: new object[,]
                {
                    { 1, "Romero", 28, "Juan carlos" },
                    { 2, "freitte", 30, "Faby alberto" },
                    { 3, "Machado Arrieta", 36, "Cinthia Cristina" },
                    { 4, "Machado", 71, "Cesar" },
                    { 5, "Machado", 46, "Maryory" }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "Id", "descripcion", "precio" },
                values: new object[,]
                {
                    { 1, "Televisor 14 pulgadas", 15000m },
                    { 2, "Televisor 18 pulgadas", 19800m },
                    { 3, "Radio", 5000m }
                });

            migrationBuilder.InsertData(
                table: "inventarios",
                columns: new[] { "Id", "cantidad", "fecha", "precio", "productoId", "tipo" },
                values: new object[] { 1, 2, new DateTime(2021, 5, 31, 16, 29, 28, 203, DateTimeKind.Local).AddTicks(5432), 30000m, 1, 0 });

            migrationBuilder.InsertData(
                table: "movimientos",
                columns: new[] { "Id", "cantidad", "clienteId", "fecha", "precio", "productoId" },
                values: new object[] { 1, 2, 5, new DateTime(2021, 5, 31, 16, 29, 28, 202, DateTimeKind.Local).AddTicks(4332), 30000m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_inventarios_productoId",
                table: "inventarios",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_clienteId",
                table: "movimientos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_productoId",
                table: "movimientos",
                column: "productoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventarios");

            migrationBuilder.DropTable(
                name: "movimientos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}
