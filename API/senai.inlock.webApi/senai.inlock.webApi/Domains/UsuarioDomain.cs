using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class UsuarioDomain
    {
        [JsonIgnore]
        public int IdUsuario { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage ="O id do usuário precisa ser informado!")]
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage ="O email do usuário precisa ser informado!")]
        [StringLength(256, ErrorMessage = "Seu email não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário precisa ser informado!")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Sua senha precisa ter de 4 a 25 caracteres")]
        public string Senha { get; set; }
    }
}
