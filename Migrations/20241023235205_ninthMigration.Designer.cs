﻿// <auto-generated />
using System;
using Itmo.Mvc.StudentsJournal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Itmo.Mvc.StudentsJournal.Migrations
{
    [DbContext(typeof(StudentsJournalContext))]
    [Migration("20241023235205_ninthMigration")]
    partial class ninthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Itmo.Mvc.StudentsJournal.Models.GradeLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("grade")
                        .HasColumnType("int");

                    b.Property<int?>("studentId")
                        .HasColumnType("int");

                    b.Property<string>("subjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("studentId");

                    b.ToTable("GradeLogs");
                });

            modelBuilder.Entity("Itmo.Mvc.StudentsJournal.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Itmo.Mvc.StudentsJournal.Models.Subject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("subjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Itmo.Mvc.StudentsJournal.Models.GradeLog", b =>
                {
                    b.HasOne("Itmo.Mvc.StudentsJournal.Models.Student", "student")
                        .WithMany("gradeLogs")
                        .HasForeignKey("studentId");

                    b.Navigation("student");
                });

            modelBuilder.Entity("Itmo.Mvc.StudentsJournal.Models.Student", b =>
                {
                    b.Navigation("gradeLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
