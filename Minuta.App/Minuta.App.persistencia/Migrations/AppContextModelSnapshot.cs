﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minuta.App.persistencia;

namespace Minuta.App.persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Minuta.App.dominio.Correspondencia", b =>
                {
                    b.Property<int>("correspondenciaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ResidenteID")
                        .HasColumnType("int");

                    b.Property<string>("estadoEntrega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remitente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipoCorrespondencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("correspondenciaID");

                    b.HasIndex("ResidenteID");

                    b.ToTable("Correspondencias");
                });

            modelBuilder.Entity("Minuta.App.dominio.MinutaAnotacion", b =>
                {
                    b.Property<int>("minutaAnotacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("asunto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaAnotacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("vigilanteID")
                        .HasColumnType("int");

                    b.HasKey("minutaAnotacionID");

                    b.HasIndex("vigilanteID");

                    b.ToTable("MinutaAnotaciones");
                });

            modelBuilder.Entity("Minuta.App.dominio.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Minuta.App.dominio.Vehiculo", b =>
                {
                    b.Property<int>("vehiculoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("placaVehiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipoVehiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("vehiculoID");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Minuta.App.dominio.UserAdmin", b =>
                {
                    b.HasBaseType("Minuta.App.dominio.Persona");

                    b.Property<string>("contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("UserAdmin");
                });

            modelBuilder.Entity("Minuta.App.dominio.Visitor", b =>
                {
                    b.HasBaseType("Minuta.App.dominio.Persona");

                    b.Property<string>("motivoVisita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("vehiculoID")
                        .HasColumnType("int")
                        .HasColumnName("Visitor_vehiculoID");

                    b.HasIndex("vehiculoID");

                    b.HasDiscriminator().HasValue("Visitor");
                });

            modelBuilder.Entity("Minuta.App.dominio.Residente", b =>
                {
                    b.HasBaseType("Minuta.App.dominio.UserAdmin");

                    b.Property<string>("estadoApartamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estadoResidente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numApartamento")
                        .HasColumnType("int");

                    b.Property<int?>("vehiculoID")
                        .HasColumnType("int");

                    b.HasIndex("vehiculoID");

                    b.HasDiscriminator().HasValue("Residente");
                });

            modelBuilder.Entity("Minuta.App.dominio.Vigilante", b =>
                {
                    b.HasBaseType("Minuta.App.dominio.UserAdmin");

                    b.Property<string>("placaVigilante")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Vigilante");
                });

            modelBuilder.Entity("Minuta.App.dominio.Correspondencia", b =>
                {
                    b.HasOne("Minuta.App.dominio.Residente", "Residente")
                        .WithMany()
                        .HasForeignKey("ResidenteID");

                    b.Navigation("Residente");
                });

            modelBuilder.Entity("Minuta.App.dominio.MinutaAnotacion", b =>
                {
                    b.HasOne("Minuta.App.dominio.Vigilante", "vigilante")
                        .WithMany()
                        .HasForeignKey("vigilanteID");

                    b.Navigation("vigilante");
                });

            modelBuilder.Entity("Minuta.App.dominio.Visitor", b =>
                {
                    b.HasOne("Minuta.App.dominio.Vehiculo", "vehiculo")
                        .WithMany()
                        .HasForeignKey("vehiculoID");

                    b.Navigation("vehiculo");
                });

            modelBuilder.Entity("Minuta.App.dominio.Residente", b =>
                {
                    b.HasOne("Minuta.App.dominio.Vehiculo", "vehiculo")
                        .WithMany()
                        .HasForeignKey("vehiculoID");

                    b.Navigation("vehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}