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
    public class RatingProfile : Profile
    {
        public RatingProfile() 
        {
            CreateMap<Rating, RatingDTO>()
                .ForMember(x => x.Score, opt => opt.MapFrom(srs => srs.Score));

            CreateMap<RatingDTO, Rating>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Score, opt => opt.MapFrom(srs => srs.Score));
        }
    }
}
