using AutoMapper;
using Music.Domain.Entities;
using Music.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Song, SongViewModel>();
            CreateMap<Artist, ArtistViewModel>();
            CreateMap<Style, StyleViewModel>();
        }
    }
}