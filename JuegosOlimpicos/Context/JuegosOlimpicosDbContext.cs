using Microsoft.EntityFrameworkCore;
using JuegosOlimpicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PortafolioProyectos.Context
{
    public class JuegosOlimpicosDbContext : DbContext
    {
        public JuegosOlimpicosDbContext()
        {
        }

        public JuegosOlimpicosDbContext(DbContextOptions<JuegosOlimpicosDbContext> options)
        : base(options)
        {

        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Deportista> Deportistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

       

            modelBuilder.Entity<Registros>()
                .HasIndex(r => new { r.DeportistaId, r.TipoPruebaId})
                ;
            modelBuilder.Entity<Resultados>()
            .HasNoKey()
            ;

            var paises = new List<Pais> {
            new Pais { Id=1,Descripcion="AUS"},
            new Pais { Id=2,Descripcion="CHN"},
            new Pais { Id=3,Descripcion="FRA"},
            new Pais { Id=4,Descripcion="ALE"},

            };

            var deportistas = new List<Deportista> {
                new Deportista{ Id=1,Nombre="Carlos Alviz",PaisId=1} ,
                new Deportista{ Id=2,Nombre="Andres Sabogal",PaisId=2} ,
                new Deportista{ Id=3,Nombre="Jorge Ortega",PaisId=3} ,
                new Deportista{ Id=4,Nombre="Pablo Velasco",PaisId=4}
            };

            //var proyectos = new List<Proyecto> {
            //    new Proyecto{Id=1,Descripcion="Leon Software",ClienteId=1,EstadoId=1,FechaInicio=DateTime.Now,FechaFin=DateTime.Now.AddDays(20),Horas=40,Precio=200000},
            //    new Proyecto{Id=2,Descripcion="Riesgos",ClienteId=2,EstadoId=2,FechaInicio=DateTime.Now,FechaFin=DateTime.Now.AddDays(10),Horas=35,Precio=205000}
            //};

            var tipoPruebas = new List<TipoPrueba> {
                new TipoPrueba{Id=1,Descripcion="ARRANQUE"},
                new TipoPrueba{Id=2,Descripcion="ENVION"}
            };

            //var lenguajesXProyectos = new List<LenguajesPorProyecto> {
            //    new LenguajesPorProyecto{ LenguajeId=1,ProyectoId=1,Nivel='A'},
            //    new LenguajesPorProyecto{ LenguajeId=2,ProyectoId=1,Nivel='A'}
            //};

            modelBuilder.Entity<Pais>().HasData(paises.ToArray());
            modelBuilder.Entity<Deportista>().HasData(deportistas.ToArray());  
            modelBuilder.Entity<TipoPrueba>().HasData(tipoPruebas.ToArray());  

        }

        public DbSet<JuegosOlimpicos.Models.Registros> Registros { get; set; }

        public DbSet<JuegosOlimpicos.Models.Resultados> Resultados { get; set; }

    }
}
