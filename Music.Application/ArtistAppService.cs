using Music.Application.Interface;
using Music.Domain.Entities;
using Music.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Application
{
    public class ArtistAppService : AppService<Artist>, IArtistAppService
    {
        private readonly IArtistService service;

        public ArtistAppService(IArtistService service) : base(service)
        {
            this.service = service;
        }
    }
}
