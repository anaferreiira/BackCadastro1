using AutoMapper;
using NPOI.SS.Formula.Functions;
using Signa.Library.Core.Exceptions;
using Signa.Library.Core.Extensions;
using Signa.TemplateCore.Api.Data.Repository;
using Signa.TemplateCore.Api.Domain.Entities;
using Signa.TemplateCore.Api.Domain.Models;
using System;
using System.Collections.Generic;

namespace Signa.TemplateCore.Api.Business
{
    public class AlcadaAcessoBL
    {

            private readonly IMapper _mapper;
        private readonly AlcadaAcessoDAO _alcada;
        private object _Usuario;
        private object _Nomeusuario;

        public AlcadaAcessoBL(
                IMapper mapper,
                AlcadaAcessoDAO alcadaAcessoDAO
            )
            {
                _mapper = mapper;
                _alcada = alcadaAcessoDAO;
            }

            public AlcadaAcessoModel Insert(AlcadaAcessoModel Alcada)
            {
                //int id = 0;

                var entidade = _mapper.Map<AlcadaAcessoEntity>(Alcada);

            //AlcadaAcessoEntity entidade = new AlcadaAcessoEntity();
            //_mapper.Map(Alcada, entidade);

            /**
            if (Alcada.AlcadaAcessoId.IsZeroOrNull())
            {
                id = _alcada.Insert(entidade);
            }
            else
            {
                id = Alcada.AlcadaAcessoId;
                _alcada.Insert(entidade);
            }
            */
            _alcada.Dupli(entidade);

                _alcada.Insert(entidade);

                return Alcada;
            }
         

            public IEnumerable<AlcadaAcessoModel> Get()
            {
                var results = _alcada.Get();

                if (results.IsNullOrEmpty())
                {
                    throw new SignaSqlNotFoundException("Nenhuma pessoa encontrada");
                }

                return _mapper.Map<IEnumerable<AlcadaAcessoModel>>(results);
            }

        public void Delete(int IdUsuario, int idAlcadaAcesso)
        {
            _alcada.Delete( IdUsuario, idAlcadaAcesso);
            }
        }
}
