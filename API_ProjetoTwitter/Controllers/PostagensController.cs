using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ProjetoTwitter.ModeloDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_ProjetoTwitter.Controllers
{
    public class PostagensController
    {
        [HttpPost("IncluirPostagem")]
        public string Post()
        {
            return "sds";
        }
    }
}
