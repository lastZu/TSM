﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TSM.Task.Infrastructure;

#nullable disable

namespace TSM.Task.Infrastructure.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20240221164349_ChengeViewNameForPriorities")]
    partial class ChengeViewNameForPriorities
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

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "Something isn't working"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "New feature"
                        },
                        new
                        {
                            Id = (byte)3,
                            Name = "Further information is requested"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = (byte)3,
                            Name = "Highest"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = (byte)1,
                            Name = "Low"
                        });
                });

            modelBuilder.Entity("TSM.Task.Domain.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_tag");

                    b.HasAlternateKey("Name")
                        .HasName("ak_tag_name");

                    b.ToTable("tag", (string)null);
                });

            modelBuilder.Entity("TSM.Task.Domain.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<byte?>("CategoryId")
                        .HasColumnType("smallint")
                        .HasColumnName("category_id");

                    b.Property<string>("Comment")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("comment");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deadline");

                    b.Property<byte?>("PriorityId")
                        .HasColumnType("smallint")
                        .HasColumnName("priority_id");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("uuid")
                        .HasColumnName("tag_id");

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

                    b.HasIndex("TagId")
                        .HasDatabaseName("ix_task_tag_id");

                    b.ToTable("task", (string)null);
                });

            modelBuilder.Entity("TSM.Task.Domain.Entities.Task", b =>
                {
                    b.HasOne("TSM.Task.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_task_category_category_id");

                    b.HasOne("TSM.Task.Domain.Entities.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_task_priority_priority_id");

                    b.HasOne("TSM.Task.Domain.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_task_tag_tag_id");

                    b.Navigation("Category");

                    b.Navigation("Priority");

                    b.Navigation("Tag");
                });
#pragma warning restore 612, 618
        }
    }
}
