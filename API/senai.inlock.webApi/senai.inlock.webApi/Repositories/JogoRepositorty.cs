using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepositorty : IJogoRepository
    {
        private string StringConexao = "data source=HALLISONSIARA\\SQLEXPRESS; initial Catalog=T_Rental_Israel; user Id=sa; pwd=senai@132";

        public void AtualizarPorUrl(int id, JogoDomain JogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdate = "update Jogo set NomeEstudio = @Nome, Descricao = @Descricao, DataLancamento = @Data, @preco where idEstudio = @IdJogo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", JogoAtualizado.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", JogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@Data", JogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@preco", JogoAtualizado.Valor);

                    cmd.ExecuteReader();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryListar = "select Estudio.NomeEstudio, NomeJogo, Descricao, DataLancamento, Valor from Jogo inner join Estudio on jogo.IdEstudio = Estudio.IdEstudio where IdJogo = @id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryListar, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain JogoBuscado = new JogoDomain
                        {
                            Estudio = new EstudioDomain()
                            {
                                NomeEstudio = rdr[0].ToString()
                            },
                            NomeJogo = rdr[1].ToString(),
                            Descricao = rdr[2].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[3]),
                            Valor = Convert.ToDecimal(rdr[4])
                        };

                        return JogoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain NovoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "insert into Jogo (IdEstudio, NomeJogo, Descricao, DataLancamento, Valor) values(@IdEstudio, @NomeJogo, @Descrição, @Data, @Valor),";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", NovoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@NomeJogo", NovoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descrição", NovoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@Data", NovoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", NovoJogo.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "Delete Jogo Where IdJogo = @id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListarJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryList = "select Estudio.NomeEstudio, NomeJogo, Descricao, DataLancamento, Valor from Jogo inner join Estudio on jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryList, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain Jogos = new JogoDomain()
                        {
                            Estudio = new EstudioDomain()
                            {
                                NomeEstudio = rdr[0].ToString()
                            },
                            NomeJogo = rdr[1].ToString(),
                            Descricao = rdr[2].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[3]),
                            Valor = Convert.ToDecimal(rdr[4])
                        };
                        ListarJogo.Add(Jogos);
                    }
                }
            }
                    return ListarJogo;
        }
    }
}
