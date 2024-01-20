namespace Signa.TemplateCore.Api.Domain.Entities
{
    public class CadastroEntity
    {
        public int ALCADA_APROVACAO_ID { get; set; }
        public string desc_grupo_usuario { get; set; }
        public string indicativo_aprova_confere { get; set; }
        public double VAL_ALCADA_DE { get; set; }
        public double val_alcada { get; set; }
        public int TAB_STATUS_ID { get; set; }
        public int GRUPO_USUARIO_ID { get; set; }
        public int USUARIO_ID { get; set; }
        public int CENTRO_CUSTO_ID { get; set; }
        public int zUSUARIO_ID { get; set; }
        public string LiberacaoAprovacao { get; set; }
        public int AlcadaAprovacaoDE { get; set; }
    }
}
