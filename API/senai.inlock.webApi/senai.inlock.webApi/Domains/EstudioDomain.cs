using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "Você precisa informar o nome do estudio")]
        [StringLength(50, ErrorMessage = "Você ultrapassou o limite maximo de caracteres que é 50!")]
        public string NomeEstudio { get; set; }
    }
}
