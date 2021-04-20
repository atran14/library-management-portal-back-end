using System;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.DatabaseContexts.Extensions
{
    public static class LibraryModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Category identity
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Action and Adventure" },
                    new Category { Id = 2, Name = "Classics" },
                    new Category { Id = 3, Name = "Comic Book/Graphic Novel" },
                    new Category { Id = 4, Name = "Detective and Mystery" },
                    new Category { Id = 5, Name = "Fantasy" },
                    new Category { Id = 6, Name = "Historical Fiction" },
                    new Category { Id = 7, Name = "Horror" },
                    new Category { Id = 8, Name = "Literary Fiction" },
                    new Category { Id = 9, Name = "Science Fiction" },
                    new Category { Id = 10, Name = "Short Stories" },
                    new Category { Id = 11, Name = "Suspense and Thrillers" }
                );
            #endregion

            #region Book entity
            modelBuilder.Entity<Book>()
                .HasData(
                    new Book { Id = 1, Name = "Life of Pi", Authors = "Yann Martel", CategoryId = 1, Description = "Generic description" },
                    new Book { Id = 2, Name = "The Three Musketeers", Authors = "Alexandre Dumas", CategoryId = 1, Description = "Generic description" },
                    new Book { Id = 3, Name = "The Call of the Wild", Authors = "Jack London", CategoryId = 1, Description = "Generic description" },
                    new Book { Id = 4, Name = "To Kill a Mockingbird", Authors = "Harper Lee", CategoryId = 2, Description = "Generic description" },
                    new Book { Id = 5, Name = "Little Women", Authors = "Louisa May Alcott", CategoryId = 2, Description = "Generic description" },
                    new Book { Id = 6, Name = "Beloved", Authors = "Toni Morrison", CategoryId = 2, Description = "Generic description" },
                    new Book { Id = 7, Name = "Watchmen", Authors = "Alan Moore, Dave Gibbons", CategoryId = 3, Description = "Generic description" },
                    new Book { Id = 8, Name = "The Boy, the Mole, the Fox and the Horse", Authors = "Charlie Mackery", CategoryId = 3, Description = "Generic description" },
                    new Book { Id = 9, Name = "The Night Fire", Authors = "Michael Connelly", CategoryId = 4, Description = "Generic description" },
                    new Book { Id = 10, Name = "The Adventures of Sherlock Holmes", Authors = "Sir Arthur Conan Doyle", CategoryId = 4, Description = "Generic description" },
                    new Book { Id = 11, Name = "And Then There Were None", Authors = "Agatha Christie", CategoryId = 4, Description = "Generic description" },
                    new Book { Id = 12, Name = "The Water Dancer", Authors = "Ta-Nehisi Coates", CategoryId = 5, Description = "Generic description" },
                    new Book { Id = 13, Name = "Circe", Authors = "Madeline Miller", CategoryId = 5, Description = "Generic description" },
                    new Book { Id = 14, Name = "Ninth House", Authors = "Leigh Bardugo", CategoryId = 5, Description = "Generic description" },
                    new Book { Id = 15, Name = "The Help", Authors = "Kathryn Stockett", CategoryId = 6, Description = "Generic description" },
                    new Book { Id = 16, Name = "One Hundred Years of Solitude", Authors = "Gabriel Garcia Marquez", CategoryId = 6, Description = "Generic description" },
                    new Book { Id = 17, Name = "Memoirs of a Geisha", Authors = "Arthur Golden", CategoryId = 6, Description = "Generic description" },
                    new Book { Id = 18, Name = "Carrie", Authors = "Stephen King", CategoryId = 7, Description = "Generic description" },
                    new Book { Id = 19, Name = "The Haunting of Hill House", Authors = "Shirley Jackson", CategoryId = 7, Description = "Generic description" },
                    new Book { Id = 20, Name = "Bird Box", Authors = "Josh Malerman", CategoryId = 7, Description = "Generic description" },
                    new Book { Id = 21, Name = "Where the Crawdads Sing", Authors = "Delia Owens", CategoryId = 8, Description = "Generic description" },
                    new Book { Id = 22, Name = "Olive, Again", Authors = "Elizabeth Strout", CategoryId = 8, Description = "Generic description" },
                    new Book { Id = 23, Name = "The Dutch House", Authors = "Ann Patchett", CategoryId = 8, Description = "Generic description" },
                    new Book { Id = 24, Name = "Brazen and the Beast", Authors = "Sarah MacLean", CategoryId = 9, Description = "Generic description" },
                    new Book { Id = 25, Name = "Royal Holiday", Authors = "Jasmine Guillory", CategoryId = 9, Description = "Generic description" },
                    new Book { Id = 26, Name = "The Savior", Authors = "J. R. Ward", CategoryId = 9, Description = "Generic description" },
                    new Book { Id = 27, Name = "The Testaments", Authors = "Margaret Atwood", CategoryId = 10, Description = "Generic description" },
                    new Book { Id = 28, Name = "The Hunger Games Trilogy", Authors = "Suzanne Collins", CategoryId = 10, Description = "Generic description" },
                    new Book { Id = 29, Name = "1984", Authors = "George Orwell", CategoryId = 10, Description = "Generic description" },
                    new Book { Id = 30, Name = "This Is How You Lose Her", Authors = "Junot Diaz", CategoryId = 11, Description = "Generic description" },
                    new Book { Id = 31, Name = "Florida", Authors = "Lauren Groff", CategoryId = 11, Description = "Generic description" },
                    new Book { Id = 32, Name = "How Long 'Til Black Future Month?", Authors = "N. K. Jemisin", CategoryId = 11, Description = "Generic description" }
                );
            #endregion

            #region User entity
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "admin",
                        LastName = "admin",
                        DOB = new DateTime(1980, 01, 01),

                        Username = "admin",
                        Password = "12345",
                        Role = UserRole.PowerUser
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Bob",
                        LastName = "McFarland",
                        DOB = new DateTime(1997, 01, 01),

                        Username = "bob97",
                        Password = "bob97",
                        Role = UserRole.NormalUser
                    }
                );
            #endregion
        }
    }
}
