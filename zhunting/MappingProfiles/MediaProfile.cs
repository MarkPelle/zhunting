using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.BLL;
using zhunting.Data.Models;

namespace zhunting.Core.MappingProfiles
{
    public class MediaProfile : Profile
    {
        public MediaProfile()
        {
            CreateMap<Media, GetMediaCollectionDTO>()
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.Url)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
