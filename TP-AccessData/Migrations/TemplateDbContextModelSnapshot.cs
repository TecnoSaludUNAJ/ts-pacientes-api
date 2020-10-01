﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_AccessData;

namespace TP_AccessData.Migrations
{
    [DbContext(typeof(TemplateDbContext))]
    partial class TemplateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP_Domain.Entities.ObraSocial", b =>
                {
                    b.Property<int>("ObraSocial_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ObraSocial_Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObraSocial_Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ObraSocial_Id");

                    b.HasAlternateKey("ObraSocial_Sigla");

                    b.ToTable("ObrasSociales");

                    b.HasData(
                        new
                        {
                            ObraSocial_Id = 1,
                            ObraSocial_Nombre = "O.S. de Empresarios Profesionales y Monotributistas",
                            ObraSocial_Sigla = "OSDEPYM"
                        },
                        new
                        {
                            ObraSocial_Id = 2,
                            ObraSocial_Nombre = "O.S. de los Empleados de Comercio y Actividades Civiles",
                            ObraSocial_Sigla = "OSECAC"
                        });
                });

            modelBuilder.Entity("TP_Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("Paciente_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado_Civil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Nacim")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObraSocial_Id")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("Paciente_Id");

                    b.HasAlternateKey("DNI", "Usuario_Id");

                    b.HasIndex("ObraSocial_Id");

                    b.ToTable("Pacientes");

                    b.HasData(
                        new
                        {
                            Paciente_Id = 1,
                            Apellido = "White",
                            DNI = 12545467,
                            Domicilio = "Albuquerque, Nuevo Mexico",
                            Email = "walterwhite@mail.com",
                            Estado_Civil = "casado",
                            Fecha_Nacim = new DateTime(1959, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidad = "Estados Unidos",
                            Nombre = "Walter",
                            ObraSocial_Id = 1,
                            Sexo = "masculino",
                            Telefono = "555-1258",
                            Usuario_Id = 1
                        },
                        new
                        {
                            Paciente_Id = 2,
                            Apellido = "White",
                            DNI = 891011234,
                            Domicilio = "4565st, Albuquerque, Nuevo Mexico",
                            Email = "skylerwhite@brba.com",
                            Estado_Civil = "casada",
                            Fecha_Nacim = new DateTime(1970, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidad = "Estados Unidos",
                            Nombre = "Skyler",
                            ObraSocial_Id = 2,
                            Sexo = "femenino",
                            Telefono = "9999-8888",
                            Usuario_Id = 2
                        });
                });

            modelBuilder.Entity("TP_Domain.Entities.Paciente", b =>
                {
                    b.HasOne("TP_Domain.Entities.ObraSocial", "ObraSocial")
                        .WithMany("Pacientes")
                        .HasForeignKey("ObraSocial_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
