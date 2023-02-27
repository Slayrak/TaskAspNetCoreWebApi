using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAspNetCoreWebApi.Domain.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }

        public decimal? Rating { get; set; }

        public int? ReviewsNumber { get; set; }
    }
}
