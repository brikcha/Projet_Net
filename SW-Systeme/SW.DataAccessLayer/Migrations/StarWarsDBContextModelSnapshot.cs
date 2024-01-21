﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SW.DataAccessLayer;

#nullable disable

namespace SW.DataAccessLayer.Migrations
{
    [DbContext(typeof(StarWarsDBContext))]
    partial class StarWarsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.22");

            modelBuilder.Entity("SW.Models.Citoyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bonheur")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EspeceId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MereBiologiqueID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PereBiologiqueID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductionEconomique")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("division")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("eventAleatoire")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sexe")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EspeceId");

                    b.HasIndex("MereBiologiqueID");

                    b.HasIndex("PereBiologiqueID");

                    b.ToTable("Citoyens");
                });

            modelBuilder.Entity("SW.Models.Distinction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BonusMerite")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DecerneAId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DecerneParId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DecerneAId");

                    b.HasIndex("DecerneParId");

                    b.ToTable("Distinctions");
                });

            modelBuilder.Entity("SW.Models.Espece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Longevite")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Majorite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Especes");
                });

            modelBuilder.Entity("SW.Models.Citoyen", b =>
                {
                    b.HasOne("SW.Models.Espece", "Espece")
                        .WithMany()
                        .HasForeignKey("EspeceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SW.Models.Citoyen", "MereBiologique")
                        .WithMany()
                        .HasForeignKey("MereBiologiqueID");

                    b.HasOne("SW.Models.Citoyen", "PereBiologique")
                        .WithMany()
                        .HasForeignKey("PereBiologiqueID");

                    b.Navigation("Espece");

                    b.Navigation("MereBiologique");

                    b.Navigation("PereBiologique");
                });

            modelBuilder.Entity("SW.Models.Distinction", b =>
                {
                    b.HasOne("SW.Models.Citoyen", "DecerneA")
                        .WithMany()
                        .HasForeignKey("DecerneAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SW.Models.Citoyen", "DecernePar")
                        .WithMany()
                        .HasForeignKey("DecerneParId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DecerneA");

                    b.Navigation("DecernePar");
                });
#pragma warning restore 612, 618
        }
    }
}
