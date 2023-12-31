﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WINKEL_ECOMMERCE.DAL;

#nullable disable

namespace WINKEL_ECOMMERCE.Migrations
{
    [DbContext(typeof(WINKEL_ApplicationDbContext))]
    [Migration("20230314125713_AddedShipAndShipItem")]
    partial class AddedShipAndShipItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AltImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Header")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Link")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.ShipItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Icon")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ShipId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.ToTable("ShipItems");
                });

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AltImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Header")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LeftVerticalText")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SupHeader")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AltImage = "This is girl photo",
                            Description = "A small river named Duden flows by tehir place and supplies it with the necessary regelialia. It is a paradisematic country.",
                            Header = "A Thouroughly <b>Modern</b> Woman",
                            Image = "bg_2.webp",
                            LeftVerticalText = "BEST ECOMMECE ONLINE SHOP",
                            SupHeader = "WINKEL ECOMMERCE SHOP"
                        },
                        new
                        {
                            Id = 2,
                            AltImage = "This is boy photo",
                            Description = "A small river named Duden flows by tehir place and supplies it with the necessary regelialia. It is a paradisematic country.",
                            Header = "Catch Your Own\r\n    <pre><b>Stylish & Look</b></pre>",
                            Image = "bg_1.webp",
                            LeftVerticalText = "WINKEL ECOMMERCE SHOP",
                            SupHeader = "ESTABLISHED SICNE 2000"
                        });
                });

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.ShipItem", b =>
                {
                    b.HasOne("WINKEL_ECOMMERCE.Models.Ship", "Ship")
                        .WithMany("ShipItems")
                        .HasForeignKey("ShipId");

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.Ship", b =>
                {
                    b.Navigation("ShipItems");
                });
#pragma warning restore 612, 618
        }
    }
}
