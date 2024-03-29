﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using constructionCompanyAPI.Entities;

#nullable disable

namespace constructionCompanyAPI.Migrations
{
    [DbContext(typeof(ConstructionCompanyDbContext))]
    [Migration("20220823140513_EntityPropertiesChanges")]
    partial class EntityPropertiesChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("constructionCompanyAPI.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voivodeship")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.CompanyOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Full_Name");

                    b.HasKey("Id");

                    b.ToTable("CompanyOwners");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.ConstructionCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("KRS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("REGON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("CompanyOwnerId")
                        .IsUnique();

                    b.HasIndex("CreatedById");

                    b.ToTable("ConstructionCompanies");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConstructionCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Full_Name");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionCompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.ConstructionCompany", b =>
                {
                    b.HasOne("constructionCompanyAPI.Entities.Address", "Address")
                        .WithOne("ConstructionCompany")
                        .HasForeignKey("constructionCompanyAPI.Entities.ConstructionCompany", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("constructionCompanyAPI.Entities.CompanyOwner", "CompanyOwner")
                        .WithOne("ConstructionCompany")
                        .HasForeignKey("constructionCompanyAPI.Entities.ConstructionCompany", "CompanyOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("constructionCompanyAPI.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("Address");

                    b.Navigation("CompanyOwner");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.Employee", b =>
                {
                    b.HasOne("constructionCompanyAPI.Entities.ConstructionCompany", "ConstructionCompany")
                        .WithMany("Employees")
                        .HasForeignKey("ConstructionCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConstructionCompany");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.User", b =>
                {
                    b.HasOne("constructionCompanyAPI.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.Address", b =>
                {
                    b.Navigation("ConstructionCompany");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.CompanyOwner", b =>
                {
                    b.Navigation("ConstructionCompany");
                });

            modelBuilder.Entity("constructionCompanyAPI.Entities.ConstructionCompany", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
