using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.DataAccess
{
    public static class DataSeed
    {
        public static void SeedData(AppDbContext appDbContext)
        {
            if(!appDbContext.Books.Any())
            {
                var bookList = new List<Book>();

                for (int i = 0; i < 10; i++)
                {
                    var book = new Book
                    {
                        Title = $"Not Dune{i}",
                        Cover = "",
                        Genre = "Science fiction",
                        Content = "Here we have book content",
                        Author = $"NotFrank NotHerbert{i}",

                    };

                    bookList.Add(book);
                }

                appDbContext.Books.AddRange(bookList);
                appDbContext.SaveChanges();

                var reviews = new List<Review>();

                for (int i = 0; i < bookList.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        var fake = new Faker<Review>()
                            .RuleFor(x => x.Message, x => x.Rant.Review())
                            .RuleFor(x => x.Reviewer, x => x.Person.FullName);

                        var review = fake.Generate();

                        review.BookId = i + 1;
                        reviews.Add(review);
                    }
                }

                appDbContext.Reviews.AddRange(reviews);
                appDbContext.SaveChanges();

                var ratings = new List<Rating>();

                for (int i = 0; i < bookList.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        var fake = new Faker<Rating>()
                            .RuleFor(x => x.Score, x => x.Random.Double(1, 5));

                        var score = fake.Generate();

                        score.BookId= i + 1;
                        ratings.Add(score);
                    }
                }

                appDbContext.Ratings.AddRange(ratings);
                appDbContext.SaveChanges();
            }
        }
    }
}
