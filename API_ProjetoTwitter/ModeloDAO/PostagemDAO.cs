using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;
using API_ProjetoTwitter.Models;

namespace API_ProjetoTwitter.ModeloDAO
{
    public class PostagemDAO
    {
        public void Inserir_Postagem(Postagens posstagem)

        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\localdb;Initial Catalog=DB.ProjetoTwitter;Integrated Security=True");

            try
            {
                // Conexão com o banco de dados
                con.Open();

                // Inserindo dados no banco de dados
                StringBuilder strSQL = new StringBuilder();

                string Tabela = "T_POSTAGENSS";

                strSQL.AppendFormat(" INSERT INTO {0} ", Tabela);
                strSQL.Append(" ( ");
                strSQL.Append("      id_usuario, ");
                strSQL.Append("      postagem, ");
                strSQL.Append("      data, ");
                strSQL.Append("      hora ");
                strSQL.Append(" ) ");
                strSQL.Append(" VALUES( ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(posstagem.Id_usuario) ? posstagem.Id_usuario : "''") + "', ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(posstagem.Postagem) ? posstagem.Postagem : "''") + "', ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(posstagem.Data) ? posstagem.Data : "''") + "', ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(posstagem.Hora) ? posstagem.Hora : "''") + "' ");
                strSQL.Append(" ) ");

                SqlCommand comandoInserir = new SqlCommand(strSQL.ToString(), con);
                comandoInserir.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Fechando conexão com o banco de dados
                con.Close();
            }
        }

        public List<Postagens> ObterPostagensDeUmUser(string id_usuario)
        {

            try
            {
                List<Postagens> listaDePostagensDoUsuario = new List<Postagens>();
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\localdb;Initial Catalog=DB.ProjetoTwitter;Integrated Security=True"))
                {
                    string oString = ("SELECT * FROM T_POSTAGENSS WHERE id_usuario=@id_usuario");
                    SqlCommand oCmd = new SqlCommand(oString, con);
                    oCmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                    // Conexão com o banco de dados
                    con.Open();

                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaDePostagensDoUsuario.Add(new Postagens() { Id_post = oReader["id_post"].ToString(), Id_usuario = oReader["id_usuario"].ToString(), Postagem = oReader["postagem"].ToString(), Data = oReader["data"].ToString(), Hora = oReader["hora"].ToString() });
                        }

                        // Fechando conexão com o banco de dados
                        con.Close();
                    }
                }
                return listaDePostagensDoUsuario;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Postagens> ObterTodasAsPostagens()
        {
            try
            {
                List<Postagens> listaDeTodasAsPostagens = new List<Postagens>();
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\localdb;Initial Catalog=DB.ProjetoTwitter;Integrated Security=True"))
                {
                    string oString = ("SELECT * FROM T_POSTAGENSS");
                    SqlCommand oCmd = new SqlCommand(oString, con);

                    // Conexão com o banco de dados
                    con.Open();

                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaDeTodasAsPostagens.Add(new Postagens() { Id_post = oReader["id_post"].ToString(), Id_usuario = oReader["id_usuario"].ToString(), Postagem = oReader["postagem"].ToString(), Data = oReader["data"].ToString(), Hora = oReader["hora"].ToString() });
                        }

                        // Fechando conexão com o banco de dados
                        con.Close();
                    }
                }
                return listaDeTodasAsPostagens;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarPostagem(string id_post)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\localdb;Initial Catalog=DB.ProjetoTwitter;Integrated Security=True"))
                {
                    using (var cmd = con.CreateCommand())
                    {
                        // Conexão com o banco de dados
                        con.Open();
                        cmd.CommandText = "DELETE FROM T_POSTAGENSS WHERE id_post=@id_post";
                        cmd.Parameters.AddWithValue("@id_post", id_post);
                        cmd.ExecuteNonQuery();
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
