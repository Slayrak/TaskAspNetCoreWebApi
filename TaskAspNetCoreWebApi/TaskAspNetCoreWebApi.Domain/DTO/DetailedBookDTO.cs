﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAspNetCoreWebApi.Domain.DTO
{
    public class DetailedBookDTO
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Cover { get; set; }

        public string? Content { get; set; }

        public decimal Rating { get; set; }

        public ICollection<ReviewDTO>? Reviews { get; set; }

    }
}
