using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using Dapper;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Crypto.Digests;
using Signa.Library.Core.Data.Repository;
using Signa.TemplateCore.Api.Domain.Entities;

namespace Signa.TemplateCore.Api.Data.Repository
{
    //Usuando a SP(Procedure) para puxar nome dos prestadores
    public class GrupoFornecedorDAO : RepositoryBase
    {
        public IEnumerable<GrupoFornecedorEntity> Get(string nomeFornecedor)
        {
           
            var sp = "Select GRUPO_FORNECEDOR_ID, NOME From GRUPO_FORNECEDOR With (NoLock) WHERE TAB_STATUS_ID LIKE @NOME Order By NOME";
         
            var param = new
            {
                NOME = nomeFornecedor + "%"
            };

            using (
                var db = Connection)
            {
                return db.Query<GrupoFornecedorEntity>(sp, param);
            }

        }
    }
}

