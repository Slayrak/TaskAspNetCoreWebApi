using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.Domain.Interfaces
{
    public interface IRatingRepository
    {
        Task RateABook(Rating rating);

    }
}
