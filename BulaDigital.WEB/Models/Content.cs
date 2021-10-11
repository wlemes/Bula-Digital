namespace BulaDigital.WEB.Models
{
    public class Content
    {
        public int idProduto { get; set; }
        public string numeroRegistro { get; set; }
        public string nomeProduto { get; set; }
        public string expediente { get; set; }
        public string razaoSocial { get; set; }
        public string cnpj { get; set; }
        public string numeroTransacao { get; set; }
        public DateTime data { get; set; }
        public string numProcesso { get; set; }
        public string idBulaPacienteProtegido { get; set; }
        public string idBulaProfissionalProtegido { get; set; }
    }
}
