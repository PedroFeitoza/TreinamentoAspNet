using Microsoft.EntityFrameworkCore;
using Repository.Entidades;

namespace Repository
{
    public class ApiContext : DbContext
    {
        //Entity Framework
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { }
    }
}
