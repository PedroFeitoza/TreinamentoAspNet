using Repository.Entidades.Produto;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProdutoPostUseCase
    {
        public Task Execute(ProdutoInputModel produto);
    }
}
