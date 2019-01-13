using Music.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Application.Interface
{
    public interface ISongAppService : IAppService<Song>
    {
    }
}
