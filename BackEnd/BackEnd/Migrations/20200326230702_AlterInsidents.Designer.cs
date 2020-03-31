﻿// <auto-generated />
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200326230702_AlterInsidents")]
    partial class AlterInsidents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BackEnd.Models.Incidents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OngsId");

                    b.Property<string>("Title");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("OngsId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("BackEnd.Models.Ongs", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Uf");

                    b.HasKey("Id");

                    b.ToTable("Ongs");
                });

            modelBuilder.Entity("BackEnd.Models.Incidents", b =>
                {
                    b.HasOne("BackEnd.Models.Ongs", "Ong")
                        .WithMany()
                        .HasForeignKey("OngsId");
                });
#pragma warning restore 612, 618
        }
    }
}
