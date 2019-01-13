using Music.Domain.Entities;
using Music.Domain.Interfaces;
using Music.Domain.Interfaces.Repositories;
using Music.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Domain.Services
{
    public class ArtistService : Service<Artist>, IArtistService
    {
        private readonly IArtistRepository songRepository;

        public ArtistService(IArtistRepository repository) : base(repository)
        {
            songRepository = repository;
        }
    }
}
