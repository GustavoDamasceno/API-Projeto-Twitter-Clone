using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_ProjetoTwitter
{
    public class Usuarios
    {
        [JsonProperty("id_usuario")]
        public string Id_usuario { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("biografia")]
        public string Biografia { get; set; }
    }
}
