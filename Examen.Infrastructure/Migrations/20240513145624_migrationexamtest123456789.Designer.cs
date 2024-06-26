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
    [Migration("20240513145624_migrationexamtest123456789")]
    partial class migrationexamtest123456789
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

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Avocat", b =>
                {
                    b.Property<int>("avocatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("avocatId"));

                    b.Property<DateTime>("dateEmbauche")
                        .HasColumnType("datetime2");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("specialiteFk")
                        .HasColumnType("int");

                    b.HasKey("avocatId");

                    b.HasIndex("specialiteFk");

                    b.ToTable("avocats");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Client", b =>
                {
                    b.Property<int>("cin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cin"));

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cin");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Dossier", b =>
                {
                    b.Property<int>("clientFk")
                        .HasColumnType("int");

                    b.Property<int>("avocatFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateDepot")
                        .HasColumnType("datetime2");

                    b.Property<bool>("clos")
                        .HasColumnType("bit");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("frais")
                        .HasColumnType("real");

                    b.HasKey("clientFk", "avocatFk", "dateDepot");

                    b.HasIndex("avocatFk");

                    b.ToTable("dossiers");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Specialite", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.HasKey("id");

                    b.ToTable("Specialite");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Avocat", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Specialite", "Specialite")
                        .WithMany("Avocats")
                        .HasForeignKey("specialiteFk")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Specialite");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Dossier", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Avocat", "Avocat")
                        .WithMany("Dossiers")
                        .HasForeignKey("avocatFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Client", "Client")
                        .WithMany("Dossiers")
                        .HasForeignKey("clientFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avocat");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Avocat", b =>
                {
                    b.Navigation("Dossiers");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Client", b =>
                {
                    b.Navigation("Dossiers");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Specialite", b =>
                {
                    b.Navigation("Avocats");
                });
#pragma warning restore 612, 618
        }
    }
}
