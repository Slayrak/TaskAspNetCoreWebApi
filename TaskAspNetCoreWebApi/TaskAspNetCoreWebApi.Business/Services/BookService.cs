using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;
using TaskAspNetCoreWebApi.Domain.Interfaces;
using TaskAspNetCoreWebApi.Domain.Interfaces.Services;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IRatingRepository _ratingRepository;

        public BookService(IBookRepository bookRepository, IRatingRepository ratingRepository, IReviewRepository reviewRepository)
        {
            _bookRepository = bookRepository;
            _ratingRepository = ratingRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Book>> GetAll(string order)
        {
            var books = await _bookRepository.GetAll();

            if(order == "author")
            {
                books = books.OrderBy(x => x.Author).ToList();
            } else if(order == "title")
            {
                books = books.OrderBy(x => x.Title).ToList();
            }

            return books;
        }

        public async Task<Book> GetBook(long id)
        {
            return await _bookRepository.FindById(id);
        }

        public async Task Delete(long id)
        {
            await _bookRepository.Delete(id);
        }

        public async Task<long> AddBook(Book book)
        {
            await _bookRepository.Create(book);

            return (long)book.Id;
        }

        public async Task<long> AddReview(long id, Review review)
        {
            review.BookId = id;
            review.Book = await _bookRepository.FindById(id);

            return await _reviewRepository.Create(review);
        }

        public async Task AddRating(long id, Rating rating)
        {
            rating.BookId = id;
            rating.Book = await _bookRepository.FindById(id);

            await _ratingRepository.RateABook(rating);

        }

        public async Task<IEnumerable<Book>> GetRecommends(string genre)
        {
            var books = await _bookRepository.GetTop10(genre);

            return books;
        }

    }
}
