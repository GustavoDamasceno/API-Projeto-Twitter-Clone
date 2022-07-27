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

        [HttpGet("obterUsuario")]
        public string Login(string nome, string senha)
        {
            string resultado;
            // Chamando método para inserir usuario no banco
            UsuarioDAO InserindoUsuarioNoBanco = new UsuarioDAO();
            resultado = InserindoUsuarioNoBanco.ObterUsuario(nome, senha);

            return resultado;


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
