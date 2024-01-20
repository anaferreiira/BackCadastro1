using AutoMapper;
using Signa.Library.Core;
using Signa.Library.Core.Aspnet.Helpers;
using Signa.Library.Core.Exceptions;
using Signa.Library.Core.Extensions;
using Signa.TemplateCore.Api.Data.Repository;
using Signa.TemplateCore.Api.Domain.Models;
using Signa.TemplateCore.Api.Services;

namespace Signa.TemplateCore.Api.Business
{
    public class PermissaoUsuarioBL
    {
        private readonly IMapper _mapper;
        private readonly UserProvider _userProvider;
        private readonly PermissaoUsuarioDAO _permissaoUsuarioDAO;
        private  int _usuarioId;
        private readonly int _funcaoId;
        private readonly int _grupoUsuarioId;

        

        public PermissaoUsuarioBL(
            IMapper mapper,
            UserProvider userProvider,
            PermissaoUsuarioDAO permissaoUsuarioDAO
        )
        {
            _mapper = mapper;
            _userProvider = userProvider;
            _permissaoUsuarioDAO = permissaoUsuarioDAO;
            _usuarioId = _userProvider.UserId;
            _funcaoId = Global.FuncaoId;
            _grupoUsuarioId = _userProvider.UserGroupId;
        }


        public PermissaoUsuarioModel Get()
        {
#if DEBUG
            _usuarioId = 1;
#endif
            if (_usuarioId.IsZeroOrNull())
                throw new SignaSqlNotFoundException("Usuário não encontrado");

            var permissoes = _permissaoUsuarioDAO.Get(_usuarioId, _funcaoId);

            if (permissoes == null)
                throw new SignaSqlNotFoundException("Nenhuma permissão encontrada para essa função com este usuário");
            permissoes.Token = TokenService.CreateToken();

            return _mapper.Map<PermissaoUsuarioModel>(permissoes);
        }

    }
}
