﻿// <auto-generated />
using System;
using JagoRTT.Infrastructure.DBConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JagoRTT.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JagoRTT.domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("JagoRTT.domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RentalId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ToolId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RentalId");

                    b.HasIndex("ToolId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea1ee3cf-b657-4f32-bd55-41eb79d9f9cf"),
                            CPF = "946.864.370-08",
                            CompanyId = new Guid("30479b7b-fd49-4fa4-8a75-7849524e3e3b"),
                            Email = "carlos@gmail.com",
                            Name = "Carlos",
                            Phone = "11 0909-212",
                            RentalId = new Guid("8959274b-907a-46e9-ae5b-8a2a4dafc795"),
                            ToolId = new Guid("38b82414-bd8f-4317-8440-d5329028989d")
                        },
                        new
                        {
                            Id = new Guid("ff2f8453-2bf9-4fe2-a8e1-c33dd5d23870"),
                            CPF = "777.762.370-19",
                            CompanyId = new Guid("30479b7b-fd49-4fa4-8a75-7849524e3e3b"),
                            Email = "anne@gmail.com",
                            Name = "Anne",
                            Phone = "11 96909-212",
                            RentalId = new Guid("c0a91cbd-e47a-4942-9e7c-6395e7647760"),
                            ToolId = new Guid("38b82414-bd8f-4317-8440-d5329028989d")
                        });
                });

            modelBuilder.Entity("JagoRTT.domain.Entities.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("ToolId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ToolId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("JagoRTT.domain.Entities.Tool", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("JagoRTT.domain.Entities.Employee", b =>
                {
                    b.HasOne("JagoRTT.domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JagoRTT.domain.Entities.Rental", "Rental")
                        .WithMany()
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JagoRTT.domain.Entities.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Rental");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("JagoRTT.domain.Entities.Rental", b =>
                {
                    b.HasOne("JagoRTT.domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JagoRTT.domain.Entities.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Tool");
                });
#pragma warning restore 612, 618
        }
    }
}
