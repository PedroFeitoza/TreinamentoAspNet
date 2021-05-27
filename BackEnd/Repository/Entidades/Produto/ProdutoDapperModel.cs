using System;

namespace Repository.Entidades.Produto
{
    class ProdutoDapperModel
    {
        public ProdutoDapperModel()
        {

        }

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string CategoriaId { get; set; }
        public string Descricao { get; set; }
        public Decimal Preco { get; set; }
        public string UnidadeMedida { get; set; }
    }
}
