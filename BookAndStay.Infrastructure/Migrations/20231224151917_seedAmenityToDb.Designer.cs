﻿// <auto-generated />
using System;
using BookAndStay.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookAndStay.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231224151917_seedAmenityToDb")]
    partial class seedAmenityToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookAndStay.Domain.Entities.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Air Conditioner"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Name = "Tv"
                        });
                });

            modelBuilder.Entity("BookAndStay.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A basic accommodation option with essential amenities. Standard rooms are usually more affordable and cater to guests looking for a comfortable yet budget-friendly stay.",
                            ImageUrl = "aa",
                            Occupancy = 2,
                            Price = 100.0,
                            RoomType = "Standard Room"
                        },
                        new
                        {
                            Id = 2,
                            Description = "An upgraded and more spacious room category compared to the standard room. Deluxe rooms often feature larger beds, higher-quality furnishings, and additional amenities for enhanced comfort. Guests choosing a deluxe room can enjoy a more luxurious experience without opting for a full suite.",
                            ImageUrl = "aa",
                            Occupancy = 2,
                            Price = 300.0,
                            RoomType = "Deluxe Room"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A suite is a larger and more luxurious accommodation option that goes beyond the features of a standard or deluxe room. It usually consists of a separate living area and bedroom, providing more space for relaxation and work. Suites may include additional amenities such as a mini-kitchen, dining area, and upgraded in-room facilities.",
                            ImageUrl = "aa",
                            Occupancy = 2,
                            Price = 100.0,
                            RoomType = "Suit"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The VIP Suite represents the pinnacle of luxury in a hotel.It is designed for high - profile guests, celebrities, or those seeking an exclusive and opulent experience.VIP Suites often feature a spacious living room, a master bedroom, a dining area, and may include special services such as a personal concierge.These suites are characterized by top - notch amenities, premium furnishings, and a high level of privacy.",
                            ImageUrl = "aa",
                            Occupancy = 2,
                            Price = 100.0,
                            RoomType = "VIP Suite"
                        });
                });

            modelBuilder.Entity("BookAndStay.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Room_Number")
                        .HasColumnType("int");

                    b.Property<int>("Room_ID")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Room_Number");

                    b.HasIndex("Room_ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Room_Number = 101,
                            Room_ID = 1
                        },
                        new
                        {
                            Room_Number = 102,
                            Room_ID = 2
                        },
                        new
                        {
                            Room_Number = 103,
                            Room_ID = 3
                        });
                });

            modelBuilder.Entity("BookAndStay.Domain.Entities.Amenity", b =>
                {
                    b.HasOne("BookAndStay.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookAndStay.Domain.Entities.Room", b =>
                {
                    b.HasOne("BookAndStay.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Room_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
