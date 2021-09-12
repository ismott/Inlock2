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
        private string StringConexao = "data source=HALLISONSIARA\\SQLEXPRESS; initial Catalog=T_Rental_Israel; user Id=sa; pwd=senai@132";
        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryLog = "select Email, Senha, IdTipoUsuario from Usuario where Email = @email and Senha = @senha";

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
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            Email = rdr[2].ToString(),
                            Senha = rdr[3].ToString()
                        };

                        return UsuarioBuscado;
                    }
                    return null;
                }
            }
        }
    }
}
