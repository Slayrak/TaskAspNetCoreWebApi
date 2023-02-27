using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.Domain.DTO
{
    public class ReviewDTO
    {
        public long? Id { get; set; }

        public string? Message { get; set; }

        public string? Reviewer { get; set; }
    }
}
