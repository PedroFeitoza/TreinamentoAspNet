using Repository.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProdutoGetAllUseCase
    {
        public Task<List<ProdutoModel>> Execute();
    }
}
