using System;

namespace Repository.Entidades
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public Guid CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; }
        public string Descricao { get; set; }
        public Decimal Preco { get; set; }
        public string UnidadeMedida { get; set; }
    }
}
