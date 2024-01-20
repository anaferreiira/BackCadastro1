using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using Signa.TemplateCore.Api.Business;
using Signa.TemplateCore.Api.Domain.Models;

namespace Signa.TemplateCore.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    //[Authorize("Bearer")]
    public class AlcadaAcessoController : Controller
    {
        private readonly AlcadaAcessoBL _alcada;

        public AlcadaAcessoController(AlcadaAcessoBL alcada)
        {
            _alcada = alcada;
        }
        /// <summary>
        /// Busca todas as pessoas na base de dados
        /// </summary>
        /// <response code="200">Pessoas cadastradas na base de dados</response>
        /// <response code="404">Nenhuma pessoa encontrada na base de dados</response>


        [HttpGet]
        [Route("AlcadaAcesso")]
        public ActionResult<IEnumerable<AlcadaAcessoModel>> Get() => Ok(_alcada.Get());

        /// <summary>
        /// Grava ou atualiza dados de Pessoa
        /// </summary>
        /// <remarks>
        /// Exemplo gravação:
        ///
        ///     POST /alcadaAcesso
        ///     {
        ///      "alcadaAcessoId": 0,
        ///      "usuarioId": 0,
        ///      "tabStatusId": 0,
        ///      "nomeUsuario": "string"
        ///     }
        ///
        /// Exemplo atualização:
        ///
        ///     POST /alcadaAcesso
        ///     {
        ///      "alcadaAcessoId": 1,
        ///     "usuarioId": 5,
        ///    "tabStatusId": 1,
        ///      "nomeUsuario": "signa"
        ///     }
         /// </remarks>
        /// <response code="200">Pessoa criada ou atualizada</response>
        /// <response code="404">Erro na inserção ou atualização, pessoa não encontrada na busca para retornar os dados</response>

        [HttpPost]
        [Route("AlcadaAcesso")]
        public ActionResult<AlcadaAcessoModel> Insert(AlcadaAcessoModel acesso) => Ok(_alcada.Insert(acesso));

        /// <summary>
        /// Exclui uma pessoa através do ID
        /// </summary>
        /// <response code="200">Mensagem de pessoa excluída com sucesso</response>


        [HttpDelete]
        [Route("AlcadaAcesso/{ID}")]
        public ActionResult<AlcadaAcessoModel> Delete(int IdUsuario, int idAlcadaAcesso)
        {
            _alcada.Delete(IdUsuario, idAlcadaAcesso);
            return Ok();
        }
 
    }
}
