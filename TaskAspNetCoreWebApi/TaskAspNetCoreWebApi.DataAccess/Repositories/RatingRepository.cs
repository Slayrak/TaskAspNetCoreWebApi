
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;
using TaskAspNetCoreWebApi.Domain.Interfaces;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.DataAccess.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _appDbContext;

        public RatingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task RateABook(Rating rating)
        {
            await _appDbContext.Ratings.AddAsync(rating);

            _appDbContext.SaveChanges();
        }
    }
}
