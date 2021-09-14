using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class TipoUsuarioDomain
    {
        [JsonIgnore]
        public int IdTipoUsuario { get; set; }

        public string Titulo { get; set; }
    }
}
