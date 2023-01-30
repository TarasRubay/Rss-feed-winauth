﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rss_feed_winauth.DataBaseContext;

#nullable disable

namespace Rssfeedwinauth.Migrations
{
    [DbContext(typeof(TableContext))]
    partial class TableContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Rss_feed_winauth.Models.RssFeedModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Authors")
                        .HasColumnType("longtext");

                    b.Property<string>("IdFeed")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("NameUser")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Publish_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RssFeedModels");
                });
#pragma warning restore 612, 618
        }
    }
}