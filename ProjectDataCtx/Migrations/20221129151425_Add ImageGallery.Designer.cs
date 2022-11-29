﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectDataCtx;

#nullable disable

namespace ProjectDataCtx.Migrations
{
    [DbContext(typeof(EfDataCtx))]
    [Migration("20221129151425_Add ImageGallery")]
    partial class AddImageGallery
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectDataCtx.DataDetails", b =>
                {
                    b.Property<int>("DataDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DataDetailsId"));

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectDataId")
                        .HasColumnType("int");

                    b.HasKey("DataDetailsId");

                    b.HasIndex("ProjectDataId");

                    b.ToTable("DataDetails");
                });

            modelBuilder.Entity("ProjectDataCtx.ImageGallery", b =>
                {
                    b.Property<int>("ImageGalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageGalleryId"));

                    b.Property<string>("ImageGalleryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageGalleryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageGalleryPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageGalleryTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageGalleryId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ProjectDataCtx.ProductModal", b =>
                {
                    b.Property<int>("ProductModalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductModalId"));

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPreviousPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductModalId");

                    b.ToTable("ProductModals");
                });

            modelBuilder.Entity("ProjectDataCtx.ProjectData", b =>
                {
                    b.Property<int>("ProjectDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectDataId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ProjectDataId");

                    b.ToTable("ProjectData");
                });

            modelBuilder.Entity("ProjectDataCtx.DataDetails", b =>
                {
                    b.HasOne("ProjectDataCtx.ProjectData", null)
                        .WithMany("Details")
                        .HasForeignKey("ProjectDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectDataCtx.ProjectData", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
