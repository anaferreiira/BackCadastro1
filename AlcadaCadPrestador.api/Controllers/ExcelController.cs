using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Signa.TemplateCore.Api.Business;
using Signa.TemplateCore.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Signa.TemplateCore.Api.Controllers
{

    [ApiController]
    [Produces("application/json")]
   // [Authorize("Bearer")]
  
    public class ExcelController : Controller
    {
        private readonly ExcelBL _excelBLL;

        public ExcelController(ExcelBL excelBLL)
        {
            _excelBLL = excelBLL;
        }

        [HttpPost]
        [Route("excel")]
        public ActionResult<string> GerarExcel(ExcelModel dadosPlanilha) => Ok(_excelBLL.GerarExcel(dadosPlanilha));
    }
}