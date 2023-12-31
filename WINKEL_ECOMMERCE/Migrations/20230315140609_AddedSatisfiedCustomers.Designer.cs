﻿// <auto-generated />
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
    [Migration("20230315140609_AddedSatisfiedCustomers")]
    partial class AddedSatisfiedCustomers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DiscountPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(5,2)")
                        .HasDefaultValueSql("00.00");

                    b.Property<bool>("HasDiscount")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(5,2)")
                        .HasDefaultValueSql("00.00");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.SatisfiedCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AltImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Position")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SatisfiedCustomers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AltImage = "Garreth Smith",
                            Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.",
                            Icon = "fas fa-quote-left",
                            Image = "person_1.webp",
                            Name = "Garreth Smith",
                            Position = "MARKETING  MANAGER"
                        },
                        new
                        {
                            Id = 2,
                            AltImage = "Garreth Smith",
                            Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.",
                            Icon = "fas fa-quote-left",
                            Image = "person_2.webp",
                            Name = "Wiktoria Manilla",
                            Position = "SALES  MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            AltImage = "Garreth Smith",
                            Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.",
                            Icon = "fas fa-quote-right",
                            Image = "person_3.webp",
                            Name = "Wladyslaw Szpilman",
                            Position = "CONTENT MANAGER"
                        },
                        new
                        {
                            Id = 4,
                            AltImage = "Garreth Smith",
                            Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.",
                            Icon = "fas fa-quote-left",
                            Image = "person_1.webp",
                            Name = "Garreth Smith",
                            Position = "MARKETING  MANAGER"
                        });
                });

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AltImage = "This is a photo",
                            Description = "But nothing the copy said could convince her and so it didn’t take long until a few insidious Copy Writers ambushed her, made her drunk with Longe and Parole and dragged her into their agency, where they abused her for their.",
                            Header = "Better Way to Ship Your Products",
                            Image = "about.webp",
                            Link = "https://vimeo.com/45830194"
                        });
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

                    b.Property<int>("ShipId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.ToTable("ShipItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
                            Icon = "fas fa-tablet-alt",
                            ShipId = 1,
                            Title = "REFUND POLICY"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
                            Icon = "fas fa-tablet-alt",
                            ShipId = 1,
                            Title = "REFUND POLICY"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
                            Icon = "fas fa-tablet-alt",
                            ShipId = 1,
                            Title = "REFUND POLICY"
                        });
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

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.Static", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Statics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 10000,
                            Name = "HAPPY CUSTOMERS"
                        },
                        new
                        {
                            Id = 2,
                            Count = 100,
                            Name = "BRANCHES"
                        },
                        new
                        {
                            Id = 3,
                            Count = 1000,
                            Name = "PARTNER"
                        },
                        new
                        {
                            Id = 4,
                            Count = 10000,
                            Name = "AWARDS"
                        });
                });

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.Summer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LeftContent")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("LeftHeading")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LeftImage")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RightContent")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("RightHeading")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RightImage")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Summers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LeftContent = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.",
                            LeftHeading = "NEW MEN'S CLOTHING SUMMER COLLECTION 2019",
                            LeftImage = "about-2.webp",
                            RightContent = " NEW WOMEN'S CLOTHING SUMMER COLLECTION 2019\r\n                Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.",
                            RightHeading = "NEW WOMEN'S CLOTHING SUMMER COLLECTION 2019",
                            RightImage = "about-1.jpg"
                        });
                });

            modelBuilder.Entity("WINKEL_ECOMMERCE.Models.ShipItem", b =>
                {
                    b.HasOne("WINKEL_ECOMMERCE.Models.Ship", "Ship")
                        .WithMany("ShipItems")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
