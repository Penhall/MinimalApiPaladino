﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalApiPaladino.Data;

#nullable disable

namespace MinimalApiPaladino.Migrations
{
    [DbContext(typeof(PaladinoDbContext))]
    [Migration("20230320144210_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("DemoMinimalApi.Models.Master", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Classificação")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Curatelado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dominio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fim")
                        .HasColumnType("TEXT");

                    b.Property<string>("Inicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumUnico")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Oficio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Protecao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Registro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Responsavel")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Masters");
                });
#pragma warning restore 612, 618
        }
    }
}
