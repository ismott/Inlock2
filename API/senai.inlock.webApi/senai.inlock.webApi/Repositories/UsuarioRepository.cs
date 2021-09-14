using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "data source=HALLISONSIARA\\SQLEXPRESS; initial Catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";
        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryLog = "SELECT IdUsuario, Email, U.IdTipoUsuario, TU.Titulo FROM usuario U INNER JOIN tipoUsuario TU ON U.idTipoUsuario = TU.idTipoUsuario WHERE email = @email AND senha = @senha";

                con.Open();
                

                using (SqlCommand cmd = new SqlCommand(QueryLog, con))
                {
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@senha", Senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain UsuarioBuscado = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Email = rdr["Email"].ToString(),
                            TipoUsuario = new TipoUsuarioDomain()
                            { 
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };

                        return UsuarioBuscado;
                    }
                    return null;
                }
            }
        }
    }
}
