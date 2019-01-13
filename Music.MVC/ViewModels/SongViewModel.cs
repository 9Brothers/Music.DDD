using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music.MVC.ViewModels
{
    public class SongViewModel
    {
        [Key]
        public int IdSong { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Name { get; set; }
        public ArtistViewModel Artist { get; set; }
        public StyleViewModel Style { get; set; }
    }
}