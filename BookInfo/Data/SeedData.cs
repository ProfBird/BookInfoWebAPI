using BookInfo.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookInfo.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Books.Any())
            {
                // Books by J. R. R. Tolkien
                Author author = new Author { Name = "J. R. R. Tolkien" };
                context.Authors.Add(author);

                Book book1 = new Book { Title = "Fellowship of the Ring", Date = DateTime.Parse("7/24/1954") }; // month/day/year
                context.Books.Add(book1);    // add the book to the dB Context
                author.Books.Add(book1);

                Book book2 = new Book { Title = "The Two Towers", Date = DateTime.Parse("1/1/1937") }; // month/day/year
                context.Books.Add(book2);    // add the book to the dB Context
                author.Books.Add(book2);

                Book book3 = new Book { Title = "The Return of the King", Date = DateTime.Parse("1/1/1937") }; // month/day/year
                context.Books.Add(book3);    // add the book to the dB Context
                author.Books.Add(book3);
                context.SaveChanges();      // save it so it gets an ID (PK value)

                // Book by C. S. Lewis
                Book book = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950") };
                context.Books.Add(book);
                context.SaveChanges();

                author = new Author { Name = "C. S. Lewis" };
                context.Authors.Add(author);
                author.Books.Add(book);

                // Book by Samuel Shellabarger
                author = new Author { Name = "Samuel Shellabarger" };
                context.Authors.Add(author);
 
                book = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947") };
                context.Books.Add(book);
                author.Books.Add(book);

                AppUser user1 = new AppUser { FirstName = "Walter", LastName = "Cronkite" };
                context.Users.Add(user1);
                Review review1 = new Review { ReviewText = "Great book, a must read!", Member = user1 };
                context.Reviews.Add(review1);
                book.Reviews.Add(review1);

                AppUser user2 = new AppUser { FirstName = "Jim", LastName = "Lehrer" };
                context.Users.Add(user2);
                Review review2 = new Review { ReviewText = "I thught it would have been better without the romance", Member = user2 };
                context.Reviews.Add(review2);
                book.Reviews.Add(review2);

                context.SaveChanges(); // save all the additions
            }
        }
    }
}

/* Code in Initialize is based on:
 * https://dotnetthoughts.net/seed-database-in-aspnet-core/
 */