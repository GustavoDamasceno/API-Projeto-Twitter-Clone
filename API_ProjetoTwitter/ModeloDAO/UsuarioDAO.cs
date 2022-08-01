using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;

namespace API_ProjetoTwitter.ModeloDAO
{
    public class UsuarioDAO
    {
        public void Inserir_Usuario(Usuarios usuario)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\localdb;Initial Catalog=DB.ProjetoTwitter;Integrated Security=True");

            try
            {
                // Conexão com o banco de dados
                con.Open();

                // Inserindo dados no banco de dados
                StringBuilder strSQL = new StringBuilder();

                string Tabela = "T_USUARIOSS";

                strSQL.AppendFormat(" INSERT INTO {0} ", Tabela);
                strSQL.Append(" ( ");
                strSQL.Append("      username, ");
                strSQL.Append("      nome, ");
                strSQL.Append("      senha, ");
                strSQL.Append("      email, ");
                strSQL.Append("      cidade, ");
                strSQL.Append("      biografia ");
                strSQL.Append(" ) ");
                strSQL.Append(" VALUES( ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(usuario.Username) ? usuario.Username : "''") + "', ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(usuario.Nome) ? usuario.Nome : "''") + "', ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(usuario.Senha) ? usuario.Senha : "''") + "', ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(usuario.Email) ? usuario.Email : "''") + "', ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(usuario.Cidade) ? usuario.Cidade : "''") + "', ");
                strSQL.Append(" '" + (!string.IsNullOrEmpty(usuario.Biografia) ? usuario.Biografia : "''") + "' ");
                strSQL.Append(" ) ");

                SqlCommand comandoInserir = new SqlCommand(strSQL.ToString(), con);
                comandoInserir.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                // Fechando conexão com o banco de dados
                con.Close();
            }

        }

        public Usuarios ObterUsuario(string nome, string senha)
        {

            try
            {
                Usuarios ObtendoUsuario = new Usuarios();
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\localdb;Initial Catalog=DB.ProjetoTwitter;Integrated Security=True"))
                {
                    string oString = ("SELECT * FROM T_USUARIOSS WHERE username=@fusername AND senha=@fsenha");
                    SqlCommand oCmd = new SqlCommand(oString, con);
                    oCmd.Parameters.AddWithValue("@fusername", nome);
                    oCmd.Parameters.AddWithValue("@fsenha", senha);

                    // Conexão com o banco de dados
                    con.Open(); ;

                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ObtendoUsuario.Id_usuario = oReader["id_usuario"].ToString();
                            ObtendoUsuario.Username = oReader["username"].ToString();
                            ObtendoUsuario.Nome = oReader["nome"].ToString();
                            ObtendoUsuario.Senha = oReader["senha"].ToString();
                            ObtendoUsuario.Email = oReader["email"].ToString();
                            ObtendoUsuario.Cidade = oReader["cidade"].ToString();
                            ObtendoUsuario.Biografia = oReader["biografia"].ToString();
                        }

                        // Fechando conexão com o banco de dados
                        con.Close();
                    }
                }
                return ObtendoUsuario;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
