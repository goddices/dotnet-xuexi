﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySqlTest.LocalTest;

namespace MySqlTest.Migrations
{
    [DbContext(typeof(MySqlDbContext))]
    [Migration("20200417053155_add_new")]
    partial class add_new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MySqlTest.LocalTest.MySqlDbContext+MyRobots", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DomainUsers")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastCommTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MachineCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("RobotCode")
                        .HasColumnType("char(36)");

                    b.Property<int>("RobotStatus")
                        .HasColumnType("int");

                    b.Property<int>("RobotType")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Version")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("robots");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75b6f572-7160-4c0f-b728-e4e4aa35bc0b"),
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
                            Id = new Guid("1e6cc4f4-f5dc-4879-af60-b00a5a1eaa94"),
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
                            Id = new Guid("1d91ee3e-b579-4cd6-b80c-377acb9351cd"),
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
                            Id = new Guid("9e5da601-5787-4025-a9ea-53e9da6fbce9"),
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
                            Id = new Guid("333da21b-41c8-4f0c-83d9-d914634130cd"),
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
                            Id = new Guid("2901ec87-685c-4d17-8a94-d30c74bb4722"),
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
                            Id = new Guid("9a3c099b-fc48-4ab9-8654-56ce2a622a3f"),
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
                            Id = new Guid("251138eb-8812-47c0-a94b-f827deb6887d"),
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
                            Id = new Guid("edb08a8f-9106-474b-8b65-274894d6e634"),
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
                            Id = new Guid("e03a655d-8733-4f96-a207-acfb788bcae4"),
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
                            Id = new Guid("c54b7bee-a577-4f6f-974a-098a870f3ad5"),
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
