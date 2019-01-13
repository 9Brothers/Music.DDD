using AutoMapper;
using Music.Domain.Entities;
using Music.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<SongViewModel, Song>();
            CreateMap<ArtistViewModel, Artist>();
            CreateMap<StyleViewModel, Style>();
        }

        //public override string ProfileName => "ViewModelToDomainMappings";
    }
}