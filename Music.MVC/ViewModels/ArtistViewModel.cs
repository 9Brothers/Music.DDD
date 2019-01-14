using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.MVC.ViewModels
{
    public class ArtistViewModel
    {
        [Key]
        public int IdArtist { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        //[MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        //[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Name { get; set; }
    }
}
