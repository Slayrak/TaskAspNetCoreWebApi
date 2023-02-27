using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.DTO;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.Business.MapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile() 
        {
            CreateMap<ReviewDTO, Review>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Message, opt => opt.MapFrom(srs => srs.Message))
                .ForMember(x => x.BookId, opt => opt.Ignore())
                .ForMember(x => x.Reviewer, opt => opt.MapFrom(srs => srs.Reviewer))
                .ForMember(x => x.Book, opt => opt.Ignore());

            CreateMap<Review, ReviewDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(srs => srs.Id))
                .ForMember(x => x.Message, opt => opt.MapFrom(srs => srs.Message))
                .ForMember(x => x.Reviewer, opt => opt.MapFrom(srs => srs.Reviewer));

        }
    }
}
