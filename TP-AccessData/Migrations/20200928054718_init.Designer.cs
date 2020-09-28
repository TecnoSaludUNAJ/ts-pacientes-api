﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_AccessData;

namespace TP_AccessData.Migrations
{
    [DbContext(typeof(TemplateDbContext))]
    [Migration("20200928054718_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObraSocial_Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObraSocial_Id");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Domicilio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado_Civil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Nacim")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObraSocial_Id")
                        .HasColumnType("int");

                    b.Property<int?>("ObraSocial_Id1")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("Paciente_Id");

                    b.HasIndex("ObraSocial_Id1");

                    b.ToTable("Pacientes");

                    b.HasData(
                        new
                        {
                            Paciente_Id = 1,
                            Apellido = "Doe",
                            DNI = 40000000,
                            Domicilio = "Calle Falsa 123, Springfield",
                            Email = "johndoe@mail.com",
                            Estado_Civil = "Soltero",
                            Fecha_Nacim = new DateTime(1997, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidad = "argentina",
                            Nombre = "John",
                            ObraSocial_Id = 1,
                            Sexo = "masculino",
                            Telefono = "1234-4566",
                            Usuario_Id = 1
                        },
                        new
                        {
                            Paciente_Id = 2,
                            Apellido = "Doe",
                            DNI = 40000000,
                            Domicilio = "Cochabamba 1614, segundo piso, corredor cuatro",
                            Email = "janedoe@mail.com",
                            Estado_Civil = "soltero",
                            Fecha_Nacim = new DateTime(1998, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidad = "argentina",
                            Nombre = "Jane",
                            ObraSocial_Id = 1,
                            Sexo = "femenino",
                            Telefono = "7777-4566",
                            Usuario_Id = 2
                        });
                });

            modelBuilder.Entity("TP_Domain.Entities.Paciente", b =>
                {
                    b.HasOne("TP_Domain.Entities.ObraSocial", "ObraSocial")
                        .WithMany()
                        .HasForeignKey("ObraSocial_Id1");
                });
#pragma warning restore 612, 618
        }
    }
}