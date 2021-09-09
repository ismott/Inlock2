using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public EstudioDomain Estudio { get; set; }

        public int IdEstudo { get; set; }

        public string NomeJogo { get; set; }

        public string Descricao { get; set; }

        public string DataLancamento { get; set; }

        public string Valor { get; set; }
    }
}
