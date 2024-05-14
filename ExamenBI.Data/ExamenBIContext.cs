using ExamenBI.Data.Configurations;
using ExamenBI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ProdStore.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenBI.Data
{
    public class ExamenBIContext:DbContext
    {
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Entraineur> Entraineurs { get; set; }
        public DbSet<Trophee> Trophees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                         Initial Catalog=FederationBD;
                         Integrated Security=true;MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
         
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContratConfiguration());
            modelBuilder.ApplyConfiguration(new TropheeConfigurations());

            // héritage : TPH

            modelBuilder.Entity<Membre>()
                .HasDiscriminator<string>("Type")
                .HasValue<Entraineur>("E")
                .HasValue<Joueur>("J")
                .HasValue<Membre>("M");
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
