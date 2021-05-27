namespace Repository.Entidades.Produto
{
    public class ProdutoInputModel
    {
        public string Codigo { get; set; }
        public CategoriaModel Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string UnidadeMedida { get; set; }
    }
}
