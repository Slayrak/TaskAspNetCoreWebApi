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
    public class AddBookProfile : Profile
    {
        public AddBookProfile() 
        {
            CreateMap<AddBookDTO, Book>()
                .ForMember(x => x.Id, opt => opt.MapFrom(srs => srs.Id))
                .ForMember(x => x.Author, opt => opt.MapFrom(srs => srs.Author))
                .ForMember(x => x.Cover, opt => opt.MapFrom(srs => srs.Cover))
                .ForMember(x => x.Title, opt => opt.MapFrom(srs => srs.Title))
                .ForMember(x => x.Content, opt => opt.MapFrom(srs => srs.Content))
                .ForMember(x => x.Genre, opt => opt.MapFrom(srs => srs.Genre))
                .ForMember(x => x.Ratings, opt => opt.Ignore())
                .ForMember(x => x.Reviews, opt => opt.Ignore());
        }
    }
}
