using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Domain.Entities
{
    public class Song
    {
        public int IdSong { get; set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public Style Style { get; set; }
    }
}
