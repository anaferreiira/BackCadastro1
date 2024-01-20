using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Signa.TemplateCore.Api.Business;
using Signa.TemplateCore.Api.Domain.Entities;
using Signa.TemplateCore.Api.Domain.Models;
using System;
using System.Collections.Generic;

namespace Signa.TemplateCore.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    //[Authorize("Bearer")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioBL _usuario;

        public UsuarioController(UsuarioBL usuario)
        {
            _usuario = usuario;

        }
        /// <summary>
        /// Busca uma pessoa através do ID
        /// </summary>
        /// <param name="id">ID da pessoa</param>
        /// <returns>Dados da pessoa</returns>
        /// <response code="200">Pessoa cadastrada na base de dados</response>
        /// <response code="404">Pessoa não encontrada na busca</response>
        [HttpGet]
        [Route("Usuario/{nomeUsuario}")]
        public ActionResult<IEnumerable<UsuarioModel>> Get(string nomeUsuario) => Ok(_usuario.Get(nomeUsuario));

    }
}
