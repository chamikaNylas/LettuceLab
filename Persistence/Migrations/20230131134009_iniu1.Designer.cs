﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230131134009_iniu1")]
    partial class iniu1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Entities.GreenHouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GreenHouses", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.GreenHouseManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DoB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GreenHouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GreenHouseId");

                    b.ToTable("GreenHouseManager");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Persistence.Entities.Outbox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ChangeAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Outboxs");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("Domain.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.GreenHouse", b =>
                {
                    b.OwnsMany("Domain.ValueObjects.Container", "Containers", b1 =>
                        {
                            b1.Property<Guid>("GreenHouseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Height")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("Length")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("Width")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("GreenHouseId", "Id");

                            b1.ToTable("Containers", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GreenHouseId");

                            b1.OwnsMany("Domain.ValueObjects.GrowBed", "GrowBeds", b2 =>
                                {
                                    b2.Property<Guid>("GreenHouseId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("ContainerId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<decimal>("Height")
                                        .HasColumnType("decimal(18,2)");

                                    b2.Property<decimal>("Length")
                                        .HasColumnType("decimal(18,2)");

                                    b2.Property<decimal>("Width")
                                        .HasColumnType("decimal(18,2)");

                                    b2.HasKey("GreenHouseId", "ContainerId", "Id");

                                    b2.ToTable("GrowBeds", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("GreenHouseId", "ContainerId");

                                    b2.OwnsMany("Domain.ValueObjects.Lettuce", "Lettuces", b3 =>
                                        {
                                            b3.Property<Guid>("GreenHouseId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<Guid>("ContainerId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<Guid>("GrowBedId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<Guid>("Id")
                                                .ValueGeneratedOnAdd()
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<string>("Type")
                                                .IsRequired()
                                                .HasColumnType("nvarchar(max)");

                                            b3.HasKey("GreenHouseId", "ContainerId", "GrowBedId", "Id");

                                            b3.ToTable("Lettuces", (string)null);

                                            b3.WithOwner()
                                                .HasForeignKey("GreenHouseId", "ContainerId", "GrowBedId");
                                        });

                                    b2.Navigation("Lettuces");
                                });

                            b1.Navigation("GrowBeds");
                        });

                    b.Navigation("Containers");
                });

            modelBuilder.Entity("Domain.Entities.GreenHouseManager", b =>
                {
                    b.HasOne("Domain.Entities.GreenHouse", null)
                        .WithMany("GreenHouseManagers")
                        .HasForeignKey("GreenHouseId");
                });

            modelBuilder.Entity("Domain.Entities.GreenHouse", b =>
                {
                    b.Navigation("GreenHouseManagers");
                });
#pragma warning restore 612, 618
        }
    }
}
