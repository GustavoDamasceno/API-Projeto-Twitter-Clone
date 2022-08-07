using API_ProjetoTwitter.ModeloDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ProjetoTwitter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Inclui usuário no banco de dados [DB.ProjetoTwitter] na tabela [T_USUARIOSS].
        /// </summary>
        /// <returns>string de sucesso</returns>
        /// <response code="200">Returna uma string de sucesso</response>
        [HttpPost("IncluirUsuario")]
        public string Post(Usuarios usuario)
        {
            try
            {
                // Chamando método para inserir usuario no banco
                UsuarioDAO InserindoUsuarioNoBanco = new UsuarioDAO();
                InserindoUsuarioNoBanco.Inserir_Usuario(usuario);

                return "Usuario incluso no banco de dados, com sucesso.";
            }
            catch(Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Obtém os dados do usuário cadastrado no banco de dados [DB.ProjetoTwitter] na tabela [T_USUARIOSS].
        /// </summary>
        /// <returns>Dados cadastrais do usuário</returns>
        /// <response code="200">Returna os dados cadastrais do usuário, caso não encontrado no banco retona null</response>
        [HttpGet("ObterUsuario/{nome},{senha}")]
        public List<Usuarios> Login(string nome, string senha)
        {
            // Chamando método para obter usuario no banco
            UsuarioDAO resultado = new UsuarioDAO();
            Usuarios obtenha = resultado.ObterUsuario(nome, senha);

            string ValidarUser = obtenha.Username;
            string ValidarSenha = obtenha.Senha;

            if (ValidarUser == nome && ValidarSenha == senha)
            {
                List<Usuarios> listaComInformacaoDoUser = new List<Usuarios>();
                listaComInformacaoDoUser.Add(obtenha);

                return listaComInformacaoDoUser;

            }
            else
            {
                return null;
            }


        }
    }
}
