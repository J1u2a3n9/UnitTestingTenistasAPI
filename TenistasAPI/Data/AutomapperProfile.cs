using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TenistasAPI.Data.Entities;
using TenistasAPI.Models;

namespace TenistasAPI.Data
{
    [ExcludeFromCodeCoverage]
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<TennisPlayerModel, TennisPlayerEntity>()
                 .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest =>dest.TotalTitles,opt=>opt.MapFrom(src=>src.CareerTitles))
                 .ForMember(dest => dest.Ranking, opt => opt.MapFrom(src => src.CurrentRanking))
                 .ReverseMap();
            this.CreateMap<TourneyModel, TourneyEntity>()
                .ReverseMap();
        }
    }
}



