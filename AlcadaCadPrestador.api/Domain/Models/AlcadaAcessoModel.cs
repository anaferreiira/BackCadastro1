namespace Signa.TemplateCore.Api.Domain.Models
{
    public class AlcadaAcessoModel
    {
        public int AlcadaAcessoId { get; set; }
        public int UsuarioId { get; set; }
        public int TabStatusId { get; set; }
        public string NomeUsuario { get; set; }
        // DOC: Aqui você consegue puxar os nomes dos usuários e seus ID e suas alçadas
    }
}
