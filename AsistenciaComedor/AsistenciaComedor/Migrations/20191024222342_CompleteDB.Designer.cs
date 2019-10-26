﻿// <auto-generated />
using System;
using AsistenciaComedor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsistenciaComedor.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191024222342_CompleteDB")]
    partial class CompleteDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsistenciaComedor.Data.Entities.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstudianteId");

                    b.Property<DateTime>("fecha");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId");

                    b.ToTable("Asistencias");
                });

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
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Escuelas");
                });

            modelBuilder.Entity("AsistenciaComedor.Data.Entities.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NivelId");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("cedula")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("edad")
                        .HasMaxLength(3);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("sexo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("NivelId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("AsistenciaComedor.Data.Entities.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombreNivel")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Niveles");
                });

            modelBuilder.Entity("AsistenciaComedor.Data.Entities.Asistencia", b =>
                {
                    b.HasOne("AsistenciaComedor.Data.Entities.Estudiante", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteId");
                });

            modelBuilder.Entity("AsistenciaComedor.Data.Entities.Estudiante", b =>
                {
                    b.HasOne("AsistenciaComedor.Data.Entities.Nivel", "Nivel")
                        .WithMany("Estudiantes")
                        .HasForeignKey("NivelId");
                });
#pragma warning restore 612, 618
        }
    }
}