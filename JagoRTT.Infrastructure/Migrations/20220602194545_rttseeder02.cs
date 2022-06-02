using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JagoRTT.Infrastructure.Migrations
{
    public partial class rttseeder02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BeginDate", "CompanyId", "EndDate", "Price", "ToolId", "Type" },
                values: new object[] { new Guid("8959274b-907a-46e9-ae5b-8a2a4dafc795"), new DateTime(2022, 6, 2, 16, 45, 44, 704, DateTimeKind.Local).AddTicks(3849), new Guid("f72af8f4-3b32-45c4-a9e1-fc8cbcdafc0d"), new DateTime(2022, 6, 2, 16, 45, 44, 704, DateTimeKind.Local).AddTicks(3850), 150m, new Guid("60242ace-c5fe-4f48-9c90-a16b137d5ca5"), 4 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BeginDate", "CompanyId", "EndDate", "Price", "ToolId", "Type" },
                values: new object[] { new Guid("c0a91cbd-e47a-4942-9e7c-6395e7647760"), new DateTime(2022, 6, 2, 16, 45, 44, 704, DateTimeKind.Local).AddTicks(3780), new Guid("30479b7b-fd49-4fa4-8a75-7849524e3e3b"), new DateTime(2022, 6, 2, 16, 45, 44, 704, DateTimeKind.Local).AddTicks(3794), 100m, new Guid("38b82414-bd8f-4317-8440-d5329028989d"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           


            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CNPJ", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("30479b7b-fd49-4fa4-8a75-7849524e3e3b"), "32.654.744/0001-16", "ncp@gmail.com", "NCP", "11 0000-0999" },
                    { new Guid("f72af8f4-3b32-45c4-a9e1-fc8cbcdafc0d"), "60.446.716/0001-49", "newschool@gmail.com", "New School", "11 7600-0779" }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Brand", "Model", "Name", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("38b82414-bd8f-4317-8440-d5329028989d"), 2, "i5", "laptop", 3 },
                    { new Guid("54698a84-a1fe-421e-ad73-65bda9540b3b"), 3, "i5", "laptop", 3 },
                    { new Guid("5e7275b0-97be-459b-bc6d-e55082665de5"), 1, "i5", "laptop", 3 },
                    { new Guid("60242ace-c5fe-4f48-9c90-a16b137d5ca5"), 4, "i5", "laptop", 2 }
                });
        }
    }
}
