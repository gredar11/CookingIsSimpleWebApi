﻿// <auto-generated />
using System;
using Cis.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cis.WebApi.Migrations
{
    [DbContext(typeof(CisDbContext))]
    [Migration("20221019111608_RecipeCategory")]
    partial class RecipeCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cis.Domain.Models.AmountOfIngredient", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("AmountOfIngredients");
                });

            modelBuilder.Entity("Cis.Domain.Models.FoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NameOfCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("FoodCategories");
                });

            modelBuilder.Entity("Cis.Domain.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("IngredientDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Cis.Domain.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeCategoryId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Cis.Domain.Models.RecipeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("Cis.Domain.Models.AmountOfIngredient", b =>
                {
                    b.HasOne("Cis.Domain.Models.Ingredient", "Ingredient")
                        .WithMany("Recipes")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cis.Domain.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Cis.Domain.Models.Ingredient", b =>
                {
                    b.HasOne("Cis.Domain.Models.FoodCategory", "Category")
                        .WithMany("Ingredients")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Cis.Domain.Models.Recipe", b =>
                {
                    b.HasOne("Cis.Domain.Models.RecipeCategory", "RecipeCategory")
                        .WithMany("Recipes")
                        .HasForeignKey("RecipeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipeCategory");
                });

            modelBuilder.Entity("Cis.Domain.Models.FoodCategory", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Cis.Domain.Models.Ingredient", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("Cis.Domain.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Cis.Domain.Models.RecipeCategory", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
