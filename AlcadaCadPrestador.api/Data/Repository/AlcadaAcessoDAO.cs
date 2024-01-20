using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel.Charts;
using Signa.Library.Core.Data.Repository;
using Signa.TemplateCore.Api.Business;
using Signa.TemplateCore.Api.Domain.Entities;

namespace Signa.TemplateCore.Api.Data.Repository
{   //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
    // essa SP trás os usuasrios de alçada
    public class AlcadaAcessoDAO : RepositoryBase
    {
        public IEnumerable<AlcadaAcessoEntity> Get()
        {
            var sql = "select ALCADA_ACESSO_ID, usuario_id from ALCADA_ACESSO where tab_status_Id=1";
            using (var db = Connection)
            {
                return db.Query<AlcadaAcessoEntity>(sql);
            }
        }
        //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
        // faz atualziação/modificação de usuários.
        public void Update(AlcadaAcessoEntity alcada)
        {
            var sp = "Update Usuario set nome = @nome where Usuario_Id= @id";
            var param = new
            {
                AlcadaAcessoId = alcada.AlcadaAcessoId,
                UsuarioId = alcada.UsuarioId,
                NomeUsuario = alcada.NomeUsuario,
                TabStatusId = alcada.TabStatusId,
            };
            using (var db = Connection)
            {
                db.Execute(sp, param);
            }
        }
        //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
        // quando selecionar um usuario para excluir.
        public void Delete(int IdUsuario, int idAlcadaAcesso )
        {
            var sql = "SP_040_EXC_ALCADA_ACESSO01";
            var param = new
            {
                @IN_USUARIO_EXC_ID = IdUsuario,
                @IN_ALCADA_ACESSO_ID = idAlcadaAcesso
            };

            using (var db = Connection)
            {
                db.Execute(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
        // com o insert ela faz a inclussão de novos usuarios para cadastro de alçada.
        public int Insert(AlcadaAcessoEntity alcada)
        {
            var sp = "SP_040_INC_ALCADA_ACESSO01";
        
            using (var db = Connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IN_USUARIO_ID", alcada.UsuarioId);
                parameters.Add("@IN_USUARIO_INCL_ID", alcada.UsuarioId);
                return db.QueryFirstOrDefault<int>(sp, parameters, transaction: null, commandType: CommandType.StoredProcedure);
            }
        }
        //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
        // com a duplicidade quando a pessoa fizer uma pesquisa e tentar cadastrar, se já houver no sistema 
        //o usuário que foi tentado ser cadastrado a API vai retornar que já existe.
        public void Dupli(AlcadaAcessoEntity duplicidade)
        {
            var sp = "SP_040_ALCADA_ACESSO_VER_DUPLI01";

            using (var db = Connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IN_ALCADA_ACESSO_ID", duplicidade.UsuarioId);
                parameters.Add("@IN_USUARIO_ID", duplicidade.UsuarioId);

                var result = db.ExecuteScalar<int>(sp, parameters, commandType: CommandType.StoredProcedure);

                if (result > 0)
                {
                    throw new Exception("Registro já cadastrado");

                }
            }
        }
    }
}



