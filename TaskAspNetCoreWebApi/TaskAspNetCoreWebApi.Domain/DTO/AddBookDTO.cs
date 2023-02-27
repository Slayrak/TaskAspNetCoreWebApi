using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAspNetCoreWebApi.Domain.DTO
{
    public class AddBookDTO
    {
		public long? Id { get; set; }

		public string? Title { get; set; }

		public string? Cover { get; set; }

		public string? Content { get; set; }

		public string? Genre { get; set; }

		public string? Author { get; set; }

    }
}
