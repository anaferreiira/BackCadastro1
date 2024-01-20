using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Mvc;
using Signa.TemplateCore.Api.Business;
using Signa.TemplateCore.Api.Domain.Models;
using System;
using System.Collections.Generic;

namespace Signa.TemplateCore.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    //[Authorize("Bearer")]
    public class PesquisaController : Controller
    {

        private readonly PesquisaBL _pesquisa;

        public PesquisaController(PesquisaBL pesquisa)
        {
            _pesquisa = pesquisa;
        }

        /// <summary>
        ///Busca dados das pessoas para fazer a formação da tabela ultizando os seus parametros de entrada
        /// </summary>
        /// <remarks>
        /// exemplo:
        /// IN_TAB_STATUS_ID:
        /// IN_GRUPO_FORNECEDOR_ID:
        /// IN_Grupo_Usuario_Id:
        /// IN_USUARIO_ID:
        ///Exemplo atualização:
        ///  {
        /// "codigoId": 36,
        /// "usuario": "AEROSOFT",
        ///  "usuarioid": "5",
        ///  "pesquisaCod": []
        ///  }
        ///   </remarks>
        /// <response code="200">Pessoas cadastradas na base de dados</response>
        /// <response code="404">Nenhuma pessoa encontrada na base de dados</response>

        [HttpGet]
       
        [Route("Pesquisa")]
        public ActionResult<IEnumerable<PesquisaModel>> Get(int IN_TAB_STATUS_ID, int? IN_GRUPO_FORNECEDOR_ID, int? IN_Grupo_Usuario_Id,
        int? IN_USUARIO_ID) =>
         Ok(_pesquisa.Get(IN_TAB_STATUS_ID, IN_GRUPO_FORNECEDOR_ID, IN_Grupo_Usuario_Id,
        IN_USUARIO_ID));

        /// <summary>
        ///Busca dados das pessoas para fazer a formação da tabela ultizando os seus parametros de entrada, trazendo o resultado 
        ///com uma tabela de dados
        /// </summary>
        /// <remarks>
        ///exemplo:
        ///
        /// exemplo:
        /// ID:5
         ///Exemplo atualização:
        ///  {
        /// "alcadA_PREST_ID":  1032,
        ///  "prestador": "TRANSCAVALINHO",
        ///  "cnpJ_PRESTADOR": "88473731000529"
        ///  }
        ///  </remarks>
        /// <response code="200">Pessoas cadastradas na base de dados</response>
        /// <response code="404">Nenhuma pessoa encontrada na base de dados</response>
       


        [HttpGet]

        [Route("PesquisaCod")]
        public ActionResult <List<PesquisaCodModel>> Get(int id)
        {
            var result = _pesquisa.PesquisaCod(id);
            return Ok(result);
        }

    }
}
