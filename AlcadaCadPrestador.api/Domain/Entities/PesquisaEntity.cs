using System.Collections.Generic;

namespace Signa.TemplateCore.Api.Domain.Entities
{
    public class PesquisaEntity
    {
        public int codigoId { get; set; }
        public string usuario { get; set; }
        public string grupousuario { get; set; }
        public string prestador { get; set; }
        public string cnpjprestador { get; set; }
        public string grupousuarioid { get; set; }
        public string usuarioid { get; set; }
        public List<PesquisaCodEntity> PesquisaCod { get; set; }
    }
}
