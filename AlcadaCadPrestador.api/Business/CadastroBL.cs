using AutoMapper;
using Signa.Library.Core.Exceptions;
using Signa.Library.Core.Extensions;
using Signa.TemplateCore.Api.Data.Repository;
using Signa.TemplateCore.Api.Domain.Entities;
using Signa.TemplateCore.Api.Domain.Models;
using System;
using System.Collections.Generic;

namespace Signa.TemplateCore.Api.Business
{
    public class CadastroBL
    {
        private readonly CadastroDAO SQL;
        private readonly IMapper mapa; public CadastroBL(CadastroDAO Cadastro, IMapper mapa)
        {
            SQL = Cadastro;
            this.mapa = mapa;
        }

        public IEnumerable<CadastroModel> GrupoUsuario()
        {
            var cadastro = SQL.GrupoUsuario(); if (cadastro == null)
            {
                throw new SignaSqlNotFoundException("Nenhum cliente encontrada com esse id");
            }
            return mapa.Map<IEnumerable<CadastroModel>>(cadastro);
        }
    }
}