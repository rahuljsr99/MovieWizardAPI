﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieWizardAPI.Data;

#nullable disable

namespace MovieWizardAPI.Migrations.MovieBudgetDb
{
    [DbContext(typeof(MovieBudgetDbContext))]
    [Migration("20240627161638_CreateTableMovieBudgets")]
    partial class CreateTableMovieBudgets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieWizardAPI.Models.MovieBudget", b =>
                {
                    b.Property<int>("MovieBudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieBudgetId"), 1L, 1);

                    b.Property<decimal>("BudgetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BudgetDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("MovieBudgetId");

                    b.ToTable("MovieBudgets", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
