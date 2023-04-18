﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceQuotes.Common;

#nullable disable

namespace PriceQuotes.Common.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230418023830_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PriceQuotes.Common.Price", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("valueId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("valueId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("PriceQuotes.Common.PriceValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("PriceValue");
                });

            modelBuilder.Entity("PriceQuotes.Common.Price", b =>
                {
                    b.HasOne("PriceQuotes.Common.PriceValue", "value")
                        .WithMany()
                        .HasForeignKey("valueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("value");
                });
#pragma warning restore 612, 618
        }
    }
}
