using Music.Domain.Entities;
using Music.Domain.Interfaces.Repositories;
using Music.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Domain.Services
{
    public class StyleService : Service<Style>, IStyleService
    {
        private readonly IStyleRepository songRepository;

        public StyleService(IStyleRepository repository) : base(repository)
        {
            songRepository = repository;
        }
    }
}
