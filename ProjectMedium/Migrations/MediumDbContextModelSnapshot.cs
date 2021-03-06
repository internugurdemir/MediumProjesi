// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectMedium.Models.DataAccess;

namespace ProjectMedium.Migrations
{
    [DbContext(typeof(MediumDbContext))]
    partial class MediumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectMedium.Models.DataAccess.Entitites.Note", b =>
                {
                    b.Property<int>("NoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ReadingCount")
                        .HasColumnType("bigint");

                    b.Property<int>("ReadingTime")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("TopicID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("NoteID");

                    b.HasIndex("TopicID");

                    b.HasIndex("UserID");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            NoteID = 1,
                            Content = "In European music theory, most countries use the solfège naming convention do–re–mi–fa–sol–la–si, including for instance Italy, Portugal, Spain, France, Romania, most Latin American countries, Greece, Albania, Bulgaria, Turkey, Russia, Arabic-speaking and Persian-speaking countries. However, in English- and Dutch-speaking regions, pitch classes are typically represented by the first seven letters of the Latin alphabet (A, B, C, D, E, F and G). A few European countries, including Germany, adopt an almost identical notation, in which H substitutes for B (see below for details). Byzantium used the names Pa–Vu–Ga–Di–Ke–Zo–Ni (Πα–Βου–Γα–Δι–Κε–Ζω–Νη).",
                            CreatedDate = new DateTime(2021, 4, 13, 17, 37, 48, 510, DateTimeKind.Local).AddTicks(9098),
                            IsActive = true,
                            ReadingCount = 0L,
                            ReadingTime = 0,
                            Title = "First Note",
                            UserID = 454
                        });
                });

            modelBuilder.Entity("ProjectMedium.Models.DataAccess.Entitites.NoteTopic", b =>
                {
                    b.Property<int>("NoteId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("NoteId", "TopicId");

                    b.HasIndex("TopicId");

                    b.ToTable("NoteTopics");
                });

            modelBuilder.Entity("ProjectMedium.Models.DataAccess.Entitites.Topic", b =>
                {
                    b.Property<int>("TopicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.HasKey("TopicID");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            TopicID = 1,
                            Photo = "~/Image/Story.jpg",
                            TopicName = "Story"
                        },
                        new
                        {
                            TopicID = 2,
                            Photo = "~/Image/Science.png",
                            TopicName = "Science"
                        },
                        new
                        {
                            TopicID = 3,
                            Photo = "~/Image/Art.png",
                            TopicName = "Art"
                        },
                        new
                        {
                            TopicID = 4,
                            Photo = "~/Image/Game.png",
                            TopicName = "Game"
                        },
                        new
                        {
                            TopicID = 5,
                            Photo = "~/Image/Technology.png",
                            TopicName = "Technology"
                        });
                });

            modelBuilder.Entity("ProjectMedium.Models.DataAccess.Entitites.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(160)")
                        .HasMaxLength(160);

                    b.Property<string>("Connections")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(155)")
                        .HasMaxLength(155);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 454,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ddemirugur@gmail.com",
                            FirstName = "Ugur",
                            IsActive = true,
                            LastName = "Demir",
                            UserName = "dd",
                            UserRole = 0
                        });
                });

            modelBuilder.Entity("ProjectMedium.Models.DataAccess.Entitites.UserTopic", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TopicId");

                    b.HasIndex("TopicId");

                    b.ToTable("UserTopics");
                });

            modelBuilder.Entity("ProjectMedium.Models.DataAccess.Entitites.Note", b =>
                {
                    b.HasOne("ProjectMedium.Models.DataAccess.Entitites.Topic", null)
                        .WithMany("Notes")
                        .HasForeignKey("TopicID");

                    b.HasOne("ProjectMedium.Models.DataAccess.Entitites.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectMedium.Models.DataAccess.Entitites.NoteTopic", b =>
                {
                    b.HasOne("ProjectMedium.Models.DataAccess.Entitites.Note", "Note")
                        .WithMany("NoteTopics")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectMedium.Models.DataAccess.Entitites.Topic", "Topic")
                        .WithMany("NoteTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectMedium.Models.DataAccess.Entitites.UserTopic", b =>
                {
                    b.HasOne("ProjectMedium.Models.DataAccess.Entitites.Topic", "Topic")
                        .WithMany("UserTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectMedium.Models.DataAccess.Entitites.User", "User")
                        .WithMany("UserTopics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
