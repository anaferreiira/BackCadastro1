using AutoMapper;
using Signa.Library.Core.Exceptions;
using Signa.TemplateCore.Api.Data.Repository;
using Signa.TemplateCore.Api.Domain.Models;
using System.Collections.Generic;
using System;
using Signa.Library.Core.Data.Repository;

namespace Signa.TemplateCore.Api.Business
{
    public class PesquisaBL
    {
        private readonly HelperRepository _helperRepository;
        private readonly IMapper _mapper;
        private readonly pesquisaDAO _pesquisa;
        private int _grupoUsuarioId;

        public PesquisaBL(
            IMapper mapper,
            pesquisaDAO pesquisaDAO
        )
        {
            _mapper = mapper;
            _pesquisa = pesquisaDAO;
        }

        internal static object GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal static object GetByString(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        internal static object Insert(PesquisaModel pesquisa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PesquisaModel> Get(int IN_TAB_STATUS_ID, int? IN_GRUPO_FORNECEDOR_ID, int? IN_Grupo_Usuario_Id,
            int? IN_USUARIO_ID)
        {
            var results = _pesquisa.Get(IN_TAB_STATUS_ID, IN_GRUPO_FORNECEDOR_ID, IN_Grupo_Usuario_Id,
            IN_USUARIO_ID);

            return _mapper.Map<IEnumerable<PesquisaModel>>(results);
        }
        public List<PesquisaCodModel> PesquisaCod(int id)
        {
          List< PesquisaCodModel >results = new List<PesquisaCodModel>();
            results = _mapper.Map<List<PesquisaCodModel>>(_pesquisa.PesquisaCod(id));
            return results;
            
        }

    }


}
