﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySqlTest.LocalTest;

namespace MySqlTest.Migrations
{
    [DbContext(typeof(MySqlDbContext))]
    partial class MySqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MySqlTest.LocalTest.MySqlDbContext+MyRobots", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DomainUsers")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("GroupId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastCommTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MachineCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("Remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RobotCode")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<int>("RobotStatus")
                        .HasColumnType("int");

                    b.Property<int>("RobotType")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Version")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("robots");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d65a9ac4-4402-4efa-8eaa-719be83245dd"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "aabb",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("545f25c3-53ad-419a-bbf3-f58b81c2e967"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "AABB",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("86c637ca-9133-4e99-9e5b-b9ffbf64c977"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "AaBb",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("3a3031a5-1463-4046-b063-cf065137e77b"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "aAbB",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("f9f32fc0-af52-411e-8632-ceea7a635def"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "bbcc",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("4173a770-cf04-426f-867d-294291e5d622"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "zxcv",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("553d394e-9cde-4843-8c27-c21b81cd08bb"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "朱峰",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("654b30ac-d038-4ad1-9955-22de3a154942"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "朱峰11",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("0bd64f72-a375-4684-af4b-27c010d4e74d"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "朱峰阿阿不",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("9e119488-468f-4217-928a-2ab4415d9e9c"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "朱峰aabb",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        },
                        new
                        {
                            Id = new Guid("c502001c-e99b-4467-8013-9cd581f7397c"),
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastCommTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "朱峰cccccc",
                            RobotCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            RobotStatus = 0,
                            RobotType = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
