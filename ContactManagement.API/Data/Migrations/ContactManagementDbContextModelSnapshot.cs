﻿// <auto-generated />
using System;
using ContactManagement.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactManagement.API.Data.Migrations
{
    [DbContext(typeof(ContactManagementDbContext))]
    partial class ContactManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactManagement.API.Data.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Contact", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a77bdc67-e4d3-4928-a5bd-f51a95a6b878"),
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            Id = new Guid("71eb7f9b-9d1c-4238-8f88-853d10673e4c"),
                            BirthDate = new DateTime(1990, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "janesmith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            PhoneNumber = "5559874567"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
