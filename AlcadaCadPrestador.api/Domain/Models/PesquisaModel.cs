using System.Collections.Generic;

namespace Signa.TemplateCore.Api.Domain.Models
{
    public class PesquisaModel
    {
        public int codigoId { get; set; }
        public string usuario { get; set; }
        public string grupousuario { get; set; }
        public string prestador { get; set; }
        public string cnpjprestador { get; set; }
        public string grupousuarioid { get; set; }
        public string usuarioid { get; set; }
        public List<PesquisaCodModel> PesquisaCod { get; set; }
        // DOC: Aqui em vez de criar um elemento para pesquisaCod, só criar um model e entity ai se ultiza a class ´pesquisa para forma a docuemtação do pesuisaCod
        // pesquisaCod é uma tabela

    }
}
