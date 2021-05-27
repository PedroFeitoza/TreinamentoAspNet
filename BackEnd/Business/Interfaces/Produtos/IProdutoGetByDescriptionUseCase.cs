using Repository.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProdutoGetByDescriptionUseCase
    {
        public Task<List<ProdutoModel>> Execute(string description);
    }
}
