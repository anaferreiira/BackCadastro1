using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Signa.TemplateCore.Api.Domain.Models;
using System.Collections.Generic;
using System;
using Signa.TemplateCore.Api.Business;

namespace Signa.TemplateCore.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    //[Authorize("Bearer")]
    public class CadastroController : Controller
    {
        private readonly CadastroBL cadastroBL; public CadastroController(CadastroBL cadastroBL)
        {
            this.cadastroBL = cadastroBL;
        }
        /// <summary>
        /// Busca todos os prestadores que estão vinculados a esse grupoo na base de dados
        /// </summary>
        /// <response code="200">Pessoas cadastradas na base de dados</response>
        /// <response code="404">Nenhuma pessoa encontrada na base de dados</response>

        [HttpGet]
        [Route("grupoUsuario")] public ActionResult<IEnumerable<CadastroModel>> GrupoUsuario() => Ok(cadastroBL.GrupoUsuario());
    }
}