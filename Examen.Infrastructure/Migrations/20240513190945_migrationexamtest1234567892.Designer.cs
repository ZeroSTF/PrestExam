﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamContext))]
    [Migration("20240513190945_migrationexamtest1234567892")]
    partial class migrationexamtest1234567892
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Contrat", b =>
                {
                    b.Property<int>("equipeFk")
                        .HasColumnType("int");

                    b.Property<int>("membreFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateContrat")
                        .HasColumnType("datetime2");

                    b.Property<int>("dureeMois")
                        .HasColumnType("int");

                    b.Property<double>("salaire")
                        .HasColumnType("float");

                    b.HasKey("equipeFk", "membreFk", "dateContrat");

                    b.HasIndex("membreFk");

                    b.ToTable("contrats");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Equipe", b =>
                {
                    b.Property<int>("equipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("equipeId"));

                    b.Property<string>("adresseLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomEquipe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("equipeId");

                    b.ToTable("equipes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Membre", b =>
                {
                    b.Property<int>("identifiant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("identifiant"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("identifiant");

                    b.ToTable("membres");

                    b.HasDiscriminator<string>("Type").HasValue("M");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Trophee", b =>
                {
                    b.Property<int>("tropheeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tropheeId"));

                    b.Property<DateTime>("dateTrophee")
                        .HasColumnType("datetime2");

                    b.Property<int>("equipeFk")
                        .HasColumnType("int");

                    b.Property<double>("recompense")
                        .HasColumnType("float");

                    b.Property<string>("typeTrophee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tropheeId");

                    b.HasIndex("equipeFk");

                    b.ToTable("trophees");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Entraineur", b =>
                {
                    b.HasBaseType("Examen.ApplicationCore.Domain.Membre");

                    b.Property<int>("grade")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("E");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Joueur", b =>
                {
                    b.HasBaseType("Examen.ApplicationCore.Domain.Membre");

                    b.Property<string>("poste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("J");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Contrat", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Equipe", "equipe")
                        .WithMany("Contrats")
                        .HasForeignKey("equipeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Membre", "membre")
                        .WithMany("Contrats")
                        .HasForeignKey("membreFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipe");

                    b.Navigation("membre");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Trophee", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Equipe", "Equipe")
                        .WithMany("trophees")
                        .HasForeignKey("equipeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Equipe", b =>
                {
                    b.Navigation("Contrats");

                    b.Navigation("trophees");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Membre", b =>
                {
                    b.Navigation("Contrats");
                });
#pragma warning restore 612, 618
        }
    }
}
