using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public EstudioDomain Estudio { get; set; }

        [Required(ErrorMessage = "O id do estudio precisa ser informado!")]
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O Nome do jogo jrecisa ser informado!")]
        [StringLength(100, ErrorMessage = "Você excedeu o limete de caracteres que é 100!")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "A descrição do jogo precisa ser informado!")]
        [StringLength(400, ErrorMessage = "Você excedeu o limete de caracteres que é 400!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento do jogo precisa ser informado!")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo precisa ser informado!")]
        public decimal Valor { get; set; }
    }
}
