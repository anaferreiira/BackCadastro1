using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Org.BouncyCastle.Crypto.Digests;
using Signa.Library.Core.Data.Repository;
using Signa.TemplateCore.Api.Domain.Entities;
using Signa.TemplateCore.Api.Domain.Models;

namespace Signa.TemplateCore.Api.Data.Repository
{
    public class UsuarioDAO : RepositoryBase
    {
        //Usuando a SP(Procedure) para puxar dados dos usaurios, colocando LIKE para fazer filtro dos nomes.
        //Por exemplo: Qaundo for colcoar um nome "Signa" vai fazer um filtro para cada letra, primeira letra "S" puxa tdoso com letra "S'
        //Assim confrome for digitando vai se completando e aparecendo a opção que desjea. 
        public IEnumerable<UsuarioEntity> Get(string nomeUsuario)
        {

            var sp = "SELECT TOP 50 NOME_USUARIO,USUARIO_ID FROM USUARIO With(Nolock) WHERE NOME_USUARIO LIKE  @NOME AND  TAB_STATUS_ID = 1 ORDER BY NOME_USUARIO";
            var param = new
            {
                NOME = nomeUsuario + "%"
            };

            using (var db = Connection)
            {
                return db.Query<UsuarioEntity>(sp, param);

            }
        }
    }
    
}
