using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Interfaces;
using Business.Interface;
using Repository.Entidades;

namespace Business
{
    public class ProdutoGetAllUseCase : IProdutoGetAllUseCase
    {
        private readonly IProdutoRepository _repository;
        public ProdutoGetAllUseCase(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProdutoModel>> Execute()
        {
            return await _repository.GetAll();
        }
    }
}
