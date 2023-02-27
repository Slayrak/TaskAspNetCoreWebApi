using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll(string order);

        Task<Book> GetBook(long id);

        Task Delete(long id);

        Task<long> AddBook(Book book);

        Task<long> AddReview(long id, Review reviewDTO);

        Task AddRating(long id, Rating ratingDTO);

        Task<IEnumerable<Book>> GetRecommends(string genre);

    }
}
