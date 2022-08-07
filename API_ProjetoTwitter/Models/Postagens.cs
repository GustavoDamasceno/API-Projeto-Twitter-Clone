using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_ProjetoTwitter.Models
{
    public class Postagens
    {
        [JsonProperty("id_post")]
        public string Id_post { get; set; }

        [JsonProperty("id_usuario")]
        public string Id_usuario { get; set; }

        [JsonProperty("postagem")]
        public string Postagem { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("hora")]
        public string Hora { get; set; }

    }
}
