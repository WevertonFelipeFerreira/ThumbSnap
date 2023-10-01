﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThumbSnap.Infraestructure.Persistence;

#nullable disable

namespace ThumbSnap.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(ThumbSnapDbContext))]
    partial class ThumbSnapDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ThumbSnap.Domain.Entities.StoryboardSnap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<Guid>("VideoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("StoryboardSnaps");
                });

            modelBuilder.Entity("ThumbSnap.Domain.Entities.VideoInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectionMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Size")
                        .HasColumnType("bigint");

                    b.Property<int>("SnapHeight")
                        .HasColumnType("int");

                    b.Property<int>("SnapTakenEverySeconds")
                        .HasColumnType("int");

                    b.Property<int>("SnapWidth")
                        .HasColumnType("int");

                    b.Property<int>("StoryboardProcessingStatus")
                        .HasColumnType("int");

                    b.Property<int?>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VideoInformations");
                });

            modelBuilder.Entity("ThumbSnap.Domain.Entities.StoryboardSnap", b =>
                {
                    b.HasOne("ThumbSnap.Domain.Entities.VideoInformation", "VideoInformation")
                        .WithMany("Snaps")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VideoInformation");
                });

            modelBuilder.Entity("ThumbSnap.Domain.Entities.VideoInformation", b =>
                {
                    b.Navigation("Snaps");
                });
#pragma warning restore 612, 618
        }
    }
}
