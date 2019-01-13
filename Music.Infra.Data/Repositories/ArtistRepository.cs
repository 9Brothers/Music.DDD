using Music.Domain.Entities;
using Music.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Infra.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        
    }
}
