using Microsoft.EntityFrameworkCore;
using Senai.Inlock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.CodeFirst.Context
{
    public class InLockContext : DbContext
    {

        // Define as entidades no BD
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Estudios> Estudios { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV9\\SQLEXPRESS ; Database= Inlock_Tarde_CodeFirst; user Id=sa; pwd=sa@132;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuario>().HasData(
                new TiposUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TiposUsuario
                {
                    IdTipoUsuario = 2,
                    Titulo = "Commum"
                });

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    IdUsuario = 1,
                    Email = "admin@admin.com",
                    Senha = "adm",
                    IdTipoUsuario = 1
                },
                new Usuarios
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com", 
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Estudios>().HasData(
                new Estudios
                {
                    IdEstudio = 1,
                    NomeEstudio = "Blizzard"
                },
                new Estudios
                {
                    IdEstudio = 2,
                    NomeEstudio = "RockStar"
                },
                new Estudios
                {
                    IdEstudio = 3,
                    NomeEstudio = "Square Enix"
                });

            modelBuilder.Entity<Jogos>().HasData
                (
                new Jogos
                {
                    IdJogo = 1,
                    NomeJogo = "Diablo III",
                    DataLancamento = Convert.ToDateTime("15/05/2012"),
                    Descricao = " Bla bla bla bla bla bla bla bla blu",
                    Valor = Convert.ToDecimal("99,00"),
                    IdEstudio = 1
                },
                new Jogos
                {
                    IdJogo = 2,
                    NomeJogo = "Red Dead Redemption II",
                    DataLancamento = Convert.ToDateTime("26/10/2018"),
                    Descricao = "Blu ble bla bli blu blu blu bla ble blob bluab",
                    Valor = Convert.ToDecimal("120,00"),
                    IdEstudio = 2
                }
                );

            base.OnModelCreating(modelBuilder);
        }



    }
}
