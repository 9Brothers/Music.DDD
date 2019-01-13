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
    public class SongAppService : AppService<Song>, ISongAppService
    {
        private readonly ISongService service;

        public SongAppService(ISongService service) : base(service)
        {
            this.service = service;
        }
    }
}
