﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RetroRelics.Postgres;

#nullable disable

namespace RetroRelics.Postgres.Migrations
{
    [DbContext(typeof(RetroRelicsContext))]
    partial class RetroRelicsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RetroRelics.Postgres.Entities.Relic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Relics");
                });

            modelBuilder.Entity("RetroRelics.Postgres.Entities.RelicMetadata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RelicId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RelicId");

                    b.ToTable("RelicMetadata");
                });

            modelBuilder.Entity("RetroRelics.Postgres.Entities.RelicMetadata", b =>
                {
                    b.HasOne("RetroRelics.Postgres.Entities.Relic", "Relic")
                        .WithMany("Metadata")
                        .HasForeignKey("RelicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Relic");
                });

            modelBuilder.Entity("RetroRelics.Postgres.Entities.Relic", b =>
                {
                    b.Navigation("Metadata");
                });
#pragma warning restore 612, 618
        }
    }
}
