﻿// <auto-generated />
using System;
using ExamenBI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamenBI.Data.Migrations
{
    [DbContext(typeof(ExamenBIContext))]
    [Migration("20211225115546_creation")]
    partial class creation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamenBI.Domain.Entities.Contrat", b =>
                {
                    b.Property<int>("EquipeFK")
                        .HasColumnType("int");

                    b.Property<int>("MembreFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateContrat")
                        .HasColumnType("datetime2");

                    b.Property<int>("DureeMois")
                        .HasColumnType("int");

                    b.Property<double>("Salaire")
                        .HasColumnType("float");

                    b.HasKey("EquipeFK", "MembreFk", "DateContrat");

                    b.HasIndex("MembreFk");

                    b.ToTable("Contrats");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Equipe", b =>
                {
                    b.Property<int>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresseLocal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEquipe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipeId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Membre", b =>
                {
                    b.Property<int>("Identifiant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifiant");

                    b.ToTable("Membres");

                    b.HasDiscriminator<string>("Type").HasValue("M");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Trophee", b =>
                {
                    b.Property<int>("TropheeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTrophee")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EquipeFK")
                        .HasColumnType("int");

                    b.Property<double>("Recompense")
                        .HasColumnType("float");

                    b.Property<string>("TypeTrophee")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TropheeId");

                    b.HasIndex("EquipeFK");

                    b.ToTable("Trophees");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Entraineur", b =>
                {
                    b.HasBaseType("ExamenBI.Domain.Entities.Membre");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("E");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Joueur", b =>
                {
                    b.HasBaseType("ExamenBI.Domain.Entities.Membre");

                    b.Property<string>("Poste")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("J");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Contrat", b =>
                {
                    b.HasOne("ExamenBI.Domain.Entities.Equipe", "Equipe")
                        .WithMany("Contrats")
                        .HasForeignKey("EquipeFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamenBI.Domain.Entities.Membre", "Membre")
                        .WithMany("Contrats")
                        .HasForeignKey("MembreFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Membre");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Trophee", b =>
                {
                    b.HasOne("ExamenBI.Domain.Entities.Equipe", "Equipe")
                        .WithMany("Trophees")
                        .HasForeignKey("EquipeFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Equipe", b =>
                {
                    b.Navigation("Contrats");

                    b.Navigation("Trophees");
                });

            modelBuilder.Entity("ExamenBI.Domain.Entities.Membre", b =>
                {
                    b.Navigation("Contrats");
                });
#pragma warning restore 612, 618
        }
    }
}