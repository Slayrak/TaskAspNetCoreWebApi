using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAspNetCoreWebApi.Domain.Models
{
    public class Review
    {
        public long? Id { get; set; }

        public string? Message { get; set; }

        public long? BookId { get; set; }
        public Book? Book { get; set; }

        public string? Reviewer { get; set; }
    }
}
