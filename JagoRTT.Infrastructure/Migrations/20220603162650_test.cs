using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JagoRTT.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CNPJ", "Email", "Name", "Phone" },
                values: new object[] { new Guid("4c0bbd06-5b45-4f95-b596-5a2150c0acee"), "88.654.744/0001-43", "naughtyat@naughtyact.com", "Naughty Cat", "1 1 1380-0999" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             
        }
    }
}
