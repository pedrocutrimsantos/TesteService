using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteService.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T01_USUARIOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CPF_CNPJ = table.Column<int>(nullable: false),
                    TypePerson = table.Column<bool>(nullable: false),
                    TypeUser = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T01_USUARIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T02_CONTA",
                columns: table => new
                {
                    T02_ID = table.Column<Guid>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false),
                    T02_USERID = table.Column<Guid>(nullable: false),
                    T02_SALDO = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T02_CONTA", x => x.T02_ID);
                    table.ForeignKey(
                        name: "FK_T02_CONTA_T01_USUARIOS_T02_USERID",
                        column: x => x.T02_USERID,
                        principalTable: "T01_USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    SendID = table.Column<Guid>(nullable: false),
                    ReceiptID = table.Column<Guid>(nullable: false),
                    OperationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transfers_T01_USUARIOS_ReceiptID",
                        column: x => x.ReceiptID,
                        principalTable: "T01_USUARIOS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Transfers_T01_USUARIOS_SendID",
                        column: x => x.SendID,
                        principalTable: "T01_USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T01_USUARIOS_CPF_CNPJ",
                table: "T01_USUARIOS",
                column: "CPF_CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_T01_USUARIOS_Email",
                table: "T01_USUARIOS",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_T02_CONTA_T02_USERID",
                table: "T02_CONTA",
                column: "T02_USERID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_ReceiptID",
                table: "Transfers",
                column: "ReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_SendID",
                table: "Transfers",
                column: "SendID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T02_CONTA");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "T01_USUARIOS");
        }
    }
}
