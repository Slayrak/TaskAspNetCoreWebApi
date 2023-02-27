using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.Interfaces;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Book> FindById(long id)
        {
            return await _appDbContext.Books.Include(x => x.Reviews).Include(x => x.Ratings).FirstAsync(x => x.Id == id);
        }

        public async Task<long> Create(Book entity)
        {
            long? resultId = 0;

            if(_appDbContext.Books.Any(x => x.Id == entity.Id))
            {
                var bytes = Encoding.UTF8.GetBytes(entity.Cover);

                entity.Cover = Convert.ToBase64String(bytes);

                _appDbContext.Books.Update(entity);

                resultId = entity.Id;
            } else
            {
                var bytes = Encoding.UTF8.GetBytes(entity.Cover);

                entity.Cover = Convert.ToBase64String(bytes);

                var book = await _appDbContext.Books.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                resultId = entity.Id;
            }

            await _appDbContext.SaveChangesAsync();

            return (long)resultId;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _appDbContext.Books.Include(x => x.Reviews).Include(x => x.Ratings).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetTop10(string genre)
        {
            return await _appDbContext.Books
                .Include(x => x.Reviews)
                .Include(x => x.Ratings)
                .Where(x => x.Reviews.Count() > 10 && x.Genre == genre)
                .OrderByDescending(x => x.Ratings.Select(x => x.Score).Average())
                .Take(10)
                .ToListAsync();
        }

        public async Task Delete(long id)
        {
            _appDbContext.Books.Remove(await _appDbContext.Books.Include(x => x.Reviews).Include(x => x.Ratings).FirstAsync(x => x.Id == id));

            _appDbContext.SaveChanges();
        }
    }
}
