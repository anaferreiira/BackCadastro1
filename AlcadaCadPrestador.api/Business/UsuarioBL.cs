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
    public class UsuarioBL
    {
        private readonly IMapper _mapper;
        private readonly UsuarioDAO _usuario;

        public UsuarioBL(
            IMapper mapper,
            UsuarioDAO usuarioDAO
        )
        {
            _mapper = mapper;
            _usuario= usuarioDAO;
        }

        internal static object GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal static object GetByString(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        //internal static object Insert(UsuarioModel usario)
       // {
          //  throw new NotImplementedException();
      //  }



        public IEnumerable<UsuarioModel> Get(string nomeUsuario)
        {
            var results = _usuario.Get(nomeUsuario);

            if (results.IsNullOrEmpty())
            {
                throw new SignaSqlNotFoundException("Nenhuma pessoa encontrada");
            }

            return _mapper.Map<IEnumerable<UsuarioModel>>(results);
        }
 
    }

}
