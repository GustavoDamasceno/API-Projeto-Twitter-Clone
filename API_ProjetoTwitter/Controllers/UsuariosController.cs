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
    }
}
