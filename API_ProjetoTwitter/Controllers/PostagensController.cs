using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ProjetoTwitter.ModeloDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_ProjetoTwitter.Models;

namespace API_ProjetoTwitter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostagensController : ControllerBase
    {
        /// <summary>
        /// Inclui postagem no banco de dados [DB.ProjetoTwitter] na tabela [T_POSTAGENSS].
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "id_usuario": "string",
        ///        "postagem": "string",
        ///        "data": "dd/mm/aaaa",
        ///        "hora": "hh:mm"
        ///     }
        ///
        /// </remarks>
        /// <returns>string de sucesso</returns>
        /// <response code="200">Returna uma string de sucesso</response>
        [HttpPost("IncluirPostagem")]
        public string Post (Postagens posstagem)
        {
            try
            {
                // Chamando método para inserir postagem no banco
                PostagemDAO InserindoPostagemNoBanco = new PostagemDAO();
                InserindoPostagemNoBanco.Inserir_Postagem(posstagem);

                return "Postagem incluida concluída, com sucesso!";
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Obtém os dados de todas as postagens disponíveis no banco de dados [DB.ProjetoTwitter] na tabela [T_POSTAGENSS].
        /// </summary>
        /// <returns>string de sucesso</returns>
        /// <response code="200">Returna os dados de todas as postagens disponíveis no banco de dados.</response>
        [HttpGet("ObterPostagens/")]
        public List<Postagens> Getda()
        {
            // Chamando método para obter todas as postagens do banco
            PostagemDAO ObtendoPostagensDeUmUser = new PostagemDAO();

            return ObtendoPostagensDeUmUser.ObterTodasAsPostagens();
        }

        /// <summary>
        /// Obtém os dados da postagem de um terminado usuário.
        /// </summary>
        /// <returns>string de sucesso</returns>
        /// <response code="200">Returna os dados das postagens do usuário</response>
        [HttpGet("ObterPostagens/{id_usuario}")]
        public List<Postagens> Get(string id_usuario)
        {
            // Chamando método para obter todas as postagens de um usuário especifico
            PostagemDAO ObtendoPostagensDeUmUser = new PostagemDAO();

            return ObtendoPostagensDeUmUser.ObterPostagensDeUmUser(id_usuario);
        }

        /// <summary>
        /// Edita uma postagem e retorna os novos dados da postagem.
        /// </summary>
        /// <returns>string de sucesso</returns>
        /// <response code="200">Returna os novos dados da postagem</response>
        [HttpPut("EditarPostagem/{id_post}")]
        public string Put()
        {
            return "sds";
        }

        /// <summary>
        /// Exclui a postagem do banco de dados [DB.ProjetoTwitter] na tabela [T_POSTAGENSS].
        /// </summary>
        /// <returns>string de sucesso</returns>
        /// <response code="200">Returna os dados da postagem</response>
        [HttpDelete("ExcluirPostagem/{id_post}")]
        public string Delete(string id_post)
        {
            // Chamando método para Deletar postagem
            PostagemDAO DeletandoPostagem = new PostagemDAO();

            DeletandoPostagem.DeletarPostagem(id_post);

            return "Tweet deletado com sucesso!";
        }

    }
}
