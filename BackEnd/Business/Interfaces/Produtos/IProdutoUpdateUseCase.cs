using Repository.Entidades.Produto;
using System;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProdutoUpdateUseCase
    {
        public Task Execute(Guid id, ProdutoInputModel modelInput);
    }
}
