using Dapper;
using NPOI.SS.Formula.Functions;
using Signa.Library.Core.Data.Repository;
using Signa.TemplateCore.Api.Business;
using Signa.TemplateCore.Api.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System;
using System.Linq;

namespace Signa.TemplateCore.Api.Data.Repository
{
    //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede

    public class pesquisaDAO : RepositoryBase
    {
        public IEnumerable<PesquisaEntity> Get(int IN_TAB_STATUS_ID, int? IN_GRUPO_FORNECEDOR_ID, int? IN_Grupo_Usuario_Id, int? IN_USUARIO_ID)
        {

            var sp = "SP_040_PESQ_ALCADA_ACESSO05";
            var param = new
            {
                IN_USUARIO_ID,
                IN_TAB_STATUS_ID,
                IN_GRUPO_FORNECEDOR_ID,
                IN_Grupo_Usuario_Id,

            };
            using (var db = Connection)
            {
                return db.Query<PesquisaEntity>(sp, param, commandType: CommandType.StoredProcedure);

            }
        } 
        //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede, quando a primeira tabela fizer um filtro de usuario, na segunda tabela vai
        // estar trazendo seus codigos de prestadores.
        public List<PesquisaCodEntity> PesquisaCod(int id)
        {
            var sp = "SP_040_CON_LIST_ALCADA_ACESSO_PREST02";
            var param = new { IN_ALCADA_ACESSO_ID = id };
            using (var db = Connection)
            {
                return db.Query<PesquisaCodEntity>(sp, param, commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}
