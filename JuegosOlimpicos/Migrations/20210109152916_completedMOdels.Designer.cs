﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortafolioProyectos.Context;

namespace JuegosOlimpicos.Migrations
{
    [DbContext(typeof(JuegosOlimpicosDbContext))]
    [Migration("20210109152916_completedMOdels")]
    partial class completedMOdels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JuegosOlimpicos.Models.Deportista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Deportistas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Carlos Alviz",
                            PaisId = 1
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Andres Sabogal",
                            PaisId = 2
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Jorge Ortega",
                            PaisId = 3
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Pablo Velasco",
                            PaisId = 4
                        });
                });

            modelBuilder.Entity("JuegosOlimpicos.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Paises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "AUS"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "CHN"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "FRA"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "ALE"
                        });
                });

            modelBuilder.Entity("JuegosOlimpicos.Models.Registros", b =>
                {
                    b.Property<int>("DeportistaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoPruebaId")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("DeportistaId", "TipoPruebaId");

                    b.HasIndex("TipoPruebaId");

                    b.HasIndex("DeportistaId", "TipoPruebaId")
                        .IsUnique();

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("JuegosOlimpicos.Models.TipoPrueba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoPrueba");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "ARRANQUE"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "ENVION"
                        });
                });

            modelBuilder.Entity("JuegosOlimpicos.Models.Deportista", b =>
                {
                    b.HasOne("JuegosOlimpicos.Models.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JuegosOlimpicos.Models.Registros", b =>
                {
                    b.HasOne("JuegosOlimpicos.Models.Deportista", "Deportista")
                        .WithMany("Registros")
                        .HasForeignKey("DeportistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuegosOlimpicos.Models.TipoPrueba", "TipoPrueba")
                        .WithMany()
                        .HasForeignKey("TipoPruebaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}