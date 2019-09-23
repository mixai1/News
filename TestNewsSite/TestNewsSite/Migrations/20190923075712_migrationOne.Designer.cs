﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestNewsSite.DataBase;

namespace TestNewsSite.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20190923075712_migrationOne")]
    partial class migrationOne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestNewsSite.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("NewId");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.HasIndex("NewId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("TestNewsSite.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("NewId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("NewId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TestNewsSite.Models.New", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Heading");

                    b.Property<string>("Img");

                    b.Property<decimal>("Positive");

                    b.Property<string>("Source");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("TestNewsSite.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Name");

                    b.Property<int>("NewId");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.HasIndex("NewId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestNewsSite.Models.UserCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCategories");
                });

            modelBuilder.Entity("TestNewsSite.Models.Admin", b =>
                {
                    b.HasOne("TestNewsSite.Models.New", "news")
                        .WithMany("admins")
                        .HasForeignKey("NewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestNewsSite.Models.Comment", b =>
                {
                    b.HasOne("TestNewsSite.Models.Admin", "admins")
                        .WithMany("comments")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestNewsSite.Models.New", "news")
                        .WithMany("comments")
                        .HasForeignKey("NewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestNewsSite.Models.User", "users")
                        .WithMany("comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestNewsSite.Models.User", b =>
                {
                    b.HasOne("TestNewsSite.Models.New", "news")
                        .WithMany("users")
                        .HasForeignKey("NewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestNewsSite.Models.UserCategory", b =>
                {
                    b.HasOne("TestNewsSite.Models.Admin", "admin")
                        .WithMany("userCategories")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestNewsSite.Models.User", "user")
                        .WithMany("userCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
