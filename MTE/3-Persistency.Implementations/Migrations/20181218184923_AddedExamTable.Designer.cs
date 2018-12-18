﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3_Persistency.Implementations;

namespace _3_Persistency.Implementations.Migrations
{
    [DbContext(typeof(MTEContext))]
    [Migration("20181218184923_AddedExamTable")]
    partial class AddedExamTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_1_Entity.Model.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Subject");

                    b.Property<double>("Time");

                    b.HasKey("Id");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("_1_Entity.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<Guid>("ExamId");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsPresent");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("_1_Entity.Model.Student", b =>
                {
                    b.HasOne("_1_Entity.Model.Exam", "Exam")
                        .WithMany("Students")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
