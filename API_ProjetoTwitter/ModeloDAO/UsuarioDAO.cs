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

        public string ObterUsuario(string nome, string senha)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\localdb;Initial Catalog=DB.ProjetoTwitter;Integrated Security=True");

            try
            {
                // Conexão com o banco de dados
                con.Open();

                // Inserindo dados no banco de dados
                string Tabela = "T_USUARIOSS";
                string strSQL = ("SELECT * FROM " + Tabela + "WHERE username='"+nome+"'");
                string strSQL2 = ("SELECT * FROM " + Tabela + "WHERE username='" + senha + "'");

                SqlCommand cmd = new SqlCommand(strSQL.ToString(), con);

                SqlCommand cmd2 = new SqlCommand(strSQL2.ToString(), con);

                if (cmd != null && cmd2 != null)
                {
                    return "Usuário válido";
                }
                else
                {
                    return "Usuário não existe";
                }



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

    }
}
