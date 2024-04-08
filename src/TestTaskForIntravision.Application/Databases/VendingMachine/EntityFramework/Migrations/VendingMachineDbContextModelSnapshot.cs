﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework;

#nullable disable

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Migrations
{
    [DbContext(typeof(VendingMachineDbContext))]
    partial class VendingMachineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.Beverage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<Guid?>("StorageBeverageId")
                        .HasColumnType("uuid")
                        .HasColumnName("storage_beverage_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_beverages");

                    b.HasIndex("Price")
                        .HasDatabaseName("ix_beverages_price");

                    b.HasIndex("StorageBeverageId")
                        .IsUnique()
                        .HasDatabaseName("ix_beverages_storage_beverage_id");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_beverages_title");

                    b.ToTable("beverages", (string)null);
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.BeverageImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BeverageId")
                        .HasColumnType("uuid")
                        .HasColumnName("beverage_id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_beverage_images");

                    b.HasAlternateKey("BeverageId")
                        .HasName("ak_beverage_images_beverage_id");

                    b.ToTable("beverage_images", (string)null);
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.Coin", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_coins");

                    b.HasIndex("Value")
                        .HasDatabaseName("ix_coins_value");

                    b.ToTable("coins", (string)null);
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.StorageBeverage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BeverageId")
                        .HasColumnType("uuid")
                        .HasColumnName("beverage_id");

                    b.Property<long>("Count")
                        .HasColumnType("bigint")
                        .HasColumnName("count");

                    b.HasKey("Id")
                        .HasName("pk_storage_beverages");

                    b.HasAlternateKey("BeverageId")
                        .HasName("ak_storage_beverages_beverage_id");

                    b.HasIndex("Count")
                        .HasDatabaseName("ix_storage_beverages_count");

                    b.ToTable("storage_beverages", (string)null);
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.StorageCoin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CoinId")
                        .HasColumnType("uuid")
                        .HasColumnName("coin_id");

                    b.Property<long>("Count")
                        .HasColumnType("bigint")
                        .HasColumnName("count");

                    b.HasKey("Id")
                        .HasName("pk_storage_coins");

                    b.HasAlternateKey("CoinId")
                        .HasName("ak_storage_coins_coin_id");

                    b.HasIndex("Count")
                        .HasDatabaseName("ix_storage_coins_count");

                    b.ToTable("storage_coins", (string)null);
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.Beverage", b =>
                {
                    b.HasOne("TestTaskForIntravision.Domain.Entities.BeverageImage", "Image")
                        .WithOne("Beverage")
                        .HasForeignKey("TestTaskForIntravision.Domain.Entities.Beverage", "Id")
                        .HasPrincipalKey("TestTaskForIntravision.Domain.Entities.BeverageImage", "BeverageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_beverages_beverage_images_id");

                    b.HasOne("TestTaskForIntravision.Domain.Entities.StorageBeverage", "Storage")
                        .WithOne("Beverage")
                        .HasForeignKey("TestTaskForIntravision.Domain.Entities.Beverage", "StorageBeverageId")
                        .HasPrincipalKey("TestTaskForIntravision.Domain.Entities.StorageBeverage", "BeverageId")
                        .HasConstraintName("fk_beverages_storage_beverages_storage_beverage_id");

                    b.Navigation("Image");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.Coin", b =>
                {
                    b.HasOne("TestTaskForIntravision.Domain.Entities.StorageCoin", "Storage")
                        .WithOne("Coin")
                        .HasForeignKey("TestTaskForIntravision.Domain.Entities.Coin", "Id")
                        .HasPrincipalKey("TestTaskForIntravision.Domain.Entities.StorageCoin", "CoinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_coins_storage_coins_id");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.BeverageImage", b =>
                {
                    b.Navigation("Beverage");
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.StorageBeverage", b =>
                {
                    b.Navigation("Beverage");
                });

            modelBuilder.Entity("TestTaskForIntravision.Domain.Entities.StorageCoin", b =>
                {
                    b.Navigation("Coin");
                });
#pragma warning restore 612, 618
        }
    }
}
