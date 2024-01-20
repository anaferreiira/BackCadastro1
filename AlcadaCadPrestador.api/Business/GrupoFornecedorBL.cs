using AutoMapper;
using Signa.Library.Core.Exceptions;
using Signa.Library.Core.Extensions;
using Signa.TemplateCore.Api.Data.Repository;
using Signa.TemplateCore.Api.Domain.Entities;
using Signa.TemplateCore.Api.Domain.Models;
using System.Collections.Generic;

namespace Signa.TemplateCore.Api.Business
{
    public class GrupoFornecedorBL
    {
        private readonly IMapper _mapper;
        private readonly GrupoFornecedorDAO _grupo;

        public GrupoFornecedorBL(
            IMapper mapper,
            GrupoFornecedorDAO GrupoFornecedorDAO
        )
        {
            _mapper = mapper;
            _grupo= GrupoFornecedorDAO;
        }
        public IEnumerable<GrupoFornecedorModel> Get(string nomeFornecedor)
        {
            var results = _grupo.Get(nomeFornecedor);

            if (results.IsNullOrEmpty())
            {
                throw new SignaSqlNotFoundException("Nenhuma pessoa encontrada");
            }

            return (IEnumerable<GrupoFornecedorModel>)_mapper.Map<IEnumerable<GrupoFornecedorModel>>(results);
        }

    }

}
