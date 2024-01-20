using Dapper;
using Signa.Library.Core.Data.Repository;
using Signa.TemplateCore.Api.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System;

namespace Signa.TemplateCore.Api.Data.Repository
{
    //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
    // com o insert ela faz a inclussão de novos usuarios para cadastro de alçada
    public class CadastroDAO : RepositoryBase
    {

        public int Insert(CadastroEntity cadastro)
        {

            var sql = "SP_ECR_INC_ALCADA_APROVACAO3";
            var param = new
            {
                USUARIO_ID = cadastro.USUARIO_ID,
                val_alcada = cadastro.val_alcada,
                zUSUARIO_ID = cadastro.zUSUARIO_ID,
                CENTRO_CUSTO_ID = cadastro.CENTRO_CUSTO_ID,
                GRUPOUSUARIO_ID = cadastro.GRUPO_USUARIO_ID,
                LiberacaoAprovacao = new DbString { Value = cadastro.LiberacaoAprovacao },
                AlcadaAprovacaoDE = cadastro.AlcadaAprovacaoDE,
            };
            using (var db = Connection)
            {
                return db.QueryFirstOrDefault<int>(sql, param, commandType: CommandType.StoredProcedure);
            }

        }
        //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
        // com a duplicidade quando a pessoa fizer uma pesquisa e tentar cadastrar, se já houver no sistema 
        //o usuário que foi tentado ser cadastrado a API vai retornar que já existe.
        public void VerDupicidadeInsert(CadastroEntity cadastro)
        {
            var sql = "SP_ECR_VER_DUP_INC_ALCADA_APROVACAO";
            var param = new
            {
                GRUPOUSER = cadastro.GRUPO_USUARIO_ID,
                Liberacao_Aprovacao = new DbString { Value = cadastro.LiberacaoAprovacao },
            };
            using (var db = Connection)
            {
                var Query = db.QueryFirstOrDefault(sql, param, commandType: CommandType.StoredProcedure);
                foreach (var item in Query)
                {
                    if (item.Value.Equals(10))
                    {
                        throw new Exception("Já está Cadastrado");
                    }
                }
            }
        }
        //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
        // quando selecionar um usuario para excluir.
        public void Delete(int id)
        {
            var sql = "SP_ECR_EXC_ALCADA_APROVACAO"; var param = new
            {
                ALCADA_APROVACAO_ID = id,
                zUSUARIO_ID = 1,
            };
            using (var db = Connection)
            {
                db.Execute(sql, param, commandType: CommandType.StoredProcedure);
            }
        }
        //Usuando a SP(Procedure) para puxar dados da tabela, usando os parametros de entrada que ela pede,
        // rras os grupos de usuários.
        public IEnumerable<CadastroEntity> GrupoUsuario()
        {
            var sql = "Select GRUPO_USUARIO_ID, desc_grupo_usuario From GRUPO_USUARIO GRUPO_USUARIO With (NoLock) WHERE GRUPO_USUARIO.TAB_STATUS_ID = 1 Order By desc_grupo_usuario";
            using (var db = Connection)
            {
                return db.Query<CadastroEntity>(sql);
            }
        }
    }
}

