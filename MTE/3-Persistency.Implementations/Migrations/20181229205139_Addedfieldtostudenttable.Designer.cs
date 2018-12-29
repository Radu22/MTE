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
    [Migration("20181229205139_Addedfieldtostudenttable")]
    partial class Addedfieldtostudenttable
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

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("_1_Entity.Model.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ExamId");

                    b.Property<double>("FinalGrade");

                    b.Property<Guid>("StudentId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("_1_Entity.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<Guid>("ExamId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("isPresent");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("_1_Entity.Model.Grade", b =>
                {
                    b.HasOne("_1_Entity.Model.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_1_Entity.Model.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("_1_Entity.Model.Student", b =>
                {
                    b.HasOne("_1_Entity.Model.Exam", "Exam")
                        .WithMany("Students")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
