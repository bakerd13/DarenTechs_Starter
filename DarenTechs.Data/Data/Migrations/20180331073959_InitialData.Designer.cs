﻿// <auto-generated />
using DarenTechs.Data.Data;
using DarenTechs.Data.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DarenTechs.Data.Data.Migrations
{
    [DbContext(typeof(DarenTechsContext))]
    [Migration("20180331073959_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DarenTechs.Data.Entities.Article.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleType");

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTimeOffset>("DatePublished");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPublic");

                    b.Property<bool>("IsPublished");

                    b.Property<DateTimeOffset>("LastModified");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Article.ArticleCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ArticleId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Blog.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long?>("PostId");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Blog.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName")
                        .IsRequired();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<long?>("CommentId");

                    b.Property<DateTimeOffset>("DatePublished");

                    b.Property<bool>("IsPublic");

                    b.Property<long?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Blog.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName");

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTimeOffset>("DatePublished");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPublic");

                    b.Property<bool>("IsPublished");

                    b.Property<DateTimeOffset>("LastModified");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Slug");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Blog.PostTag", b =>
                {
                    b.Property<long>("PostId");

                    b.Property<long>("TagId");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Blog.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Article.ArticleCategory", b =>
                {
                    b.HasOne("DarenTechs.Data.Entities.Article.Article")
                        .WithMany("Categories")
                        .HasForeignKey("ArticleId");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Blog.Category", b =>
                {
                    b.HasOne("DarenTechs.Data.Entities.Blog.Post")
                        .WithMany("Categories")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Blog.Comment", b =>
                {
                    b.HasOne("DarenTechs.Data.Entities.Blog.Comment")
                        .WithMany("Replies")
                        .HasForeignKey("CommentId");

                    b.HasOne("DarenTechs.Data.Entities.Blog.Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("DarenTechs.Data.Entities.Blog.PostTag", b =>
                {
                    b.HasOne("DarenTechs.Data.Entities.Blog.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DarenTechs.Data.Entities.Blog.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}