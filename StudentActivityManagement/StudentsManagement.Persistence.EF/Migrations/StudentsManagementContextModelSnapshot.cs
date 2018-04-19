﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StudentsManagement.Persistence.EF;
using System;

namespace StudentsManagement.Persistence.EF.Migrations
{
    [DbContext(typeof(StudentsManagementContext))]
    partial class StudentsManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentsManagement.Domain.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("OwnerId");

                    b.Property<int?>("StudentId");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TypeId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("StudentsManagement.Domain.ActivityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ActivityType");
                });

            modelBuilder.Entity("StudentsManagement.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentsManagement.Domain.StudentActivityInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<int>("Attendance");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Grade");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.ToTable("StudentActivityInfo");
                });

            modelBuilder.Entity("StudentsManagement.Domain.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentsManagement.Domain.Activity", b =>
                {
                    b.HasOne("StudentsManagement.Domain.Teacher", "Owner")
                        .WithMany("Activities")
                        .HasForeignKey("OwnerId");

                    b.HasOne("StudentsManagement.Domain.Student")
                        .WithMany("Activities")
                        .HasForeignKey("StudentId");

                    b.HasOne("StudentsManagement.Domain.ActivityType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}