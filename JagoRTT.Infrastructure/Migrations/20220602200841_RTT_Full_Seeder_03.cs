using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JagoRTT.Infrastructure.Migrations
{
    public partial class RTT_Full_Seeder_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CPF", "CompanyId", "Email", "Name", "Phone", "RentalId", "ToolId" },
                values: new object[] { new Guid("ea1ee3cf-b657-4f32-bd55-41eb79d9f9cf"), "946.864.370-08", new Guid("30479b7b-fd49-4fa4-8a75-7849524e3e3b"), "carlos@gmail.com", "Carlos", "11 0909-212", new Guid("8959274b-907a-46e9-ae5b-8a2a4dafc795"), new Guid("38b82414-bd8f-4317-8440-d5329028989d") });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CPF", "CompanyId", "Email", "Name", "Phone", "RentalId", "ToolId" },
                values: new object[] { new Guid("ff2f8453-2bf9-4fe2-a8e1-c33dd5d23870"), "777.762.370-19", new Guid("30479b7b-fd49-4fa4-8a75-7849524e3e3b"), "anne@gmail.com", "Anne", "11 96909-212", new Guid("c0a91cbd-e47a-4942-9e7c-6395e7647760"), new Guid("38b82414-bd8f-4317-8440-d5329028989d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
