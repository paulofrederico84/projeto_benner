﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Benner_WebAPI.Data;

namespace Projeto_Benner_WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200916204910_CriacaoInicialProjetoEstacionamento")]
    partial class CriacaoInicialProjetoEstacionamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto_Benner_WebAPI.Models.Estacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHoraEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraSaida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdVeiculo")
                        .HasColumnType("int");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("real");

                    b.Property<int?>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Estacionamento");
                });

            modelBuilder.Entity("Projeto_Benner_WebAPI.Models.TabelaPreco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("ValorHora")
                        .HasColumnType("real");

                    b.Property<DateTime>("VigenciaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VigenciaInicial")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TabelaPreco");
                });

            modelBuilder.Entity("Projeto_Benner_WebAPI.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("Projeto_Benner_WebAPI.Models.Estacionamento", b =>
                {
                    b.HasOne("Projeto_Benner_WebAPI.Models.Veiculo", "Veiculo")
                        .WithMany("Estacionamento")
                        .HasForeignKey("VeiculoId");
                });
#pragma warning restore 612, 618
        }
    }
}