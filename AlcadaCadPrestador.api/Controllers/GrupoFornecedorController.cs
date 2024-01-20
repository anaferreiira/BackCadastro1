using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Signa.TemplateCore.Api.Business;
using Signa.TemplateCore.Api.Domain.Models;
using System.Collections.Generic;

namespace Signa.TemplateCore.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
   // [Authorize("Bearer")]
    public class GrupoFornecedorController : Controller
    {
        private readonly GrupoFornecedorBL _grupo;

        public GrupoFornecedorController(GrupoFornecedorBL grupo)
        {
            _grupo = grupo;
        }

        /// <summary>
        /// Busca todos os prestadores que estão vinculados a esse grupoo na base de dados
        /// </summary>
        /// <response code="200">Pessoas cadastradas na base de dados</response>
        /// <response code="404">Nenhuma pessoa encontrada na base de dados</response>
        [HttpGet]
        [Route("Grupo")]
        public ActionResult<IEnumerable<GrupoFornecedorModel>> Get(string nomeFornecedor) => Ok(_grupo.Get(nomeFornecedor));

    }
}
