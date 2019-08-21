﻿// <auto-generated />
using AsistenciaComedor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsistenciaComedor.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190820225456_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsistenciaComedor.Data.Entities.Escuela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("direccionRegional")
                        .HasMaxLength(100);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Escuelas");
                });
#pragma warning restore 612, 618
        }
    }
}
