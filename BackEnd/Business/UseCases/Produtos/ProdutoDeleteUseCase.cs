using System;
using System.Threading.Tasks;
using Repository.Interfaces;
using Business.Interface;

namespace Business
{
    public class ProdutoDeleteUseCase : IProdutoDeleteUseCase
    {
        private readonly IProdutoRepository _repository;
        public ProdutoDeleteUseCase(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(Guid id)
        {          
            await _repository.Delete(id);    
        }
    }
}
