﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TSM.Task.Infrastructure;

#nullable disable

namespace TSM.Task.Api.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20240116221534_revertTest")]
    partial class revertTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TSM.Task.Domain.Entities.Category", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("TSM.Task.Domain.Entities.Priority", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_priority");

                    b.ToTable("priority", (string)null);
                });

            modelBuilder.Entity("TSM.Task.Domain.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<byte?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("smallint")
                        .HasColumnName("category_id");

                    b.Property<string>("Comment")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("comment");

                    b.Property<DateTime?>("Deadline")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 17, 1, 15, 33, 883, DateTimeKind.Local).AddTicks(2129))
                        .HasColumnName("deadline");

                    b.Property<byte?>("PriorityId")
                        .IsRequired()
                        .HasColumnType("smallint")
                        .HasColumnName("priority_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_task");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_task_category_id");

                    b.HasIndex("PriorityId")
                        .HasDatabaseName("ix_task_priority_id");

                    b.ToTable("task", (string)null);
                });

            modelBuilder.Entity("TSM.Task.Domain.Entities.Task", b =>
                {
                    b.HasOne("TSM.Task.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_category_category_id");

                    b.HasOne("TSM.Task.Domain.Entities.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_priority_priority_id");

                    b.Navigation("Category");

                    b.Navigation("Priority");
                });
#pragma warning restore 612, 618
        }
    }
}
