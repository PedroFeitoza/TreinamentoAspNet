using Repository.Entidades;
using System;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProdutoGetByIdUseCase
    {
        public Task<ProdutoModel> Execute(Guid id);
    }
}
