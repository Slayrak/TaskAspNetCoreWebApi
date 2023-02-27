using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAspNetCoreWebApi.Domain.Models
{
    public class Rating
    {
        public long? Id { get; set; }
        public long? BookId { get; set; }
        public Book? Book { get; set; }

        public double? Score { get; set; }
    }
}
