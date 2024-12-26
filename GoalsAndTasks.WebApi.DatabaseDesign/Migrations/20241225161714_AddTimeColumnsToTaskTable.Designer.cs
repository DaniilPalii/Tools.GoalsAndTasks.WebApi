﻿// <auto-generated />
using System;
using GoalsAndTasks.DataPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoalsAndTasks.WebApi.DatabaseDesign.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241225161714_AddTimeColumnsToTaskTable")]
    partial class AddTimeColumnsToTaskTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoalsAndTasks.WebApi.DataPersistence.Entities.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateOnly?>("DueDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly?>("DueTime")
                        .HasColumnType("time");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly?>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}