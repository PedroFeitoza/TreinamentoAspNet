using System;

namespace Repository.Entidades.Categoria
{
    public class CategoriaDapperModel
    {
        public CategoriaDapperModel()
        {

        }
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
