using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.Business.MapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<BookDTO, Book>();

            CreateMap<Book, BookDTO>()
                .ForMember(x => x.ReviewsNumber, opt => opt.Ignore())
                .ForMember(x => x.Rating, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title));
        }

    }
}
