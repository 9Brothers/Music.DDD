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
    public class SongService : Service<Song>, ISongService
    {
        private readonly ISongRepository songRepository;

        public SongService(ISongRepository repository) : base(repository)
        {
            songRepository = repository;
        }
    }
}
