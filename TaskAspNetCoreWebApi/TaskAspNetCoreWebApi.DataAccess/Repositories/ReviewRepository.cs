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
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _appDbContext;

        public ReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Review> FindById(long id)
        {
            var res = await _appDbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }

        public async Task<long> Create(Review entity)
        {
            await _appDbContext.Reviews.AddAsync(entity);
            _appDbContext.SaveChanges();

            return (long)entity.Id;
        }
    }
}
