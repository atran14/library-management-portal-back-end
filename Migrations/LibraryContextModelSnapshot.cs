﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back_end.DatabaseContexts;

namespace back_end.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("back_end.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Authors")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Unknown");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("None");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Authors = "Yann Martel",
                            CategoryId = 1,
                            Description = "Generic description",
                            Name = "Life of Pi"
                        },
                        new
                        {
                            Id = 2,
                            Authors = "Alexandre Dumas",
                            CategoryId = 1,
                            Description = "Generic description",
                            Name = "The Three Musketeers"
                        },
                        new
                        {
                            Id = 3,
                            Authors = "Jack London",
                            CategoryId = 1,
                            Description = "Generic description",
                            Name = "The Call of the Wild"
                        },
                        new
                        {
                            Id = 4,
                            Authors = "Harper Lee",
                            CategoryId = 2,
                            Description = "Generic description",
                            Name = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 5,
                            Authors = "Louisa May Alcott",
                            CategoryId = 2,
                            Description = "Generic description",
                            Name = "Little Women"
                        },
                        new
                        {
                            Id = 6,
                            Authors = "Toni Morrison",
                            CategoryId = 2,
                            Description = "Generic description",
                            Name = "Beloved"
                        },
                        new
                        {
                            Id = 7,
                            Authors = "Alan Moore, Dave Gibbons",
                            CategoryId = 3,
                            Description = "Generic description",
                            Name = "Watchmen"
                        },
                        new
                        {
                            Id = 8,
                            Authors = "Charlie Mackery",
                            CategoryId = 3,
                            Description = "Generic description",
                            Name = "The Boy, the Mole, the Fox and the Horse"
                        },
                        new
                        {
                            Id = 9,
                            Authors = "Michael Connelly",
                            CategoryId = 4,
                            Description = "Generic description",
                            Name = "The Night Fire"
                        },
                        new
                        {
                            Id = 10,
                            Authors = "Sir Arthur Conan Doyle",
                            CategoryId = 4,
                            Description = "Generic description",
                            Name = "The Adventures of Sherlock Holmes"
                        },
                        new
                        {
                            Id = 11,
                            Authors = "Agatha Christie",
                            CategoryId = 4,
                            Description = "Generic description",
                            Name = "And Then There Were None"
                        },
                        new
                        {
                            Id = 12,
                            Authors = "Ta-Nehisi Coates",
                            CategoryId = 5,
                            Description = "Generic description",
                            Name = "The Water Dancer"
                        },
                        new
                        {
                            Id = 13,
                            Authors = "Madeline Miller",
                            CategoryId = 5,
                            Description = "Generic description",
                            Name = "Circe"
                        },
                        new
                        {
                            Id = 14,
                            Authors = "Leigh Bardugo",
                            CategoryId = 5,
                            Description = "Generic description",
                            Name = "Ninth House"
                        },
                        new
                        {
                            Id = 15,
                            Authors = "Kathryn Stockett",
                            CategoryId = 6,
                            Description = "Generic description",
                            Name = "The Help"
                        },
                        new
                        {
                            Id = 16,
                            Authors = "Gabriel Garcia Marquez",
                            CategoryId = 6,
                            Description = "Generic description",
                            Name = "One Hundred Years of Solitude"
                        },
                        new
                        {
                            Id = 17,
                            Authors = "Arthur Golden",
                            CategoryId = 6,
                            Description = "Generic description",
                            Name = "Memoirs of a Geisha"
                        },
                        new
                        {
                            Id = 18,
                            Authors = "Stephen King",
                            CategoryId = 7,
                            Description = "Generic description",
                            Name = "Carrie"
                        },
                        new
                        {
                            Id = 19,
                            Authors = "Shirley Jackson",
                            CategoryId = 7,
                            Description = "Generic description",
                            Name = "The Haunting of Hill House"
                        },
                        new
                        {
                            Id = 20,
                            Authors = "Josh Malerman",
                            CategoryId = 7,
                            Description = "Generic description",
                            Name = "Bird Box"
                        },
                        new
                        {
                            Id = 21,
                            Authors = "Delia Owens",
                            CategoryId = 8,
                            Description = "Generic description",
                            Name = "Where the Crawdads Sing"
                        },
                        new
                        {
                            Id = 22,
                            Authors = "Elizabeth Strout",
                            CategoryId = 8,
                            Description = "Generic description",
                            Name = "Olive, Again"
                        },
                        new
                        {
                            Id = 23,
                            Authors = "Ann Patchett",
                            CategoryId = 8,
                            Description = "Generic description",
                            Name = "The Dutch House"
                        },
                        new
                        {
                            Id = 24,
                            Authors = "Sarah MacLean",
                            CategoryId = 9,
                            Description = "Generic description",
                            Name = "Brazen and the Beast"
                        },
                        new
                        {
                            Id = 25,
                            Authors = "Jasmine Guillory",
                            CategoryId = 9,
                            Description = "Generic description",
                            Name = "Royal Holiday"
                        },
                        new
                        {
                            Id = 26,
                            Authors = "J. R. Ward",
                            CategoryId = 9,
                            Description = "Generic description",
                            Name = "The Savior"
                        },
                        new
                        {
                            Id = 27,
                            Authors = "Margaret Atwood",
                            CategoryId = 10,
                            Description = "Generic description",
                            Name = "The Testaments"
                        },
                        new
                        {
                            Id = 28,
                            Authors = "Suzanne Collins",
                            CategoryId = 10,
                            Description = "Generic description",
                            Name = "The Hunger Games Trilogy"
                        },
                        new
                        {
                            Id = 29,
                            Authors = "George Orwell",
                            CategoryId = 10,
                            Description = "Generic description",
                            Name = "1984"
                        },
                        new
                        {
                            Id = 30,
                            Authors = "Junot Diaz",
                            CategoryId = 11,
                            Description = "Generic description",
                            Name = "This Is How You Lose Her"
                        },
                        new
                        {
                            Id = 31,
                            Authors = "Lauren Groff",
                            CategoryId = 11,
                            Description = "Generic description",
                            Name = "Florida"
                        },
                        new
                        {
                            Id = 32,
                            Authors = "N. K. Jemisin",
                            CategoryId = 11,
                            Description = "Generic description",
                            Name = "How Long 'Til Black Future Month?"
                        });
                });

            modelBuilder.Entity("back_end.Models.BorrowRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActionByUserId")
                        .HasColumnType("int");

                    b.Property<int>("ActionStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ActionTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BorrowRequestDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BorrowUntilDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActionByUserId");

                    b.HasIndex("RequestUserId");

                    b.ToTable("BorrowRequest");
                });

            modelBuilder.Entity("back_end.Models.BorrowRequestDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BorrowRequestId")
                        .HasColumnType("int");

                    b.Property<int>("RequestedBookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BorrowRequestId");

                    b.HasIndex("RequestedBookId");

                    b.ToTable("BorrowRequestDetails");
                });

            modelBuilder.Entity("back_end.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action and Adventure"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Classics"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comic Book/Graphic Novel"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Detective and Mystery"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Historical Fiction"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Literary Fiction"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Short Stories"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Suspense and Thrillers"
                        });
                });

            modelBuilder.Entity("back_end.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DOB = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "12345",
                            Role = 0,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            DOB = new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bob",
                            LastName = "McFarland",
                            Password = "bob97",
                            Role = 1,
                            Username = "bob97"
                        });
                });

            modelBuilder.Entity("back_end.Models.Book", b =>
                {
                    b.HasOne("back_end.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("back_end.Models.BorrowRequest", b =>
                {
                    b.HasOne("back_end.Models.User", "ActionByUser")
                        .WithMany()
                        .HasForeignKey("ActionByUserId");

                    b.HasOne("back_end.Models.User", "RequestUser")
                        .WithMany("BorrowRequests")
                        .HasForeignKey("RequestUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionByUser");

                    b.Navigation("RequestUser");
                });

            modelBuilder.Entity("back_end.Models.BorrowRequestDetails", b =>
                {
                    b.HasOne("back_end.Models.BorrowRequest", "BorrowRequest")
                        .WithMany("BorrowRequestDetails")
                        .HasForeignKey("BorrowRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_end.Models.Book", "RequestedBook")
                        .WithMany("BorrowRequestDetails")
                        .HasForeignKey("RequestedBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BorrowRequest");

                    b.Navigation("RequestedBook");
                });

            modelBuilder.Entity("back_end.Models.Book", b =>
                {
                    b.Navigation("BorrowRequestDetails");
                });

            modelBuilder.Entity("back_end.Models.BorrowRequest", b =>
                {
                    b.Navigation("BorrowRequestDetails");
                });

            modelBuilder.Entity("back_end.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("back_end.Models.User", b =>
                {
                    b.Navigation("BorrowRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
